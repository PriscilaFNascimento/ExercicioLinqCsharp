using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using ExercicioLinq.Entities;

namespace ExercicioLinq
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Employee> list = new List<Employee>();

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!(sr.EndOfStream))
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        string email = line[1];
                        double salary = double.Parse(line[2], CultureInfo.InvariantCulture);

                        Employee emp = new Employee(name, email, salary);

                        list.Add(emp);
                    }

                    Console.Write("Enter value: ");
                    double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


                    var emails = list.Where(p => p.Salary > value).OrderBy(p => p.Email).Select(p => p.Email);
                    var sum = list.Where(p => p.Name.StartsWith('M')).Sum(p => p.Salary);

                    Console.WriteLine();
                    Console.WriteLine($"Email of people whose salary is more than {value.ToString("F2", CultureInfo.InvariantCulture)}:");
                    foreach (string email in emails)
                    {
                        Console.WriteLine(email);
                    }

                    Console.WriteLine();
                    Console.Write("Sum of salary of people whose name starts with 'M': " + sum);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
