using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventariztionTelecom
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        // какая то ёбаная магия заставляющая форму двигаться
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            MouseMove += Form_MouseMove;
            foreach (Control ctrl in Controls)
                ctrl.MouseMove += Form_MouseMove;
        }

        void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            
            string regName = regNameField.Text;
            string regSurname = regSurnameField.Text;
            string regLogin = regLoginField.Text;
            string regPass = regPassField.Text;
            string defaultRole = "user";
            DataBase db = new DataBase();

            if (isUserExists()) return;
            try
            {
               
                string sql = "INSERT INTO USERS (USERNAME,PASSWORD,NAME,SURNAME,USER_ROLE) VALUES (@regLogin,  @regPass,  @regName,  @regSurname,  @defaultRole)";


                db.openConnection();
                SqlCommand command = new SqlCommand(sql, db.getConnection());
                command.Parameters.Add("@regLogin", SqlDbType.VarChar, 50).Value = regLogin;
                command.Parameters.Add("@regPass", SqlDbType.VarChar, 50).Value = regPass;
                command.Parameters.Add("@regName", SqlDbType.VarChar, 50).Value = regName;
                command.Parameters.Add("@regSurname", SqlDbType.VarChar, 50).Value = regSurname;
                command.Parameters.Add("@defaultRole", SqlDbType.VarChar, 50).Value = defaultRole;


                if (command.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Аккаунт создан", "Успех!");
                }

                db.closeConnection();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //Проверка на совпадение логинов при регистрации
        public Boolean isUserExists()
        {
            DataBase db = new DataBase();
            string sql = "SELECT * FROM USERS WHERE USERNAME LIKE @userLogin";

            db.openConnection();

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();



            SqlCommand command = new SqlCommand(sql, db.getConnection());


            command.Parameters.Add("@userLogin", SqlDbType.VarChar, 50).Value = regLoginField.Text;



            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой Логин уже занят!");
                return true;

            }
            else return false;

        }
    }
}
