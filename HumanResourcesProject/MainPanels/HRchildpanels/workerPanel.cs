using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResourcesProject.MainPanels.HRchildpanels
{
    public partial class workerPanel : Form
    {
        DataBase DT = new DataBase();

        public workerPanel()
        {
            InitializeComponent();
        }

        private void workerPanel_Load(object sender, EventArgs e)
        {
            DT.DataGrid_WORKER(dataGridView1);
            //dateTimePicker1.MinDate = DateTime.Today;
        }
    }
}
