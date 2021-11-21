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

namespace WindowsFormsAppMapa
{





public partial class FormMapa : Form
{


        Dictionary<String, InfoPolygon> HashElements = new Dictionary<String, InfoPolygon>();

        private bool m_IsCreate;

        InfoPolygon m_SelectedInfoPolygon;

        private FormForVariables m_FormInterfaceVariables;

        private List<PointLatLng> gpolypoints = new List<PointLatLng>();
        private List<PointLatLng> gedgepoints = new List<PointLatLng>();

        private SQLiteConnection DB;
        private GMapOverlay OverlayMarkers = new GMapOverlay("markers");
        private GMapOverlay[] m_OverlaysPoligons =
        {
           new GMapOverlay("poligons layer 0"),
           new GMapOverlay("poligons layer 1"),
           new GMapOverlay("poligons layer 2")
        };

        private Bitmap[] ImageMarkers = 
        {
          (Bitmap) Image.FromFile("../../icons/icon_A.png"),
          (Bitmap) Image.FromFile("../../icons/icon_B.png"),
          (Bitmap) Image.FromFile("../../icons/icon_C.png")   
        };


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

            _gMapa.Overlays.Add(m_OverlaysPoligons[0]);
            _gMapa.Overlays.Add(m_OverlaysPoligons[1]);
            _gMapa.Overlays.Add(m_OverlaysPoligons[2]);
            _gMapa.Overlays.Add(OverlayMarkers);
        }
        public FormMapa()
        {
            InitializeComponent();
        }

        private void FormMapa_Load(object sender, EventArgs e)
        {
            Initilization_mapa(gMapa as GMapControl);
            DB = new SQLiteConnection("Data Source=database.db; Version=3");
            DB.Open();
        }

        private void gMapa_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && m_IsCreate)
            {
                //base.OnMouseMove(e);
                //Application.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
                double X = gMapa.FromLocalToLatLng(e.X, e.Y).Lng;
                double Y = gMapa.FromLocalToLatLng(e.X, e.Y).Lat;

                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Y, X), GMarkerGoogleType.arrow);

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
                        m_FormInterfaceVariables = new FormForVariables(HashElements);
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
                            InfoPolygon plygone = new InfoPolygon(gpolypoints, m_FormInterfaceVariables.ToName);

                            int typeIndex = m_FormInterfaceVariables.Type;

                            Color[] colors = { Color.Red, Color.Green, Color.Blue };

                            plygone.Fill = new SolidBrush(Color.FromArgb(m_FormInterfaceVariables.Depth, colors[typeIndex]));
                            plygone.Stroke = new Pen(Color.Black, 1);

                            plygone.IsHitTestVisible = true;
                            plygone.m_toName = m_FormInterfaceVariables.ToName;
                            plygone.m_Type = m_FormInterfaceVariables.Type;
                            plygone.m_Depth = m_FormInterfaceVariables.Depth;

                            Console.WriteLine(m_FormInterfaceVariables.Type.ToString());

                            // ImageMarkers[typeIndex].SetResolution(25,25);



                            plygone.m_Marker = new GMarkerGoogle(plygone.Origin, ImageMarkers[typeIndex]);
                            m_OverlaysPoligons[typeIndex].Markers.Add(plygone.m_Marker);
                            m_OverlaysPoligons[typeIndex].Polygons.Add(plygone);

                            HashElements[plygone.m_toName] = plygone;



                            Console.WriteLine(plygone.m_toName);
                            this.listBoxElements.Items.Add(plygone.m_toName);

                            gMapa.ReloadMap();

                            gedgepoints.Clear();
                            gpolypoints.Clear();
                            OverlayMarkers.Markers.Clear();
                            OverlayMarkers.Polygons.Clear();

                            m_IsCreate = false;
                            this.button5.BackColor = Color.White;
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


            //var iitem = (InfoPolygon)item;
            //Console.WriteLine(iitem.m_toName);

            var ppoly = new InfoPolygon((InfoPolygon)item);
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
            m_IsCreate = !m_IsCreate;
            this.button5.BackColor = (m_IsCreate) ? Color.Red : Color.White;
        }

        private void checkBoxLayer0_CheckedChanged(object sender, EventArgs e)
        {
            m_OverlaysPoligons[0].IsVisibile = this.checkBoxLayer0.Checked;
        }

        private void checkBoxLayer1_CheckedChanged(object sender, EventArgs e)
        {
            m_OverlaysPoligons[1].IsVisibile = this.checkBoxLayer1.Checked;
        }

        private void checkBoxLayer2_CheckedChanged(object sender, EventArgs e)
        {
            m_OverlaysPoligons[2].IsVisibile = this.checkBoxLayer2.Checked;
        }

        private void gMapa_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
        {
            m_SelectedInfoPolygon = (InfoPolygon)item;
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
            m_OverlaysPoligons[m_SelectedInfoPolygon.m_Type].Polygons.Remove(m_SelectedInfoPolygon);
            m_OverlaysPoligons[m_SelectedInfoPolygon.m_Type].Markers.Remove(m_SelectedInfoPolygon.m_Marker);
            HashElements.Remove(m_SelectedInfoPolygon.m_toName.ToString());
            DeleteElemntToListing(m_SelectedInfoPolygon.m_toName.ToString());
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
            m_FormInterfaceVariables = new FormForVariables(m_SelectedInfoPolygon,HashElements);
            m_FormInterfaceVariables.ShowDialog(this);

            //DialogResult dr = m_FormInterfaceVariables.ShowDialog(this);
            if (!m_FormInterfaceVariables.IsStatus)
            {
                Console.WriteLine("Cancel |||| ");
                m_FormInterfaceVariables.Close();
            }
            else
            {
                /**/

                m_OverlaysPoligons[m_SelectedInfoPolygon.m_Type].Polygons.Remove(m_SelectedInfoPolygon);
                m_OverlaysPoligons[m_SelectedInfoPolygon.m_Type].Markers.Remove(m_SelectedInfoPolygon.m_Marker);
                HashElements.Remove(m_SelectedInfoPolygon.m_toName.ToString());
                DeleteElemntToListing(m_SelectedInfoPolygon.m_toName.ToString());
                gedgepoints.Clear();
                gpolypoints.Clear();
                OverlayMarkers.Markers.Clear();
                OverlayMarkers.Polygons.Clear();
                /**/

                InfoPolygon plygone = new InfoPolygon(m_SelectedInfoPolygon.Points, m_SelectedInfoPolygon.Name);

                plygone.m_toName = m_FormInterfaceVariables.ToName;
                plygone.m_Type = m_FormInterfaceVariables.Type;
                plygone.m_Depth = m_FormInterfaceVariables.Depth;

                /**/
                int typeIndex = m_FormInterfaceVariables.Type;

                Console.WriteLine(typeIndex);

                Color[] colors = { Color.Red, Color.Green, Color.Blue };

                plygone.IsHitTestVisible = true;
                plygone.Fill = new SolidBrush(Color.FromArgb(m_FormInterfaceVariables.Depth, colors[typeIndex]));
                plygone.Stroke = new Pen(Color.Black, 1);
                /**/

                /**/
                plygone.IsHitTestVisible = true;
                plygone.m_toName = m_FormInterfaceVariables.ToName;
                plygone.m_Type = m_FormInterfaceVariables.Type;
                plygone.m_Depth = m_FormInterfaceVariables.Depth;
                /**/

                /**/
                Console.WriteLine(plygone.m_toName);
                this.listBoxElements.Items.Add(plygone.m_toName);

                plygone.m_Marker = new GMarkerGoogle(plygone.Origin, ImageMarkers[typeIndex]);
                m_OverlaysPoligons[typeIndex].Markers.Add(plygone.m_Marker);
                m_OverlaysPoligons[typeIndex].Polygons.Add(plygone);

                HashElements[plygone.m_toName] = plygone;

                gMapa.ReloadMap();

                //m_SelectedInfoPolygon = plygone;

                m_IsCreate = false;
                this.button5.BackColor = Color.White;
                /**/
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

                var ppoly = new InfoPolygon((InfoPolygon)item);
                ppoly.Fill = new SolidBrush(Color.FromArgb(50, Color.White));
                OverlayMarkers.Polygons.Clear();
                OverlayMarkers.Polygons.Add(ppoly);

                InfoToOutput(ppoly);
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


        private void InfoToOutput(InfoPolygon _poly)
        {
            string[] ABC = { "A", "B", "C" };
            labelInfo.Text = "     INFORMATION       \n\n" +
                             "Name : " + _poly.m_toName.ToString() + " \n" + 
                             "Group : " + ABC[_poly.m_Type] + "\n" +
                             "Depth : " + _poly.m_Depth.ToString() + "\n";
        }
    }



    public class InfoPolygon : GMapPolygon
    {

        public String m_toName;
        public int m_Type;
        public int m_Depth;

        public PointLatLng Origin;
        // static GMapPolygon();
        public GMapMarker m_Marker;

        public InfoPolygon(InfoPolygon _infoPoly) :
            base(_infoPoly.Points, _infoPoly.Name)
        {
            m_toName = _infoPoly.m_toName;
            m_Type = _infoPoly.m_Type;
            m_Depth = _infoPoly.m_Depth;

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

        public InfoPolygon(List<PointLatLng> points, string name)
            : base(points, name)
        {
            m_toName = name;
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
