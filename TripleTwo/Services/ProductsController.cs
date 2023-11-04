using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TripleTwo.BAL;
using TripleTwo.Code;
using TripleTwo.Entities;

namespace TripleTwo.Services
{
    public class ProductsController : ApiController
    {
        ProductManager objim = new ProductManager();
        [Route("api/GetProductsList")]
        [HttpPost]
        public List<GetProductsListResponse> GetProductsList(GetProductsListParam p)
        {
            try
            {
                return objim.GetItemsList(p);
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "ProductController", "GetProductsList - Services");
                return new List<GetProductsListResponse>();
            }
        }

        [Route("api/GetProductDetailById")]
        [HttpGet]
        public GetProductDetailsResponse GetProductDetailById(Int32 ProductId)
        {
            try
            {
                GetProductDetailsResponse res = new GetProductDetailsResponse();

                res=objim.GetProductDetailById(ProductId);

                List<ProductImage> productImage = new List<ProductImage>();
                productImage= objim.GetProductImagesById(ProductId);
                res.ProductImages = productImage;
                return res;
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "ProductController", "GetProductDetailById - Services");
                return new GetProductDetailsResponse();
            }
       
        }

        [Route("api/AddRemoveCartItems")]
        [HttpPost]
        public AddRemoveCartItemsResponse AddRemoveCartItems(AddRemoveCartItemsParams p)
        {
            try
            {
                return objim.AddRemoveCartItems(p);
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "Items", "AddRemoveCartItems-Services");
                return new AddRemoveCartItemsResponse { ResultID = 0, ResultMessage = Settings.BaseErrorMessage };
            }
        }

        [HttpPost]
        public RemoveItemCartResponse RemoveItemCart(RemoveItemCartParams p)
        {
            try
            {
                return objim.RemoveItemCart(p);
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "Items", "RemoveItemCart-Services");
                return new RemoveItemCartResponse { ResultID = 0, ResultMessage = Settings.BaseErrorMessage };
            }
        }
        [Route("api/GetCart")]
        [HttpPost]
        public List<GetCustomerItemCartResponse> GetCustomerCart(GetCustomerItemCartParams p)
        {
            try
            {
                return objim.GetCustomerItemCart(p);
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "Items", "GetCustomerCart-Services");
                return new List<GetCustomerItemCartResponse>();
            }
        }


    }
}