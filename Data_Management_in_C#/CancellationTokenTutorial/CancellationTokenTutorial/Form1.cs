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

namespace CancellationTokenTutorial
{
    public partial class Form1 : Form
    {
        static CancellationTokenSource tokenSource;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            tokenSource = new CancellationTokenSource();
            CancellationToken ct = tokenSource.Token;
            button1.Visible = false;
            try
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 30;
                //ct.ThrowIfCancellationRequested();
                await LongRunningOperation(ct);
                //Thread.Sleep(1000000);
            }
            catch (OperationCanceledException ex)
            {
                MessageBox.Show(ex.Message, "Canceled");
            }

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "message");

            //}
            finally
            {
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.MarqueeAnimationSpeed = 0;
                button1.Visible = true;
            }

        }

       
        private static async Task<string> LongRunningOperation(CancellationToken token)
        {
            int counter=0;
            //token.ThrowIfCancellationRequested();
           await Task.Run(async ()=>
            {
                try
                {
                    for (counter = 0; counter < 500; counter++)
                    {
                        Thread.Sleep(500);
                        await Task.Run(async ()=> 
                        {
                            await Task.Delay(500);
                            if (token.IsCancellationRequested)
                            {

                                token.ThrowIfCancellationRequested();

                            }


                        },token);
                        //if (token.IsCancellationRequested)
                        //{

                        //    token.ThrowIfCancellationRequested();

                        //}


                    }
                }
                catch (OperationCanceledException ex)
                {
                    MessageBox.Show(ex.Message, "Cancelled");

                }

            },token);
            return "Counter = " + counter;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
            button2.Visible = false;
        }
    }
}
