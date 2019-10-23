using System;
using System.Collections.Generic;
using ProductApi.Interfaces;
using ProductApi.Models;
using MySql.Data.MySqlClient;

namespace ProductApi.Services
{
    public class ProductRepository : IProductRepository
    {
        private string url { get; }
        public ProductRepository()
        {
            url = "Data Source=localhost;User ID=root;Password=;Database=api_php_lumen";
        }
        public List<Product> All()
        {
            List<Product> products = new List<Product>();

            using (MySqlConnection conn = new MySqlConnection(url))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM products";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conn;
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                id = reader.GetInt32(reader.GetOrdinal("id")),
                                name = reader.GetString(reader.GetOrdinal("name")),
                                description = reader.GetString(reader.GetOrdinal("description")),
                                price = reader.GetDouble(reader.GetOrdinal("price")),
                                stock = reader.GetInt32(reader.GetOrdinal("stock")),
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return products;
        }

        public Product Find(int id)
        {
            Product product = new Product();

            using (MySqlConnection conn = new MySqlConnection(url))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM products WHERE id = @id";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = conn;
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product.id = reader.GetInt32(reader.GetOrdinal("id"));
                            product.name = reader.GetString(reader.GetOrdinal("name"));
                            product.description = reader.GetString(reader.GetOrdinal("description"));
                            product.price = reader.GetDouble(reader.GetOrdinal("price"));
                            product.stock = reader.GetInt32(reader.GetOrdinal("stock"));
                        }
                    }
                    conn.Close();
                }
            }
            return product;
        }

        public string Insert(Product item)
        {
            using (MySqlConnection conn = new MySqlConnection(url))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO products (name, description, price, stock) VALUES (@name, @description, @price, @stock)";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@name", item.name);
                    cmd.Parameters.AddWithValue("@description", item.description);
                    cmd.Parameters.AddWithValue("@price", item.price);
                    cmd.Parameters.AddWithValue("@stock", item.stock);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return "Product Saved!";
        }

        public string Update(int id, Product item)
        {
            using (MySqlConnection conn = new MySqlConnection(url))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE products name = @name, description = @description, price = @price, stock = @stock WHERE id = @id";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", item.name);
                    cmd.Parameters.AddWithValue("@description", item.description);
                    cmd.Parameters.AddWithValue("@price", item.price);
                    cmd.Parameters.AddWithValue("@stock", item.stock);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return "Product Updated!";
        }

        public string Delete(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(url))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM products WHERE id = @id";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return "Product Deleted!";
        }
    }
}
