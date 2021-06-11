using Course.Entities.Enums;
using System.Collections.Generic;

namespace Course.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; } //associação entre duas classes diferentes
        public List<HourContract> Contracts { get; private set; } = new List<HourContract>();//<HourContract> = vindo da classe HourContract / new List<HourContract>(); = instânciar para que não seja nula

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
            // contract não está aqui, pois não se passa lista instânciada (assossiada para muitos) no construtor
        }

        public void AddContract(HourContract contract) //operação AddContract = para adicionar contrato ao trabalhador
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)  //operação RemoveContract = para remover contrato desse trabalhador
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month) // operação para retornar quanto o funcionário ganhou em um determinado ano e mês
        {
            double sum = BaseSalary; //BaseSalary ao invez de 0, pois o trabalhador receberá um salário independentemente de algum contrato
            foreach (HourContract contract in Contracts)// para percorrer a lista de contratos
            {
                if (contract.Date.Year == year && contract.Date.Month == month)// se o ano e mês do contrato for o mesmo que recebi do argumento, então entra na soma
                {
                    sum += contract.TotalValue(); //soma recebe ela mesma (que é = ao salário) mais valor do contrato
                }
            }
            return sum;
        }
    }
}
