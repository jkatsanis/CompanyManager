using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace CompanyManager.Tests
{
    public sealed class ProductsTests
    {
        [Fact]
        public void Constructor()
        {
            var product = new Product(ProductType.Mouse);

            product.ProductType.Should().Be(ProductType.Mouse);
        }

        [Fact]
        public void StringConcentation()
        {
            var product = new Product(ProductType.Keyboard);

            product.ToString().Should().Be("Product: Keyboard");
        }
    }
}