﻿using EasyGroceries.Product.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGroceries.Product.Application.Contracts.Services
{
    public interface IProductService
    {
        Task<List<ProductInfoDto>> GetProductList();
        Task<ProductInfoDto> GetProductDetails(int id);
    }
}
