using MyMechanic.Domain;
using FluentNHibernate.Mapping;

namespace MyMechanic.DataNHibernate.Mappings
{
    public class MechanicMap : ClassMap<Mechanic>
    {
        public MechanicMap()
        {
            Schema("dbo");
            Table("Mechanics");

            Id(x => x.Id);

            Map(x => x.UserName)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
            Map(x => x.CompanyName)
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
            HasMany(x => x.Inspections)
               .Access.CamelCaseField(Prefix.Underscore)
               .Inverse()
               .Cascade.AllDeleteOrphan();

        }
    }
}
