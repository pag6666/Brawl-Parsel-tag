using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrawlStars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool check_string_on_null(string text) 
        {
            bool requets = false;
            if (text != null)
            {
                if (text.Trim().Length > 0)
                {
                    requets = true;
                }
                else
                {
                    MessageBox.Show("поле для тег пустое!.", "ошибка текста", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
            return requets;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string tag_text = "";
            tag_text = textBox1.Text.ToString();
            if (check_string_on_null(tag_text)) 
            {
                //success
                Window_information wi = new Window_information();
                Const_Class.Tag_form = tag_text.Trim();
                this.Hide();
                wi.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Const_Class.main_form = this;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            {
               
            }
        }
    }
}
