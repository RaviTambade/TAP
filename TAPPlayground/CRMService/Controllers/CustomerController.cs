using System.Collections.Generic;
using CRMService.Models;
using CRMService.Services;
using CRMService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

using MySql.Data.MySqlClient;

namespace CRMService.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class CustomersController : ControllerBase

    {
        private readonly ICustomerService _custsrv;
        public CustomersController(ICustomerService custsrv)
        {
            _custsrv = custsrv;
        }

        [HttpGet]
        [Route("/getallcustomers")]
        public IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> customers = _custsrv.GetAll();
            return customers;
        }

        [HttpGet]
        [Route("/getcustomerdetails/{id}")]
        public Customer GetById(int id)
        {
            Customer customer = _custsrv.GetById(id);
            return customer;
        }

        // [Authorize(Roles = Role.Employee)]
        [HttpPut]
        [Route("/update/{id}")]
        public bool Update( int id,[FromBody] Customer customer)
        {
            Customer oldCustomer = _custsrv.GetById(id);
            if(oldCustomer.CustomerId==0){
                return false;
            }
            customer.CustomerId=id;
            bool status = _custsrv.Update(customer);
            return status;
        }

        // [Authorize(Roles = Role.Employee)]
        [HttpPost]
        [Route("/addcustomer")]
        public bool Insert([FromBody] Customer customer)
        {
            bool status = _custsrv.Insert(customer);
            return status;
        }

        // [Authorize(Roles = Role.Employee)]
        [HttpDelete]
        [Route("/delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _custsrv.Delete(id);
            return status;
        }
    }
}