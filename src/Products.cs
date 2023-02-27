using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager
{
    public class Product
    {
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
