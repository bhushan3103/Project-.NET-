using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;
using MyShoeWorldApp.Models;
using System.Data;
using System.ComponentModel;

namespace MyShoeWorldApp.Dal
{
    public class ProductDal
    {
        private readonly string connectionString;
        List<Product> productsCollection = new List<Product>();
        public ProductDal()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyShoeWorldConStr"].ConnectionString;
        }
        public List<Product> GetAllProducts()
        {
            using (MySqlConnection CN = new MySqlConnection(connectionString))
            {
                CN.Open();
                MySqlCommand CMD = new MySqlCommand();
                CMD.Connection = CN;
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.CommandText = "GetAllProducts";
                MySqlDataReader DR = CMD.ExecuteReader();
                while (DR.Read())
                {
                    Product product = new Product()
                    {
                        ProductId = Convert.ToInt32(DR["ProductId"]),
                        ProductName = DR["ProductName"].ToString(),
                        UnitPrice = Convert.ToInt32(DR["UnitPrice"]),
                        Picture = DR["Picture"].ToString()
                    };
                    productsCollection.Add(product);
                }
                DR.Close();
                CN.Close();
            }
            return productsCollection;
        }
        public Product GetProductDetails(int productId)
        {
            using (MySqlConnection CN = new MySqlConnection(connectionString))
            {
                CN.Open();
                MySqlCommand CMD = new MySqlCommand();
                CMD.Connection = CN;
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.CommandText = "GetOneProduct";
                CMD.Parameters.AddWithValue("e_ProductID", productId);
                MySqlDataReader DR = CMD.ExecuteReader();
                DR.Read();
                Product product = new Product()
                {
                    ProductId = Convert.ToInt32(DR["ProductId"]),
                    ProductName = DR["ProductName"].ToString(),
                    UnitPrice = Convert.ToInt32(DR["UnitPrice"]),
                    Picture = DR["Picture"].ToString()
                };
                DR.Close();
                CN.Close();
                return product;
            }
        }
        public List<Product> GetCartProducts(List<Cart> cartItems)
        {
            List<Product> products = new List<Product>();
            using (MySqlConnection CN = new MySqlConnection(connectionString))
            {
                CN.Open();
                MySqlCommand CMD = new MySqlCommand();
                CMD.Connection = CN;
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.CommandText = "GetOneProduct";
                foreach (Cart cart in cartItems)
                {
                    CMD.Parameters.Clear();
                    CMD.Parameters.AddWithValue("e_ProductID", cart.ProductId);
                    MySqlDataReader DR = CMD.ExecuteReader();
                    DR.Read();
                    Product product = new Product()
                    {
                        ProductId = Convert.ToInt32(DR["ProductId"]),
                        ProductName = DR["ProductName"].ToString(),
                        UnitPrice = Convert.ToInt32(DR["UnitPrice"]),
                        Picture = DR["Picture"].ToString()
                    };
                    DR.Close();
                    products.Add(product);
                }
                CN.Close();

            }
            return products;
        }
    }
}