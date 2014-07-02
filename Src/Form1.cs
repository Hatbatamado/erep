using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace erep
{
    public partial class Form1 : Form
    {
        Skybound.Gecko.GeckoWebBrowser web;
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(600, 400);
            this.Location = new Point(Screen.GetWorkingArea(this).Width / 2 - 300, 200);
            Skybound.Gecko.Xpcom.Initialize(@"..\..\Src\xulrunner");
            this.Text = "Auto fight";
            Alapok();
        }

        Button bot;
        private void Alapok()
        {
            //-------------------------------------------------------
            Button adatok = new Button();
            Controls.Add(adatok);
            adatok.Text = "Belépési adatok";
            adatok.Location = new Point(150, 150);
            adatok.Size = new System.Drawing.Size(100, 22);
            adatok.TabIndex = 1;
            adatok.Click += adatok_Click;
            //-------------------------------------------------------
            bot = new Button();
            Controls.Add(bot);
            bot.Text = "Bot indítása";
            bot.Size = new Size(100, 22);
            bot.Location = new Point(300, 150);
            bot.Focus();
            bot.TabIndex = 0;
            bot.Click += bot_Click;
        }

        void bot_Click(object sender, EventArgs e)
        {
            Controls.Clear();
        }

        TextBox nevt, passt;
        void adatok_Click(object sender, EventArgs e)
        {
            string load;
            Controls.Clear();
            //-------------------------------------------------------
            Label cim = new Label();
            Controls.Add(cim);
            cim.Text = (sender as Button).Text;
            cim.Font = new Font("Arial", 14, FontStyle.Bold);
            cim.Size = new Size(175, 22);
            cim.Location = new Point(300 - (175 / 2), 5);
            //-------------------------------------------------------
            Label nev = new Label();
            Controls.Add(nev);
            nev.Text = "Felhasználó név:";
            nev.Size = new Size(115, 22);
            nev.Font = new System.Drawing.Font("Arial", 10);
            nev.Location = new Point(100, 75);
            //-------------------------------------------------------
            nevt = new TextBox();
            Controls.Add(nevt);
            nevt.Location = new Point(220, 73);
            nevt.Size = new Size(nevt.Size.Width + 50, 22);
            nevt.Focus();
            //-------------------------
            load = Load_t(1);
            if (load != "-")
            {
                nevt.Text = load;
                nevt.Select(nevt.Text.Length, 0);
            }
            //-------------------------------------------------------
            Label pass = new Label();
            Controls.Add(pass);
            pass.Text = "Jelszó:";
            pass.Size = new Size(50, 22);
            pass.Font = new Font("Arial", 10);
            pass.Location = new Point(164, 100);
            //-------------------------------------------------------
            passt = new TextBox();
            Controls.Add(passt);
            passt.Location = new Point(220, 98);
            passt.Size = nevt.Size;
            //-------------------------
            load = Load_t(2);
            if (load != "-")
                passt.Text = load;
            //-------------------------------------------------------
            Button ok = new Button();
            Controls.Add(ok);
            ok.Text = "Mentés";
            ok.Location = new Point(180, 140);
            ok.Click += ok_Click;
            //-------------------------------------------------------
            Controls.Add(bot);
            bot.Location = new Point(280, 140);
            //-------------------------------------------------------
        }

        void ok_Click(object sender, EventArgs e)
        {
            Save_t();
            Controls.Clear();
            Alapok();
        }

        private string Load_t(int melyik)
        {
            if (File.Exists("config.conf"))
            {
                string be = "";
                StreamReader sr = new StreamReader("config.conf");
                switch (melyik)
                {
                    case 1:
                        be = sr.ReadLine();
                        if (be != "")
                        {
                            sr.Close();
                            return be;
                        }
                        break;
                    case 2:
                        be = sr.ReadLine();
                        be = sr.ReadLine();
                        if (be != "")
                        {
                            sr.Close();
                            return be;
                        }
                        break;
                }
                sr.Close();
            }
            return "-";
        }

        private void Save_t()
        {
            StreamWriter sw = new StreamWriter("config.conf",false); //overwrite
            sw.WriteLine(nevt.Text);
            sw.WriteLine(passt.Text);
            sw.Close();
        }
    }
}
