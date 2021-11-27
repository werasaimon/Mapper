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
    public partial class FormUser : Form
    {
        private bool m_IsAdministrator;
        private bool m_isVariablee;
        private String m_Username;
        private SQLiteConnection DB;

        public bool IsAdministrator { get => m_IsAdministrator; set => m_IsAdministrator = value; }
        public bool IsVariablee { get => m_isVariablee; set => m_isVariablee = value; }
        public string Username { get => m_Username; set => m_Username = value; }

        public FormUser(SQLiteConnection _db)
        {
            InitializeComponent();
            textBoxPass.PasswordChar = '*';
            DB = _db;
            m_isVariablee = false;
            m_Username = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /**
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "SELECT Username,Password FROM Users WHERE Username='@username' AND Password = '@password'";

            CMD.Parameters.AddWithValue("@username", textBoxUser.Text);
            CMD.Parameters.AddWithValue("@password", textBoxPass.Text);

            SQLiteDataReader SQL = CMD.ExecuteReader();

            var count = 0;
            while (SQL.Read())
            { 
                String name = SQL["Username"].ToString();
                System.Console.WriteLine("Name: " + name.ToString());
                count = count + 1;
            }
            **/


            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select * from Users WHERE Username=@username AND Password=@password";
            CMD.Parameters.AddWithValue("username", textBoxUser.Text);
            CMD.Parameters.AddWithValue("password", textBoxPass.Text);
            SQLiteDataReader SQL = CMD.ExecuteReader();
            int count = 0;
            bool Admin = false;
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {
                    String AdminStr = SQL["Admin"].ToString();
                    bool.TryParse(AdminStr, out Admin);
                    System.Console.WriteLine(Admin.ToString());
                    count++;
                }
            }


            if (count == 0)
            {
                MessageBox.Show("ВВедите Имя и Пароль ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (count == 1)
            {
                m_isVariablee = true;
                m_IsAdministrator = Admin;
                m_Username = textBoxUser.Text;
                Close();
            }



            //string query = "SELECT * FROM Users WHERE Username= @user AND Password= @password"; // wrong statment?
            //SQLiteConnection conn = new SQLiteConnection("Data Source=Login.db;Version=3;");
            //conn.Open();
            //SQLiteCommand cmd = new SQLiteCommand(query, conn);
            //cmd.Parameters.AddWithValue("user", textBoxUser.Text);
            //cmd.Parameters.AddWithValue("Password", textBoxPass.Text);
            //SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            ////dataGridView1.DataSource = dt; // only shows one line of data


            //if (dt.Rows.Count > 0)
            //{
            //    MessageBox.Show("You're Logged in", "Login Successful");

            //}

            //if (count == 0)
            //{
            //    MessageBox.Show("ВВедите Имя и Пароль ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else if (count == 1)
            //{
            //    m_IsAdministrator = true;
            //    Close();
            //}

        }


    }
}
