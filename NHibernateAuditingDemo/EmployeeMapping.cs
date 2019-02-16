namespace NHibernateAuditingDemo
{
    using FluentNHibernate.Mapping;

    public class EmployeeMapping : ClassMap<Employee>
    {
        public EmployeeMapping()
        {
            Table("Employees");
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.DateOfBirth);
            References(x => x.Department);
        }
    }
}
