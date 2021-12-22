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
        public string UserName
        { // Не говнокодная передача данных с формы на форму
            get { return label2.Text; }
            set { label2.Text = value; }
         
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
            
            
            
        }
    }
}
