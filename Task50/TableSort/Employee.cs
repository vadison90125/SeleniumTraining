namespace TableSort
{
    class Employee
    {
        private readonly string name;
        private readonly string position;
        private readonly string office;
        private readonly int age;
        private readonly int salary;

        public Employee (string name, string position, string office, int age, int salary)
        {
            this.name = name;
            this.position = position;
            this.office = office;
            this.age = age;
            this.salary = salary;
        }

        public static List<string> SortEmployee(int age, int salary, List<Employee> list)
        {
            var selectedPeople = from p in list
                                 where p.age > age && p.salary > salary
                                 select p;
            
            List<string> result = new List<string>();

            foreach (Employee person in selectedPeople)
            {
                result.Add($"{person.name} - {person.position} - {person.office}");
            }
            return result;
        }
    }
}
