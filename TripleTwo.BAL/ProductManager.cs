using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTwo.DAL;
using TripleTwo.Entities;

namespace TripleTwo.BAL
{
    public class ProductManager
    {
        ProductData objid = new ProductData();
        public List<GetProductsListResponse> GetItemsList(GetProductsListParam p)
        {
            return objid.GetItemsList(p);
        }

        public GetProductDetailsResponse GetProductDetailById(int ProductId)
        {
            return objid.GetProductDetailById(ProductId);
        }

        public List<ProductImage> GetProductImagesById(int productId)
        {
            return objid.GetProductImagesById(productId);
        }

        public AddRemoveCartItemsResponse AddRemoveCartItems(AddRemoveCartItemsParams p)
        {
            return objid.AddRemoveCartItems(p);
        }

        public RemoveItemCartResponse RemoveItemCart(RemoveItemCartParams p)
        {
            return objid.RemoveItemCart(p);
        }

        public List<GetCustomerItemCartResponse> GetCustomerItemCart(GetCustomerItemCartParams p)
        {
            return objid.GetCustomerItemCart(p);
        }
    }
}
