using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Demote()
        {
            int newPos = (int)Position - 1;
            Position = (Position)newPos;
        }

        public void Promote()
        {
            if(Position == Position.Owner)
            {
                Console.WriteLine("Cant promote owner!");
                Console.ReadLine();
                return;
            }
            int newPos = (int)Position + 1;
            Position = (Position)newPos;
        }
    }
}
