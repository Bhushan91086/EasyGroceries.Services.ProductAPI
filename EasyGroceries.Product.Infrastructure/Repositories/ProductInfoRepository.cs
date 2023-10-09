using EasyGroceries.Product.Application.Contracts.Infrastructure;
using EasyGroceries.Product.Domain;
using Microsoft.Extensions.Configuration;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EasyGroceries.Product.Infrastructure.Repositories
{
    public class ProductInfoRepository : IProductInfoRepository
    {
        private readonly IConfiguration _configuration;
        public ProductInfoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IReadOnlyList<ProductInfo>> GetAllProductsInfo()
        {
            var sql = "SELECT * FROM ProductInfo";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ProductInfo>(sql);
                return result.ToList();
            }
        }

        public async Task<ProductInfo> GetProductInfoById(int id)
        {
            var sql = "SELECT * FROM ProductInfo WHERE ProductId = @id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<ProductInfo>(sql, new { id });
                return result;
            }
        }


        //    private static List<ProductInfo> productInfoList = new List<ProductInfo>
        //    {
        //        new ProductInfo(){ ProductId = 1, Name = "Parle G", Category = "Bakery Product", Description = "Tasty Biscuits", Price = 10},
        //        new ProductInfo(){ ProductId = 2, Name = "Gokul Milk", Category = "Dairy Product", Description = "Buffelo Milk", Price = 70},
        //        new ProductInfo(){ ProductId = 3, Name = "Tomato", Category = "Vegitable", Description = "Fresh", Price = 20},
        //        new ProductInfo(){ ProductId = 4, Name = "Dove Soap", Category = "Cosmetic", Description = "Soft Skin", Price = 45},
        //        new ProductInfo(){ ProductId = 5, Name = "Crocin", Category = "Medicine", Description = "For fever", Price = 30},
        //    };

        //    public async Task<ProductInfo> GetProductInfoById(int id)
        //    {
        //        var product = productInfoList.FirstOrDefault(x => x.ProductId == id);
        //        if (product != null)
        //        {
        //            return product;
        //        }

        //        return null;
        //    }

        //    public async Task<IReadOnlyList<ProductInfo>> GetAllProductsInfo()
        //    {
        //        return productInfoList;
        //    }
    }
}
