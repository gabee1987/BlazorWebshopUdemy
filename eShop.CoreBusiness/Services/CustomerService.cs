using eShop.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.CoreBusiness.Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> m_customers;

        // Example for AddTransient dependency injection
        public string Uid { get; set; }
        public CustomerService()
        {
            Uid = Guid.NewGuid().ToString();

            m_customers = new List<Customer>()
            {
                new Customer { CustomerNumber = 1, FirstName = "John", LastName = "Smith", Email = "john.smith@email.com" },
                new Customer { CustomerNumber = 1, FirstName = "David", LastName = "Wright", Email = "david.wright@email.com" },
                new Customer { CustomerNumber = 1, FirstName = "Isabelle", LastName = "Hope", Email = "isabelle.hope@email.com" }
            };
        }
        public Customer GetCustomerById( int id )
        {
            return m_customers.FirstOrDefault( c => c.CustomerNumber == id );
        }
    }
}
