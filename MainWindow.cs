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
    public partial class MainWindow : Form
    {
        DataBase db = new DataBase();


        private void LoadData()
        {
            db.openConnection();
            string sql = "SELECT   device_id, device_name, device_cabinet, users.surname FROM users  INNER JOIN device ON responsible_for_device_id = users.USER_ID ";

            SqlCommand command = new SqlCommand(sql, db.getConnection());
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                






            }
            reader.Close();
            db.closeConnection();
            foreach (string[] s in data)
            {

                dataGridView1.Rows.Add(s);
            }
        }
        



        public string UserName
        { // Не говнокодная передача данных с формы на форму
            get { return label2.Text; }
            set { label2.Text = value; }

        }
        public string UserRole
        { // Не говнокодная передача данных с формы на форму
            get { return userRoleLabel.Text; }
            set { userRoleLabel.Text = value; }

        }





        public MainWindow()
        {
            InitializeComponent();

            
        }
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


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form login = new Login();
            login.Show();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
