using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager
{
    public sealed class Product
    {
        /// <summary>
        /// The products max available for all companies. Only 64
        /// Products can be in all companies together
        /// </summary>
        public static readonly int s_maxProducts = 64;

        /// <summary>
        ///     The product count of existing products:
        ///     Keyboard,
        ///     Mouse,
        ///     Headset,
        ///     Screen,
        ///     PC,
        ///     Controller,
        ///     Helps on the iteration
        /// </summary>
        public static readonly int s_productsAvailable = 6;

        public ProductType ProductType { get; }

        public Product(ProductType type)
        {
            this.ProductType = type;
        }

        /// <summary>
        ///     Writes the ProductType.
        /// </summary>
        public override string ToString()
        {
            return "=";
        }

    }
}
