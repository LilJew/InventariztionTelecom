using DraggableControls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventariztionTelecom
{
    public partial class AddRecord : Form
    {
        
        class ComboItem
        {
            public int Id { get; set; }
            public string Text { get; set; }
        }

        public AddRecord()
        {
            
            InitializeComponent();
            this.Draggable(true);

        }

        private void AddRecord_Load(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            db.openConnection();
            string sql = "SELECT user_id, SURNAME FROM USERS";
            SqlCommand command = new SqlCommand(sql,db.getConnection());
            SqlDataReader reader =  command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    ComboItem ci = new ComboItem()
                    {
                        Id = reader.GetInt32(0),
                        Text = reader.GetString(1)
                        
                    };
                    comboBox1.Items.Add(ci.Id + "." + ci.Text);

                }
            }
            reader.Close();
            
            
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            db.openConnection();
            string sql = "SURNAME FROM USERS";
            SqlCommand command = new SqlCommand(sql, db.getConnection());

            db.closeConnection();


        }

        private void addRecordExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            

        }
    }
}
