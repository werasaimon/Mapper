using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppMapa
{
    public partial class FormAddUsers : Form
    {
        private bool isUsernameEdit;
        private bool isPasswordEdit;
        private SQLiteConnection DB;// = new SQLiteConnection("Data Source=../../database/DB.db; Version=3");
        public FormAddUsers()
        {
            InitializeComponent();
            
            comboBoxAdmin.SelectedIndex = 0;
            DB = new SQLiteConnection("Data Source=../../database/DB.db; Version=3");
            DB.Open();
            UpdateTable();

            textBoxUsername.Text = "Username";//подсказка
            textBoxUsername.ForeColor = Color.Gray;

            textBoxPassword.Text = "Password";//подсказка
            textBoxPassword.ForeColor = Color.Gray;
            

            isUsernameEdit = true;
            isPasswordEdit = true;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }


        public void UpdateTable()
        {
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM Users",DB);
            DataSet dset = new DataSet();
            adapter.Fill(dset, "info");
            dataGridView1.DataSource = dset.Tables[0];
        }


        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

      

        private void buttonDelete_Click(object sender, EventArgs e)
        {
           System.Console.WriteLine( dataGridView1.CurrentRow.Cells[1].Value.ToString());

            SQLiteCommand CMD = DB.CreateCommand();
            String name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            CMD.CommandText = "DELETE FROM Users WHERE Username='" + name + "';";
            CMD.ExecuteNonQuery();
            CMD.Dispose();

            UpdateTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("ВВедите Имя и Групу ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {

            if(textBoxUsername.Text != "" && textBoxPassword.Text != "" && !isUsernameEdit && !isPasswordEdit)
            {

                SQLiteCommand CMD = DB.CreateCommand();
                CMD.CommandText = "select * from Users WHERE Username=@username";
                CMD.Parameters.AddWithValue("username", textBoxUsername.Text);
                SQLiteDataReader SQL = CMD.ExecuteReader();
                int count = 0;
                if (SQL.HasRows)
                {
                    while (SQL.Read())
                    {
                        count++;
                    }
                }

                if(count == 0)
                {
                    CMD = DB.CreateCommand();
                    CMD.CommandText = "insert into Users (Username, Password, Admin)" +
                                       "values(@username, @password, @admin)";

                    CMD.Parameters.Add("@username", System.Data.DbType.String).Value = textBoxUsername.Text;
                    CMD.Parameters.Add("@password", System.Data.DbType.String).Value = textBoxPassword.Text;
                    CMD.Parameters.Add("@admin", System.Data.DbType.Boolean).Value = comboBoxAdmin.SelectedIndex;

                    textBoxUsername.Text = string.Empty;
                    textBoxPassword.Text = string.Empty;

                    textBoxUsername.Text = "Username";//подсказка
                    textBoxUsername.ForeColor = Color.Gray;
                    textBoxUsername.SelectionStart = 0;
                    isUsernameEdit = true;

                    textBoxPassword.PasswordChar = '\0';
                    textBoxPassword.Text = "Password";//подсказка
                    textBoxPassword.ForeColor = Color.Gray;
                    textBoxPassword.SelectionStart = 0;
                    isPasswordEdit = true;

                    CMD.ExecuteNonQuery();

                    UpdateTable();
                }
                else
                {
                    MessageBox.Show("Такое имя уже есть !!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                
            }
            else 
            {
                MessageBox.Show("ВВедите Имя и Пароль ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


         
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            if(isUsernameEdit)
            {
              textBoxUsername.Text = null;
              textBoxUsername.ForeColor = Color.Black;
              textBoxUsername.SelectionStart = 0;
              isUsernameEdit = false;
            }
            
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (isPasswordEdit)
            {
                textBoxPassword.Text = null;
                textBoxPassword.ForeColor = Color.Black;
                textBoxPassword.SelectionStart = 0;
                isPasswordEdit = false;
                textBoxPassword.PasswordChar = '*';
            }
        }
    }
}
