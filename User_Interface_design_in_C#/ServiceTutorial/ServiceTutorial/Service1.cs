using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTutorial
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        public void OnDebug()
            {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                //System.IO.File.Create(Environment.CurrentDirectory + "OnStart.txt");
                System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStart.txt");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        protected override void OnStop()
        {
            try
            {
                System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStop.txt");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
