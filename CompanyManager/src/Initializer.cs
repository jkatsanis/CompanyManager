using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager.src
{
    public static class Initializer
    {
        public static List<Company> InitializeCompanies(string companiesPath, string employeesPath)
        {
            Random rndm = new Random();
            List<Company> s_companies = new List<Company>();

            if (ReadFromCSV(companiesPath) == null || ReadFromCSV(employeesPath) == null)
            {
                return new List<Company>(0);
            }
            string[] companies = ReadFromCSV(companiesPath)!;
            string[] employees = ReadFromCSV(employeesPath)!;

            for (int i = 1; i < companies.Length; i++)
            {
                string[] name = companies[i].Split(';');

                s_companies.Add(new Company(name[0]));
            }

            for (int i = 0; i < employees.Length; i++)
            {
                int randomIdx = rndm.Next(0, companies.Length - 1);
                string[] employee = employees[i].Split(";");
                Enum.TryParse<Position>(employee[1], out Position pos);
                s_companies[randomIdx].Employees.Add(new Employee(employee[0], pos));
            }

            Initializer.InitializeProducts(s_companies);


            return s_companies;
        }

        public static string[]? ReadFromCSV(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            string[] s = File.ReadAllLines(path);
            return s;
        }

        public static void InitializeProducts(List<Company> companies)
        {
            Random rnd = new Random();
            for (int i = 0; i < Product.s_maxProducts; i++)
            {
                int companyIdx = rnd.Next(0, companies.Count);

                ProductType t = (ProductType)rnd.Next(0, Product.s_productsAvailable);

                Product p = new Product(t);

                companies[companyIdx].Products.Add(p);
            }
        }
    }
}
