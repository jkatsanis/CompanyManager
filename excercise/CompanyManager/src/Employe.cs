using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CompanyManager
{
    public sealed class Employee
    {
        public string Name { get; }
        public Position Position { get; private set; }

        public Employee(string name, Position position)
        {
            Name = name;
            Position = position;
        }


        /// <summary>
        /// Prints the name and the position of the employee to the console
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "=";
        }

        /// <summary>
        /// Demotes an employee, if a employee has the Position Employee he will get fired
        /// </summary>
        /// <param name="employees">The HashShet where the employee lives in, will get removed if Position is Position.Employee</param>
        public void Demote(MyHashSet<Employee> employees)
        {

        }

        /// <summary>
        /// Promotes the employee by 1 position up. Owner cant be promoted
        /// </summary>
        public void Promote()
        {

        }
    }
}
