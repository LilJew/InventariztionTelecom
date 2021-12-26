using DraggableControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventariztionTelecom
{
    public partial class AddRecord : Form
    {
        public AddRecord()
        {
        
            InitializeComponent();
            this.Draggable(true);

        }

        private void AddRecord_Load(object sender, EventArgs e)
        {
            
        }
    }
}
