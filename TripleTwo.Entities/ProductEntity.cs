using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTwo.Entities
{
    public class ProductEntity
    {
    }

    public class GetProductDetailsResponse
    {
        public Int64 ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string NormalPrice { get; set; }
        public string DisplayNormalPrice { get { return Settings.SetPriceFormat(NormalPrice); } }
        public string OfferPrice { get; set; }
        public string DisplayOfferPrice { get { return Settings.SetPriceFormat(OfferPrice); } }
        public string ProductInfo { get; set; }
        public string Conditions { get; set; }

        public List<ProductImage> ProductImages { get; set; }


    }

    public class ProductImage
    {
        public Int64 ProductId { get; set; }
        public string Image { get; set; }
        public string ImagePath { get { return Settings.GetItemsImagePath(this.ProductId, this.Image); } }
    }

    public class GetProductsListResponse
        {
        public Int64 ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string NormalPrice { get; set; }
        public string DisplayNormalPrice { get { return Settings.SetPriceFormat(NormalPrice); } }
        public string OfferPrice { get; set; }
        public string DisplayOfferPrice { get { return Settings.SetPriceFormat(OfferPrice); } }
        public string ProductInfo { get; set; }
        public string ProductImage { get; set; }
        public string ProductImagePath { get { return Settings.GetItemsImagePath(this.ProductId, this.ProductImage); } }
    }

    public class GetProductsListParam : paggingEntity
    {
        public Int64 ProductId { get; set; }
    }


        public class ProductsEntity
        {
            public Int64 ProductId { get; set; }
            public string ProductTitle { get; set; }
            public string NormalPrice { get; set; }
            public string DisplayNormalPrice { get { return Settings.SetPriceFormat(NormalPrice); } }
            public string OfferPrice { get; set; }
            public string DisplayOfferPrice { get { return Settings.SetPriceFormat(OfferPrice); } }
            public string ProductInfo { get; set; }
            public string ProductImage { get; set; }
            public string ProductImagePath { get { return Settings.GetItemsImagePath(this.ProductId, this.ProductImage); } }
            public Int32 TotalRecords { get; set; }
        }

        public class ProductImagesEntity
        {
            public Int64 ImageId { get; set; }
            public Int64 Id { get; set; }
            public string Image { get; set; }
            public string ImagePath { get { return Settings.GetItemsImagePath(Id, Image); } }
            public int MainImage { get; set; }
        }
        public class ProductsListEntity
        {
            public ProductsEntity ItemDetails { get; set; }
            public List<ProductsEntity> Items { get; set; }
            public List<ProductImagesEntity> ItemImages { get; set; }
        }

        public class ProductsParamsEntity : paggingEntity
        {
            public string SearchStr { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
        }


    public class ItemCartEntity
    {
        public long CartID { get; set; }
        public long CustomerID { get; set; }
        public long OutletID { get; set; }
        public long MallID { get; set; }
        public long TotalItems { get; set; }
        public long TotalCartQty { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedDateDisplay { get { return Settings.SetDateTimeFormat(this.AddedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDateDisplay { get { return Settings.SetDateTimeFormat(this.ModifiedDate); } }
    }

    public class CartItemsEntity
    {
        public long CartProductID { get; set; }
        public long CartID { get; set; }
       
        public long CustomerID { get; set; }
        public long ProductId { get; set; }
        public int Qty { get; set; }

       
        public DateTime ProductAddedDate { get; set; }
        public string ProductAddedDateDisplay { get { return Settings.SetDateTimeFormat(this.ProductAddedDate); } }
        public DateTime ProductModifiedDate { get; set; }
        public string ProductModifiedDateDisplay { get { return Settings.SetDateTimeFormat(this.ProductModifiedDate); } }
    }

    public class AddRemoveCartItemsParams
    {
        public long CartProductID { get; set; }
        public long CartID { get; set; }
        public long ProductId { get; set; }
        public long CustomerID { get; set; }
        public long Qty { get; set; }

        public long Action { get; set; } //1-add,2-update,-1-delete
    }

    public class AddRemoveCartItemsResponse : Settings.BaseResponse
    {
    }

    public class RemoveItemCartParams
    {
        public long CartID { get; set; }
        public long OutletID { get; set; }
    }

    public class RemoveItemCartResponse : Settings.BaseResponse
    {
    }

    public class GetCustomerItemCartResponse : CartEntity
    {
      
        public decimal TotalCartPrice { get; set; }
        public string TotalCartPriceDisplay { get { return Settings.SetPriceFormat(Convert.ToString(this.TotalCartPrice)); } }
        public List<GetCustomerCartItemsEntity> CartItems { get; set; }
    }

    public class GetCustomerCartItemsEntity : CartItemsEntity
    {
       
        public string ProductTitle { get; set; }
        public decimal NormalPrice { get; set; }
        public string NormalPriceDisplay { get { return Settings.SetPriceFormat(Convert.ToString(this.NormalPrice)); } }
        public decimal OfferPrice { get; set; }
        public string OfferPriceDisplay { get { return Settings.SetPriceFormat(Convert.ToString(this.OfferPrice)); } }
        //public string OfferPricePercentage { get { return Settings.GetOfferPricePercentage(this.ItemPrice, this.OfferPrice); } }
     
        public decimal TotalItemPrice { get; set; }
        public string TotalItemPriceDisplay { get { return Settings.SetPriceFormat(Convert.ToString(this.TotalItemPrice)); } }

        public string Productimage { get; set; }
        public string ProductimagePath { get { return Settings.GetItemsImagePath(base.ProductId, this.Productimage); } }
    
    }

    public class CartEntity
    {
        public long CartID { get; set; }
        public long CustomerID { get; set; }
       
        public long TotalProducts { get; set; }
        public long TotalCartQty { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedDateDisplay { get { return Settings.SetDateTimeFormat(this.AddedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDateDisplay { get { return Settings.SetDateTimeFormat(this.ModifiedDate); } }
    }


    public class GetCustomerItemCartParams
    {
        public long CustomerID { get; set; }
    }

    public class AddItemOrderParams
    {
        public long CartID { get; set; }
        public long CustomerID { get; set; }
    }

    public class AddItemOrderResponse : Settings.BaseResponse
    {
    }


}
