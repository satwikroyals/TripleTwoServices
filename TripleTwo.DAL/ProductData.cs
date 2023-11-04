using Dapper;
using DbFactory.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTwo.Entities;


namespace TripleTwo.DAL
{
    public class ProductData
    {
        public List<GetProductsListResponse> GetItemsList(GetProductsListParam p)
        {
            try
            {
                DapperRepositry<GetProductsListResponse> _repo = new DapperRepositry<GetProductsListResponse>(Settings.ProviederName, Settings.DbConnection);
                DynamicParameters param = new DynamicParameters();
                param.Add("@SearchStr", p.str, DbType.String, ParameterDirection.Input);
                param.Add("@PageIndex", p.pgindex, DbType.Int16, ParameterDirection.Input);
                param.Add("@PageSize", p.pgsize, DbType.Int16, ParameterDirection.Input);
                param.Add("@ProductId", p.ProductId, DbType.Int32, ParameterDirection.Input);
                return _repo.GetList("GetProducts", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductImage> GetProductImagesById(int productId)
        {
            DapperRepositry<ProductImage> _repo = new DapperRepositry<ProductImage>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
           
            param.Add("@ProductId", productId, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetProductImagesById", param);
        }

        public GetProductDetailsResponse GetProductDetailById(int productId)
        {
            DapperRepositry<GetProductDetailsResponse> _repo = new DapperRepositry<GetProductDetailsResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@productId", productId, DbType.Int32, ParameterDirection.Input);
            return _repo.GetResult("GetProductDetailById", param);
        }

        public AddRemoveCartItemsResponse AddRemoveCartItems(AddRemoveCartItemsParams p)
        {
            DapperRepositry<AddRemoveCartItemsResponse> _repo = new DapperRepositry<AddRemoveCartItemsResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CartProductID", p.CartProductID, DbType.Int64, ParameterDirection.Input);
            param.Add("@CartID", p.CartID, DbType.Int64, ParameterDirection.Input);
            param.Add("@ProductId", p.ProductId, DbType.Int64, ParameterDirection.Input);
            param.Add("@CustomerID", p.CustomerID, DbType.Int64, ParameterDirection.Input);
            param.Add("@Qty", p.Qty, DbType.Int32, ParameterDirection.Input);
            param.Add("@Action", p.Action, DbType.Int32, ParameterDirection.Input);
            return _repo.GetResult("AddRemoveCartProducts", param);
        }

        public RemoveItemCartResponse RemoveItemCart(RemoveItemCartParams p)
        {
            DapperRepositry<RemoveItemCartResponse> _repo = new DapperRepositry<RemoveItemCartResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CartID", p.CartID, DbType.Int64, ParameterDirection.Input);
            param.Add("@OutletID", p.OutletID, DbType.Int64, ParameterDirection.Input);
            return _repo.GetResult("RemoveItemCart", param);
        }

        public List<GetCustomerItemCartResponse> GetCustomerItemCart(GetCustomerItemCartParams p)
        {
            DapperRepositry<dynamic> _repo = new DapperRepositry<dynamic>(Settings.ProviederName, Settings.DbConnection);
            List<GetCustomerItemCartResponse> cart = new List<GetCustomerItemCartResponse>();
            List<GetCustomerCartItemsEntity> cartitems = new List<GetCustomerCartItemsEntity>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerID", p.CustomerID, DbType.Int64, ParameterDirection.Input);
            SqlConnection s = new SqlConnection(Settings.DbConnection.ToString());
            using (IDbConnection db = (IDbConnection) s)
            {
                var result = db.QueryMultiple("GetCustomerProductCart", commandType: CommandType.StoredProcedure, param: param);
                cart = result.Read<GetCustomerItemCartResponse>().ToList();
                cartitems = result.Read<GetCustomerCartItemsEntity>().ToList();
                if (cartitems != null)
                {
                    foreach (GetCustomerCartItemsEntity ci in cartitems)
                    {
                        ci.TotalItemPrice = Settings.CalculateCartItemTotalPrice(new Settings.CalculateCartItemTotalPriceParams
                        {
                            Qty = ci.Qty,
                            DealPrice = ci.NormalPrice,
                            OfferPrice = ci.OfferPrice,

                        });
                    }
                }
                if (cart != null)
                {

                    foreach (GetCustomerItemCartResponse c in cart)
                    {
                        c.CartItems = cartitems.Where(ci => ci.CartID == c.CartID).ToList();
                        c.TotalCartPrice = c.CartItems.Sum(ci => ci.TotalItemPrice);
                    }
                }
            }
            return cart;
        }




    }
}
