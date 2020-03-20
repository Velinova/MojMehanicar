using System;
using MyMechanic.Business.Models;
using MyMechanic.Domain;

namespace MyMechanic.Business.Mappers
{
    public static class MechanicMapper
    {
        public static ListMechanicGridViewModel MapToListViewModel(this Mechanic mechanic)
        {
            var model = new ListMechanicGridViewModel();
            model.Id = mechanic.Id;
            model.CompanyName = mechanic.CompanyName;
            model.InspectionsCount = mechanic.Inspections.Count;
            var ratings = 0;
            var sumrating = 0;
            for (int i=0; i<mechanic.Inspections.Count; i++)
            {
                if (mechanic.Inspections[i].Rating != 0)
                {
                    ratings++;
                    sumrating += mechanic.Inspections[i].Rating;
                }
            }
            model.RatingCount = ratings;
            if(ratings == 0){
                model.AverageRating = 0;
            }
            else{
                model.AverageRating = sumrating / ratings;
            }

            return model;
        }
        public static MechanicViewModel MapToViewModel(this Mechanic mechanic)
        {
            var model = new MechanicViewModel();
            model.Id = mechanic.Id;
            model.UserName = mechanic.UserName;
            model.Password = mechanic.Password;
            model.Email = mechanic.Email;
            model.CompanyName = mechanic.CompanyName;
            model.City = mechanic.City;
            model.Country = mechanic.Country;
            model.Address = mechanic.Address;
            model.PostalCode = mechanic.PostalCode;
            return model;
        }
        public static MechanicGridViewModel MapToGridViewModel(this Mechanic mechanic)
        {
            var model = new MechanicGridViewModel();
            model.Id = mechanic.Id;
            model.UserName = mechanic.UserName;
            model.Email = mechanic.Email;
            model.CompanyName = mechanic.CompanyName;
            model.City = mechanic.City;
            model.Country = mechanic.Country;
            model.Address = mechanic.Address;
            return model;
        }

    }
}
