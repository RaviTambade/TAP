//using ECommerceApp.Helpers;
using DeliveryService.Models;
using DeliveryService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace DeliveryService.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class DeliveryController : ControllerBase

    {
        private readonly IDeliveryService _deliverysrv;
        public DeliveryController(IDeliveryService deliverysrv)
        {
            _deliverysrv = deliverysrv;
        }

        [HttpGet]
        [Route("getalldeliveries")]
        public IEnumerable<Delivery> GetAllShippers()
        {
            List<Delivery> deliveries = _deliverysrv.GetAll();
            return deliveries;
        }

        [HttpGet]
        [Route("getdeliverydetails/{id}")]
        public Delivery GetById(int id)
        {
            Delivery delivery = _deliverysrv.GetById(id);
            return delivery;
        }

     //   [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("updateDelivery/{id}")]
        public bool Update( int id,[FromBody] Delivery delivery)
        {
            Delivery oldDilivery = _deliverysrv.GetById(id);
            if(oldDilivery.ShipperId==0){
                return false;
            }
            delivery.ShipperId=id;
            bool status = _deliverysrv.Update(delivery);
            return status;
        }

       // [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("addDelivery/")]
        public bool Insert([FromBody] Delivery delivery)
        {
            bool status = _deliverysrv.Insert(delivery);
            return status;
        }

      //  [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("deleteDelivery/{id}")]
        public bool Delete(int id)
        {
            bool status = _deliverysrv.Delete(id);
            return status;
        }
    }
}