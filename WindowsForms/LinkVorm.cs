using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public class LinkVorm :Form
    {
        public LinkVorm() { }
        public LinkVorm(string Peakiri, string Nupp, string Fail)
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text= Peakiri;
            Button nupp = new Button
            {
                Text= Nupp,
                Location=new System.Drawing.Point(50,50),
                Size=new System.Drawing.Size(100,50),
                BackColor=System.Drawing.Color.LightBlue,
                ForeColor=System.Drawing.Color.White,
            };
            nupp.Click += Nupp_Click;
            Label failiNimi = new Label
            {
                Text=Fail,
                Location = new System.Drawing.Point(100, 50),
                Size = new System.Drawing.Size(100, 50),
                BackColor = System.Drawing.Color.LightBlue,
                ForeColor = System.Drawing.Color.White,
            };
            this.Controls.Add(nupp);
            this.Controls.Add(failiNimi);
        }

        private void Nupp_Click(object sender, EventArgs e)
        {
            //random dlja randomnoi muziki
            Random rnd = new Random();
            //massiv dlja zvukov
            string[] PlayList = { @"..\..\ahem_x.wav", @"..\..\applause_y.wav", @"..\..\buzzer3_x.wav" };
            Button nupp_sender=(Button)sender;
            var vastus = MessageBox.Show("Kas tahad muusika kuulata?","Küsimus",MessageBoxButtons.YesNo);
            if (vastus == DialogResult.Yes)
            {
                using(var muusika=new SoundPlayer(PlayList[rnd.Next(0,2)]))
                {
                    muusika.Play();
                }
            }
            else
            {
                MessageBox.Show("SAD");
            }
        }
    }
}
