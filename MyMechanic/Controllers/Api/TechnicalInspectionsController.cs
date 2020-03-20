using MyMechanic.App_Start;
using MyMechanic.Business.Models;
using MyMechanic.Business.Services;
using System;
using System.Net;
using System.Web.Mvc;

namespace MyMechanic.Controllers.Api
{
    public class TechnicalInspectionsController : Controller
    {
        private readonly ITechnicalInspectionService _inspectionService;

        public TechnicalInspectionsController(ITechnicalInspectionService inspectionService)
        {
            _inspectionService = inspectionService;
        }

        [HttpPost]
        public ActionResult Add(CreateTechnicalInspectionViewModel model)
        {
            var inspection = _inspectionService.Create(model);
            return Json(inspection);
        }

        [HttpPost]
        public ActionResult GetPendingInspections(Guid id)
        {
            var pending = _inspectionService.GetPendingInspections(id);
            return Json(pending);
        }

        [HttpPost]
        public ActionResult GetInProgressInspections(Guid id)
        {
            var inProgress = _inspectionService.GetInProgressInspections(id);
            return Json(inProgress);
        }

        [HttpPost]
        public ActionResult GetDoneInspections(Guid id)
        {
            var done = _inspectionService.GetDoneInspections(id);
            return Json(done);
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            _inspectionService.Delete(id);
            return Json(true);
        }

        [HttpPost]
        public ActionResult GetbyId(Guid id)
        {
            var inspection = _inspectionService.GetById(id);
            return Json(inspection);
        }
        [HttpPost]
        public ActionResult Update(UpdateTechnicalInspectionViewModel model)
        {
            _inspectionService.Update(model);
            return Json(true);
        }
        [HttpPost]
        public ActionResult GetAll()
        {
            var inspections = _inspectionService.GetAll();
            return Json(inspections);
        }
    }
}