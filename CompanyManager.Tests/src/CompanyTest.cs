using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager.Tests.src
{
    public class CompanyTest
    {

        [Fact]
        public void Constructor()
        {
            var company = new Company("Asus");
            company.Name.Should().Be("Asus");
        }

    }
}
