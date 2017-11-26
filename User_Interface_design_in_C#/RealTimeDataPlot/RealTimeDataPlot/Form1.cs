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
using System.Diagnostics;

namespace RealTimeDataPlot
{
    public partial class Form1 : Form
    {
        private Thread cpuThread;
        private Thread ramThread;
        private Thread networkThread;
        private double[] cpuArray = new double[60];
        private double[] ramArray = new double[60];
        private double[] networkArray = new double[60];
        public Form1()
        {
            InitializeComponent();
            string[] networkInterface = this.printNetworkCards();
            for (int i = 0; i < networkInterface.Length; i++)
            {
                comboBox1.Items.Add(networkInterface[i]);
            }
        }
        private void getPerformanceCounter()
        {
            var cpuPerfCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

            while(true)
            {
                cpuArray[cpuArray.Length - 1] = Math.Round(cpuPerfCounter.NextValue(), 0);
                Array.Copy(cpuArray, 1, cpuArray, 0, cpuArray.Length - 1);
                if(cpuChart.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdateCpuChart(); });
                }
                else
                {
                    //......
                }
                Thread.Sleep(1000);
            }
        }


        private void getMemoryCounter()
        {
            var ramCounter = new PerformanceCounter("Memory", "Available Bytes");

            while (true)
            {
                ramArray[ramArray.Length - 1] = Math.Round(ramCounter.NextValue(), 0);
                Array.Copy(ramArray, 1, ramArray, 0, ramArray.Length - 1);
                if (ramChart.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdateRamChart(); });
                }
                else
                {
                    //......
                }
                Thread.Sleep(1000);
            }
        }

        private void getNetworkCounter(object networkCard)
        {
            PerformanceCounter bandwidthCounter = new PerformanceCounter("Network Interface", "Current Bandwidth", networkCard.ToString());
            while(true)
            {
                networkArray[networkArray.Length - 1] = Math.Round(bandwidthCounter.NextValue(), 0);
                Array.Copy(networkArray, 1, networkArray, 0, networkArray.Length - 1);
                if (networkChart.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdateNetworkChart(); });
                }
                else
                {
                    //......
                }
                Thread.Sleep(1000);
            }
        }
        private void UpdateCpuChart()
        {
            cpuChart.Series["Series1"].Points.Clear();
            for (int i = 0; i < cpuArray.Length-1; i++)
            {
                cpuChart.Series["Series1"].Points.AddY(cpuArray[i]);
            }
        }

        private void UpdateRamChart()
        {
            ramChart.Series["Series1"].Points.Clear();
            for (int i = 0; i < ramArray.Length - 1; i++)
            {
                ramChart.Series["Series1"].Points.AddY(ramArray[i]);
            }
        }

        private void UpdateNetworkChart()
        {
            networkChart.Series["Series1"].Points.Clear();
            for (int i = 0; i < networkArray.Length - 1; i++)
            {
                networkChart.Series["Series1"].Points.AddY(networkArray[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cpuThread = new Thread(new ThreadStart(this.getPerformanceCounter));
            cpuThread.IsBackground = true;
            cpuThread.Start();
            ramThread = new Thread(new ThreadStart(this.getMemoryCounter));
            ramThread.IsBackground = true;
            ramThread.Start();
            networkThread = new Thread(new ParameterizedThreadStart(this.getNetworkCounter));
            networkThread.IsBackground = true;
            networkThread.Start(comboBox1.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ramThread = new Thread(new ThreadStart(this.getMemoryCounter));
            //ramThread.IsBackground = true;
            //ramThread.Start();
        }

        public string[] printNetworkCards()
        {
            PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");
            String[] instancename = category.GetInstanceNames();
            return instancename;
        }
    }
}
