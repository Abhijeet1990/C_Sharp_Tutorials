using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlTutorial
{
    public partial class UserControl_One : UserControl
    {
        public UserControl_One()
        {
            InitializeComponent();
        }

        public State selectedState
        {
            get
            {
                return (State)comboBox1.SelectedItem;

            }
        }

        private void UserControl_One_Load(object sender, EventArgs e)
        {
            List<State> States = new List<State>();
            States.Add(new UserControlTutorial.State() { ID = 1, Name = "TX" });
            States.Add(new UserControlTutorial.State() { ID = 2, Name = "AZ" });
            States.Add(new UserControlTutorial.State() { ID = 3, Name = "MI" });
            States.Add(new UserControlTutorial.State() { ID = 4, Name = "DE" });
            States.Add(new UserControlTutorial.State() { ID = 5, Name = "KU" });
            comboBox1.DataSource = States;
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Name";
        }
    }
}
