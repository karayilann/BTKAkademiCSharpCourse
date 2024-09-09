using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAcces.Concrete.EntitiyFramework;
using Northwind.DataAcces.Concrete.NHibernate;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
        }

        private IProductService _productService;

        private void Form1_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = _productService.GetAll();
            MessageBox.Show("Products are listed.");

        }
    }
}
