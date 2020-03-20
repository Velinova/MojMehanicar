using System;
using MyMechanic.Business.Models;
using MyMechanic.Domain;

namespace MyMechanic.Business.Mappers
{
    public static class VehicleMapper
    {
        public static VehicleViewModel MapToViewModel(this Vehicle vehicle)
        {
            var model = new VehicleViewModel();
            model.Id = vehicle.Id;
            model.Type = vehicle.Type;
            model.Owner = vehicle.Owner.MapToViewModel();
            model.Model = vehicle.Model;
            model.License = vehicle.License;
            return model;
        }
        public static VehicleGridViewModel MapToGridViewModel(this Vehicle vehicle)
        {
            var model = new VehicleGridViewModel();
            model.Id = vehicle.Id;
            model.License = vehicle.License;
            model.Model = vehicle.Model;
            model.Type = vehicle.Type.ToString();
            model.OwnerName = vehicle.Owner.Name;
            model.InspectionsCount = vehicle.Inspections.Count;
            return model;
        }

    }
}
