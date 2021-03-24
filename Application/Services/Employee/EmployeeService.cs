using Application.DB;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Employee
{
    public class EmployeeService
    {

        public Task<ICollection<Application.Models.Employee>> GetAll()
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                // return all entities from 'Employees' collection
                // where FirstName equals 'Robert'
                ICollection<Application.Models.Employee> employees = session
                    .Query<Models.Employee>().ToList();

                return Task.FromResult(employees);
            }
        }

        
    }
}
