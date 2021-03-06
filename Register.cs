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
using DraggableControls;

namespace InventariztionTelecom
{
    public partial class Register : Form
    {
        public Register()
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
            Login login = new Login();
            login.Show();
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            string regName = regNameField.Text;
            string regSurname = regSurnameField.Text;
            string regLogin = regLoginField.Text;
            string regPass = db.getHash(regPassField.Text);
            string defaultRole = "user";
          
            
            

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

                if (isAllFieldsFilled())
                {
                    MessageBox.Show("Успех, Войдите в программу под своими данными");
                    command.ExecuteNonQuery();
                    ActiveForm.Hide();
                    Login login = new Login();
                    login.Show();


                }
                else
                {
                    this.errorLabel.Visible = true;
                    this.errorLabel.Text = "Обнаружены пустые поля";
                    this.errorLabel.ForeColor = Color.DarkRed;
                    this.errorLabel.BackColor = Color.LightGreen;
                    command.Cancel();
                }
                

              





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.closeConnection();
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
        public Boolean isAllFieldsFilled() 
        {
            foreach (Control control in this.Controls)
            {
                if(control.GetType() == typeof(TextBox))
                {

                    if (control.Text == "")
                    {
                        goto isFalse;
                    }
                    else goto isTrue;
                }
            }
        isTrue: return true;
        isFalse: return false;

        }

        

    }
}
