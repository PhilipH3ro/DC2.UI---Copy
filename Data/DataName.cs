using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DC2.UI.Model;

namespace DC2.UI.Data
{
    public class DataName
    {
        public List<CustomerDTO> GetAll()
        {
            var customers = LoadCustomers();
            return (from cust in customers
                    orderby cust.FirstName
                    select cust).ToList();
        }

        public CustomerDTO GetById(string id)
        {
            var customers = LoadCustomers();
            return customers.FirstOrDefault(x => x.Id == id);
        }

        public void AddCustomer(CustomerDTO customer)
        {
            var customers = LoadCustomers();
            customer.Id = Guid.NewGuid().ToString();
            customers.Add(customer);
       
            SaveCustomers(customers);
        }
        public void RemoveCustomer(CustomerDTO removeCustomer)
        {
            var customers = LoadCustomers();
            var customer = customers.FirstOrDefault(x => x.Id == removeCustomer.Id);
            customers.Remove(customer);

            SaveCustomers(customers);
        }
        public void UpdateCustomer(CustomerDTO newUserDetails)
        {
            var customers = LoadCustomers();

            var customer = customers.FirstOrDefault(x => x.Id == newUserDetails.Id);
            if (customer is not null)
            {
                customers.Remove(customer);
                customers.Add(newUserDetails);
            }
            customers = (from cust in customers
                         orderby customer.Id
                         select cust).ToList();

            SaveCustomers(customers);
        }

        //private int GetNewId()
        //{
        //    var customers = LoadCustomers();
        //    var max = customers.Max(x => x.Id);
        //    return max + 1;
        //}


        private List<CustomerDTO> LoadCustomers()
        {
            var path = @"Data\Customer.json";
            var jsonResponse = File.ReadAllText(path);
            var tmp = JsonConvert.DeserializeObject<IEnumerable<CustomerDTO>>(jsonResponse);
            return tmp.ToList();
        }

        private void SaveCustomers(List<CustomerDTO> customers)
        {
            var path = @"Data\Customer.json";
            var jsonResponse = JsonConvert.SerializeObject(customers);
            File.WriteAllText(path, jsonResponse);
        }
    }
}
