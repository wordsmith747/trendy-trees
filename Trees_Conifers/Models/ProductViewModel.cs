using System;
using System.Collections.Generic;

namespace TrendyTrees.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        public double Price_Small { get; set; }
        public double Price_Large { get; set; }
        public int Number_Items_Basket { get; set; }

        public int UnitsInStock { get; set; }

        public bool FreeShipping { get; set; }

        public DateTime PublishDate { get; set; }

        public IList<ProductDimensionInfo> AvailableDimensions { get; set; }

        public bool DetermineIsNew()
        {

            var timePublished = PublishDate;
            var timeCurrent = DateTime.Now;

            TimeSpan difference1 = timeCurrent.Subtract(timePublished);

            var fractionalDays = difference1.TotalDays;
            Math.Round(fractionalDays);

            if (fractionalDays < 30)
            {
                return true;
            }

            else
            {
                return false;

            }
        }

        public bool IsInStockOrIsOutofStock()
        {
            var inStock = UnitsInStock;

            if (inStock < 10)
            {
                return true;
            }

            return false;
        }
    }

    public class ProductDimensionInfo
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
    }
}