using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataColumnExpression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTable table = new DataTable();

            // Create the first column.
            DataColumn priceColumn = new DataColumn();
            priceColumn.DataType = System.Type.GetType("System.Decimal");
            priceColumn.ColumnName = "price";
            priceColumn.DefaultValue = 50;

            // Create the second, calculated, column.
            DataColumn taxColumn = new DataColumn();
            taxColumn.DataType = System.Type.GetType("System.Decimal");
            taxColumn.ColumnName = "tax";
            taxColumn.Expression = "price * 0.0862";

            // Create third column.
            DataColumn totalColumn = new DataColumn();
            totalColumn.DataType = System.Type.GetType("System.Decimal");
            totalColumn.ColumnName = "total";
            totalColumn.Expression = "price + tax";

            // Add columns to DataTable.
            table.Columns.Add(priceColumn);
            table.Columns.Add(taxColumn);
            table.Columns.Add(totalColumn);

            DataRow row = table.NewRow();
            table.Rows.Add(row);
            DataView view = new DataView(table);
            dataGridView1.DataSource = view;
        }
    }
}
