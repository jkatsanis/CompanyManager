using CompanyManager.src;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager.Tests.src
{
    public sealed class InitializerTest
    {
        [Fact]

        // HINT RUN THE TESTS EVENTUALLY TWICE!!!!
        public void InitializeCompanies_Valid()
        {
            List<Company> companies = Initializer.InitializeCompanies("assets\\companies.csv", "assets\\employees.csv");

            int count = companies.Count;

            count.Should().Be(6);

            List<Product> products = companies[0].Products.GetValues();
            List<Employee> employees = companies[0].Employees.GetValues();

            products.Count.Should().Be(13);
            employees.Count.Should().Be(6);

            List<Product> products1 = companies[1].Products.GetValues();
            List<Employee> employees1 = companies[1].Employees.GetValues();

            products1.Count.Should().Be(14);
            employees1.Count.Should().Be(4);
        }

        [Fact]
        public void InitializeCompanies_InValid()
        {
            List<Company> companies = Initializer.InitializeCompanies("assedts\\companies.csv", "assets\\employees.csv");

            companies.Should().NotBeNull();
            companies.Count.Should().Be(0);
        }

        [Fact]  
        public void InitializeCompanies_InValid_Null()
        {
            List<Company> companies = Initializer.InitializeCompanies(null!, null!);

            companies.Should().NotBeNull();
            companies.Count.Should().Be(0);
        }

    }
}
