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
            Console.WriteLine("Add Parcel Details");
            Courier courier = new Courier();
            AddParcelDetail(courier);
            Console.ReadKey();
        }

        private static void AddParcelDetail(Courier courier)
        {
            string AddMoreParcel = "";
            do
            {
                CourierKata model = new CourierKata();
                #region Input Parcel Detail
                Console.Write("Enter Height : ");

                decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, CultureInfo.DefaultThreadCurrentCulture, out decimal height);
                model.Height = height;
                Console.Write("Enter Width : ");
                decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, CultureInfo.DefaultThreadCurrentCulture, out decimal width);
                model.Width = width;

                Console.Write("Enter Length : ");
                decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, CultureInfo.DefaultThreadCurrentCulture, out decimal length);
                model.Length = length;

                Console.Write("Enter Parcel Weight(kg) : ");
                decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, CultureInfo.DefaultThreadCurrentCulture, out decimal weight);

                #endregion
            }
        }
    }
}
