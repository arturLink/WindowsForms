using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class MinuVorm : Form
    {
        TreeView puu;
        Button nupp;
        Label silt;
        CheckBox mruut1, mruut2;
        RadioButton rnupp1,rnupp2, rnupp3, rnupp4;
        PictureBox pilt;
        ProgressBar riba;
        Timer aeg;
        TextBox teksti;
        public MinuVorm()
        {
            //InitializeComponent();
            Height = 600;
            Width = 900;
            Text = "Minu oma vorm koos elementidega";
            BackColor = Color.LightBlue;
            puu = new TreeView();
            puu.Dock = DockStyle.Left;
            puu.Location = new Point(0, 0);
            TreeNode oksad = new TreeNode("Elementid");
            oksad.Nodes.Add(new TreeNode("Nupp-Button"));
            oksad.Nodes.Add(new TreeNode("Silt-Label"));
            oksad.Nodes.Add(new TreeNode("DialogAken-MessageBox"));
            oksad.Nodes.Add(new TreeNode("Märkeruut-Checkbox"));
            oksad.Nodes.Add(new TreeNode("Radionupp-RadioButton"));
            oksad.Nodes.Add(new TreeNode("Edenemisriba-ProgressBar"));
            oksad.Nodes.Add(new TreeNode("Tekstkast-TextBox"));
            oksad.Nodes.Add(new TreeNode("LinkVorm"));

            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            puu.DoubleClick += Puu_DoubleClick;
            this.Controls.Add(puu);
        }

        private void Puu_DoubleClick(object sender, EventArgs e)
        {
            if (teksti.Enabled)
            {
                teksti.Enabled = false;
            }
            else
            {
                teksti.Enabled = true;
            }
        }

        private void Puu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            silt = new Label // внизу разные свойства для элементов
            {
                Text = "Minu esimene vorm",
                Size = new Size(200, 50),
                Location = new Point(200, 80),
                Width = 100,
                Height = 20,
                ForeColor = Color.White,
                BackColor = Color.Blue,
                BorderStyle = BorderStyle.FixedSingle,
            };
            mruut1 = new CheckBox
            {
                Checked = false,
                Text = "Üks",
                Location = new Point(silt.Left + silt.Width, 0),
                Height = 25,
            };
            mruut2 = new CheckBox
            {
                Checked = false,
                Text = "Kaks",
                Location = new Point(silt.Left + silt.Width, mruut1.Height),
                Height = 25,
            };
            if (e.Node.Text=="Nupp-Button")
            {
                nupp=new Button();
                nupp.Text = "Vajuta siia";
                nupp.Height = 30;
                nupp.Width = 80;
                nupp.Location= new Point(200, 100);
                nupp.Click += Nupp_Click;

                this.Controls.Add(nupp);
            }
            else if (e.Node.Text=="Silt-Label")
            {
                silt = new Label // внизу разные свойства для элементов
                { Text = "Minu esimene vorm",
                    Size = new Size(200, 50),
                    Location = new Point(200, 80),
                    Width = 100,
                    Height = 20,
                    ForeColor= Color.White,
                    BackColor = Color.Blue,
                    BorderStyle = BorderStyle.FixedSingle,
                };
                silt.MouseEnter += Silt_MouseEnter;
                silt.MouseLeave += Silt_MouseLeave;
                this.Controls.Add(silt);
            }
            else if (e.Node.Text== "DialogAken-MessageBox")
            {
                MessageBox.Show("Aken", "Kõike lihtne aken");
                var vastus = MessageBox.Show("Kas paneme aken kinni?","Valik",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(vastus == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sis töötame edasi lapsed");
                }
            }
            else if (e.Node.Text== "Märkeruut-Checkbox")
            {
                mruut1 = new CheckBox
                {
                    Checked = false,
                    Text = "Üks",
                    Location=new Point(silt.Left+silt.Width,0),
                    Height=25,
                };
                mruut2 = new CheckBox
                {
                    Checked = false,
                    Text = "Kaks",
                    Location = new Point(silt.Left + silt.Width, mruut1.Height),
                    Height = 25,
                };
                mruut1.CheckedChanged += Mruut1_CheckedChanged;
                mruut2.CheckedChanged += Mruut2_CheckedChanged;
                

                this.Controls.Add(mruut1);
                this.Controls.Add(mruut2);
            }
            else if (e.Node.Text== "Radionupp-RadioButton")
            {
                rnupp1 = new RadioButton
                {
                    Text="Paremale",
                    Width=112,
                    Location=new Point(mruut2.Left+mruut2.Width, mruut1.Height+mruut2.Height),

                };
                rnupp2 = new RadioButton
                {
                    Text = "Vasakule",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width + rnupp1.Width, mruut1.Height + mruut2.Height),

                };
                rnupp3 = new RadioButton
                {
                    Text = "Ülesse",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width + rnupp1.Width + rnupp2.Width, mruut1.Height + mruut2.Height),

                };
                rnupp4 = new RadioButton
                {
                    Text = "Alla",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width + rnupp1.Width + rnupp2.Width + rnupp3.Width, mruut1.Height + mruut2.Height),

                };

                pilt = new PictureBox
                {
                    Image=new Bitmap("Slaming.png"),
                    Location=new Point(300,300),
                    Size = new Size(200,200),
                    SizeMode=PictureBoxSizeMode.Zoom,
                };

                rnupp1.CheckedChanged += new EventHandler(Rnuppud_Changed);
                rnupp2.CheckedChanged += new EventHandler(Rnuppud_Changed);
                rnupp3.CheckedChanged += new EventHandler(Rnuppud_Changed);
                rnupp4.CheckedChanged += new EventHandler(Rnuppud_Changed);

                this.Controls.Add(rnupp1);
                this.Controls.Add(rnupp2);
                this.Controls.Add(rnupp3);
                this.Controls.Add(rnupp4);
                this.Controls.Add(pilt);
            }
            else if (e.Node.Text== "Edenemisriba-ProgressBar")
            {
                riba = new ProgressBar
                {
                    Width=400,
                    Height=30,
                    //Location=new Point(350,500),
                    Value=0,
                    Minimum=0,
                    Maximum=100,
                    Step=1,
                    Dock=DockStyle.Bottom
                };

                aeg = new Timer();
                aeg.Enabled=true;
                aeg.Tick += Aeg_Tick;

                this.Controls.Add(riba);
            }
            else if (e.Node.Text== "Tekstkast-TextBox")
            {
                teksti = new TextBox
                {
                    Font= new Font("Arial",34,FontStyle.Bold),
                    Location=new Point(350,400),
                    Enabled=false,
                };
                //teksti.MouseDoubleClick += Teksti_MouseDoubleClick;

                this.Controls.Add(teksti);
            }
            else if (e.Node.Text=="LinkVorm")
            {
                LinkVorm art =new LinkVorm("SoundPlayer","Play","Faili nimi");
                art.ShowDialog();
            }
           
        }

        //private void Teksti_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    if (teksti.Enabled)
        //    {
        //        teksti.Enabled = false;
        //    }
        //    else
        //    {
        //        teksti.Enabled = true;
        //    }
        //}

        private void Aeg_Tick(object sender, EventArgs e)
        {
            riba.PerformStep();
        }
        private void Rnuppud_Changed(object sender, EventArgs e)
        {
            if (rnupp1.Checked==true)
            {
                pilt.Location = new Point(pilt.Left+10,pilt.Top);
                rnupp1.Checked= false;
            }
            else if (rnupp2.Checked==true)
            {
                pilt.Location = new Point(pilt.Left -10, pilt.Top);
                rnupp2.Checked = false;
            }
            else if (rnupp3.Checked == true)
            {
                pilt.Location = new Point(pilt.Left, pilt.Top + 10);
                rnupp3.Checked = false;
            }
            else if (rnupp4.Checked == true)
            {
                pilt.Location = new Point(pilt.Left, pilt.Top-10);
                rnupp4.Checked = false;
            }
        }

        private void Mruut2_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut1.Checked == true && mruut2.Checked == true)
            {
                var vastus = MessageBox.Show("1+2=3", "Calculation",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else if (mruut1.Checked == false && mruut2.Checked == false)
            {
                var vastus = MessageBox.Show("0+0=0", "Calculation",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else if (mruut1.Checked == true && mruut2.Checked == false)
            {
                var vastus = MessageBox.Show("1+0=1", "Calculation",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else if (mruut1.Checked == false && mruut2.Checked == true)
            {
                var vastus = MessageBox.Show("0+2=2", "Calculation",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void Mruut1_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut1.Checked == true && mruut2.Checked == true)
            {
                var vastus = MessageBox.Show("1+2=3", "Calculation",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else if (mruut1.Checked == false && mruut2.Checked == false)
            {
                var vastus = MessageBox.Show("0+0=0", "Calculation",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else if (mruut1.Checked == true && mruut2.Checked == false)
            {
                var vastus = MessageBox.Show("1+0=1", "Calculation",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else if (mruut1.Checked == false && mruut2.Checked == true)
            {
                var vastus = MessageBox.Show("0+2=2", "Calculation",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void Silt_MouseLeave(object sender, EventArgs e)
        {
            silt.ForeColor = Color.White;
            silt.BackColor = Color.Blue;
        }

        private void Silt_MouseEnter(object sender, EventArgs e)
        {
            silt.ForeColor= Color.Black;
            silt.BackColor = Color.Cyan;
        }

        Random rnd=new Random();
        private void Nupp_Click(object sender, EventArgs e)
        {
            int red, green, blue;
            red=rnd.Next(120,255);
            green = rnd.Next(120,255);
            blue = rnd.Next(120, 255);
            this.BackColor= Color.FromArgb(red,green,blue);
        }
    }
}
