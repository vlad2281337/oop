using System;
using System.Collections.Generic;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; ++i)
            {
                Employee employee = ParseEmployeeFromConsole();
                employees.Add(employee);
            }
            Console.WriteLine();

            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n - 1; ++j)
                    if (employees[j].Salary < employees[j + 1].Salary)
                        (employees[j], employees[j + 1]) = (employees[j + 1], employees[j]);


            double highestAvgSalary = 0;
            string highestDepartment = null;

            for (int i = 0; i < employees.Count; ++i)
            {
                int depCount = 1;
                double avgSalary = employees[i].Salary;

                for (int j = i + 1; j < employees.Count; ++j)
                    if (employees[i].Department == employees[j].Department)
                    {
                        ++depCount;
                        avgSalary += employees[j].Salary;
                    }

                avgSalary /= depCount;

                if (avgSalary > highestAvgSalary)
                {
                    highestAvgSalary = avgSalary;
                    highestDepartment = employees[i].Department;
                }
            }

            Console.WriteLine($"Highest Average Salary: {highestDepartment}");

            foreach (var employee in employees)
                if (employee.Department == highestDepartment)
                    Console.WriteLine(employee);

            Console.ReadKey();
        }

        static Employee ParseEmployeeFromConsole()
        {
            string[] inputs = Console.ReadLine().Replace('.', ',').Split(' ');

            string name = inputs[0];
            double salary = Convert.ToDouble(inputs[1]);
            string position = inputs[2],
                    department = inputs[3];

            (string email, int? age) = inputs.Length switch
            {
                4 => (null, null),
                5 => int.TryParse(inputs[4], out int result)
                        ? (null as string, result)
                        : (inputs[4], null as int?),
                _ => (inputs[4], int.Parse(inputs[5]))
            };

            return new Employee(name, salary, position, department, email, age);
        }
    }
}
    
    

