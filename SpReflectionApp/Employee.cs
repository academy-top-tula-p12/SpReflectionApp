using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpReflectionApp
{
    public class Employee : IMovable, IWorkable
    {
        public string Name { set; get; }
        public int Age { set; get; }

        public Employee()
        {
            Name = "";
            Age = 0;
        }

        public Employee(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Move() => Console.WriteLine($"{Name} moves");
        public void Work() => Console.WriteLine($"{Name} works");

        override public string ToString()
        {
            return $"{Name} {Age}";
        }

        public void ConsolePrint()
        {
            Console.WriteLine(this.ToString());
        }
    }

    public interface IMovable
    {
        void Move();
    }

    public interface IWorkable
    {
        void Work();
    }
}
