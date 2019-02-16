namespace NHibernateAuditingDemo
{
    using FluentNHibernate.Mapping;

    public class DepartmentMapping : ClassMap<Department>
    {
        public DepartmentMapping()
        {
            Table("Departments");
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany(x => x.Employees);
        }
    }
}
