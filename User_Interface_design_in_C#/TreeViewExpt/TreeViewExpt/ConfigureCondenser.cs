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
    public partial class ConfigureCondenser : Form
    {
        public ConfigureCondenser(string BlockName,
            string objectAlias)
        {
            InitializeComponent();
            ObjectTypeComboBox.DataSource = Enum.GetNames(typeof(CondenserType)).ToList();
            BlockAliasLabel.Text += BlockName;
            ObjectAliasLabel.Text += objectAlias;
        }
    }
}
