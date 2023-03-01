using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager.src
{
    public static class Initializer
    {
        /// <summary>
        ///     Initializes the list of companies by reading from CSV files and creating Company and Employee objects.
        ///     Also initializes the products RANDOMLY for each company.
        ///     
        ///     Hint: Use the RandomProvider class
        /// </summary>
        /// <param name="companiesPath">The path of the CSV file containing the list of companies.</param>
        /// <param name="employeesPath">The path of the CSV file containing the list of employees.</param>
        /// <returns>A list of Company objects that have been initialized with employees and products.</returns>
        public static List<Company> InitializeCompanies(string companiesPath, string employeesPath)
        {
            return new List<Company>(0);
        }

  
    }
}
