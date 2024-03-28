using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        private List<string> texts = new List<string>();
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



        error:
            texts.Clear();
                Thread.Sleep(100);
                var driverService = EdgeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                tag_wi = Const_Class.Tag_form;
                EdgeOptions options = new EdgeOptions();

                options.AddArgument("headless"); // Запуск в headless режиме

                IWebDriver driver = new EdgeDriver(driverService, options);

                driver.Navigate().GoToUrl("https://brawlify.com/");
                //hpStatsFormProfileTag
                IWebElement input = driver.FindElement(By.Id("hpStatsFormProfileTag"));
                input.SendKeys(tag_wi);
                IWebElement button = driver.FindElement(By.Id("hp-profile-submit"));
                button.Click();
                //get-labels
                try
                {
                IWebElement table = driver.FindElement(By.TagName("tbody"));
                IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
                foreach (var row in rows)
                {
                    IList<IWebElement> cells = row.FindElements(By.TagName("td"));

                    foreach (var cell in cells)
                    {
                        texts.Add(cell.Text);
                    }


                }
                Const_Class.pb.Value = 100;
                }
                catch (Exception ex)
                {
                        
                        driver.Quit();
                       
                        if (Const_Class.pb.Value < 100)
                        {
                         Const_Class.pb.Value = Const_Class.pb.Value+10;
                        }
                else 
                {
                    Const_Class.pb.Value = 0;
                }
                goto error;
                new Thread(() => {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Проверте ваш тег на правильность", "(- - )", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }).Start();
                this.Close();
                }
            driver.Quit();
            
            setImageAndText();
        }
        private void setImageAndText() 
        {
            listView2.Items.Clear();
            int index = 0;
            foreach (var i in texts) 
            {
                ListViewItem item = new ListViewItem(new string[] {"", i});
                item.ImageIndex = index;
                listView2.Items.Add(item);
                
                index++;
            }
        }
        private void Window_information_Load(object sender, EventArgs e)
        {
            ImageList imagelist =  new ImageList();
            imagelist.ImageSize = new Size(30, 30);
            //add
            imagelist.Images.Add(new Bitmap("image\\0.png"));
            imagelist.Images.Add(new Bitmap("image\\1.png"));
            imagelist.Images.Add(new Bitmap("image\\2.png"));
            imagelist.Images.Add(new Bitmap("image\\3.png"));
            imagelist.Images.Add(new Bitmap("image\\4.png"));
            imagelist.Images.Add(new Bitmap("image\\5.png"));
            imagelist.Images.Add(new Bitmap("image\\6.png"));
           
            Bitmap emptyimage = new Bitmap(50, 50);
            using (Graphics gr = Graphics.FromImage(emptyimage)) 
            {
                gr.Clear(Color.White);

            }
            imagelist.Images.Add(emptyimage);

            listView2.SmallImageList = imagelist;
            var load = new loader_From();
            CheckForIllegalCrossThreadCalls = false;
            new Thread(() => {
                
                load.ShowDialog();


            }).Start();
            new Thread(() => {
                MessageBox.Show("подождите пару минут");
            }).Start();
            GetState();
            Thread.Sleep(1000);
            load.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                GetState();
              
            }).Start();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
