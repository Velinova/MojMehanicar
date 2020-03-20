using System;
using System.Collections.Generic;

namespace MyMechanic.Domain
{
    public class Mechanic
    {
        private readonly Guid _id = default;
        private string _userName;
        private string _email;
        private string _password;
        private string _companyName;
        private string _city;
        private string _country;
        private string _postalCode;
        private string _address;
        private IList<TechnicalInspection> _inspections;
        public virtual Guid Id
        {
            get { return _id; }
        }

        public virtual string UserName
        {
            get {return _userName; }
            set {_userName = value; }
        }
        public virtual string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public virtual string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public virtual string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        
        public virtual string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public virtual string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public virtual string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }
        public virtual string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public virtual IList<TechnicalInspection> Inspections
        {
            get { return _inspections; }
            set { _inspections = value; }
        }
        
        #region Constructors
        public Mechanic()
        {
            _inspections = new List<TechnicalInspection>();
        }
        public Mechanic(string UserName, string Password, string Email, string CompanyName,  string City, string Country, string PostalCode, string Adress) {
            _userName = UserName;
            _email = Email;
            _password = Password;
            _companyName = CompanyName;
            _city = City;
            _country = Country;
            _address = Adress;
            _postalCode = PostalCode;
            _inspections = new List<TechnicalInspection>();

        }
        #endregion
    }

}
