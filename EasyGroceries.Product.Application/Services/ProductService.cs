using EasyGroceries.Product.Application.Contracts.Services;
using EasyGroceries.Product.Application.DTOs;
using EasyGroceries.Product.Application.Features.ProductInfo.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGroceries.Product.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ProductInfoDto> GetProductDetails(int id)
        {
            var productInfo = await _mediator.Send(new GetProductInfoRequest() { Id = id });
            return productInfo;
        }

        public async Task<List<ProductInfoDto>> GetProductList()
        {
            var productInfos = await _mediator.Send(new GetProductInfoListRequest());
            return productInfos;
        }
    }
}
