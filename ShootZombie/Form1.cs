using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShootZombie
{
    public partial class Form1 : Form
    {
        PictureBox[,] a = new PictureBox[4, 4];
        Random rand = new Random();
        int pictureboxWidth = 110;
        int pictureboxHeight = 110;
        int pictureboxSpace = 0;
        int count = 0;
        int timeLeft = 30;
        int countdown = 3;
        int hp = 200;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        void createArray()
        {
           
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    int pictureboxX = 3 + pictureboxSpace + x * (pictureboxWidth + pictureboxSpace);
                    int pictureboxY = 100 + pictureboxSpace + y * (pictureboxHeight + pictureboxSpace);
                    
                    a[x, y] = new PictureBox();
                    a[x, y].Location = new System.Drawing.Point(pictureboxX, pictureboxY);
                    a[x, y].Size = new System.Drawing.Size(pictureboxWidth, pictureboxHeight);
                    a[x, y].SizeMode = PictureBoxSizeMode.Zoom;
                    a[x, y].BackColor = Color.Transparent;
                    if (x == 3)
                    {
                        int j = rand.Next(0, 4);
                        a[j, y].Image = ShootZombie.Properties.Resources.Pns_01;
                    }
                    this.Controls.Add(a[x, y]);
                }
            }
        }

        void createFirstRow()
        {
            
            bool flag = false;
            int j = rand.Next(0, 4);

            if (count == 221 && flag == false)
            {
                a[j, 0].Image = ShootZombie.Properties.Resources.Saitama;
                flag = true;
                return;
            }
            
            if (count >= 0 && count < 37)
            {
                a[j, 0].Image = ShootZombie.Properties.Resources.Pns_01;
            }
            else if (count >= 37 && count < 77)
            {
                a[j, 0].Image = ShootZombie.Properties.Resources.Pns_02;
            }
            else if (count >= 77 && count < 117)
            {
                a[j, 0].Image = ShootZombie.Properties.Resources.Pns_03;
            }
            else if (count >= 117 && count < 167)
            {
                a[j, 0].Image = ShootZombie.Properties.Resources.Pns_04;
            }
            else if (count >= 167 && count < 222)
            {
                a[j, 0].Image = ShootZombie.Properties.Resources.Pns_05;
            }


            this.Controls.Add(a[j, 0]);

        }

        private void buttonPress(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 'C')
            {
                if (a[0, 3].Image != null)
                {
                    count++;
                    scoreCalculate();
                    minus.Visible = false;
                    a[0, 3].Image = null;
                    for (int y = 2; y >= 0; y--)
                    {
                        for (int x = 0; x < 4; x++)
                        {
                            if (a[x, y].Image != null)
                            {
                                a[x, y + 1].Image = a[x, y].Image;
                                a[x, y].Image = null;
                            }
                        }
                    }
                    createFirstRow();
                }
                else if (a[0, 3].Image == null)
                {
                    hp -= 10;
                    minus.Visible = true;
                    label2.Text = hp.ToString();
                }
            }

            if (e.KeyValue == 'V')
            {
                if (a[1, 3].Image != null)
                {
                    count++;
                    scoreCalculate();
                    minus.Visible = false;
                    a[1, 3].Image = null;
                    for (int y = 2; y >= 0; y--)
                    {
                        for (int x = 0; x < 4; x++)
                        {
                            if (a[x, y].Image != null)
                            {
                                a[x, y + 1].Image = a[x, y].Image;
                                a[x, y].Image = null;
                            }
                        }
                    }
                    createFirstRow();
                }
                else if (a[1, 3].Image == null)
                {
                    hp -= 10;
                    minus.Visible = true;
                    label2.Text = hp.ToString();
                }
            }

            if (e.KeyValue == 'N')
            {
                if (a[2, 3].Image != null)
                {
                    count++;
                    scoreCalculate();
                    minus.Visible = false;
                    a[2, 3].Image = null;
                    for (int y = 2; y >= 0; y--)
                    {
                        for (int x = 0; x < 4; x++)
                        {
                            if (a[x, y].Image != null)
                            {
                                a[x, y + 1].Image = a[x, y].Image;
                                a[x, y].Image = null;
                            }
                        }
                    }
                    createFirstRow();
                }
                else if (a[2, 3].Image == null)
                {
                    hp -= 10;
                    minus.Visible = true;
                    label2.Text = hp.ToString();
                }
            }

            if (e.KeyValue == 'M')
            {
                if (a[3, 3].Image != null)
                {
                    count++;
                    scoreCalculate();
                    minus.Visible = false;
                    a[3, 3].Image = null;
                    for (int y = 2; y >= 0; y--)
                    {
                        for (int x = 0; x < 4; x++)
                        {
                            if (a[x, y].Image != null)
                            {
                                a[x, y + 1].Image = a[x, y].Image;
                                a[x, y].Image = null;
                            }
                        }
                    }
                    createFirstRow();
                }
                else if (a[3, 3].Image == null)
                {
                    hp -= 10;
                    minus.Visible = true;
                    label2.Text = hp.ToString();
                }
            }
            if (hp == 0)
            {
                timer.Stop();
                minus.Visible = false;
                this.Close();

                var overForm = new Form7();
                overForm.Location = this.Location;
                overForm.StartPosition = FormStartPosition.CenterScreen;
                overForm.Show();
                overForm.String1 = count + "";
                overForm.String2 = score.ToString();
                overForm.SetValue();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                label1.Text = (timeLeft % 60).ToString();

                if(count == 221)
                {
                    timer.Stop();
                    this.Close();

                    var winForm = new Form6();
                    winForm.Location = this.Location;
                    winForm.StartPosition = FormStartPosition.CenterScreen;
                    //timeForm.FormClosing += delegate { this.Show(); };
                    winForm.Show();
                    winForm.String1 = count + "";
                    winForm.String2 = score.ToString();
                    winForm.SetValue();
                }
            }
            else
            {
                timer.Stop();
                minus.Visible = false;
                this.Close();

                var timeForm = new Form5();
                timeForm.Location = this.Location;
                timeForm.StartPosition = FormStartPosition.CenterScreen;
                //timeForm.FormClosing += delegate { this.Show(); };
                timeForm.Show();
                timeForm.String1 = count+"";
                timeForm.String2 = score.ToString();
                timeForm.SetValue();
                
            }
        }
        void scoreCalculate()
        {
            if (count > 0 && count <= 40)
            {
                score += 100;
            }
            else if (count > 40 && count <= 80)
            {
                score += 500;
            }
            else if (count > 80 && count <= 120)
            {
                score += 1000;
            }
            else if (count > 120 && count <= 170)
            {
                score += 2000;
            }
            else if (count >= 170 && count <= 220)
            {
                score += 5000;
            }
            else if (count == 221)
            {
                score += 10000;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countdown--;
            if (countdown > 0)
            {
                if (countdown == 2) {
                    pictureBox6.BackgroundImage = ShootZombie.Properties.Resources._2;
                }
                else if (countdown == 1)
                {
                    pictureBox6.BackgroundImage = ShootZombie.Properties.Resources._1;
                }
            }
            else if (countdown == 0)
            {
                pictureBox6.Visible = false;
                timer1.Stop();
                createArray();
                timer.Start();
               
            }
        }
    }
}
