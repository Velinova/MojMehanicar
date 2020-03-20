using System;
using MyMechanic.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMechanic.Domain
{
    public enum InspectionStatus{
        PENDING = -1,
        IN_PROGRESS = 0,
        DONE = 1
    }
    public class TechnicalInspection
    {
        private readonly Guid _id = default;
        private Mechanic _mechanic;
        private Vehicle _vehicle;
        private User _user;
        private string _userNote;
        private string _mechanicNote;
        private InspectionStatus _status;
        private int _rating;

        #region Constructors

        public TechnicalInspection() { }
    
        public TechnicalInspection(Mechanic mechanic, Vehicle vehicle, User user,string userNote)
        {
            _mechanic = mechanic;
            _vehicle = vehicle;
            _user = user;
            _userNote = userNote;
            _mechanicNote = String.Empty;
            _status = InspectionStatus.PENDING;
            _rating = 0;
        }
        #endregion

        #region Properties
        public virtual Guid Id
        {
            get { return _id; }
        }
        public virtual Mechanic Mechanic
        {
            get { return _mechanic; }
            set { _mechanic = value; }
        }
        public virtual Vehicle Vehicle
        {
            get { return _vehicle; }
            set { _vehicle = value; }
        }
        public virtual User User
        {
            get { return _user; }
            set { _user = value; }
        }
        public virtual string UserNote
        {
            get { return _userNote;}
            set { _userNote = value; }
        }
        public virtual string MechanicNote
        {
            get { return _mechanicNote; }
            set { _mechanicNote = value; }
        }
        public virtual InspectionStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public virtual int Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        #endregion
    }
}
