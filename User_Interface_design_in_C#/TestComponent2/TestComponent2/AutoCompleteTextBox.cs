using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Data;

namespace TestComponent2
{
    public enum eObjectType
    { None, Book, Display, Chart, Table, Model, Filter, HealthCheck, Variable, LayoutPanel, ModelTemplate }

    public partial class AutoCompleteTextBox : TextBox
    {
        private ToolTip _toolTip;
        private DataGridView _dataGridView;
        private ListBox _listBox;
        private System.ComponentModel.IContainer components;
        private eObjectType _objecType;
        private DataTable _requiredData;
        private DataView _dvVariableDetails = new DataView();
        private int _holdvariableID;
        public bool ArrowKeyPressed;

        public AutoCompleteTextBox()
        {
            InitializeComponent();
            this.MaxLength = 500;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._listBox = new System.Windows.Forms.ListBox();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // _listBox
            // 
            this._listBox.FormattingEnabled = true;
            this._listBox.Location = new System.Drawing.Point(0, 0);
            this._listBox.Name = "_listBox";
            this._listBox.Size = new System.Drawing.Size(120, 96);
            this._listBox.TabIndex = 0;
            this.ResumeLayout(false);

        }

        public void CreateCustomGrid(eObjectType objectType)
        {
            _objecType = objectType;
            _dataGridView = new DataGridView();
            //_requiredData = new DataTable();

            if (_objecType == eObjectType.ModelTemplate)
            {
                _dataGridView.Columns.Add("Name", "Name");
                _dataGridView.Columns.Add("Description", "Description");

            }
            else
            {
                _dataGridView.Columns.Add("Unit", "Unit");
                _dataGridView.Columns.Add("Name", "Name");
                _dataGridView.Columns.Add("Tag", "Tag");
            }

            _dataGridView.AutoGenerateColumns = false;
            _dataGridView.AllowUserToAddRows = false;
            _dataGridView.AllowUserToDeleteRows = false;
            _dataGridView.AllowUserToOrderColumns = false;
            _dataGridView.AllowUserToResizeRows = false;
            _dataGridView.MultiSelect = false;
            _dataGridView.RowHeadersVisible = false;
            _dataGridView.ReadOnly = true;

            _dataGridView.BackgroundColor = Color.White;
            _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dataGridView.VirtualMode = true;

            _dataGridView.CellValueNeeded += OnDataGridViewCellValueNeeded;
            this.PreviewKeyDown += OnEditCellPreviewKeyDown;
            _dataGridView.DoubleClick += OnDataGridViewDoubleClick;

            _dataGridView.MinimumSize = new Size(150, 100);
            _dataGridView.Width = 400;
            _dataGridView.Height = 125;

            ResetGridView();
            this.MaxLength = 500;

            this.KeyUp -= OnEditCellKeyUp;
            this.KeyUp += OnEditCellKeyUp;

            this.Disposed += OnCustomDataGridViewTextBoxEditingControlDisposed;
        }


        #region DataGridCreatingandBinding
        public DataTable GridViewData
        {
            get
            {
                return _requiredData;
            }
            set
            {
                _requiredData = value;
            }
        }
        private void OnDataGridViewCellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            e.Value = Convert.ToString(_dvVariableDetails[e.RowIndex][e.ColumnIndex]);
        }

        private void OnEditCellPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    {
                        InsertVariableInTextBox();
                        break;
                    }
                case Keys.Down:
                    {
                        if ((_dataGridView.Visible) && (_dataGridView.SelectedRows[0].Index < _dataGridView.Rows.Count - 1))
                        {
                            int i = _dataGridView.SelectedRows[0].Index + 1;
                            _dataGridView.Rows[i].Selected = true;
                            _dataGridView.CurrentCell = _dataGridView.Rows[i].Cells[0];
                        }
                        ArrowKeyPressed = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if ((_dataGridView.Visible) && (_dataGridView.SelectedRows[0].Index > 0))
                        {
                            int i = _dataGridView.SelectedRows[0].Index - 1;
                            _dataGridView.Rows[i].Selected = true;
                            _dataGridView.CurrentCell = _dataGridView.Rows[i].Cells[0];
                        }

                        ArrowKeyPressed = true;
                        break;
                    }
                case Keys.Enter:
                    {
                        InsertVariableInTextBox();
                        break;
                    }
                case Keys.Escape:
                    {
                        _dataGridView.Visible = false;
                        ArrowKeyPressed = false;
                        break;
                    }
            }
        }

        private void OnDataGridViewDoubleClick(object sender, EventArgs e)
        {
            InsertVariableInTextBox();
        }

        private void ResetGridView()
        {
            _dataGridView.Visible = false;
        }

        private void OnEditCellKeyUp(object sender, KeyEventArgs e)
        {
            if (ArrowKeyPressed || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) return;

            UpdateGridBox(((TextBox)sender).Text);
        }

        private void OnCustomDataGridViewTextBoxEditingControlDisposed(object sender, EventArgs e)
        {
            _dataGridView.Visible = false;
        }

        private void InsertVariableInTextBox()
        {
            if (_dataGridView.SelectedRows != null && _dataGridView.Visible)
            {
                string variableName = _objecType != eObjectType.ModelTemplate ? (Convert.ToString(_dataGridView.SelectedRows[0].Cells["Unit"].Value) + " " + Convert.ToString(_dataGridView.SelectedRows[0].Cells["Name"].Value)) : Convert.ToString(_dataGridView.SelectedRows[0].Cells["Name"].Value);
                //Getting parent form
                Form1 form = this.Parent as Form1;

                if (form != null)
                {
                    if (_dataGridView.SelectedRows[0].Cells["VariableID"] != null)
                    {
                        _holdvariableID = form._variableID = Convert.ToInt32(_dataGridView.SelectedRows[0].Cells["VariableID"].Value);
                    }
                    form._IsAutoCompleteTextBox = true;
                    form.PopulateVariableNameTextBox();
                }
                ResetGridView();
            }
            ArrowKeyPressed = false;
        }
    }
}
