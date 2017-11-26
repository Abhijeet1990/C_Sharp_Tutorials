using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewExpt
{
    public partial class ConfigureInletCooling : Form
    {
        public ConfigureInletCooling(string BlockName,
            string objectAlias)
        {
            InitializeComponent();
            ObjectTypeComboBox.DataSource = Enum.GetNames(typeof(ICType)).ToList();
            label2.Text += BlockName;
            label10.Text += objectAlias;
        }
    }
}
