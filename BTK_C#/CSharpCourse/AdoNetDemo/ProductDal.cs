using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo
{
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;initial catalog=ETrade;Integrated Security=True;");

        private void ControlConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        #region DataTable (Not Recommend)
        //public DataTable GetAll()
        //{
        //    SqlConnection _connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;initial catalog=ETrade;Integrated Security=True;");

        //    if (_connection.State == ConnectionState.Closed)
        //    {
        //        _connection.Open();
        //    }

        //    SqlCommand selectCommand = new SqlCommand("Select * from Products", _connection);

        //    SqlDataReader reader = selectCommand.ExecuteReader();

        //    DataTable dt = new DataTable();

        //    dt.Load(reader);

        //    reader.Close();
        //    _connection.Close();

        //    return dt;

        //} 
        #endregion

        #region Get Data With Lists
        public List<Product> GetAll()
        {

            ControlConnection();

            SqlCommand selectCommand = new SqlCommand("Select * from Products", _connection);

            SqlDataReader reader = selectCommand.ExecuteReader();

            List<Product> productsList = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product
                {
                    ID = Convert.ToInt32(reader[0]),
                    Name = reader[1].ToString(),
                    UnitPrice = Convert.ToDecimal(reader[2]),
                    StockAmount = Convert.ToInt32(reader[3])
                };
                productsList.Add(product);

            }

            reader.Close();
            _connection.Close();

            return productsList;

        }
        #endregion

        #region Add New Product
        public void AddObject(Product product)
        {
            ControlConnection();
            SqlCommand addCommand = new SqlCommand
                ("Insert into Products values(@name,@unitPrice,@stockAmount)", _connection);

            addCommand.Parameters.AddWithValue("@name", product.Name);
            addCommand.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            addCommand.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            addCommand.ExecuteNonQuery();
            _connection.Close();

        }
        #endregion

        #region Update Products
        public void UpdateProduct(Product product)
        {
            ControlConnection();
            SqlCommand updateCommand = new SqlCommand
            (
                    "Update Products set " +
                    "Name = @name, " +
                    "UnitPrice = @unitPrice," +
                    "StockAmount = @stockAmount " +
                    "where ID = @id",
                    _connection
            );
            updateCommand.Parameters.AddWithValue("@name", product.Name);
            updateCommand.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            updateCommand.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            updateCommand.Parameters.AddWithValue("@id", product.ID);
            updateCommand.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion

        #region Delete Product
        public void DeleteProduct(int ID)
        {
            ControlConnection();

            SqlCommand deleteCommand = new SqlCommand("Delete from Products where Id = @id", _connection);

            deleteCommand.Parameters.AddWithValue("@id", ID);
            deleteCommand.ExecuteNonQuery();
            _connection.Close();

        } 
        #endregion

    }
}
