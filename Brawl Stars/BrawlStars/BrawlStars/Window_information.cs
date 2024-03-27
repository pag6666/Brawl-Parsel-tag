using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace BrawlStars
{
    public partial class Window_information : Form
    {
       
        //2RQ009L0Y
        public Window_information()
        {
            InitializeComponent();
        }
        private string tag_wi = "";
        private void Window_information_FormClosed(object sender, FormClosedEventArgs e)
        {
            Const_Class.main_form.Show();
        }
        private void GetState() 
        {
            try
            {
                new Thread(() => {
                    MessageBox.Show("подождите пару минут");
                }).Start();
               

                Thread.Sleep(100);
                var driverService = EdgeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                tag_wi = Const_Class.Tag_form;
                EdgeOptions options = new EdgeOptions();

                options.AddArgument("--headless"); // Запуск в headless режиме

                IWebDriver driver = new EdgeDriver(driverService,options);

                driver.Navigate().GoToUrl("https://brawlify.com/");
                //hpStatsFormProfileTag
                IWebElement input = driver.FindElement(By.Id("hpStatsFormProfileTag"));
                input.SendKeys(tag_wi);
                IWebElement button = driver.FindElement(By.Id("hp-profile-submit"));
                button.Click();
                //get-labels
                IWebElement label2_em = driver.FindElement(By.CssSelector("td.text-left.shadow-normal.text-warning"));
                label2.Text = label2_em.Text;
                IWebElement label3_em = driver.FindElement(By.CssSelector("td.text-left.text-hp2.shadow-normal"));
                label3.Text = label3_em.Text;
                IWebElement label4_em = driver.FindElement(By.CssSelector("td.text-left.text-info.shadow-normal"));
                label4.Text = label4_em.Text;
                IWebElement label5_em = driver.FindElement(By.CssSelector("span.text-orange.shadow-normal"));
                label5.Text = label5_em.Text;
               // IWebElement label6_em = driver.FindElement(By.CssSelector(""));




                driver.Close();
            }
            catch (Exception ex) 
            {
                new Thread(() => {
                    MessageBox.Show(ex.Message, "Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    MessageBox.Show("Проверте ваш тег на правильность","(- - )",MessageBoxButtons.OK,MessageBoxIcon.Question);
                }).Start();
                this.Close();
            }
        }

        private void Window_information_Load(object sender, EventArgs e)
        {

            GetState();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetState();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
