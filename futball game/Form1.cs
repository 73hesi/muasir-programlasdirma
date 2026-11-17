using System;
using System.Drawing;
using System.Windows.Forms;

namespace futball_game
{
    public partial class Form1 : Form
    {
        int suretX = 5;
        int suretY = 5;
        Random rnd = new Random();
        System.Windows.Forms.Timer oyunTimer;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.DoubleBuffered = true;
            this.Text = "Top Oyunu";
            //button1.Visible = false;
            button2.Visible = false;

            this.ActiveControl = null;      

           

            oyunTimer = new System.Windows.Forms.Timer();
            oyunTimer.Interval = 20;
            oyunTimer.Tick += timer1_Tick;
            oyunTimer.Start();
        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left && panel1.Left > 0)
            {
                panel1.Left -= 25;
            }
            else if (e.KeyCode == Keys.Right && panel1.Right < this.ClientSize.Width)
            {
                panel1.Left += 25;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left += suretX;
            pictureBox1.Top += suretY;


            if (pictureBox1.Left <= 0 || pictureBox1.Right >= this.ClientSize.Width)
            {
                suretX = -suretX;
            }


            if (pictureBox1.Top <= 0)
            {
                suretY = Math.Abs(suretY);
            }


            if (pictureBox1.Bounds.IntersectsWith(panel1.Bounds) && suretY > 0)
            {
                suretY = -Math.Abs(suretY);

               
                suretY -= 1;

                suretX = rnd.Next(-8, 9);
                if (suretX == 0) suretX = 5;

               
                if (suretX > 0)
                    suretX += 1;
                else
                    suretX -= 1;
            }


            

            if (pictureBox1.Top > panel1.Bottom)
            {
                oyunTimer.Stop();
                MessageBox.Show("Oyun Bitdi!\nTopu tuta bilmədiniz.", "Game Over");

                button1.Visible = true;
                button2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("cixilsin?", "Təsdiq",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = 30;
            pictureBox1.Left = rnd.Next(50, this.ClientSize.Width - 100);

            
            suretX = 5;
            suretY = 5;

           
            oyunTimer.Start();
        }
        // klaviaturanin fokuslanmasinda problem yasayirdim, hell ede bilmedim. ona gore bu hisseni aiden aldim.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                if (panel1.Left > 0)
                    panel1.Left -= 25;
                return true;
            }
            else if (keyData == Keys.Right)
            {
                if (panel1.Right < this.ClientSize.Width)
                    panel1.Left += 25;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
