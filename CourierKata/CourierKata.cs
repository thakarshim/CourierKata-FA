using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierKata
{
    public partial class ShippingSpeed
    {
        public string ShipSpeed { get; set; }
        public decimal Cost { get; set; }
    }
    public partial class Discount
    {
        public string DiscountText { get; set; }
        public decimal Amount { get; set; }
    }

    public partial class CourierKata
    {
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal Price { get; set; }
        public string Text { get; set; }
        public decimal Weight { get; set; }
        public decimal OverWeightCharge { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public partial class Courier
    {
        public ShippingSpeed ShippingSpeed;
        public List<CourierKata> CourierKataList;
        public decimal TotalCost { get; set; } = 0;
        public Discount Discount { get; set; }
        public Courier()
        {
            this.ShippingSpeed = new ShippingSpeed();
            this.Discount = new Discount();
            this.CourierKataList = new List<CourierKata>();
        }
    }
}
