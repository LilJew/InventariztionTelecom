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
        }
    }
}
