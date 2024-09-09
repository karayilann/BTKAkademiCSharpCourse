using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo
{
    public partial class Form1 : Form
    {
        ProductDal _productDal = new ProductDal();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dataGridView1.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           _productDal.AddObject(new Product
           {
               Name = txtName.Text,
               UnitPrice = Convert.ToDecimal(txtPrice.Text),
               StockAmount = Convert.ToInt32(txtStock.Text)
           });
           ClearTxtBox();
           MessageBox.Show("Products Added", "Warning", MessageBoxButtons.OK);
           LoadProducts();
        }

        private void ClearTxtBox()
        {
            txtName.Text = null;
            txtPrice.Text = null;
            txtStock.Text = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtUpdateName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtUpdatePrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtUpdateAmount.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product updatedProduct = new Product()
            {
                ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Name =txtUpdateName.Text,
                UnitPrice = Convert.ToDecimal(txtUpdatePrice.Text),
                StockAmount = Convert.ToInt32(txtUpdateAmount.Text)
            };
            _productDal.UpdateProduct(updatedProduct);
            MessageBox.Show("Product Upgraded");
            LoadProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var deletedObjectValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            _productDal.DeleteProduct(deletedObjectValue);
            LoadProducts();
            MessageBox.Show("Product Deleted");
        }

    }
}
