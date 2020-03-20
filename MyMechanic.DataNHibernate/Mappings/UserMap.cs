using MyMechanic.Domain;
using FluentNHibernate.Mapping;

namespace MyMechanic.DataNHibernate.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Schema("dbo");
            Table("Users");

            Id(x => x.Id);
            Map(x => x.UserName)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
            Map(x => x.Name)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
            Map(x => x.Surname)
               .Access.CamelCaseField(Prefix.Underscore)
               .Not.Nullable();
            Map(x => x.Email)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
            Map(x => x.Password)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
            Map(x => x.City)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
            Map(x => x.Country)
               .Access.CamelCaseField(Prefix.Underscore)
               .Not.Nullable();
            Map(x => x.PostalCode)
               .Access.CamelCaseField(Prefix.Underscore)
               .Not.Nullable();
            Map(x => x.Address)
               .Access.CamelCaseField(Prefix.Underscore)
               .Not.Nullable();
            Map(x => x.Role)
                .CustomType<UserRole>()
               .Access.CamelCaseField(Prefix.Underscore)
               .Not.Nullable();
            HasMany(x => x.Vehicles)
                .Access.CamelCaseField(Prefix.Underscore)
                .Inverse()
                .Cascade.AllDeleteOrphan();
            
        }
    }
}
