using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TShopSkiItemsApi
    {
        public Guid ApplicationId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Guid OrderId { get; set; }
        public int ProductVariantId { get; set; }
        public string ProductVariantName { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? ValidDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Device { get; set; }
        public string PaymentMode { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string PostalArea { get; set; }
        public int? Total { get; set; }
    }
}
