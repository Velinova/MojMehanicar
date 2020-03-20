using MyMechanic.Domain;
using FluentNHibernate.Mapping;

namespace MyMechanic.DataNHibernate.Mappings
{
    public class VehicleMap : ClassMap<Vehicle>
    {
        public VehicleMap()
        {
            Schema("dbo");
            Table("Vehicle");

            Id(x => x.Id)
                .Column("Id")
                .Access.CamelCaseField(Prefix.Underscore);

            Map(x => x.Type)
                .Column("Type")
                .CustomType<VehicleType>()
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Model)
                .Column("Model")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.License)
                .Column("License")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            HasMany(x => x.Inspections)
              .Access.CamelCaseField(Prefix.Underscore)
              .Inverse()
              .Cascade.AllDeleteOrphan();

            References<User>(x => x.Owner).
                Column("OwnerId")
                .Nullable()
                .Access.CamelCaseField(Prefix.Underscore);

           
        }
    }
}
