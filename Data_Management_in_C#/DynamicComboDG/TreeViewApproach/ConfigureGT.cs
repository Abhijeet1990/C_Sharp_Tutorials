﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewApproach
{
    public partial class ConfigureGT : Form
    {
        public ConfigureGT(bool InletAirHeatingCheck,bool InletAirCoolingCheck, bool PeakFiringCheck,
            bool SteamInjectionCheck, string BlockName,
            string objectAlias)
        {
            InitializeComponent();


            ObjectTypeComboBox.DataSource= Enum.GetNames(typeof(GTType)).ToList();
            if (!InletAirHeatingCheck)
            {
                label8.Enabled = false;
                textBox7.Enabled = false;
            }
            if (!PeakFiringCheck)
            {
                label4.Enabled = false;
                textBox3.Enabled = false;
                button2.Enabled = false;
            }
            if (!SteamInjectionCheck)
            {
                label5.Enabled = false;
                textBox4.Enabled = false;
            }
            
            label2.Text += BlockName;
            label10.Text += objectAlias;


        }
    }
}
