using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinTodo.Model;
using WinTodo.Helper;
using System.IO;

namespace WinTodo
{
    public partial class Form1 : Form
    {
        FirebaseHelper firebaseHelper;
        List<RowInfo> d;
        List<RowInfo> w;
        List<RowInfo> m;
        int ma, mb;
        public Form1()
        {
            InitializeComponent();
            firebaseHelper = new FirebaseHelper();
            string dpath = Application.StartupPath + "\\today.txt";
            string wpath = Application.StartupPath + "\\week.txt";
            string mpath = Application.StartupPath + "\\month.txt";
            string lpath = Application.StartupPath + "\\location.txt";
            if (!File.Exists(dpath))
            {
                File.Create(dpath);
            }
            if (!File.Exists(wpath))
            {
                File.Create(wpath);
            }
            if (!File.Exists(mpath))
            {
                File.Create(mpath);
            }
            if (!File.Exists(lpath))
            {
                File.Create(lpath);
                Delay(1000);
                firebaseHelper.loc(0, 0);
            }
            Delay(1000);
            int a = firebaseHelper.locx();
            int b = firebaseHelper.locy();

            Location = new Point(a, b);
            dset();
            wset();
            mset();
            Thread thread = new Thread(() => Delay(100));
            thread.Start();
        }
        public void cl()
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                // Turn on WS_EX_TOOLWINDOW style bit
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }
        void dset()
        {
            d = firebaseHelper.Geta("today");
            dataGridView1.DataSource = d.ToList();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersVisible = false;
        }
        void wset()
        {
            w = firebaseHelper.Geta("week");
            dataGridView2.DataSource = w.ToList();
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersVisible = false;
            cl();
        }
        void mset()
        {
            m = firebaseHelper.Geta("month");
            dataGridView3.DataSource = m.ToList();
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.ColumnHeadersVisible = false;
            cl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            d.RemoveAt(e.RowIndex);
            dataGridView1.DataSource = d.ToList();
            d = firebaseHelper.Dela("today", d);
            cl();
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            w.RemoveAt(e.RowIndex);
            dataGridView2.DataSource = w.ToList();
            w = firebaseHelper.Dela("week", w);
            cl();
        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            m.RemoveAt(e.RowIndex);
            dataGridView3.DataSource = m.ToList();
            m = firebaseHelper.Dela("month", m);
            cl();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RowInfo k = new RowInfo { Text = textBox1.Text };
                textBox1.Text = "";
                d.Add(k);
                dataGridView1.DataSource = d.ToList();
                d = firebaseHelper.Newa("today", k.Text);
                cl();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RowInfo k = new RowInfo { Text = textBox2.Text };
                textBox2.Text = "";
                w.Add(k);
                dataGridView2.DataSource = w.ToList();
                w = firebaseHelper.Newa("week", k.Text);
                cl();
            }

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RowInfo k = new RowInfo { Text = textBox3.Text };
                textBox3.Text = "";
                m.Add(k);
                dataGridView3.DataSource = m.ToList();
                m = firebaseHelper.Newa("month", k.Text);
                cl();
            }
        }
        public DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);
            while (AfterWards >= ThisMoment)
            {
                Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            cl();
            return DateTime.Now;
        }
        public void music()
        {
            //Console.Beep(262, 400);

            //Console.Beep(440, 500);
            //Console.Beep(440, 500);
            //Console.Beep(440, 500);
            //Console.Beep(349, 350);
            //Console.Beep(523, 150);
            //Console.Beep(440, 500);
            //Console.Beep(349, 350);
            //Console.Beep(523, 150);
            //Console.Beep(440, 1000);
            //Console.Beep(659, 500);
            //Console.Beep(659, 500);
            //Console.Beep(659, 500);
            //Console.Beep(698, 350);
            //Console.Beep(523, 150);
            //Console.Beep(415, 500);
            //Console.Beep(349, 350);
            //Console.Beep(523, 150);
            //Console.Beep(440, 1000);

            //Console.Beep(523, 400);
            //Console.Beep(587, 400);
            //Console.Beep(659, 800);
            //Console.Beep(587, 200);
            //Console.Beep(659, 800);
            //Console.Beep(784, 200);
            //Console.Beep(659, 800);
            //Console.Beep(587, 200);
            //Console.Beep(494, 400);
            //Console.Beep(392, 400);
            //Console.Beep(440, 400);
            //Console.Beep(523, 400);
            //Console.Beep(587, 400);
            //Console.Beep(659, 400);
            //Console.Beep(659, 800);

            //Console.Beep(262, 100);
            //Console.Beep(294, 100);
            //Console.Beep(330, 100);
            //Console.Beep(349, 100);
            //Console.Beep(392, 100);
            //Console.Beep(440, 100);
            //Console.Beep(494, 100);
            //Console.Beep(523, 100); //
            //Console.Beep(587, 100);
            //Console.Beep(659, 100);
            //Console.Beep(698, 100);
            //Console.Beep(784, 100);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ma = e.X;
                mb = e.Y;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point(Location.X + (e.X - ma), Location.Y + (e.Y - mb));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            firebaseHelper.loc(Location.X, Location.Y);
        }
    }
}
