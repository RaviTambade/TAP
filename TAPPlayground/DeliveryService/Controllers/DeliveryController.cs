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
        public async Task <IEnumerable<Delivery>> GetAllShippers()
        {
            IEnumerable<Delivery> deliveries = await _deliverysrv.GetAll();
            return deliveries;
        }

        [HttpGet]
        [Route("getdeliverydetails/{id}")]
        public async Task <Delivery> GetById(int id)
        {
            Delivery delivery = await _deliverysrv.GetById(id);
            return delivery;
        }

     //   [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("updateDelivery/{id}")]
        public async Task< bool> Update( int id,[FromBody] Delivery delivery)
        {
            Delivery oldDilivery = await _deliverysrv.GetById(id);
            if(oldDilivery.ShipperId==0){
                return false;
            }
            delivery.ShipperId=id;
            bool status = await _deliverysrv.Update(delivery);
            return status;
        }

       // [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("addDelivery/")]
        public async Task <bool> Insert([FromBody] Delivery delivery)
        {
            bool status = await _deliverysrv.Insert(delivery);
            return status;
        }

      //  [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("deleteDelivery/{id}")]
        public async Task <bool> Delete(int id)
        {
            bool status = await _deliverysrv.Delete(id);
            return status;
        }
    }
}