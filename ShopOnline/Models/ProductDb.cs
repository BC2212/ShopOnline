using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopOnline.Controllers
{
    public class ProductDb : BasicDb
    {
        public List<Product> GetProducts(ref string err)
        {
            List<Product> list = new List<Product>();
            SqlDataReader dataReader = data.MyExecuteReader(ref err, "Q_Product_GetProducts", CommandType.StoredProcedure, null);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    list.Add(new Product()
                    {
                        ProductID = Convert.ToInt32(dataReader["ProductID"].ToString()),
                        ProductName = dataReader["ProductName"].ToString(),
                        Vendor = dataReader["Vendor"].ToString(),
                        Quantity = Convert.ToInt32(dataReader["Quantity"].ToString())
                    });
                }
            }

            return list;
        }

        public Product GetProductByID(ref string err, int id)
        {
            SqlDataReader dataReader = data.MyExecuteReader(ref err, "Q_Product_GetProductByID", CommandType.StoredProcedure, new SqlParameter("@ProductID", id));
            Product product = null;
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    product = new Product()
                    {
                        ProductID = Convert.ToInt32(dataReader["ProductID"]),
                        ProductName = dataReader["ProductName"].ToString(),
                        Vendor = dataReader["Vendor"].ToString(),
                        Quantity = Convert.ToInt32(dataReader["Quantity"])
                    };
                }
            }

            return product;
        }

        public bool InsertUpdateProduct(ref string err, ref int rows, Product product)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProductID", product.ProductID),
                new SqlParameter("@ProductName", product.ProductName),
                new SqlParameter("@Vendor", product.Vendor),
                new SqlParameter("@Quantity", product.Quantity)
            };

            return data.MyExecuteNonQuery(ref err, ref rows, "Q_Product_InsertUpdate", CommandType.StoredProcedure, param);
        }

        public bool DeleteProduct(ref string err, ref int rows, int id)
        {
            return data.MyExecuteNonQuery(ref err, ref rows, "Q_Product_Delete", CommandType.StoredProcedure, new SqlParameter("@ProductID", id));
        }
    }
}