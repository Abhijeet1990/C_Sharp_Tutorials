using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestComponent2
{
    public partial class Form1 : Form
    {
        public int _variableID;
        internal bool _IsAutoCompleteTextBox;
        internal eObjectType _objecType;
        private readonly StoredProcedureCalls _sp = new StoredProcedureCalls();
        public Form1()
        {
            InitializeComponent();
        }

        internal void PopulateVariableNameTextBox()
        {
            DataSet dsTemp = null;

            dsTemp = _objecType == eObjectType.ModelTemplate ? _sp.GetVariableMasterList(_variableID) : (_variableListByUnit ?? _sp.GetVariableListByBlock(0));

            if (null == dsTemp || dsTemp.Tables[0].Rows.Count == 0) return;

            DataTable variableListDataTable = Utilities.GetVariableListDataTable(dsTemp, _variableID, _objecType);
            if (variableListDataTable.Rows.Count == 0) return;

            autoCompleteVariableTextBox.Text = _objecType != eObjectType.ModelTemplate ? Convert.ToString(variableListDataTable.Rows[0]["Unit"]) + " " +
                Convert.ToString(variableListDataTable.Rows[0]["Name"]) : dsTemp.Tables[0].Rows[0]["Name"].ToString();


            modified = true;
        }
    }
}
