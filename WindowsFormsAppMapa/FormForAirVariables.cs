using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsAppMapa
{
    public partial class FormForAirVariables : Form
    {
        private SQLiteConnection DB;

        private bool m_isStatus;
        private bool m_isModify;
        private String m_toInfoText;
        private String m_toName;
        private String m_toType;
        private int m_Depth;

        private int m_IconIndex;

        Dictionary<String, InfoBase> m_HashElements;
        Dictionary<String, Color> m_HashColors = new Dictionary<String, Color>();
        public FormForAirVariables()
        {
            InitializeComponent();
        }

        public FormForAirVariables(Dictionary<String, InfoBase> _HashElements, bool _modify, SQLiteConnection _db)
        {
            InitializeComponent();
            DB = _db;
            m_Depth = 55;
            m_HashElements = _HashElements;
            m_isModify = _modify;
            m_toName = "";
            //m_toType = comboBoxType.SelectedText;
            UpdateItemsTypes();
            this.comboBoxType.SelectedIndex = 0;
        }


        public FormForAirVariables(InfoBase _InfoPoly, Dictionary<String, InfoBase> _HashElements, bool _modify, SQLiteConnection _db)
        {
            InitializeComponent();
            DB = _db;
            ToInfoText = _InfoPoly.ToInfoText;
            ToName = _InfoPoly.ToName;
            Depth = _InfoPoly.Depth;
            textBoxNmae.Text = m_toName;
            trackBarDepth.Value = m_Depth;
            m_HashElements = _HashElements;
            m_isModify = _modify;

            richTextBox1.Text = m_toInfoText;

            UpdateItemsTypes();
            // comboBoxType.SelectedText = _InfoPoly.m_toType;
            this.comboBoxType.SelectedIndex = this.comboBoxType.FindStringExact(_InfoPoly.ToType);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            m_toInfoText = richTextBox1.Text;

            if (textBoxNmae.Text == "Name Marker" || textBoxNmae.Text == "" || comboBoxType.Text == "")
            {
                MessageBox.Show("ВВедите Имя и Групу ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (m_isModify == true)
            {

                m_isStatus = true;
                m_toName = this.textBoxNmae.Text;
                m_toType = comboBoxType.GetItemText(comboBoxType.SelectedItem);
                m_IconIndex = cboFace.SelectedIndex;

                Console.WriteLine("OK!");
                this.Close();

            }
            else
            {
                bool isNotCopy = false;
                foreach (var entry in m_HashElements)
                {
                    // do something with entry.Value or entry.Key
                    if (entry.Key == this.textBoxNmae.Text)
                    {
                        isNotCopy = true;
                        break;
                    }
                }

                if (isNotCopy)
                {
                    MessageBox.Show("Такое имя уже есть!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    m_isStatus = true;
                    m_toName = this.textBoxNmae.Text;
                    m_toType = comboBoxType.GetItemText(comboBoxType.SelectedItem);
                    m_IconIndex = cboFace.SelectedIndex;
                    m_toInfoText = richTextBox1.Text;
                    Console.WriteLine("OK! ---  " + m_toType);
                    this.Close();
                }
            }
        }

        public bool IsStatus { get => m_isStatus; set => m_isStatus = value; }
        public string ToName { get => m_toName; set => m_toName = value; }
        public int Depth { get => m_Depth; set => m_Depth = value; }
        public string ToType { get => m_toType; set => m_toType = value; }
        public string ToInfoText { get => m_toInfoText; set => m_toInfoText = value; }
        public int IconIndex { get => m_IconIndex; set => m_IconIndex = value; }

        private void UpdateItemsTypes()
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select * from PollutionTypes where Type=1";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {
                    String name = SQL["Name"].ToString();
                    int color;
                    Int32.TryParse(SQL["Color"].ToString(), out color);
                    m_HashColors[name] = Color.FromArgb(color);
                    comboBoxType.Items.Add(name);

                }
            }
        }

        private void trackBarDepth_Scroll(object sender, EventArgs e)
        {
            m_Depth = this.trackBarDepth.Value;
            Console.WriteLine(m_Depth.ToString());
            this.label1.Text = "Depth = " + m_Depth.ToString();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            m_isStatus = false;
            this.Close();
        }

        private void textBoxNmae_Leave(object sender, EventArgs e)
        {
            if (textBoxNmae.Text == "")
            {
                textBoxNmae.Text = "Name Marker";
                textBoxNmae.ForeColor = Color.Silver;
            }
        }

        private void textBoxNmae_Enter(object sender, EventArgs e)
        {
            if (textBoxNmae.Text == "Name Marker")
            {
                textBoxNmae.Text = "";
                textBoxNmae.ForeColor = Color.Black;
            }
        }

        private void comboBoxType_DrawItem(object sender, DrawItemEventArgs e)
        {
            float size = 12;
            System.Drawing.Font myFont;
            FontFamily family = FontFamily.GenericSansSerif;

            // Get the item text    
            string text = ((ComboBox)sender).Items[e.Index].ToString();

            Color animalColor = new System.Drawing.Color();

            animalColor = m_HashColors[text];
            family = FontFamily.GenericSansSerif;

            // Draw the background of the item.
            e.DrawBackground();

            // Create a square filled with the animals color. Vary the size
            // of the rectangle based on the length of the animals name.
            Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4);
            e.Graphics.FillRectangle(new SolidBrush(animalColor), rectangle);

            // Draw each string in the array, using a different size, color,
            // and font for each item.
            myFont = new Font(family, size, FontStyle.Bold);
            e.Graphics.DrawString(text, myFont, System.Drawing.Brushes.Black,
                new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));

            // Draw the focus rectangle if the mouse hovers over an item.
            e.DrawFocusRectangle();
        }

        private void comboBoxType_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemWidth = 25;
        }

        private void FormForAirVariables_Load(object sender, EventArgs e)
        {
            // Faces.
            Image[] images =
            {
              Image.FromFile("../../icons/rd1.png"),
              Image.FromFile("../../icons/rd2.png"),
              Image.FromFile("../../icons/rd3.png"),
              Image.FromFile("../../icons/rd4.png")
            };

        
            cboFace.DisplayImages(images);
            cboFace.SelectedIndex = 0;
            cboFace.DropDownHeight = 200;
        }
    }
}
