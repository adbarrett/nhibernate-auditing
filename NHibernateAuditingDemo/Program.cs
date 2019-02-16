using System;
using NHibernate;
using NHibernateAuditingDemo.Models;
using NHibernateAuditingDemo.NHibernate;

namespace NHibernateAuditingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ISessionFactory sessionFactory = NHibernateSessionFactory.GetSessionFactory();
            using (ISession session = sessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var department = new Department
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Sales"
                };

                session.Save(department);

                var employee = new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Joe",
                    LastName = "Bloggs",
                    DateOfBirth = new DateTime(1985, 7, 30),
                    Department = department
                };

                session.Save(employee);

                transaction.Commit();
            }
        }
    }
}
