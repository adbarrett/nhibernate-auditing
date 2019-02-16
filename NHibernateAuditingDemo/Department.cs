namespace NHibernateAuditingDemo
{
    using System.Collections.Generic;

    public class Department : IAuditable
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Employee> Employees { get; set; }
    }
}
