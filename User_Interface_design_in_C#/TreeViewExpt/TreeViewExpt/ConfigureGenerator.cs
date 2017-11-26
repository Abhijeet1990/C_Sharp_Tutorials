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
    public partial class ConfigureGenerator : Form
    {
        public ConfigureGenerator(string BlockName,
            string objectAlias)
        {

            InitializeComponent();
            ObjectTypeComboBox.DataSource = Enum.GetNames(typeof(GenType)).ToList();
            BlockAliasLabel.Text += BlockName;
            ObjectAliasLabel.Text += objectAlias;
        }
    }
}
