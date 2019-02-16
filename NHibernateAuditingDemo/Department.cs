namespace NHibernateAuditingDemo
{
    using System.Collections.Generic;

    public class Department
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Employee> Employees { get; set; }
    }
}
