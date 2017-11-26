using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDelegate
{
    public partial class Publisher : UserControl
    {
        //2. Define An event based on that delegate
        public event OnCheckedEventHandler Onchecked;
        public event OnCheckedEventHandler OnSelectedCBIndex;
        public event OnCheckedEventHandler OnSelectedGBCheckBox;
        public List<string> Statuses;
        public Publisher()
        {
            InitializeComponent();
        }
        //3.raise the event
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(this.Onchecked!=null)
            {
                
                this.Onchecked(this, new Data() { Text = this.textBox1.Text});
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.OnSelectedCBIndex != null)
            {

                this.OnSelectedCBIndex(this, new Data() { Text = this.comboBox1.SelectedItem.ToString() });
            }
        }

        private void Check_Click(object sender, EventArgs e)
        {
            
            foreach(var ctrl in this.groupBox1.Controls)
            {
                if(ctrl is CheckBox)
                {
                    //CheckBox control = new CheckBox(c);
                    MessageBox.Show(ctrl.ToString());
                    if (ctrl != null)
                    {
                        //control = (CheckBox)ctrl;

                        this.Statuses.Add(ctrl.ToString());
                    }
                        
                }
            }
            if(this.OnSelectedGBCheckBox!=null)
            {
                this.OnSelectedGBCheckBox(this, new TestDelegate.Data() { Statuses = this.Statuses });
            }
        }
    }


    //1.  Define A delegate
    public delegate void OnCheckedEventHandler(object o, Data args);
    public class Data:EventArgs
    {
        public string Text { get; set; }
        public List<string> Statuses { get; set; }

    }
}
