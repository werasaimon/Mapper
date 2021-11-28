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
  
    
    public partial class FormPollutionTypes : Form
    {
        private bool isNameEdit;
        private SQLiteConnection DB;// = new SQLiteConnection("Data Source=../../database/DB.db; Version=3");
        public FormPollutionTypes()
        {
            InitializeComponent();
            DB = new SQLiteConnection("Data Source=../../database/DB.db; Version=3");
            DB.Open();

            comboBoxType.SelectedIndex = 0;
            UpdateTable();

            isNameEdit = true;
            textBoxPollutionType.Text = "Pollution Types";//подсказка
            textBoxPollutionType.ForeColor = Color.Gray;

            // расширенное окно для выбора цвета
            colorDialog1.FullOpen = true;
            // установка начального цвета для colorDialog
            colorDialog1.Color = this.BackColor;

        }

     

        public void UpdateTable()
        {
            System.Console.WriteLine("wera");
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM PollutionTypes", DB);
            DataSet dset = new DataSet();
            adapter.Fill(dset, "info");
            dataGridView1.DataSource = dset.Tables[0];
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxPollutionType.Text != "" && !isNameEdit)
            {

                SQLiteCommand CMD = DB.CreateCommand();
                CMD.CommandText = "select * from PollutionTypes WHERE Name=@name";
                CMD.Parameters.AddWithValue("@name", textBoxPollutionType.Text);
                SQLiteDataReader SQL = CMD.ExecuteReader();
                int count = 0;
                if (SQL.HasRows)
                {
                    while (SQL.Read())
                    {
                        count++;
                    }
                }

                if (count == 0)
                {
                    if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                        return;

                    CMD = DB.CreateCommand();
                    CMD.CommandText = "insert into PollutionTypes (Name, Type, Color)" +
                                       "values(@name, @type, @color)";

                    CMD.Parameters.Add("@name", System.Data.DbType.String).Value = textBoxPollutionType.Text;
                    CMD.Parameters.Add("@type", System.Data.DbType.Int32).Value = comboBoxType.SelectedIndex;
                    CMD.Parameters.Add("@color", System.Data.DbType.Int32).Value = colorDialog1.Color.ToArgb();

                    textBoxPollutionType.Text = string.Empty;

                    textBoxPollutionType.Text = "Pollution Types";//подсказка
                    textBoxPollutionType.ForeColor = Color.Gray;
                    textBoxPollutionType.SelectionStart = 0;
                    isNameEdit = true;

                    CMD.ExecuteNonQuery();

                    UpdateTable();
                }
                else
                {
                    MessageBox.Show("Такое уже есть !!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите названия поля !!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxPollutionType_Enter(object sender, EventArgs e)
        {
            if (isNameEdit)
            {
                textBoxPollutionType.Text = null;
                textBoxPollutionType.ForeColor = Color.Black;
                textBoxPollutionType.SelectionStart = 0;
                isNameEdit = false;
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            String name = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            CMD.CommandText = "DELETE FROM PollutionTypes WHERE Name='" + name + "';";
            CMD.ExecuteNonQuery();

            CMD.CommandText = "DELETE FROM InformationGround WHERE Type='" + name + "';";
            CMD.ExecuteNonQuery();


            CMD.CommandText = "DELETE FROM InformationAir WHERE Type='" + name + "';";
            CMD.ExecuteNonQuery();

            CMD.Dispose();

            UpdateTable();
        }
    }
}
