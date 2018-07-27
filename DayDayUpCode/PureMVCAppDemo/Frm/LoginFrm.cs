﻿using System;
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
    /// <summary>
    /// 窗体的交互动作
    /// </summary>
    /// <param name="data"></param>
    public delegate void CallFormDoMutual(object data);
    public partial class LoginFrm : BaseForm
    {
        public LoginFrm()
        {
            InitializeComponent();
            Init();
        }
        //封装一个公用的调度方法
        public CallFormDoMutual Call { get; private set; }
        void Init()
        {
            Call = CallTodo;
        }
        public override void CallTodo(object data)
        {
            string tip = data as string;
            rtbTip.Text += "\r\n" + tip+"\t" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseForm bf = OutSideCall.GetFormInstance(typeof(RegisterFrm).Name) as BaseForm;
            string tip = this.GetType().Name + " call " + bf.GetType().Name;
            bf.CallTodo(tip);
        }
    }
}
