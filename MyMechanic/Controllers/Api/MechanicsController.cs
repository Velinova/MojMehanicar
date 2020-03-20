using MyMechanic.App_Start;
using MyMechanic.Business.Models;
using MyMechanic.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMechanic.Controllers.Api
{
    public class MechanicsController : Controller
    {
        private readonly IMechanicService _mechanicService;

        public MechanicsController(IMechanicService mechanicService)
        {
            _mechanicService = mechanicService;
        }
        [HttpPost]
        public ActionResult GetAll()
        {
            var mechanics = _mechanicService.GetAll();
            return Json(mechanics);
        }
        [HttpPost]
        public ActionResult GetAllList()
        {
            var mechanics = _mechanicService.GetAllList();
            return Json(mechanics);
        }
        [HttpPost]
        public ActionResult GetInspections(Guid id)
        {
            var inspections = _mechanicService.GetInspections(id);
            return Json(inspections);
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            _mechanicService.Delete(id);
            return Json(true);
        }
        [HttpPost]
        public ActionResult Update(UpdateMechanicViewModel model)
        {
            _mechanicService.Update(model);
            return Json(true);
        }

        [HttpPost]
        public ActionResult GetById(Guid id)
        {
            var mechanic = _mechanicService.GetById(id);
            return Json(mechanic);
        }

        [HttpPost]
        public ActionResult RegisterMechanic(RegisterMechanicViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Helpers.InvalidModelState(ModelState);
            }
            var mechanicId = _mechanicService.RegisterMechanic(model);
            return Json(mechanicId);
        }

        [HttpPost]
        public ActionResult SignInMechanic(SignInMechanicViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Helpers.InvalidModelState(ModelState);
            }
            var mechanicId = _mechanicService.SignInMechanic(model);
            return Json(mechanicId);
        }
        [HttpPost]
        public ActionResult GetAverage(Guid id)
        {
           
            var average = _mechanicService.GetAverage(id);
            return Json(average);
        }
    }
}