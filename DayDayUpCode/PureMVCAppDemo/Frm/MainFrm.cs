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
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            InitMainPage();
        }
        void InitMainPage()
        {
            List<string> forms = new List<string>();
            forms.Add(typeof(LoginFrm).Name);
            forms.Add(typeof(RegisterFrm).Name);
            Point p = this.Location;
            for (int i = 0; i < forms.Count; i++)
            {
                Button btn = new Button()
                {
                    Name = forms[i],
                    Text = forms[i],
                    Location = new Point(p.X, p.Y + i * 35)
                };
                btn.Click += new EventHandler(Button_Click);
                this.Controls.Add(btn);

                //进行puremvc注册
                string name = forms[i];
               // Form frm = OutSideCall.GetFormInstance(name);
                
            }
        }
        void Button_Click(object sender, EventArgs e)
        {
            Button b = (sender as Button);
            string formName = b.Name;
            Form frm = OutSideCall.GetFormInstance(formName);
            BaseForm lf = frm as BaseForm;
            if (!lf.IsHandleCreated)
            {//判断窗体是否已经加载
                if (!lf.IsDisposed)//如果没有被销毁【窗体为进行关闭】
                    lf.Show();
                else { }
            }
            string tip = this.GetType().Name + " call " + lf.GetType().Name;
           // FormFacade fc = new FormFacade(formName, this);
           // OutSideCall.SendNotify(typeof(LoginFrm).Name, tip);
        }
    }
}
