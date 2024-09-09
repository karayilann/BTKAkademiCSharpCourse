using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Business.DependecyResolvers.Ninject;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Concrete.NHibernate;
using Northwind.Entities.Concrete;

namespace Northwind.UIOperations
{
    public partial class Products : Form
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public Products()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            #region FilterCategories 

            cmbFilterCategories.DataSource = _categoryService.GetAll();
            cmbFilterCategories.DisplayMember = "CategoryName";
            cmbFilterCategories.ValueMember = "CategoryId";

            #endregion

            #region AddProductCategories 

            cmbNewProductCategory.DataSource = _categoryService.GetAll();
            cmbNewProductCategory.DisplayMember = "CategoryName";
            cmbNewProductCategory.ValueMember = "CategoryId";

            #endregion

            #region UpdateProductCategories 

            cmbUpdateProductCategory.DataSource = _categoryService.GetAll();
            cmbUpdateProductCategory.DisplayMember = "CategoryName";
            cmbUpdateProductCategory.ValueMember = "CategoryId";

            #endregion
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAllProducts();
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource =
                    _productService.GetProductsByCategory(Convert.ToInt32(cmbFilterCategories.SelectedValue));
            }
            catch
            {
                
            }
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbxName.Text))
            {
                LoadProducts();
            }
            else
            {
                dgwProduct.DataSource = _productService.GetProductsByProductName(tbxName.Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    CategoryId = Convert.ToInt32(cmbNewProductCategory.SelectedValue),
                    ProductName = tbxNewProductName.Text,
                    QuantityPerUnit = tbxNewProductQPU.Text,
                    UnitPrice = Convert.ToDecimal(tbxNewProductPrice.Text),
                    UnitsInStock = Convert.ToInt16(tbxNewProductStock.Text)
                });

                MessageBox.Show("Product added!");
                LoadProducts();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Update(new Product
                {
                    ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                    CategoryId = Convert.ToInt32(cmbUpdateProductCategory.SelectedValue),
                    ProductName = tbxUpdateProductName.Text,
                    QuantityPerUnit = tbxUpdateProductQPU.Text,
                    UnitPrice = Convert.ToDecimal(tbxUpdateProductPrice.Text),
                    UnitsInStock = Convert.ToInt16(tbxUpdateProductStock.Text),
                });

                MessageBox.Show("Product updated!");
                ClearUpdateFields();
                LoadProducts();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        private void ClearUpdateFields()
        {
            tbxUpdateProductName.Text = "";
            cmbUpdateProductCategory.SelectedValue = "";
            tbxUpdateProductQPU.Text = "";
            tbxUpdateProductPrice.Text = "";
            tbxUpdateProductStock.Text = "";
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgwProduct.CurrentRow;
            tbxUpdateProductName.Text = row.Cells[1].Value.ToString();
            cmbUpdateProductCategory.SelectedValue = Convert.ToInt32(row.Cells[2].Value);
            tbxUpdateProductPrice.Text = row.Cells[3].Value.ToString();
            tbxUpdateProductQPU.Text = row.Cells[4].Value.ToString();
            tbxUpdateProductStock.Text = row.Cells[5].Value.ToString();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgwProduct.CurrentRow != null)
            {
                try
                {
                    _productService.Delete(new Product
                    {
                        ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)
                    });
                    MessageBox.Show("Product deleted!");
                    LoadProducts();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}
