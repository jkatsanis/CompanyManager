using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager.src
{
    public static class Initializer
    {
        public static List<Company> InitializeCompanies(string path)
        {
            //if (!File.Exists(path))
            //{
            //    return new List<Company>(0);
            //}

            List<Company> s_companies = new List<Company>();

            //string[] lines = File.ReadAllLines(path);

            //for (int i = 1; i < lines.Length; i++)
            //{
            //    string[] name = lines[i].Split(';');

            //    companies.Add(new Company(name[0]));
            //}
            s_companies.Add(new Company("asus"));
            s_companies.Add(new Company("intel"));
            s_companies.Add(new Company("amd"));
            s_companies.Add(new Company("keksfirma"));

            s_companies[0].Employees.Add(new Employee("gerd", Position.Employee));
            s_companies[0].Employees.Add(new Employee("manfred", Position.Manager));
            s_companies[0].Employees.Add(new Employee("gerfred", Position.Owner));

            s_companies[0].Products.Add(new Product(ProductType.Banana));
            s_companies[0].Products.Add(new Product(ProductType.Banana));
            s_companies[0].Products.Add(new Product(ProductType.Kiwi));
            s_companies[0].Products.Add(new Product(ProductType.Kiwi));
            s_companies[0].Products.Add(new Product(ProductType.Kiwi));
            s_companies[0].Products.Add(new Product(ProductType.Chicken));
            s_companies[0].Products.Add(new Product(ProductType.Chicken));
            s_companies[0].Products.Add(new Product(ProductType.Chicken));

            return s_companies;
        }
    }
}
