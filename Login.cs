using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace InventariztionTelecom
{
    
    public partial class Login : Form
    {
        


        MainWindow main = new MainWindow();


        public Login()
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
            Form register = new Register();
            register.Show();
        }

        
        
        //"SELECT * FROM 'USERS' WHERE 'USERNAME' = @userLogin  AND 'PASSWORD' = @userPass"
        
        //Меторд проверяющий Админские привилегии
        public void userRoleCheck()
        {
            string userName = loginField.Text;
            DataBase db = new DataBase();
            db.openConnection();
            string sql = "SELECT USER_ROLE FROM USERS WHERE USERNAME = @un";
            SqlParameter nameParam = new SqlParameter("@un", userName);
            SqlCommand command = new SqlCommand(sql, db.getConnection());
            command.Parameters.Add(nameParam);
            string Form_Role = command.ExecuteScalar().ToString();
            main.UserRole = Form_Role;
            
            switch (Form_Role)
            {
                default: Form.ActiveForm.Hide();main.Show(); break;
            }

            command.ExecuteNonQuery();
            
            

            db.closeConnection();

        }

        public void loginButton_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            string userLogin = loginField.Text;
            string userPass = db.getHash(passField.Text);
            //string sql = "SELECT * FROM [USERS] WHERE [USERNAME] = @userLogin  AND [PASSWORD] = @userPass";

            
            try
            {
                if (loginField.Text == "" || passField.Text == "")
                {
                    
                }


                string sql = "SELECT * FROM USERS WHERE USERNAME LIKE @userLogin  AND PASSWORD LIKE @userPass";

                db.openConnection();
                

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                


                SqlCommand command = new SqlCommand(sql, db.getConnection());

                
                command.Parameters.Add("@userLogin", SqlDbType.VarChar, 50).Value = userLogin;
                command.Parameters.Add("@userPass", SqlDbType.VarChar, 50).Value = userPass;
               
               
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    main.UserName = userLogin;
                    
                    
                    MessageBox.Show("Успешный логин");
                    
                    userRoleCheck();
                    
                }

                else MessageBox.Show("Произошла ошибка при авторизации\n" +
                    "Возможные причины:\n" +
                    "1.Проблемы с сетью\n" +
                    "2.Неверно введены данные учётной записи");




                command.ExecuteNonQuery();
                
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            
           



        }
        
    }
}
