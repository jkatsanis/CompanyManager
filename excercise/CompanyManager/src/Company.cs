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

        /// <summary>
        /// All the companies in the program
        /// </summary>
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
            return false;
        }

        /// <summary>
        ///     Allows the user to select a product from a list of available products 
        ///     and then sends the selected product. 
        ///     Verify that the user's input is a valid index for the product list
        /// </summary>
        private void SelectProduct()
        {

        }

        /// <summary>
        ///     Sends the specified product to a selected company, 
        ///     updates the inventory of the sending and receiving companies,
        ///     and prints a success message to the console.
        /// </summary>
        /// <param name="send">Product to send</param>
        private void SendProduct(Product send)
        {

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
    
        }

        /// <summary>
        ///     Retrieves and displays a list of available products and employees working at the company.
        ///     Shows a View of the Organisation.
        /// </summary>
        public void ViewOrganisation()
        {

        }

        /// <summary>
        ///     Selects an employee by user input to promote or demote.
        ///     This method selects an employee to be promoted or demoted based on the provided boolean value. 
        /// </summary>
        private void SelectEmployee(bool demote)
        {

        }

        /// <summary>
        ///     Employee is either demoted or promoted.
        /// </summary>
        /// <param name="employee">employee to demote or Promote</param>
        /// <param name="demote">If True demote</param>
        public void TransitEmployee(Employee employee, bool demote)
        {

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
            return null;
        }


        /// <summary>
        ///  Perfoms the same things as SelectCompany, here you can pass
        ///  a string companyName and it will automaticly be selected
        /// </summary>
        /// <param name="companyName">The company which should be selected</param>
        /// <returns>Returns the selected Company</returns>
        public static Company SelectCompany(string companyName)
        {
            return null;
        }

        /// <summary>
        ///     Searches for the correct company in the company object with the provided companyName.
        /// </summary>
        /// <param name="companyName">Name of Company</param>
        /// <returns>Returns the specific object of the companyName, null if it is not found</returns>
        public static Company GetCompanyByName(string companyName)
        {
            return null;
        }
    }
}