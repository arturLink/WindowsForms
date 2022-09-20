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

            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            this.Controls.Add(puu);
        }

        private void Puu_AfterSelect(object sender, TreeViewEventArgs e)
        {
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
