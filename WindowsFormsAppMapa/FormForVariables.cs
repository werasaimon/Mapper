using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppMapa
{
    public partial class FormForVariables : Form
    {
        private bool   m_isStatus;
        private bool   m_isModify;
        private String m_toName;
        private int    m_Type;
        private int    m_Depth;

        Dictionary<String, InfoPolygon> m_HashElements;


        public FormForVariables(Dictionary<String, InfoPolygon> _HashElements , bool _modify)
        {
            InitializeComponent();
            m_Depth = 55;
            m_HashElements = _HashElements;
            m_isModify = _modify;
        }


        public FormForVariables(InfoPolygon _InfoPoly , Dictionary<String, InfoPolygon> _HashElements , bool _modify)
        {
            InitializeComponent();
            m_toName = _InfoPoly.m_toName;
            m_Type = _InfoPoly.m_Type;
            m_Depth = _InfoPoly.m_Depth;
            comboBoxType.SelectedIndex = m_Type;
            textBoxNmae.Text = m_toName;
            trackBarDepth.Value = m_Depth;
            m_HashElements = _HashElements;
            m_isModify = _modify;
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            m_isStatus = false;
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {

            if(textBoxNmae.Text == "Name Marker" || textBoxNmae.Text == "" || comboBoxType.Text == "")
            {
                MessageBox.Show("ВВедите Имя и Групу ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(m_isModify==true)
            {

                m_isStatus = true;
                m_toName = this.textBoxNmae.Text;
                m_Type = this.comboBoxType.SelectedIndex;

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

                    Console.WriteLine("OK!");
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
    }
}
