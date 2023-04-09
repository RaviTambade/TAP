using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceApp.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class ShippersController : ControllerBase

    {
        private readonly IShipperService _shippersrv;
        public ShippersController(IShipperService shippersrv)
        {
            _shippersrv = shippersrv;
        }

        [HttpGet]
        [Route("getallshippers")]
        public IEnumerable<Shipper> GetAllShippers()
        {
            List<Shipper> shippers = _shippersrv.GetAll();
            return shippers;
        }

        [HttpGet]
        [Route("/getshipperdetails/{id}")]
        public Shipper GetById(int id)
        {
            Shipper shipper = _shippersrv.GetById(id);
            return shipper;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("/update/{id}")]
        public bool Update( int id,[FromBody] Shipper shipper)
        {
            Shipper oldShipper = _shippersrv.GetById(id);
            if(oldShipper.ShipperId==0){
                return false;
            }
            shipper.ShipperId=id;
            bool status = _shippersrv.Update(shipper);
            return status;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("/addshipper/")]
        public bool Insert([FromBody] Shipper shipper)
        {
            bool status = _shippersrv.Insert(shipper);
            return status;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("/delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _shippersrv.Delete(id);
            return status;
        }
    }
}