using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CompanyManager
{
    public class Employee
    {
        public string Name { get; }
        public Position Position { get; private set; }

        public Employee(string name, Position position)
        {
            Name = name;
            Position = position;
        }

        public override string ToString()
        {
            return $"Name: {Name} Position: {Position}";
        }

        public void Demote(MyHashSet<Employee> employees)
        {
            if (Position == Position.Employee)
            {
                TransitMessage("fired");
                employees.Remove(this);
                return;
            }
            int newPos = (int)Position - 1;
            Position = (Position)newPos;

            TransitMessage(Position.ToString());
        }

        public void Promote()
        {
            if(Position == Position.Owner)
            {
                Console.WriteLine("Cant promote owner!");
                //Console.ReadLine();
                return;
            }
            int newPos = (int)Position + 1;
            Position = (Position)newPos;

            TransitMessage(Position.ToString());
        }

        public void TransitMessage(string pos)
        {
            Console.WriteLine();
            string msg = $"Succesfully transitet employee {Name} to the Position: {pos}";
            Console.WriteLine(msg);
            //Console.ReadLine();
        }
    }
}
