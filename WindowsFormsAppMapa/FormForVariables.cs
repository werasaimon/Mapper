using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace WindowsFormsAppMapa
{
    public partial class FormForVariables : Form
    {
        private SQLiteConnection DB;

        private bool   m_isStatus;
        private bool   m_isModify;
        private String m_toInfoText;
        private String m_toName;
        private String m_toType;
        private int    m_Type;
        private int    m_Depth;

        Dictionary<String, InfoPolygon> m_HashElements;
        Dictionary<String, Color> m_HashColors = new Dictionary<String, Color>();

        public FormForVariables(Dictionary<String, InfoPolygon> _HashElements , bool _modify, SQLiteConnection _db)
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


        public FormForVariables(InfoPolygon _InfoPoly , Dictionary<String, InfoPolygon> _HashElements , bool _modify, SQLiteConnection _db)
        {
            InitializeComponent();
            DB = _db;
            m_toInfoText = _InfoPoly.m_toInfoText;
            m_toName = _InfoPoly.m_toName;
            m_Type = _InfoPoly.m_Type;
            m_Depth = _InfoPoly.m_Depth;
            textBoxNmae.Text = m_toName;
            trackBarDepth.Value = m_Depth;
            m_HashElements = _HashElements;
            m_isModify = _modify;

            richTextBox1.Text = m_toInfoText;

            UpdateItemsTypes();
            // comboBoxType.SelectedText = _InfoPoly.m_toType;
            this.comboBoxType.SelectedIndex = this.comboBoxType.FindStringExact(_InfoPoly.m_toType);
        }

        //public void seter(InfoPolygon _InfoPoly)
        //{
        //    m_toName = _InfoPoly.m_toName;
        //    m_Type = _InfoPoly.m_Type;
        //    m_Depth = _InfoPoly.m_Depth;
        //    comboBoxType.SelectedIndex = m_Type;
        //    textBoxNmae.Text = m_toName;    
        //    trackBarDepth.Value = m_Depth;
        //}

        public bool IsStatus { get => m_isStatus; set => m_isStatus = value; }
        public string ToName { get => m_toName; set => m_toName = value; }
        public int Type { get => m_Type; set => m_Type = value; }
        public int Depth { get => m_Depth; set => m_Depth = value; }
        public string ToType { get => m_toType; set => m_toType = value; }
        public string ToInfoText { get => m_toInfoText; set => m_toInfoText = value; }

        private void Cancel_Click(object sender, EventArgs e)
        {
            m_isStatus = false;
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            m_toInfoText = richTextBox1.Text;

            if (textBoxNmae.Text == "Name Marker" || textBoxNmae.Text == "" || comboBoxType.Text == "")
            {
                MessageBox.Show("ВВедите Имя и Групу ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(m_isModify==true)
            {

                m_isStatus = true;
                m_toName = this.textBoxNmae.Text;
                m_Type = this.comboBoxType.SelectedIndex;
                m_toType = comboBoxType.GetItemText(comboBoxType.SelectedItem);

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
                    m_Type = this.comboBoxType.SelectedIndex;
                    m_toType = comboBoxType.GetItemText(comboBoxType.SelectedItem);
                    Console.WriteLine("OK! ---  " + m_toType);
                    this.Close();
                }
            }


          
        }

        private void trackBarDepth_Scroll(object sender, EventArgs e)
        {
            m_Depth = this.trackBarDepth.Value;
            Console.WriteLine(m_Depth.ToString());
            this.label1.Text = "Depth = " + m_Depth.ToString();
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
            if(textBoxNmae.Text == "Name Marker")
            {
                textBoxNmae.Text = "";
                textBoxNmae.ForeColor = Color.Black;
            }
        }


        private void UpdateItemsTypes()
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select * from PollutionTypes";
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
    }
}
