using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMechanic.Domain
{
    public enum VehicleType
    {
        CAR=1,
        BUS=2,
        TRAIN=3,
        MOTORCYCLE=4,
        BIKE=5, 
        VAN=6,
    }
   
    public class Vehicle
    {
        private readonly Guid _id = default;
        private VehicleType _type;
        private string _model;
        private string _license;
        private User _owner;
        private IList<TechnicalInspection> _inspections;

        #region Constructors
        public Vehicle() {
            _inspections = new List<TechnicalInspection>();
        }
        public Vehicle (VehicleType type, string model, string license,  User owner) {
            _type = type;
            _model = model;
            _license = license;
            _owner = owner;
            _inspections = new List<TechnicalInspection>();
        }
        #endregion
        //public VehicleType MapToVehicleType(int type)
        //{
        //    switch (type)
        //    {
        //        case 1: return VehicleType.CAR;
        //        case 2: return VehicleType.BUS;
        //        case 3: return VehicleType.TRAIN;
        //        case 4: return VehicleType.MOTORCYCLE;
        //        case 5: return VehicleType.BIKE;
        //        case 6: return VehicleType.VAN;
        //    }
        //    return VehicleType.CAR;
        //}
        #region Properties
        public virtual Guid Id
        {
            get { return _id; }
        }
        public virtual VehicleType Type {
            get { return _type; }
            set { _type = value; }
        }
        public virtual string Model {
            get { return _model; }
            set { _model = value; }
        }
        public virtual string License {
            get { return _license; }
            set { _license = value; }
        }
        public virtual User Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
        public virtual IList<TechnicalInspection> Inspections
        {
            get { return _inspections; }
            set { _inspections = value; }
        }
       
        #endregion

    }
}
