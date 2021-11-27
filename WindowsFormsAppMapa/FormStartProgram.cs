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
    public partial class FormStartProgram : Form
    {
        FormMapa m_FormMapa;
        FormAddUsers m_FormAddUsers;
        FormPollutionTypes m_FormPollutionTypes;
        public FormStartProgram()
        {
            InitializeComponent();
        }

        private void buttonMapper_Click(object sender, EventArgs e)
        {
            m_FormMapa = new FormMapa();
            m_FormMapa.Show();
        }

        private void buttonAddUsers_Click(object sender, EventArgs e)
        {
            m_FormAddUsers = new FormAddUsers();
            m_FormAddUsers.Show();
        }

        private void buttonAddPollutionTypes_Click(object sender, EventArgs e)
        {
            m_FormPollutionTypes = new FormPollutionTypes();
            m_FormPollutionTypes.Show();
        }
    }
}
