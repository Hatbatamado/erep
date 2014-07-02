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
            Skybound.Gecko.Xpcom.Initialize(@"..\..\Src\xulrunner");
            this.Text = "Auto fight";
            Alapok();
        }

        private void Alapok()
        {
            this.Size = new Size(600, 400);
            this.Location = new Point(Screen.GetWorkingArea(this).Width/2-300, 200);
            //-------------------------------------------------------
            Button adatok = new Button();
            Controls.Add(adatok);
            adatok.Text = "Belépési adatok";
            adatok.Location = new Point(150, 150);
            adatok.Size = new System.Drawing.Size(100, 22);
            adatok.Click += adatok_Click;
        }

        TextBox nevt, passt;
        void adatok_Click(object sender, EventArgs e)
        {
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
            //-------------------------------------------------------
            Button ok = new Button();
            Controls.Add(ok);
            ok.Text = "OK";
            ok.Location = new Point(250, 140);
            ok.Click += ok_Click;
            //-------------------------------------------------------
            Load_t();
        }

        void ok_Click(object sender, EventArgs e)
        {
            Save_t();
            Controls.Clear();
            Alapok();
        }

        private void Load_t()
        {
            if (File.Exists("config.conf"))
            {
                string be = "";
                StreamReader sr = new StreamReader("config.conf");
                //-------------------------------------------------------
                be = sr.ReadLine();
                if (be != "")
                    nevt.Text = be;
                //-------------------------------------------------------
                be = sr.ReadLine();
                if (be != "")
                    passt.Text = be;
                //-------------------------------------------------------
                sr.Close();
            }
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
