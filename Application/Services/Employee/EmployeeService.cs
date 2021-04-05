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

        // Get ALL
        public async Task<ICollection<Models.Employee>> GetAll()
        {
            // Open Session 
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                // Return all entities from 'Employees' collection
                ICollection<Models.Employee> employees = session
                  .Query<Models.Employee>().ToList();

                return await Task.FromResult(employees);
            }
        }




        // GetByID
        public async Task<Models.Employee> GetByID(string EmployeeID)
        {
            using(IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                Models.Employee employee = (Models.Employee)session.Query<Models.Employee>().Where(x => x.Id == EmployeeID);

                return await Task.FromResult(employee);
            }
        }
        
    }
}
