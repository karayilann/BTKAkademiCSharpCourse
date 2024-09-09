using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwind.Business.Concrete;

namespace Northwnd.WebFormsUI
{
    public partial class Form1 : Form
    {
        private ProductManager productManager = new ProductManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgwProducts.DataSource = productManager.GetAll();
        }
    }
}
