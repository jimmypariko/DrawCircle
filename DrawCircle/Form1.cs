using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
//using System.Random;

namespace DrawCircle
{
    public partial class Form1 : Form
    {
        int Pos = 0;
        int Pos_x, Pos_y;
        int bal_num;
        int SndPos = 1;
        int trdPos = 2;
        int forPos = 3;
        int drawcount = 0;

        public Form1()
        {
            InitializeComponent();
            bal_num = 2;
        }

        //private PictureBox pictureBox1 = new PictureBox();
        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Dock the PictureBox to the form and set its background to white.
           // pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BackColor = Color.DarkGray;
            // Connect the Paint event of the PictureBox to the event handler method.
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);

            // Add the PictureBox control to the Form.
            this.Controls.Add(pictureBox1);

            this.timer1.Enabled = true;

            this.timer1.Start();
        }

        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Pos_x = Pos % 16;
            //Pos_y = (Pos - Pos_x) / 16;
            //g.FillEllipse(Brushes.LightGray, Pos_x*32, Pos_y*32, 32, 32);
            //SndPos += Pos;
            //g.FillEllipse(Brushes.LightGray,(SndPos%16)*32 , ((SndPos - SndPos%16)/16)*32, 32, 32);
            //g.FillEllipse(Brushes.LightGray, (trdPos % 16) * 32, ((trdPos - trdPos % 16) / 16) * 32, 32, 32);
            //g.FillEllipse(Brushes.LightGray, (forPos % 16) * 32, ((forPos - forPos % 16) / 16) * 32, 32, 32);

            System.Random r = new System.Random();

            forPos = (int)r.Next(255);
            g.FillEllipse(Brushes.LightGray, (forPos % 16) * 32, ((forPos - forPos % 16) / 16) * 32, 30, 30);
            forPos = (int)r.Next(255);
            g.FillEllipse(Brushes.LightGray, (forPos % 16) * 32, ((forPos - forPos % 16) / 16) * 32, 30, 30);
            forPos = (int)r.Next(255);
            g.FillEllipse(Brushes.LightGray, (forPos % 16) * 32, ((forPos - forPos % 16) / 16) * 32, 30, 30);
            forPos = (int)r.Next(255);
            g.FillEllipse(Brushes.LightGray, (forPos % 16) * 32, ((forPos - forPos % 16) / 16) * 32, 30, 30);
            forPos = (int)r.Next(255);
            g.FillEllipse(Brushes.LightGray, (forPos % 16) * 32, ((forPos - forPos % 16) / 16) * 32, 30, 30);
            forPos = (int)r.Next(255);
            g.FillEllipse(Brushes.LightGray, (forPos % 16) * 32, ((forPos - forPos % 16) / 16) * 32, 30, 30);
            forPos = (int)r.Next(255);
            g.FillEllipse(Brushes.LightGray, (forPos % 16) * 32, ((forPos - forPos % 16) / 16) * 32, 30, 30);
            forPos = (int)r.Next(255);
            g.FillEllipse(Brushes.LightGray, (forPos % 16) * 32, ((forPos - forPos % 16) / 16) * 32, 30, 30);
            forPos = (int)r.Next(255);
            g.FillEllipse(Brushes.LightGray, (forPos % 16) * 32, ((forPos - forPos % 16) / 16) * 32, 30, 30);
            forPos = (int)r.Next(255);
            g.FillEllipse(Brushes.LightGray, (forPos % 16) * 32, ((forPos - forPos % 16) / 16) * 32, 30, 30);

            drawcount++;
            if(drawcount%10 == 0)
            {
                save_drawimage();
            }
        }
        private void save_drawimage()
        {
            this.timer1.Stop();

            //PictureBox1の大きさを取得
            Rectangle rect = pictureBox1.ClientRectangle;

            //PictureBox1に表示されている画像を取得するためのBitmap
            Bitmap bmp = new Bitmap(rect.Width, rect.Height);
            //bmpに画像を入れるための準備
            Graphics g = Graphics.FromImage(bmp);
            PaintEventArgs pea = new PaintEventArgs(g, rect);

            //PaintBackgroundイベントを発生
            this.InvokePaintBackground(pictureBox1, pea);
            //Paintイベントを発生
            this.InvokePaint(pictureBox1, pea);

//            pictureBox1.Image = (Image)bmp;
            //pictureBox2.Show();
            //画像を保存する
            //bmp.Save(@"C:\test_" + drawcount.ToString() + ".png");
            //PNG形式で保存する
            //bmp.Save("C:\\test.png", System.Drawing.Imaging.ImageFormat.Png);
            //後始末
            g.Dispose();
            bmp.Dispose();

            this.timer1.Start();
        }

        private void interval_on(object sender, EventArgs e)
        {
            //Graphics g = this.pictureBox1;

            if (Pos < (16*16 - bal_num))
            {
                this.pictureBox1.Invalidate();
                forPos++;
                if (forPos == 16 * 16)
                {
                    trdPos++;
                    forPos = trdPos + 1;
                }
                if(trdPos == 16*16 - 1)
                {
                    SndPos++;
                    trdPos = SndPos + 1;
                    forPos = trdPos + 1;
                }
                if (SndPos == 16 * 16 - 2)
                {
                    Pos++;
                    SndPos = Pos + 1;
                    trdPos = SndPos + 1;
                    forPos = trdPos + 1;
                }
            }

        }
    }
}
