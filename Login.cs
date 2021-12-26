using DraggableControls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace InventariztionTelecom
{

    public partial class Login : Form
    {

        MainWindow main = new MainWindow();

        public Login()
        {
            InitializeComponent();
            this.Draggable(true);
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
                    
                    
                    //MessageBox.Show("Успешный логин");
                    
                    userRoleCheck();
                    
                }

                else MessageBox.Show("\n" +
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
