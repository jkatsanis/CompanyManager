using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace CompanyManager.Tests
{
    public class ProductsTests
    {
        [Fact]
        public void Constructor()
        {
            var product = new Product(ProductType.Chicken);

            product.ProductType.Should().Be(ProductType.Chicken);
        }

        [Fact]
        public void StringConcentation()
        {
            var product = new Product(ProductType.Chicken);

            product.ToString().Should().Be("Product: Chicken");
        }
    }
}