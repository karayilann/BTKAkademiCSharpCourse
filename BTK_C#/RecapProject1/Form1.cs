using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecapProject1
{
    public partial class ProductsForm : Form
    {
        private ProductDal productDal = new ProductDal();

        public ProductsForm()
        {
            InitializeComponent();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            GetProducts();
            ListCategories();
        }

        private void GetProducts()
        {
            dgwProduct.DataSource = productDal.GetAllProducts();
        }

        private void ListCategories()
        {
            cbxCategories.DataSource = productDal.GetCategories();
            cbxCategories.DisplayMember = "CategoryName";
            cbxCategories.ValueMember = "CategoryId";
        }

        private void cbxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = productDal.GetProductsByCategories((int)cbxCategories.SelectedValue);
            }
            catch
            {
                
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        { 
            
           //if (string.IsNullOrEmpty(txtName.Text)) return;
           if(txtName.Text ==null) return;
           dgwProduct.DataSource = productDal.GetProductsByName(txtName.Text);
        }
    }
}
