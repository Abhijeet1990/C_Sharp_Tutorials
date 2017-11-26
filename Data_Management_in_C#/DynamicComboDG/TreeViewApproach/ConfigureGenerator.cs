using System;
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
    public partial class ConfigureGenerator : Form
    {
        public ConfigureGenerator(string BlockName,
            string objectAlias)
        {

            InitializeComponent();
            ObjectTypeComboBox.DataSource = Enum.GetNames(typeof(GenType)).ToList();
            label2.Text += BlockName;
            label10.Text += objectAlias;
        }
    }
}
