using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntitiyFrameworkDemo
{
    public partial class Form1 : Form
    {
        private ProductDal _productDal = new ProductDal();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //// Eğer using kullanmazsak Garbage Collector silene kadar kalmaya devam edecek bu işlem bittikten sonra Dispose etmesini sağlıyoruz.
            //using (ETradeContext context = new ETradeContext())
            //{
            //    // Veritabanına erişme methodunu kullanmak için App.config içinde ETradeContext adı ile açılan connection stringe erişim sağlar.
            //    dataGridView1.DataSource = context.Products.ToList();
            //}

            LoadProducts();
        }

        /// <summary>
        /// Databaseden gelen verileri tabloya yansıtır.
        /// </summary>
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

            LoadProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productDal.DeleteObject(new Product
            {
                ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.UpdateObject(new Product
            {
                ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Name = txtUpdateName.Text,
                UnitPrice = Convert.ToDecimal(txtUpdatePrice.Text),
                StockAmount = Convert.ToInt32(txtUpdateAmount.Text)
            });
            LoadProducts();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtUpdateName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtUpdatePrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtUpdateAmount.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //SearchProducts(txtSearch.Text);
            dataGridView1.DataSource = _productDal.GetByName(txtSearch.Text);
        }

        // Bu yöntemde productlar listelenir ve ardından sorgu yapılır yeniden koleksiyona alınır. Bu işlem memory kaybına yol açabilir.
        // Ayrıca büyük küçük harf duyarlılığı da vardır.
        private void SearchProducts(string key)
        {
            // Bu aşağıdaki p=>p.Name methoduna LINQ olarak adlandırılır.
            var result = _productDal.GetAll().Where(n => n.Name.Contains(key)).ToList();
            dataGridView1.DataSource = result;
        }

    }
}
