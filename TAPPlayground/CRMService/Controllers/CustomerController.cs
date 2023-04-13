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
        [Route("getallcustomers")]
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            IEnumerable<Customer> customers = await _custsrv.GetAll();
            return customers;
        }

        [HttpGet]
        [Route("getcustomerdetails/{id}")]
        public async Task<Customer> GetById(int id)
        {
            Customer customer =await _custsrv.GetById(id);
            return customer;
        }

        // [Authorize(Roles = Role.Employee)]
        [HttpPut]
        [Route("update/{id}")]
        public async Task<bool> Update( int id,[FromBody] Customer customer)
        {
            Customer oldCustomer =await _custsrv.GetById(id);
            if(oldCustomer.CustomerId==0){
                return false;
            }
            customer.CustomerId=id;
            bool status =await _custsrv.Update(customer);
            return status;
        }

        // [Authorize(Roles = Role.Employee)]
        [HttpPost]
        [Route("addcustomer")]
        public async Task<bool> Insert([FromBody] Customer customer)
        {
            bool status = await _custsrv.Insert(customer);
            return status;
        }

        // [Authorize(Roles = Role.Employee)]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            bool status = await _custsrv.Delete(id);
            return status;
        }
    }
}