using System;
using MyMechanic.Business.Models;
using MyMechanic.Domain;

namespace MyMechanic.Business.Mappers
{
    public static class TechnicalInspectionMapper
    {
        public static TechnicalInspectionViewModel MapToViewModel(this TechnicalInspection inspection)
        {
            var model = new TechnicalInspectionViewModel();
            model.Id = inspection.Id;
            model.Mechanic = inspection.Mechanic.MapToViewModel();
            model.Vehicle = inspection.Vehicle.MapToViewModel();
            model.UserNote = inspection.UserNote;
            model.MechanicNote = inspection.MechanicNote;
            model.Status = inspection.Status;
            model.Rating = inspection.Rating;
            return model;
        }
        public static TechnicalInspectionGridViewModel MapToGridViewModel(this TechnicalInspection inspection)
        {
            var model = new TechnicalInspectionGridViewModel();
            model.Id = inspection.Id;
            model.MechanicName = inspection.Mechanic.CompanyName;
            model.VehicleOwner = inspection.Vehicle.Owner.Name;
            model.Status = inspection.Status.ToString();
            model.Rating = inspection.Rating;
            model.VehicleLicense = inspection.Vehicle.License;

            return model;
        }

    }
}
