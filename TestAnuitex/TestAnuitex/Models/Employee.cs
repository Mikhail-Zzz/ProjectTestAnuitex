namespace TestAnuitex
{
    public abstract class Employee : IWorker
    {
        public Employee(string name, string surname, string patronymic, double exp)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Experience = exp;
        }

        public string FullName => $"{Name} {Surname }" + (string.IsNullOrEmpty(Patronymic) ? "" : $" {Patronymic}");

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public double Experience { get; private set; }

        public abstract void DoWork();

        public override string ToString()
        {
            return $"ФИО: {Name} {Surname} {Patronymic} | Стаж: {Experience}";
        }
    }
}
