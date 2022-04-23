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
            // print tbl_CANDIDATE to DataGrid1
            string query_SHOW = "select * from TBL_WORKER";
            DT.list(dataGridView1, query_SHOW);

            //dateTimePicker1.MinDate = DateTime.Today;
        }
    }
}
