using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace CompanyManager.Tests
{
    public sealed class MyHashSetTests
    {
        [Fact]
        public void Add_Successfully()
        {
            var hashSet = new MyHashSet<Employee>();
            var employee = new Employee("Bar", Position.Manager);

            hashSet.Add(employee).Should().BeTrue();
            foreach (var element in hashSet.GetValues())
            {
                if (element.Equals(employee))
                {
                    element.Should().Be(employee);
                }
            }
        }

        [Fact]
        public void Add_Null()
        {
            MyHashSet<Employee?> hashSet = new();
            hashSet.Add(null).Should().BeFalse("Null possibility must be handled");
        }

        [Fact]
        public void Add_Copy()
        {
            var hashSet = new MyHashSet<Employee>();
            var foo = new Employee("Foo", Position.Manager);
            var fooCopy = foo;

            hashSet.Add(foo).Should().BeTrue("No copies yet");
            hashSet.Add(fooCopy).Should().BeFalse("Already contained, so it can't add it");
        }

        [Fact]
        public void Remove_Successfully()
        {
            var hashSet = new MyHashSet<Employee>();
            var bar = new Employee("Bar", Position.Employee);
            hashSet.Add(bar);
            hashSet.Remove(bar);

            hashSet.Contains(bar).Should().BeFalse();
        }

        [Fact]
        public void Contains_Null()
        {
            var hashSet = new MyHashSet<Employee>();
            hashSet.Contains(null!).Should().BeFalse("No nulls allowed");
        }

        [Fact]
        public void Contains_Success()
        {
            var hashSet = new MyHashSet<Employee>();
            var foo = new Employee("Foo", Position.Employee);

            hashSet.Add(foo);
            hashSet.Contains(foo).Should().BeTrue("Contained in hashSet");

            foreach (var element in hashSet.GetValues())
            {
                element.Should().Be(foo, "foo should be in the set");
            }
        }
        [Fact]
        public void Contains_Multiple()
        {
            var hashSet = new MyHashSet<Employee>();
            var foo = new Employee("Foo", Position.Employee);
            var bar = new Employee("Bar", Position.Employee);

            hashSet.Add(foo);
            hashSet.Contains(foo).Should().BeTrue();
            hashSet.Contains(bar).Should().BeFalse();

            hashSet.Add(bar);
            hashSet.Contains(foo).Should().BeTrue();
            hashSet.Contains(bar).Should().BeTrue();
        }
        [Fact]
        public void DoesNot_Contains()
        {
            var hashSet = new MyHashSet<Employee>();
            hashSet.Contains(new("FalseFoo", Position.Employee)).Should().BeFalse("Is not in the set");
        }
    }

}
