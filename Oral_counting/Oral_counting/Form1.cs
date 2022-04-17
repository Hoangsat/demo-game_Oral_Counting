using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oral_counting
{
    public partial class Form1 : Form
    {
        int count;
        int min = 1;
        int max = 10;
        int count_max = 3;
        Random rnd = new Random();
        string answer;
        public Form1()
        {
            
            InitializeComponent();
            start();
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            start();
        }
        private void start()
        {
            progress.Visible = true;
            progress.Minimum = 0;
            progress.Maximum = count_max;
            progress.Value = 0;
            button_plus.Enabled = false;
            count = 0;
            think();
        }
        private void think()
        {
            
            int a, b;
            a = rnd.Next(min, max + 1);
            b = rnd.Next(min, max + 1);
            label_think.Text = a.ToString() + " + " + b.ToString() + " = ";
            answer = (a + b).ToString();
            count++;
        }

        private void text_answer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (text_answer.Text == answer)
                {
                    
                    progress.Value = count;
                    if (count == count_max)
                    {
                        gamewin();
                        return;
                    }
                    else
                    {
                        text_answer.Text = "";
                        think();
                    }
                }
                else
                {
                    gameover();
                }
            }
        }
        private void gameover()
        {
            text_answer.Text = answer;
            done();
        }
        private void gamewin()
        {
            MessageBox.Show("WIN!!");
            done();
        }
        private void done()
        {
            button_plus.Enabled = true;
            progress.Visible = false;
            label_think.Enabled = false;
            text_answer.Enabled = false;
            button_plus.Focus();
        }
    }
}
