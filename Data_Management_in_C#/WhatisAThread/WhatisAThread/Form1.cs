using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatisAThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //start the progress bar
            progressBar1.Style = ProgressBarStyle.Marquee;

            //set the name without threads
            //SetName();

            ///Set the name of the new thread
            Thread t = new Thread(SetName);
            t.Start();
        }

        public void SetName()
        {
            string name = "Abhijeet";
            System.Threading.Thread.Sleep(5000);
            this.Invoke(new Action<string>(setLabel), name);
        }
        private void setLabel(string name)
        {
            label1.Text = name;
            progressBar1.Style = ProgressBarStyle.Blocks;
        }
    }
}
