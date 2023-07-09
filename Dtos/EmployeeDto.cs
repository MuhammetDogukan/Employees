namespace Empoyees.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public List<int> Subordinate { get; init; }
        public int Director { get; init; }
    }
}
