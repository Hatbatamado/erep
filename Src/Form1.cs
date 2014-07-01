using System;
using System.Drawing;
using System.Windows.Forms;

namespace erep
{
    public partial class Form1 : Form
    {
        Skybound.Gecko.GeckoWebBrowser web;
        public Form1()
        {
            InitializeComponent();
            Skybound.Gecko.Xpcom.Initialize("xulrunner");
            this.Text = "Auto fight";
            Alapok();
        }

        private void Alapok()
        {
            this.Size = new Size(600, 400);
            this.Location = new Point(600 / 2 - 250, 100);
            //-------------------------------------------------------
            Button adatok = new Button();
            Controls.Add(adatok);
            adatok.Text = "Belépési adatok";
            adatok.Location = new Point(150, 150);
            adatok.Size = new System.Drawing.Size(100, 22);
            adatok.Click += adatok_Click;
        }

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

        }
    }
}
