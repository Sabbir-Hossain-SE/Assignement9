using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using CustomerInfo.Repository;
using CustomerInfo.Model;

namespace CustomerInfo.Manager
{
    class CustomerManager
    {
        CustomerRepositpry _customerRepository = new CustomerRepositpry();
        public bool Save(Customer customer)
        {
            return _customerRepository.Save(customer);
        }
        public bool IsCodeExist(Customer customer)
        {
            return _customerRepository.IsCodeExist(customer);
        }
        public bool IsPhoneExist(Customer customer)
        {
            return _customerRepository.IsCodeExist(customer);
        }

        public DataTable Display()
        {
            return _customerRepository.Display();
        }

        public DataTable DistrictCombo()
        {
            return _customerRepository.DistrictCombo();
        }
        public DataTable Search(string name, int key)
        {
            return _customerRepository.Search(name ,key);
        }

    }
}
