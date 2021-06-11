using System;
using System.Globalization;
using Course.Entities;
using Course.Entities.Enums;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level: (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()); //receber o string de função do funcionério e converter para workerLevel
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName); //instanciando o objeto departamento
            Worker worker = new Worker(name, level, baseSalary, dept);//instanciando o objeto worker

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine()); //GUARDAR NA VARIÁVEL N O QUE O USUÁRIO DIGITAR (READLINE)

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:"); //$ #{i} para interpolação
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());// datatime.parse para converter padrão americano para brasileiro
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);// PARA ADICIONAR O CONTRATO QUE ACABEI DE INSTANCIAR
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));//GUARDAR UM RECORTE DO MÊS DIGITADO NA VARIÁVEL MONTH A PARTIR DO ZERO ATÉ O SEGUNDO CARACTER
            int year = int.Parse(monthAndYear.Substring(3));//GUARDAR UM RECORTE DO ANO DIGITADO NA VARIÁVEL YEAR A PARTIR DO TERCEIRO CARACTER
            Console.WriteLine("Name : " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
