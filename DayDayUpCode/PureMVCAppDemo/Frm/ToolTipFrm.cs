using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PureMVCAppDemo
{
    public partial class ToolTipFrm : BasePureMVCMediator
    {
        public ToolTipFrm()
        {
            InitializeComponent();
            MouseLeave += new  EventHandler(MouseLeave_Event);
        }
        public void SetTip(Form toolFrm,string tip)
        {
             
            //窗体大小计算
            Size = new Size(200, 200);
            lblTip.Text = tip;
            //位置计算
            Point loc= toolFrm.Location;
            Location = new Point(loc.X-50, loc.Y-50);
            Show();
            TopLevel = true;
            ActiveControl = lblTip;
        }
        private void MouseLeave_Event(object sender,EventArgs e)
        {
            this.Hide();
        }
    }
}
