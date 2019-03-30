using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CourierKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Courier Kata");
            Console.WriteLine("Please Add Your Parcel Details");
            Courier courier = new Courier();
            AddParcelDetail(courier);
            CalculateDiscount(courier);
            SpeedShipping(courier);
            Console.ReadKey();
        }

        private static void AddParcelDetail(Courier courier)
        {
            string AddMoreParcel = "";
            do
            {
                CourierKata model = new CourierKata();
                #region Input Parcel Detail
                Console.Write("Please Enter Parcel Height: ");

                decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, CultureInfo.DefaultThreadCurrentCulture, out decimal height);
                model.Height = height;
                Console.Write("Please Enter Parcel Width: ");
                decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, CultureInfo.DefaultThreadCurrentCulture, out decimal width);
                model.Width = width;

                Console.Write("Please Enter Parcel Length: ");
                decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, CultureInfo.DefaultThreadCurrentCulture, out decimal length);
                model.Length = length;

                Console.Write("Please Enter Parcel Weight(kg): ");
                decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, CultureInfo.DefaultThreadCurrentCulture, out decimal weight);
                model.Weight = weight;
                if (model.Weight > 15)
                {
                    model.Price = 50;
                    model.Text = "Heavy parcel";
                    if (model.Weight > 50)
                    {
                        model.OverWeightCharge = (model.Weight - 50) * 1;
                    }
                }
                else
                {
                    if (model.Height < 10 && model.Width < 10 && model.Length < 10)
                    {
                        model.Price = 3;
                        model.Text = "Small Parcel";
                        if (model.Weight > 1)
                        {
                            model.OverWeightCharge = (model.Weight - 1) * 2;
                        }
                    }
                    else if (model.Height < 50 && model.Width < 50 && model.Length < 50)
                    {
                        model.Price = 8;
                        model.Text = "Medium Parcel";
                        if (model.Weight > 3)
                        {
                            model.OverWeightCharge = (model.Weight - 3) * 2;
                        }
                    }
                    else if (model.Height < 100 && model.Width < 100 && model.Length < 100)
                    {
                        model.Price = 15;
                        model.Text = "Large Parcel";
                        if (model.Weight > 6)
                        {
                            model.OverWeightCharge = (model.Weight - 6) * 2;
                        }
                    }
                    else
                    {
                        model.Price = 25;
                        model.Text = "XL Parcel";
                        if (model.Weight > 10)
                        {
                            model.OverWeightCharge = (model.Weight - 10) * 2;
                        }
                    }
                }
                model.TotalPrice = model.Price + model.OverWeightCharge;
                courier.CourierKataList.Add(model);
                Console.Write("Do You Want to Add More Parcel (Y/N)? ");
                AddMoreParcel = Console.ReadLine();
            }
            while (AddMoreParcel.Trim().ToLower() == "y");
            Console.WriteLine("Parcel List");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("Height\tWidth\tLength\tText\t\tPrice\tOver Weigth Charge\tTotal Price");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (CourierKata obj in courier.CourierKataList)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t${4}\t${5}\t\t\t${6}", obj.Height, obj.Width, obj.Length, obj.Text, obj.Price, obj.OverWeightCharge, obj.TotalPrice);
            }
            #endregion
        }

        private static void CalculateDiscount(Courier courier)
        {
            #region Discount 
            var courierKataList = new List<CourierKata>();
            courier.Discount.DiscountText = "Discount ";
            //check all small parcel
            if (courier.CourierKataList.Count(x => x.Text == "Small Parcel") == courier.CourierKataList.Count())
            {
                courierKataList = new List<CourierKata>();
                for (int i = 1; i <= courier.CourierKataList.Count; i++)
                {
                    if (i % 4 == 0)
                    {
                        courier.Discount.Amount = courier.Discount.Amount + courierKataList.Min(x => x.TotalPrice);
                        courierKataList = new List<CourierKata>();
                    }
                    else
                    {
                        courierKataList.Add(courier.CourierKataList[i - 1]);
                    }
                }
            }
            else if (courier.CourierKataList.Count(x => x.Text == "Medium Parcel") == courier.CourierKataList.Count())
            {
                courierKataList = new List<CourierKata>();
                for (int i = 1; i <= courier.CourierKataList.Count; i++)
                {
                    if (i % 3 == 0)
                    {
                        courier.Discount.Amount = courier.Discount.Amount + courierKataList.Min(x => x.TotalPrice);
                        courierKataList = new List<CourierKata>();
                    }
                    else
                    {
                        courierKataList.Add(courier.CourierKataList[i - 1]);
                    }
                }
            }
            else
            {
                courierKataList = new List<CourierKata>();
                for (int i = 1; i <= courier.CourierKataList.Count; i++)
                {
                    if (i % 5 == 0)
                    {
                        courier.Discount.Amount = courier.Discount.Amount + courierKataList.Min(x => x.TotalPrice);
                        courierKataList = new List<CourierKata>();
                    }
                    else
                    {
                        courierKataList.Add(courier.CourierKataList[i - 1]);
                    }
                }
            }
            #endregion
            courier.TotalCost = courier.CourierKataList.Sum(x => x.TotalPrice) - courier.Discount.Amount;
            Console.WriteLine("\t\t\t\t\t\t\t{0}\t-${1}", courier.Discount.DiscountText, courier.Discount.Amount);
            Console.WriteLine("\t\t\t\t\t\t\t{0}\t${1}", "Total Shipping Cost ", courier.TotalCost);
        }

        private static void SpeedShipping(Courier courier)
        {
            #region Speed Shipping
            Console.WriteLine("Do You Want Speedy Shipping (Y/N)? ");
            string AddSpeedShipping = Console.ReadLine();
            if (AddSpeedShipping.Trim().ToLower() == "y")
            {
                courier.ShippingSpeed.ShipSpeed = "Speedy shipping Charges";
                courier.ShippingSpeed.Cost = courier.TotalCost;
                courier.TotalCost = (courier.TotalCost * 2);
                Console.WriteLine("Height\tWidth\tLength\tText\t\tPrice\tOver Weigth Charge\tTotal Price");
                Console.WriteLine("-----------------------------------------------------------------------------------");
                foreach (CourierKata obj in courier.CourierKataList)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t${4}\t${5}\t\t\t${6}", obj.Height, obj.Width, obj.Length, obj.Text, obj.Price, obj.OverWeightCharge, obj.TotalPrice);
                }
                Console.WriteLine("\t\t\t\t\t\t\t{0}\t-${1}", courier.Discount.DiscountText, courier.Discount.Amount);
                Console.WriteLine("\t\t\t\t\t\t{0}\t${1}", courier.ShippingSpeed.ShipSpeed, courier.ShippingSpeed.Cost);
                Console.WriteLine("\t\t\t\t\t\t\t{0}\t${1}", "Total Shipping Cost ", courier.TotalCost);

            }
            #endregion
        }
    }
}
