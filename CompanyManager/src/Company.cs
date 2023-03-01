using CompanyManager.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager
{
    public sealed class Company
    {
        public MyHashSet<Employee> Employees { get; set; }
        public MyHashSet<Product> Products { get; set; }

        public string Name { get; }

        public static readonly string[] s_options =
        {
            "Send Product",
            "Demote Employee",
            "Promote Employee",
            "View Organisation",
            "Quit",
        };

        static public List<Company> s_companies = Initializer.InitializeCompanies("assets\\companies.csv", "assets\\employees.csv");

        public Company(string name)
        {
            this.Employees = new MyHashSet<Employee>();
            this.Products = new MyHashSet<Product>();
            this.Name = name;
        }

        /// <summary>
        ///     Prints a list to the console with a msg before
        /// </summary>
        /// <param name="printList">List to Print</param>
        /// <param name="msg">Message to Print</param>
        private void PrintList<T>(List<T> printList, string msg)
        {
            Console.WriteLine(msg);

            for (int i = 0; i < printList.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {printList[i]!}");
            }
            Console.WriteLine();
        }

        /// <summary>
        ///     It checks if the provided num is smaller than 0 or greaterequal than the Count.
        ///     If true an error message is written.
        /// </summary>
        /// <param name="num">Number to check</param>
        /// <param name="list">The lists Count</param>
        /// <returns>Returns true if invalid, otherwise false</returns>

        public bool IsInValidNumber<T>(int num, List<T> list)
        {
            if (0 > num || num >= list.Count)
            {
                Console.WriteLine("Invalid number!");
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Allows the user to select a product from a list of available products 
        ///     and then sends the selected product. 
        ///     Verify that the user's input is a valid index for the product list
        /// </summary>
        private void SelectProduct()
        {
            List<Product> productList = Products.GetValues();
            PrintList(productList, "Here are the available product: ");

            Console.WriteLine("Which product do u want to send? type out the number for example '1' for the first product");

            int num = int.Parse(Console.ReadLine()!);

            if (IsInValidNumber(num - 1, productList))
            {
                return;
            }
            SendProduct(productList[num - 1]);
        }

        /// <summary>
        ///     Sends the specified product to a selected company, 
        ///     updates the inventory of the sending and receiving companies,
        ///     and prints a success message to the console.
        /// </summary>
        /// <param name="send">Product to send</param>
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
        }

        /// <summary>
        ///     Sends the specified product to a selected company, 
        ///     updates the inventory of the sending and receiving companies,
        ///     and prints a success message to the console.
        /// </summary>
        /// <param name="send">Product to send</param>
        /// <param name="companyToSend">Specifes the company where you want to send it to</param>
        public void SendProduct(Product send, Company companyToSend)
        {
            Console.WriteLine();
            Console.Write("Where do u want to send the product?");

            companyToSend.Products.Add(send);
            Products.Remove(send);

            Console.WriteLine();
            string wl = $"Succesfully sent the product {send.ToString()} to the Organisation: {companyToSend.Name}";
            Console.WriteLine(wl);
        }

        /// <summary>
        ///     Retrieves and displays a list of available products and employees working at the company.
        ///     Shows a View of the Organisation.
        /// </summary>
        public void ViewOrganisation()
        {
            List<Product> productList = Products.GetValues();
            PrintList(productList, "Here are the available product: ");

            List<Employee> employeeList = Employees.GetValues();
            PrintList(employeeList, "Here are the employees working at this company: ");

            Console.WriteLine("Press enter if you are done viewing the organisation");
            Console.ReadLine();
        }

        /// <summary>
        ///     Selects an employee by user input to promote or demote.
        ///     This method selects an employee to be promoted or demoted based on the provided boolean value. 
        /// </summary>
        private void SelectEmployee(bool demote)
        {
            List<Employee> employeeList = Employees.GetValues();
            PrintList(employeeList, "Here are the employees at this company");

            string ot = demote ? "Demote" : "Promote";

            string demoteMsg = $"Which employee do u want to {ot}? Type the employee number";
            Console.WriteLine(demoteMsg);
            Console.WriteLine("If you demote a employee he will get fired!");

            int num = int.Parse(Console.ReadLine()!);

            if (IsInValidNumber(num - 1, employeeList))
            {
                return;
            }

            TransitEmployee(employeeList[num - 1], demote);
        }

        /// <summary>
        ///     Employee is either demoted or promoted.
        /// </summary>
        /// <param name="employee">employee to demote or Promote</param>
        /// <param name="demote">If True demote</param>
        public void TransitEmployee(Employee employee, bool demote)
        {
            if (demote)
            {
                employee.Demote(Employees);
                return;
            }
            employee.Promote();
        }

        /// <summary>
        /// Perfons a option to the given string. There is a switch
        /// case to perfom option for specified string values
        /// </summary>
        /// <param name="option">Option in a string</param>
        public void PerfomOption(string option)
        {
            Console.WriteLine();
            switch (option)
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
                default:
                    {
                        PerfomOption(option);
                        break;
                    }

            }
            Console.WriteLine();
        }


        /// <summary>
        ///     Asks the user to select a company to be affected and returns the selected company.
        ///     All companies are then listed.
        /// </summary>
        /// <returns>Returns the selected Company</returns>
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

            return Company.GetCompanyByName(companyNameInput!)!;
        }


        /// <summary>
        ///  Perfoms the same things as SelectCompany, here you can pass
        ///  a string companyName and it will automaticly be selected
        /// </summary>
        /// <param name="companyName">The company which should be selected</param>
        /// <returns>Returns the selected Company</returns>
        public static Company SelectCompany(string companyName)
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


            return Company.GetCompanyByName(companyName!);
        }

        /// <summary>
        ///     Searches for the correct company in the company object with the provided companyName.
        /// </summary>
        /// <param name="companyName">Name of Company</param>
        /// <returns>Returns the specific object of the companyName, null if it is not found</returns>
        public static Company GetCompanyByName(string companyName)
        {
            foreach (Company company in Company.s_companies)
            {
                if (company.Name == companyName)
                {
                    return company;
                }
            }

            return null!;
        }
    }
}