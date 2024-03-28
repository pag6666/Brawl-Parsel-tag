using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrawlStars
{
    public partial class loader_From : Form
    {
        public loader_From()
        {
            InitializeComponent();
        }

        private void loader_From_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.Icon = Const_Class.main_form.Icon;
            Const_Class.pb = progressBar1;
            new Thread(() =>
            {
                if(progressBar1.Value > 99) 
                {
                    Thread.Sleep(100);
                    this.Close();
                }
            }).Start();
        
        }
    }
}
