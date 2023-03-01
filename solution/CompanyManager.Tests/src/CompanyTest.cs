using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager.Tests.src
{
    public sealed class CompanyTest
    {

        [Fact]
        public void Constructor()
        {
            var company = new Company("Foo");
            company.Name.Should().BeSameAs("Foo");
        }

        [Fact]
        public void InvalidNumber_IndexHigh()
        {
            var list = new List<int>();
            var company = new Company("Bar");

            for (int i = 0; i < 5; i++)
            {
                list.Add(i + 1);
            }

            company.IsInValidNumber(6, list).Should().BeTrue("Index is out of range");
        }

        [Fact]
        public void InvalidNumber_IndexLow()
        {
            var list = new List<int>();
            var company = new Company("Foo");

            list.Add(5);

            company.IsInValidNumber(-5, list).Should().BeTrue("Index is out of range");
        }

        [Fact]
        public void ValidNumber()
        {
            var list = new List<int>();
            var company = new Company("Bar");

            for (int i = 0; i < 5; i++)
            {
                list.Add(i + 1);
            }

            company.IsInValidNumber(3, list).Should().BeFalse("Index is in range");
        }

        [Fact]
        public void SendProducts()
        {
            var companySupplier = new Company("Foo");
            var company = new Company("Bar");
            var product = new Product(ProductType.Mouse);

            companySupplier.SendProduct(product, company);

            companySupplier.Products.Contains(product).Should().BeFalse();
            company.Products.Contains(product).Should().BeTrue();
        }

        [Fact]
        public void TransitEmployee_Demote()
        {
            var company = new Company("Foo");
            var bar = new Employee("Bar", Position.Manager);
            company.Employees.Add(bar);

            company.TransitEmployee(bar, true);

            bar.Position.Should().Be(Position.Employee, "Degraded by one position");
        }

        [Fact]
        public void TransitEmployee_Promote()
        {
            var company = new Company("Bar");
            var foo = new Employee("Foo", Position.Employee);
            company.Employees.Add(foo);

            company.TransitEmployee(foo, false);

            foo.Position.Should().Be(Position.Manager, "Promoted to mangager");
        }

        [Fact]
        public void GetCompanyByName_Success()
        {
            var company = new Company("Foo");

            Company.s_companies.Add(company);

            Company.GetCompanyByName("Foo").Should().Be(company, "Company in list contained");
        }

        [Fact]
        public void GetCompanyByName_NotFound()
        {
            var company = new Company("Bar");

            Company.s_companies.Add(company);

            Company.GetCompanyByName("Foo").Should().Be(null);
        }
    }
}