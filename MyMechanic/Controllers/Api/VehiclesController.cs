using MyMechanic.Business.Models;
using MyMechanic.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace MyMechanic.Controllers.Api
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost]
        public ActionResult Create(CreateVehicleViewModel model)
        {
            if (!ModelState.IsValid)
                return Json("Invalid Model");
            var vehicle = _vehicleService.Create(model);

            return Json(vehicle);
        }
        [HttpPost]
        public ActionResult Update(UpdateVehicleViewModel model)
        {
            if (!ModelState.IsValid)
                return Json("Invalid Model");
            _vehicleService.Update(model);

            return Json(true);
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            _vehicleService.Delete(id);

            return Json(true);
        }
        [HttpPost]
        public ActionResult GetById(Guid id)
        {
            var vehicle = _vehicleService.GetById(id);

            return Json(vehicle);
        }
        [HttpPost]
        public ActionResult GetAll()
        {
            var vehicles = _vehicleService.GetAll();

            return Json(vehicles);
        }
    }
}