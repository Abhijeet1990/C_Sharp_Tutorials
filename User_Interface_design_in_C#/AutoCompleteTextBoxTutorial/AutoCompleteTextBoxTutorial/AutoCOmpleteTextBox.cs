using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCompleteTextBoxTutorial
{
    public partial class AutoCOmpleteTextBox : TextBox
    {
        
        public AutoCOmpleteTextBox()
        {
            var source = new AutoCompleteStringCollection();
            source.AddRange(new string[]
                        {
                        "January",
                        "February",
                        "March",
                        "April",
                        "May",
                        "June",
                        "July",
                        "August",
                        "September",
                        "October",
                        "November",
                        "December"
                        });
            InitializeComponent();
            this.AutoCompleteCustomSource = source;
            this.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           
        }

        public AutoCOmpleteTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
