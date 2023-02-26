﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager
{
    // TODO: Read employes from file
    // TODO: Get products, for example constructor list, by a method
   
    // TODO: Product count sending
    public class Company
    {
        public MyHashSet<Employee> Employees { get; set; }
        public MyHashSet<Product> Products { get; set; }    

        public string Name { get; }

        public static string[] s_options =
        {
            "Send Product",
            "Demote Employee",
            "Promote Employee",
            "View Organisation"
        };

        static public List<Company> s_companies = new List<Company>();

        public Company(string name)
        {
            this.Employees = new MyHashSet<Employee>();
            this.Products = new MyHashSet<Product>();
            this.Name = name;
        }

        public static void InitCompanies()
        {
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
        }

        
        private void PrintProducts<T>(List<T> printList, string msg)
        {
            Console.WriteLine(msg);

            for(int i = 0; i < printList.Count; i++)
            {
                string wrl = $"{i + 1}) {printList[i]!.ToString()}";
                Console.WriteLine(wrl);
            }
            Console.WriteLine();
        }

        private bool IsValidNumber<T>(int num, List<T> list)
        {
            if (0 > num - 1 || num - 1 >= list.Count)
            {
                Console.WriteLine("Invalid number!");
                Console.ReadLine();
                return true;
            }

            return false;
        }

        private void SelectProduct()
        {
            List<Product> productList = Products.GetValues();
            PrintProducts(productList, "Here are the available product: ");

            Console.WriteLine("Which product do u want to send? type out the number for example '1' for the first product");

            int num = int.Parse(Console.ReadLine()!);

            if(IsValidNumber(num , productList))
            {
                return;
            }
            SendProduct(productList[num - 1]); 
        }

        private void SendProduct(Product send)
        {
            Console.WriteLine();
            Console.WriteLine("Where do u want to send the product?");
            Company sendTo = Company.SelectCompany();

            sendTo.Products.Add(send);
            Products.Remove(send);
        }

        private void ViewOrganisation()
        {
            List<Product> productList = Products.GetValues();
            PrintProducts(productList, "Here are the available product: ");

            List<Employee> employeeList = Employees.GetValues();
            PrintProducts(employeeList, "Here are the employees working at this company: ");

            Console.WriteLine("Press enter if you done viewing the organisation");
            Console.ReadLine();
        }

        private void SelectEmployee(bool demote)
        {
            List<Employee> employeeList = Employees.GetValues();
            PrintProducts(employeeList, "Here are the employees at this company");
            Console.WriteLine("Which employee do u want to demote? " +
                "type out the number for example '1' for the first employee");

            Console.WriteLine("If you demote a employee he will get fired!");

            int num = int.Parse(Console.ReadLine()!);

            if (IsValidNumber(num, employeeList))
            {
                return;
            }

            TransitEmployee(employeeList[num - 1], demote);
        }

        private void TransitEmployee(Employee employee, bool demote)
        {
            if (demote)
            {
                if (employee.Position == Position.Employee)
                {
                    Employees.Remove(employee);
                    return;
                }
                employee.Demote();
                return;
            }
            employee.Promote();
        }

        public void PerfomOption(string option)
        {
            Console.WriteLine();
            switch(option)
            {
                case "Send Product":
                    {
                        SelectProduct();
                        break;
                    }
                case "View Organisation":
                    {
                        ViewOrganisation();
                        break;
                    }
                case "Demote Employee":
                    {
                        SelectEmployee(true);
                        break;
                    }
                case "Promote Employee":
                    {
                        SelectEmployee(false);
                        break;
                    }
            }
            Console.WriteLine();
        }

        public static Company SelectCompany()
        {
            Console.WriteLine();
            Console.WriteLine("Which company should be effected? (Type out the company name)");

            int cnt = 'a';
            for (int i = 0; i < Company.s_options.Length; i++)
            {
                string wrl = Convert.ToChar(cnt) + ") " + Company.s_companies[i].Name;

                Console.WriteLine(wrl);
                cnt++;
            }

            string companyNameInput = Console.ReadLine()!;

            return Company.GetCompanyByName(companyNameInput!);
        }

        public static Company GetCompanyByName(string companyName)
        {
            foreach(Company company in Company.s_companies)
            {
                if(company.Name == companyName)
                {
                    return company;
                }
            }

            return null!;
        }
    }
}
