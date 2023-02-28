using CompanyManager.src;
using System;
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
            "View Organisation",
            "Quit",
        };

        static public List<Company> s_companies = Initializer.InitializeCompanies("assets\\companies.txt");

        public Company(string name)
        {
            this.Employees = new MyHashSet<Employee>();
            this.Products = new MyHashSet<Product>();
            this.Name = name;
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
            Console.Write("Where do u want to send the product?");
            Company sendTo = Company.SelectCompany();

            sendTo.Products.Add(send);
            Products.Remove(send);

            Console.WriteLine();
            string wl = $"Succesfully sent the product {send.ToString()} to the Organisation: {sendTo.Name}";
            Console.WriteLine(wl);
            Console.ReadLine();
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

            string ot = (demote) ? "Demote" : "Promote";

            string demoteMsg = $"Which employee do u want to {ot}? Type the employee number";
            Console.WriteLine(demoteMsg);
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
                employee.Demote(Employees);
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
            for (int i = 0; i < Company.s_companies.Count; i++)
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
