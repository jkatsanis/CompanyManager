using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace CompanyManager.Tests
{
    public sealed class EmployeeTests
    {
        [Fact]
        public void Constructor()
        {
            var employee = new Employee("Foo", Position.Employee);

            employee.Position.Should().Be(Position.Employee);
            employee.Name.Should().Be("Foo");

            employee.ToString().Should().Be("Name: Foo Position: Employee");
        }
        [Fact]
        public void Demote_Success()
        {
            var foo = new Employee("Foo", Position.Manager);
            var hashSet = new MyHashSet<Employee>();

            foo.Demote(hashSet);
            foo.Position.Should().Be(Position.Employee, "Foo position was demoted");
        }

        [Fact]
        public void Demote_Fired()
        {
            var bar = new Employee("Bar", Position.Employee);
            var hashSet = new MyHashSet<Employee>();
            hashSet.Add(bar);

            bar.Demote(hashSet);
            hashSet.Contains(bar).Should().BeFalse("List empty, because employee was fired");
        }

        [Fact]
        public void Demote_MultipleTimes()
        {
            var foo = new Employee("Foo", Position.Owner);
            var hashSet = new MyHashSet<Employee>();

            foo.Demote(hashSet);
            foo.Position.Should().Be(Position.VicePresident);

            foo.Demote(hashSet);
            foo.Position.Should().Be(Position.Manager, "Demoted twice");
        }

        [Fact]
        public void Promote_Success()
        {
            var foo = new Employee("Foo", Position.Employee);

            foo.Promote();
            foo.Position.Should().Be(Position.Manager, "Got Promoted once");
        }

        [Fact]
        public void Promote_MultipleTimes()
        {
            var foo = new Employee("Foo", Position.Employee);

            foo.Promote();
            foo.Position.Should().Be(Position.Manager);

            foo.Promote();
            foo.Position.Should().Be(Position.VicePresident, "Promoted twice");

            foo.ToString().Should().Be("Name: Foo Position: VicePresident");
        }

        [Fact]
        public void Promototion_NotPossible()
        {
            var foo = new Employee("Foo", Position.Owner);

            foo.Promote();
            foo.Position.Should().Be(Position.Owner, "Nothing further than the owner");
        }
    }
}