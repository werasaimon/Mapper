using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

using System.Data.SQLite;

using Newtonsoft.Json;

namespace WindowsFormsAppMapa
{


    /**
    public class CustomCheckedListBox : CheckedListBox
    {
        public CustomCheckedListBox()
        {
            DoubleBuffered = true;
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Size checkSize = CheckBoxRenderer.GetGlyphSize(e.Graphics, System.Windows.Forms.VisualStyles.CheckBoxState.MixedNormal);
            int dx = (e.Bounds.Height - checkSize.Width) / 2;
            e.DrawBackground();
            bool isChecked = GetItemChecked(e.Index);//For some reason e.State doesn't work so we have to do this instead.
            CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(dx, e.Bounds.Top + dx), isChecked ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            using (StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center })
            {
                using (Brush brush = new SolidBrush(isChecked ? CheckedItemColor : ForeColor))
                {
                    e.Graphics.DrawString(Items[e.Index].ToString(), Font, brush, new Rectangle(e.Bounds.Height, e.Bounds.Top, e.Bounds.Width - e.Bounds.Height, e.Bounds.Height), sf);
                }
            }
        }
        Color checkedItemColor = Color.Green;
        public Color CheckedItemColor
        {
            get { return checkedItemColor; }
            set
            {
                checkedItemColor = value;
                Invalidate();
            }
        }
    }
    /**/


    public partial class FormMapa : Form
{
        private bool m_IsUser;
        private bool m_IsAdministrator;
        private String m_Username;

        Dictionary<String, InfoBase> HashElements = new Dictionary<String, InfoBase>();
        Dictionary<String, GMapOverlay> GroundOverlays = new Dictionary<String, GMapOverlay>();
        Dictionary<String, GMapOverlay> AirOverlays = new Dictionary<String, GMapOverlay>();
        Dictionary<String, Color> m_HashColors = new Dictionary<String, Color>();

        private bool m_IsCreateGround;
        private bool m_IsCreateAir;

        InfoBase m_SelectedInfoPolygon;

        private FormForVariables m_FormInterfaceVariables;
        private FormForAirVariables m_FormInterfaceAirVariables;
        private FormUser m_FormAdministrator;

        private List<PointLatLng> gpolypoints = new List<PointLatLng>();
        private List<PointLatLng> gedgepoints = new List<PointLatLng>();

        private SQLiteConnection DB;
        private GMapOverlay OverlayMarkers = new GMapOverlay("markers");


        private List<Status> rowStatusGroundLayers = new List<Status>();
        private List<Status> rowStatusAirLayers = new List<Status>();


        //private GMapOverlay[] m_OverlaysPoligons =
        //{
        //   new GMapOverlay("poligons layer 0"),
        //   new GMapOverlay("poligons layer 1"),
        //   new GMapOverlay("poligons layer 2")
        //};

        private Bitmap[] ImageMarkers =
         {
          (Bitmap) Image.FromFile("../../icons/rd1.png"),
          (Bitmap) Image.FromFile("../../icons/rd2.png"),
          (Bitmap) Image.FromFile("../../icons/rd3.png"),
          (Bitmap) Image.FromFile("../../icons/rd4.png")

        };




        private void ConnectUser(SQLiteConnection _db)
        {

            if (m_IsUser == false)
            {
                m_FormAdministrator = new FormUser(_db);
                m_FormAdministrator.ShowDialog(this);

                if (m_FormAdministrator.IsVariablee)
                {
                    m_IsAdministrator = m_FormAdministrator.IsAdministrator;
                    m_IsUser = true;
                    m_Username = m_FormAdministrator.Username;
                    //labelUsername.Text = m_FormAdministrator.Username;
                }
                else
                {
                    Close();
                }
            }
            else
            {
                m_IsAdministrator = false;
                m_IsUser = false;
                m_Username = "";
                //labelUsername.Text = "Username";
            }
        }


        private double GetScaleMap()
        {
            GMapRoute route = new GMapRoute("getScale");
            PointLatLng point1 = gMapa.FromLocalToLatLng(0, 0);
            route.Points.Add(point1);

            point1 = gMapa.FromLocalToLatLng(100, 0);
            route.Points.Add(point1);

            return route.Distance;
        }


        

        private void Initilization_mapa(GMapControl _gMapa)
        {
            _gMapa.DragButton = MouseButtons.Left;
            _gMapa.MapProvider = GMapProviders.GoogleMap;
            _gMapa.Position = new PointLatLng(50, 30);
            _gMapa.MinZoom = 5;
            _gMapa.MaxZoom = 100;
            // _gMapa.Location = new Point(25, 25);
            _gMapa.Zoom = 10;
            _gMapa.MapScaleInfoEnabled = true;

            //_gMapa.Overlays.Add(m_OverlaysPoligons[0]);
            //_gMapa.Overlays.Add(m_OverlaysPoligons[1]);
            //_gMapa.Overlays.Add(m_OverlaysPoligons[2]);
            _gMapa.Overlays.Add(OverlayMarkers);
        }
        public FormMapa()
        {
            InitializeComponent();
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void FormMapa_Load(object sender, EventArgs e)
        {
            Initilization_mapa(gMapa as GMapControl);
            DB = new SQLiteConnection("Data Source=../../database/DB.db; Version=3");
            DB.Open();
            LoadLayers();
            LoadInformationGroundDB();
            LoadInformationAirdDB();

            ConnectUser(DB);
        }

        private void gMapa_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && (m_IsCreateGround || m_IsCreateAir))
            {
                //base.OnMouseMove(e);
                //Application.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
                double X = gMapa.FromLocalToLatLng(e.X, e.Y).Lng;
                double Y = gMapa.FromLocalToLatLng(e.X, e.Y).Lat;

                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Y, X), GMarkerGoogleType.arrow);

                if(m_IsCreateAir)
                {
                    m_FormInterfaceAirVariables = new FormForAirVariables(HashElements, false, DB);
                    m_FormInterfaceAirVariables.ShowDialog(this);

                    var m_Marker = new GMarkerGoogle(new PointLatLng(Y, X), GMarkerGoogleType.arrow);
                    OverlayMarkers.Markers.Add(m_Marker);

                    /**/
                    if (!m_FormInterfaceAirVariables.IsStatus)
                    {
                        Console.WriteLine("Cancel |||| ");
                        m_FormInterfaceAirVariables.Close();
                        gedgepoints.Clear();
                        gpolypoints.Clear();
                        OverlayMarkers.Markers.Clear();
                        OverlayMarkers.Polygons.Clear();
                    }
                    else
                    {
                        Console.WriteLine("OK |||||||||||||| 22222222");
                        m_FormInterfaceAirVariables.Close();

                        Console.WriteLine("weraearararara 222222222\n");
                        //----------------------------------------------------------//
                        InfoAir markere = new InfoAir(new PointLatLng(Y, X), ImageMarkers[m_FormInterfaceAirVariables.IconIndex], m_FormInterfaceAirVariables.ToName);
                        
                        //int typeIndex = m_FormInterfaceVariables.Type;

                        Color colore = m_HashColors[m_FormInterfaceAirVariables.ToType];


                        markere.Username = m_Username;
                        markere.ToInfoText = m_FormInterfaceAirVariables.ToInfoText;
                        markere.ToName = m_FormInterfaceAirVariables.ToName;
                        markere.ToType = m_FormInterfaceAirVariables.ToType;
                        markere.Depth = m_FormInterfaceAirVariables.Depth;
                        markere.Icon = m_FormInterfaceAirVariables.IconIndex;

                        markere.ToolTipText = markere.ToName;


                        AirOverlays[m_FormInterfaceAirVariables.ToType].Markers.Add(markere);

                        HashElements[markere.ToName] = markere;

                        OverlayMarkers.Markers.Add(new GMarkerGoogle(new PointLatLng(Y, X), ImageMarkers[markere.Icon]));
                        OverlayMarkers.Markers.Add(markere);
                        SaveInfoAirInDB(markere);

                        Console.WriteLine(markere.ToName);
                        this.listBoxElements.Items.Add(markere.ToName);

                        gMapa.ReloadMap();

                        gedgepoints.Clear();
                        gpolypoints.Clear();
                        OverlayMarkers.Markers.Clear();
                        OverlayMarkers.Polygons.Clear();

                        m_IsCreateAir = false;
                        m_IsCreateGround = false;
                        //this.button5.BackColor = Color.White;
                    }
                    /**/
                    return;
                }
                   

                if(gpolypoints.Count == 0)
                {
                    gpolypoints.Add(new PointLatLng(Y, X));
                    OverlayMarkers.Markers.Add(new GMarkerGoogle(new PointLatLng(Y, X), GMarkerGoogleType.orange_small));
                    OverlayMarkers.Markers.Add(marker);

                    gedgepoints.Add(new PointLatLng(Y, X));
                    gedgepoints.Add(new PointLatLng(Y, X));
                    GMapPolygon _poly = new GMapPolygon(gedgepoints, "line");
                    _poly.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    _poly.Stroke = new Pen(Color.Black, 2);
                    OverlayMarkers.Polygons.Add(_poly);
                }
                else
                {
                    /**
                    GPoint _A = gMapa.FromLatLngToLocal(gpolypoints[0]);
                    GPoint _B = gMapa.FromLatLngToLocal(gpolypoints[gpolypoints.Count-1]);

                   
                    double Distance = Math.Pow(_A.X - _B.X, 2.0) +
                                      Math.Pow(_A.Y - _B.Y, 2.0);
                    Distance = Math.Sqrt(Distance);

                    **/


                    GMapRoute route = new GMapRoute("getScale");
                    route.Points.Add(gpolypoints[0]);
                    route.Points.Add(new PointLatLng(Y, X));
                    var Distance = route.Distance / GetScaleMap();

                    Console.WriteLine((Distance).ToString() +  "  < " + (0.3).ToString());
               
                    /**/
                    if(Distance < 0.3 && gpolypoints.Count >= 3)
                    {
                        m_FormInterfaceVariables = new FormForVariables(HashElements,false,DB);
                        m_FormInterfaceVariables.ShowDialog(this);

                        //DialogResult dr = m_FormInterfaceVariables.ShowDialog(this);
                        if (!m_FormInterfaceVariables.IsStatus)
                        {
                            Console.WriteLine("Cancel |||| ");
                            m_FormInterfaceVariables.Close();
                            gedgepoints.Clear();
                            gpolypoints.Clear();
                            OverlayMarkers.Markers.Clear();
                            OverlayMarkers.Polygons.Clear();
                        }
                        else
                        {
                            Console.WriteLine("OK ||||||||||||||");
                            m_FormInterfaceVariables.Close();

                            Console.WriteLine("weraearararara\n");
                            //----------------------------------------------------------//
                            InfoGround plygone = new InfoGround(gpolypoints, m_FormInterfaceVariables.ToName);

                            //int typeIndex = m_FormInterfaceVariables.Type;

                            Color colore = m_HashColors[m_FormInterfaceVariables.ToType];

                            plygone.Fill = new SolidBrush(Color.FromArgb(m_FormInterfaceVariables.Depth, colore));
                            plygone.Stroke = new Pen(Color.Black, 1);

                            plygone.IsHitTestVisible = true;
                            plygone.Username = m_Username;
                            plygone.ToInfoText = m_FormInterfaceVariables.ToInfoText;
                            plygone.ToName = m_FormInterfaceVariables.ToName;
                            plygone.ToType = m_FormInterfaceVariables.ToType;
                            plygone.Depth = m_FormInterfaceVariables.Depth; 

                            //Console.WriteLine(m_FormInterfaceVariables.Type.ToString());

                            // ImageMarkers[typeIndex].SetResolution(25,25);


                            //System.Console.WriteLine("tototo Type:  " + plygone.ToType);
                            //plygone.m_Marker = new GMarkerGoogle(plygone.Origin, ImageMarkers[typeIndex]);
                            //m_OverlaysPoligons[typeIndex].Markers.Add(plygone.m_Marker);
                            GroundOverlays[m_FormInterfaceVariables.ToType].Polygons.Add(plygone);

                            HashElements[plygone.ToName] = plygone;

                            SaveInfoGroundInDB(plygone);

                            Console.WriteLine(plygone.ToName);
                            this.listBoxElements.Items.Add(plygone.ToName);

                            gMapa.ReloadMap();

                            gedgepoints.Clear();
                            gpolypoints.Clear();
                            OverlayMarkers.Markers.Clear();
                            OverlayMarkers.Polygons.Clear();

                            m_IsCreateGround = false;
                            //this.button5.BackColor = Color.White;
                        }
                    }
                    else 
                    {

                        List<PointLatLng> _polypoints = new List<PointLatLng>();
                        _polypoints.Add(gpolypoints[gpolypoints.Count-1]);
                        _polypoints.Add(new PointLatLng(Y, X));
                        GMapPolygon _poly = new GMapPolygon(_polypoints,"line");
                        _poly.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                        _poly.Stroke = new Pen(Color.Black, 2);
                        OverlayMarkers.Polygons.Add(_poly);

                        gpolypoints.Add(new PointLatLng(Y, X));
                        OverlayMarkers.Markers.Add(marker);
                    }
                    /**/
                }  
            }
        }


        private void gMapa_MouseMove(object sender, MouseEventArgs e)
        {
            if(gpolypoints.Count >= 1)
            {
                double X = gMapa.FromLocalToLatLng(e.X, e.Y).Lng;
                double Y = gMapa.FromLocalToLatLng(e.X, e.Y).Lat;

                OverlayMarkers.Markers[0].Position = new PointLatLng(Y, X);

                /**
                int xx = e.X - this.gMapa.Width / 2;
                int yy = e.Y - this.gMapa.Height / 2;
                Console.WriteLine("X :" + xx.ToString() + "   Y :" + yy.ToString());

                int w = OverlayMarkers.Markers[0].LocalArea.Width;
                int h = OverlayMarkers.Markers[0].LocalArea.Height;

                Console.WriteLine("W :" + w.ToString() + "   H :" + h.ToString());

                var cx=gMapa.Location.X;
                var cy=gMapa.Location.Y;

                OverlayMarkers.Markers[0].LocalPosition = new Point(cx-(xx - (w/2 - 5)), cy-(yy - h));
                **/
            }
        }

        private void gMapa_OnPolygonDoubleClick(GMapPolygon item, MouseEventArgs e)
        {
            /**/
            Console.WriteLine(String.Format("Polygon {0} with tag {1} was clicked", item.Name, item.Tag));
            //item.Points.Clear();

           // item.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));


            //var iitem = (InfoGround)item;
            //Console.WriteLine(iitem.m_toName);

            var ppoly = new InfoGround((InfoGround)item);
            ppoly.Fill = new SolidBrush(Color.FromArgb(50, Color.White));
            OverlayMarkers.Polygons.Clear();
            OverlayMarkers.Polygons.Add(ppoly);

            InfoToOutput(ppoly);
            //listBoxElements.SelectedItem = iitem.m_toName.ToString();
            //listBoxElements.Focus();
            /**/


        }

        private void button5_Click(object sender, EventArgs e)
        {
            m_IsCreateGround = !m_IsCreateGround;
            if (m_IsCreateGround) m_IsCreateAir = false;
           // this.button5.BackColor = (m_IsCreate) ? Color.Red : Color.White;
        }

        private void gMapa_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
        {
            m_SelectedInfoPolygon = (InfoBase)item;
            if (e.Button == MouseButtons.Right)
            {    
                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(this, new Point(e.X, e.Y));
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(m_SelectedInfoPolygon.SeasonType == SeasonTypeInfo.Ground)
            {
              DeleteInfoGrountInDB(m_SelectedInfoPolygon);
              GroundOverlays[m_SelectedInfoPolygon.ToType].Polygons.Remove((InfoGround)m_SelectedInfoPolygon);
            }
            else if (m_SelectedInfoPolygon.SeasonType == SeasonTypeInfo.Air)
            {
                DeleteInfoAirInDB(m_SelectedInfoPolygon);
                AirOverlays[m_SelectedInfoPolygon.ToType].Markers.Remove((InfoAir)m_SelectedInfoPolygon);
            }


                //m_OverlaysPoligons[m_SelectedInfoPolygon.m_Type].Markers.Remove(m_SelectedInfoPolygon.m_Marker);
            HashElements.Remove(m_SelectedInfoPolygon.ToName.ToString());
            DeleteElemntToListing(m_SelectedInfoPolygon.ToName.ToString());
            gedgepoints.Clear();
            gpolypoints.Clear();
            OverlayMarkers.Markers.Clear();
            OverlayMarkers.Polygons.Clear();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.listBoxElements.Items.Add("wera suka");
        }

        private void ModifyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


            if (m_SelectedInfoPolygon.SeasonType == SeasonTypeInfo.Ground)
            {

                m_FormInterfaceVariables = new FormForVariables(m_SelectedInfoPolygon, HashElements, true, DB);
                m_FormInterfaceVariables.ShowDialog(this);

                //DialogResult dr = m_FormInterfaceVariables.ShowDialog(this);
                if (!m_FormInterfaceVariables.IsStatus)
                {
                    Console.WriteLine("Cancel |||| ");
                    m_FormInterfaceVariables.Close();
                }
                else //if(m_FormInterfaceVariables.ToName != m_SelectedInfoPolygon.m_toName)
                {
                    /**/
                    DeleteInfoGrountInDB(m_SelectedInfoPolygon);
                    GroundOverlays[m_SelectedInfoPolygon.ToType].Polygons.Remove((InfoGround)m_SelectedInfoPolygon);
                    //GroundOverlays[m_SelectedInfoPolygon.m_toType].Markers.Remove(m_SelectedInfoPolygon.m_Marker);
                    HashElements.Remove(m_SelectedInfoPolygon.ToName.ToString());
                    DeleteElemntToListing(m_SelectedInfoPolygon.ToName.ToString());
                    gedgepoints.Clear();
                    gpolypoints.Clear();
                    OverlayMarkers.Markers.Clear();
                    OverlayMarkers.Polygons.Clear();
                    /**/

                    InfoGround plygone = new InfoGround(((InfoGround)m_SelectedInfoPolygon).Points, ((InfoGround)m_SelectedInfoPolygon).Name);

                    plygone.Username = m_Username;
                    plygone.ToInfoText = m_FormInterfaceVariables.ToInfoText;
                    plygone.ToName = m_FormInterfaceVariables.ToName;
                    plygone.ToType = m_FormInterfaceVariables.ToType;
                    plygone.Depth = m_FormInterfaceVariables.Depth;

                    /**/

                    Color colore = m_HashColors[m_FormInterfaceVariables.ToType];

                    plygone.IsHitTestVisible = true;
                    plygone.Fill = new SolidBrush(Color.FromArgb(m_FormInterfaceVariables.Depth, colore));
                    plygone.Stroke = new Pen(Color.Black, 1);
                    /**/

                    /**/
                    plygone.IsHitTestVisible = true;
                    plygone.Username = m_Username;
                    plygone.ToName = m_FormInterfaceVariables.ToName;
                    plygone.ToInfoText = m_FormInterfaceVariables.ToInfoText;
                    plygone.ToType = m_FormInterfaceVariables.ToType;
                    plygone.Depth = m_FormInterfaceVariables.Depth;
                    /**/

                    /**/
                    Console.WriteLine(m_FormInterfaceVariables.ToName);
                    this.listBoxElements.Items.Add(plygone.ToName);

                    // plygone.m_Marker = new GMarkerGoogle(plygone.Origin, ImageMarkers[typeIndex]);
                    // m_OverlaysPoligons[typeIndex].Markers.Add(plygone.m_Marker);
                    GroundOverlays[m_FormInterfaceVariables.ToType].Polygons.Add(plygone);

                    HashElements[plygone.ToName] = plygone;
                    gMapa.ReloadMap();

                    //m_SelectedInfoPolygon = plygone;
                    SaveInfoGroundInDB(plygone);

                    m_IsCreateAir = false;
                    m_IsCreateGround = false;
                    //this.button5.BackColor = Color.White;
                    /**/
                }
            }
            else if (m_SelectedInfoPolygon.SeasonType == SeasonTypeInfo.Air)
            {

                m_FormInterfaceAirVariables = new FormForAirVariables(m_SelectedInfoPolygon, HashElements, true, DB);
                m_FormInterfaceAirVariables.ShowDialog(this);


                //DialogResult dr = m_FormInterfaceVariables.ShowDialog(this);
                if (!m_FormInterfaceAirVariables.IsStatus)
                {
                    Console.WriteLine("Cancel |||| ");
                    m_FormInterfaceAirVariables.Close();
                }
                else //if(m_FormInterfaceVariables.ToName != m_SelectedInfoPolygon.m_toName)
                {
                    /**/
                    DeleteInfoAirInDB(m_SelectedInfoPolygon);
                    AirOverlays[m_SelectedInfoPolygon.ToType].Markers.Remove((InfoAir)m_SelectedInfoPolygon);
                    //GroundOverlays[m_SelectedInfoPolygon.m_toType].Markers.Remove(m_SelectedInfoPolygon.m_Marker);
                    HashElements.Remove(m_SelectedInfoPolygon.ToName.ToString());
                    DeleteElemntToListing(m_SelectedInfoPolygon.ToName.ToString());
                    gedgepoints.Clear();
                    gpolypoints.Clear();
                    OverlayMarkers.Markers.Clear();
                    OverlayMarkers.Polygons.Clear();
                    /**/

                    InfoAir marker = new InfoAir(((InfoAir)m_SelectedInfoPolygon).Origin,
                                                ImageMarkers[m_FormInterfaceAirVariables.IconIndex],
                                                m_FormInterfaceAirVariables.ToName);

                    marker.Username = m_Username;
                    marker.ToInfoText = m_FormInterfaceAirVariables.ToInfoText;
                    marker.ToName = m_FormInterfaceAirVariables.ToName;
                    marker.ToType = m_FormInterfaceAirVariables.ToType;
                    marker.Depth = m_FormInterfaceAirVariables.Depth;
                    marker.Icon = m_FormInterfaceAirVariables.IconIndex;

                    marker.ToolTipText = marker.ToName;

                    /**

                    Color colore = m_HashColors[m_FormInterfaceAirVariables.ToType];

                    marker.IsHitTestVisible = true;
                    marker.Fill = new SolidBrush(Color.FromArgb(m_FormInterfaceAirVariables.Depth, colore));
                    marker.Stroke = new Pen(Color.Black, 1);
                    /**/

                    /**/
                    marker.IsHitTestVisible = true;
                    marker.Username = m_Username;
                    marker.ToName = m_FormInterfaceAirVariables.ToName;
                    marker.ToInfoText = m_FormInterfaceAirVariables.ToInfoText;
                    marker.ToType = m_FormInterfaceAirVariables.ToType;
                    marker.Depth = m_FormInterfaceAirVariables.Depth;
                    marker.Icon = m_FormInterfaceAirVariables.IconIndex;
                    /**/

                    /**/
                    Console.WriteLine(m_FormInterfaceAirVariables.ToName);
                    this.listBoxElements.Items.Add(marker.ToName);

                    // plygone.m_Marker = new GMarkerGoogle(plygone.Origin, ImageMarkers[typeIndex]);
                    // m_OverlaysPoligons[typeIndex].Markers.Add(plygone.m_Marker);
                    AirOverlays[m_FormInterfaceAirVariables.ToType].Markers.Add(marker);

                    HashElements[marker.ToName] = marker;
                    gMapa.ReloadMap();

                    //m_SelectedInfoPolygon = plygone;
                    SaveInfoAirInDB(marker);

                    m_IsCreateAir = false;
                    m_IsCreateGround = false;
                    //this.button5.BackColor = Color.White;
                    /**/

                }    
            }
            this.contextMenuStrip1.Close();
        }

        private void listBoxElements_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if(listBoxElements.SelectedIndex == -1)
            {

            }
            else
            {
                Console.WriteLine(listBoxElements.SelectedItem.ToString() );

                var item = HashElements[listBoxElements.SelectedItem.ToString()];
                gMapa.Position = item.Origin;

                if(item.SeasonType == SeasonTypeInfo.Ground)
                {
                  var ppoly = new InfoGround((InfoGround)item);
                  ppoly.Fill = new SolidBrush(Color.FromArgb(50, Color.White));
                  OverlayMarkers.Polygons.Clear();
                  OverlayMarkers.Polygons.Add(ppoly);
                }

              
                InfoToOutput(item);
            }

        }


        private void DeleteElemntToListing(string removelistitem)
        {
            for (int n = listBoxElements.Items.Count - 1; n >= 0; --n)
            {
                if (listBoxElements.Items[n].ToString().Contains(removelistitem))
                {
                    listBoxElements.Items.RemoveAt(n);
                }
            }
        }


        private void listBoxElements_DrawItem(object sender, DrawItemEventArgs e)
        {

            // 1. Get the item
            string selectedItem = listBoxElements.Items[e.Index].ToString();

            // 2. Choose font 
            Font font = new Font("Arial", 50);

            // 3. Choose colour
            SolidBrush solidBrush = new SolidBrush(Color.Red);

            // 4. Get bounds
            int left = e.Bounds.Left;
            int top = e.Bounds.Top;

            // 5. Use Draw the background within the bounds
            e.DrawBackground();

            // 6. Colorize listbox items
            e.Graphics.DrawString(selectedItem, font, solidBrush, left, top);
        }


        private void FormMapa_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }



        private void InfoToOutput(InfoBase _poly)
        {
            labelInfo.Text = "     INFORMATION       \n\n" +
                             "----- Username ----- \n " +
                             _poly.Username.ToString() + "\n" +
                             "\n ----- Coords ----- \n " +
                             "X: " + _poly.Origin.Lat.ToString() + "\n" +
                             " Y: " + _poly.Origin.Lng.ToString() + " \n" +
                             "\n ----- Data ----- \n " +
                             "Name : " + _poly.ToName.ToString() + " \n" +
                             "Type : " + _poly.ToType.ToString() + "\n" +
                             "Depth : " + _poly.Depth.ToString() + "\n" +
                             "\n ----- Info ----- \n " + 
                             _poly.ToInfoText.ToString() + "\n";

            labelInfoOutput.Text = "           INFORMATION :: " +
                             "| Username: " +
                             _poly.Username.ToString() + " |   " +
                             " | Coords: " +
                             " X: " + _poly.Origin.Lat.ToString() + " , " +
                             " Y: " + _poly.Origin.Lng.ToString() + " |   " +
                             "| Name : " + _poly.ToName.ToString() + " |  " +
                             "| Type : " + _poly.ToType.ToString() + " |  " +
                             "| Depth : " + _poly.Depth.ToString() + " |  \n\n";
        }

  

        private void LoadLayers()
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select * from PollutionTypes";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {
                    String name = SQL["Name"].ToString();

                    int type;
                    Int32.TryParse(SQL["Type"].ToString(), out type);

                    if(type == 0)
                    {
                        // -------------------------------------------- //
                        customCheckedListBoxGround.Items.Add(name, true);
                    
                        int color;
                        Int32.TryParse(SQL["Color"].ToString(), out color);
                        m_HashColors[name] = Color.FromArgb(color);

                        Status statusColor = new Status();
                        statusColor.background = Color.FromArgb(color);
                        rowStatusGroundLayers.Add(statusColor);

                        System.Console.WriteLine(name);
                        var layer = new GMapOverlay(name);
                        GroundOverlays.Add(name, layer);
                        gMapa.Overlays.Add(layer);
                        // -------------------------------------------- //
                    }
                    else 
                    {
                        customCheckedListBoxAir.Items.Add(name, true);

                        int color;
                        Int32.TryParse(SQL["Color"].ToString(), out color);
                        m_HashColors[name] = Color.FromArgb(color);

                        Status statusColor = new Status();
                        statusColor.background = Color.FromArgb(color);
                        rowStatusAirLayers.Add(statusColor);

                        System.Console.WriteLine(name);
                        var layer = new GMapOverlay(name);
                        AirOverlays.Add(name, layer);
                        gMapa.Overlays.Add(layer);
                    }
                   
                }
            }

        }

        private void DeleteInfoGrountInDB(InfoBase _infoPoly)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            String name = _infoPoly.ToName;
            CMD.CommandText = "DELETE FROM Information WHERE Name='" + name + "';";
            CMD.ExecuteNonQuery();
            CMD.Dispose();
        }

        private void DeleteInfoAirInDB(InfoBase _infoPoly)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            String name = _infoPoly.ToName;
            CMD.CommandText = "DELETE FROM InformationAir WHERE Name='" + name + "';";
            CMD.ExecuteNonQuery();
            CMD.Dispose();
        }


        private void SaveInfoGroundInDB(InfoGround _infoPoly)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "insert or replace into Information(Name,Depth,Type,SizePoints,Points,Origin,Username,Info) " +
                              "values(@name,@depth,@type,@sizePoints,@points,@origin,@username,@info)";

            CMD.Parameters.Add("@name", System.Data.DbType.String).Value = _infoPoly.ToName;
            CMD.Parameters.Add("@depth", System.Data.DbType.Int32).Value = _infoPoly.Depth;
            CMD.Parameters.Add("@type", System.Data.DbType.String).Value = _infoPoly.ToType;
            CMD.Parameters.Add("@username", System.Data.DbType.String).Value = _infoPoly.Username;
            CMD.Parameters.Add("@info", System.Data.DbType.String).Value = _infoPoly.ToInfoText;
            CMD.Parameters.Add("@sizePoints", System.Data.DbType.Int32).Value = _infoPoly.Points.Count;

            String jsonPoints = JsonConvert.SerializeObject(_infoPoly.Points);
            CMD.Parameters.Add("@points", System.Data.DbType.String).Value = jsonPoints;

            String jsonOrigin = JsonConvert.SerializeObject(_infoPoly.Origin);
            CMD.Parameters.Add("@origin", System.Data.DbType.String).Value = jsonOrigin;

            CMD.ExecuteNonQuery();
        }

        private void SaveInfoAirInDB(InfoAir _infoAir)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "insert or replace into InformationAir(Name,Depth,Type,Origin,Username,Info,Icon) " +
                              "values(@name,@depth,@type,@origin,@username,@info,@icon)";

            CMD.Parameters.Add("@name", System.Data.DbType.String).Value = _infoAir.ToName;
            CMD.Parameters.Add("@depth", System.Data.DbType.Int32).Value = _infoAir.Depth;
            CMD.Parameters.Add("@type", System.Data.DbType.String).Value = _infoAir.ToType;
            CMD.Parameters.Add("@username", System.Data.DbType.String).Value = _infoAir.Username;
            CMD.Parameters.Add("@info", System.Data.DbType.String).Value = _infoAir.ToInfoText;
            CMD.Parameters.Add("@icon", System.Data.DbType.Int32).Value = _infoAir.Icon;

            String jsonOrigin = JsonConvert.SerializeObject(_infoAir.Origin);
            CMD.Parameters.Add("@origin", System.Data.DbType.String).Value = jsonOrigin;

            CMD.ExecuteNonQuery();
        }

        private void LoadInformationGroundDB()
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select * from Information";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {
                    String name = SQL["Name"].ToString();
                    String type = SQL["Type"].ToString();
                    String username = SQL["Username"].ToString();
                    String infotext = SQL["Info"].ToString();
                    int depth = 0;
                    int size = 0;
                    Int32.TryParse(SQL["Depth"].ToString(), out depth);
                    Int32.TryParse(SQL["SizePoints"].ToString(), out size);

                    

                    //System.Console.WriteLine("Name: " + name.ToString());
                    //System.Console.WriteLine("Depth:" + depth.ToString());
                    //System.Console.WriteLine("Type: " + type.ToString());
                    //System.Console.WriteLine("Size: " + size.ToString());

                    string jsonOrigin = SQL["Origin"].ToString();
                    PointLatLng desOrigin = JsonConvert.DeserializeObject<PointLatLng>(jsonOrigin);
                    System.Console.WriteLine(jsonOrigin.ToString());

                    string jsonPoints = SQL["Points"].ToString();
                    List<PointLatLng> desPoints = JsonConvert.DeserializeObject<List<PointLatLng>>(jsonPoints);
                    foreach (var it in desPoints)
                    {
                        System.Console.WriteLine(it);
                    }


                    if (!HashElements.ContainsKey(name))
                    {
                        //HashElements.Remove(name);
                        /**/

                        InfoGround plygone = new InfoGround(desPoints, name);

                        Color colore = m_HashColors[type];

                        plygone.Fill = new SolidBrush(Color.FromArgb(depth, colore));
                        plygone.Stroke = new Pen(Color.Black, 1);

                        plygone.IsHitTestVisible = true;
                        plygone.ToInfoText = infotext;
                        plygone.Username = username;
                        plygone.ToName = name;
                        plygone.ToType = type;
                        plygone.Depth = depth;

                        

                        Console.WriteLine(plygone.ToName);
                        this.listBoxElements.Items.Add(plygone.ToName);

                        //plygone.m_Marker = new GMarkerGoogle(desOrigin, ImageMarkers[typeIndex]);
                        //m_OverlaysPoligons[typeIndex].Markers.Add(plygone.m_Marker);
                        GroundOverlays[type].Polygons.Add(plygone);

                        HashElements[plygone.ToName] = plygone;
                        gMapa.ReloadMap();

                        /**/
                    }
                }
            }
        }



        private void LoadInformationAirdDB()
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select * from InformationAir";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {
                    String name = SQL["Name"].ToString();
                    String type = SQL["Type"].ToString();
                    String username = SQL["Username"].ToString();
                    String infotext = SQL["Info"].ToString();
                    int depth = 0;
                    int icon = 0;
                    Int32.TryParse(SQL["Depth"].ToString(), out depth);
                    Int32.TryParse(SQL["Icon"].ToString(), out icon);


                    if (!HashElements.ContainsKey(name))
                    {
                        //HashElements.Remove(name);
                        /**/

                        string jsonOrigin = SQL["Origin"].ToString();
                        PointLatLng desOrigin = JsonConvert.DeserializeObject<PointLatLng>(jsonOrigin);
                        System.Console.WriteLine(jsonOrigin.ToString());

                        InfoAir marker = new InfoAir(desOrigin, ImageMarkers[icon], name);

                        Color colore = m_HashColors[type];

                        //plygone.Fill = new SolidBrush(Color.FromArgb(depth, colore));
                        //plygone.Stroke = new Pen(Color.Black, 1);

                        marker.IsHitTestVisible = true;
                        marker.ToInfoText = infotext;
                        marker.Username = username;
                        marker.ToName = name;
                        marker.ToType = type;
                        marker.Depth = depth;

                        marker.ToolTipText = marker.ToName;

                        Console.WriteLine(marker.ToName);
                        this.listBoxElements.Items.Add(marker.ToName);

                        //plygone.m_Marker = new GMarkerGoogle(desOrigin, ImageMarkers[typeIndex]);
                        //m_OverlaysPoligons[typeIndex].Markers.Add(plygone.m_Marker);
                        AirOverlays[type].Markers.Add(marker);

                        HashElements[marker.ToName] = marker;
                        gMapa.ReloadMap();

                        /**/
                    }
                }
            }
        }


        private bool ValueCheck(CheckState Check)
        {
            if (Check == CheckState.Checked)
                return true;
            else
                return false;
        }



        private void groundToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           m_IsCreateGround = !m_IsCreateGround;
           if (m_IsCreateGround) m_IsCreateAir = false;
        }

        private void airToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_IsCreateAir = !m_IsCreateAir;
            if (m_IsCreateAir) m_IsCreateGround = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Close();
        }

   

        private Color customCheckedListBoxGround_GetBackColor(CustomCheckedListBox listbox, DrawItemEventArgs e)
        {
            return rowStatusGroundLayers[e.Index].background;
        }

        private void customCheckedListBoxGround_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var key = customCheckedListBoxGround.Items[e.Index].ToString();
            if (GroundOverlays.ContainsKey(key))
            {
                GroundOverlays[key].IsVisibile = ValueCheck(e.NewValue);
            }
        }

        private Color customCheckedListBoxAir_GetBackColor(CustomCheckedListBox listbox, DrawItemEventArgs e)
        {
            return rowStatusAirLayers[e.Index].background;
        }

        private void customCheckedListBoxAir_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gMapa_OnMarkerDoubleClick(GMapMarker item, MouseEventArgs e)
        {
            InfoToOutput((InfoAir)item);
        }

        private void customCheckedListBoxAir_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var key = customCheckedListBoxAir.Items[e.Index].ToString();
            if (AirOverlays.ContainsKey(key))
            {
                AirOverlays[key].IsVisibile = ValueCheck(e.NewValue);
            }
        }

        private void gMapa_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if(!m_IsCreateAir && !m_IsCreateGround)
            {
              m_SelectedInfoPolygon = (InfoAir)item;
              if (e.Button == MouseButtons.Right)
              {
                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(this, new Point(e.X, e.Y));
                }
              }
            }
          
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           System.Console.WriteLine( e.ClickedItem.ToString() );
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            string text = e.ToString();
            System.Console.WriteLine(text);
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Console.WriteLine(toolStripComboBox1.SelectedIndex.ToString());

            if(toolStripComboBox1.SelectedIndex == 0)
            {
                for (int i = 0; i < customCheckedListBoxAir.Items.Count; i++)
                {
                    customCheckedListBoxAir.SetItemChecked(i, true);
                }

                for (int i = 0; i < customCheckedListBoxGround.Items.Count; i++)
                {
                    customCheckedListBoxGround.SetItemChecked(i, true);
                }
            }
            else if (toolStripComboBox1.SelectedIndex == 1)
            {
                for (int i = 0; i < customCheckedListBoxAir.Items.Count; i++)
                {
                    customCheckedListBoxAir.SetItemChecked(i, true);
                }

                for (int i = 0; i < customCheckedListBoxGround.Items.Count; i++)
                {
                    customCheckedListBoxGround.SetItemChecked(i, false);
                }

            }
            if (toolStripComboBox1.SelectedIndex == 2)
            {
                for (int i = 0; i < customCheckedListBoxAir.Items.Count; i++)
                {
                    customCheckedListBoxAir.SetItemChecked(i, false);
                }

                for (int i = 0; i < customCheckedListBoxGround.Items.Count; i++)
                {
                    customCheckedListBoxGround.SetItemChecked(i, true);
                }
            }
        }
    }


    struct Status
    {
        public Color background;
        public Color foreground;
    }


    public enum SeasonTypeInfo
    {
        Ground,
        Air
    }

    public interface InfoBase
    {
        SeasonTypeInfo SeasonType { get; set; }

        PointLatLng Origin { get; set; }
        string Username { get; set; }
        string ToInfoText { get; set; }
        string ToType { get; set; }
        string ToName { get; set; }
        int Depth { get; set; }
        int Icon { get; set; }
    }

    public class InfoAir : GMarkerGoogle, InfoBase
    {
        public SeasonTypeInfo SeasonType { get; set; }
        public PointLatLng Origin { get; set; }
        public string Username { get; set; }
        public string ToInfoText { get; set; }
        public string ToType { get; set; }
        public string ToName { get; set; }
        public int Depth { get; set; }
        public int Icon { get; set; }

        public InfoAir(PointLatLng _origin, GMarkerGoogleType _type_marker , string name)
            : base(_origin, _type_marker)
        {
            SeasonType = SeasonTypeInfo.Air;
            ToName = name;
            Origin = _origin;
        }

        public InfoAir(PointLatLng _origin, Bitmap _tBitmap, string name)
          : base(_origin, _tBitmap)
        {
            SeasonType = SeasonTypeInfo.Air;
            ToName = name;
            Origin = _origin;
        }

        public InfoAir(InfoAir _infoAir) 
            : base(_infoAir.Origin , _infoAir.Type)
        {
            SeasonType = SeasonTypeInfo.Air;
            Username = _infoAir.Username;
            ToInfoText = _infoAir.ToInfoText;
            ToName = _infoAir.ToName;
            ToType = _infoAir.ToType;
            Depth = _infoAir.Depth;
            Origin = _infoAir.Origin;
            Icon = _infoAir.Icon;
        }

    }

    public class InfoGround : GMapPolygon, InfoBase
    {

        public SeasonTypeInfo SeasonType { get; set; }
        public PointLatLng Origin { get; set; }
        public string Username { get; set; }
        public string ToInfoText { get; set; }
        public string ToType { get; set; }
        public string ToName { get; set; }
        public int Depth { get; set; }
        public int Icon { get; set; }

        public InfoGround(InfoGround _infoPoly) :
            base(_infoPoly.Points, _infoPoly.Name)
        {
            SeasonType = SeasonTypeInfo.Ground;
            Username = _infoPoly.Username;
            ToInfoText = _infoPoly.ToInfoText;
            ToName = _infoPoly.ToName;
            ToType = _infoPoly.ToType;
            Depth = _infoPoly.Depth;
            Icon = _infoPoly.Icon;

            base.LocalPoints.Capacity = Points.Count;

            double LatCenter = 0;
            double LngCenter = 0;
            for (int i = 0; i < _infoPoly.Points.Count; i++)
            {
                LatCenter += _infoPoly.Points[i].Lat;
                LngCenter += _infoPoly.Points[i].Lng;
            }

            double u = LatCenter / _infoPoly.Points.Count;
            double v = LngCenter / _infoPoly.Points.Count;

            Origin = new PointLatLng(u, v);
        }

        public InfoGround(List<PointLatLng> points, string name)
            : base(points, name)
        {
            SeasonType = SeasonTypeInfo.Ground;
            ToName = name;
            base.LocalPoints.Capacity = Points.Count;

            double LatCenter = 0;
            double LngCenter = 0;
            for (int i = 0; i < points.Count; i++)
            {
                LatCenter += points[i].Lat;
                LngCenter += points[i].Lng;
            }

            double u = LatCenter / points.Count;
            double v = LngCenter / points.Count;

            Origin = new PointLatLng(u, v);
        }

    }
}
