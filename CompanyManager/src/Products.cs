using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager
{
    public sealed class Product
    {
        public static readonly int s_maxProducts = 64;
        public static readonly int s_productsAvailable = 6;

        public ProductType ProductType { get; }

        public Product(ProductType type)
        {
            this.ProductType = type;
        }

        public override string ToString()
        {
            return $"Product: {ProductType}";
        }
    }
}
