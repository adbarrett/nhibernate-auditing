using System;
using NHibernateAuditingDemo.Interfaces;

namespace NHibernateAuditingDemo.Models
{
    public class Employee : IAuditable
    {
        public virtual string Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual Department Department { get; set; }
    }
}
