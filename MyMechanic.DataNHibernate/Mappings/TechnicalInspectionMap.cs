using MyMechanic.Domain;
using FluentNHibernate.Mapping;

namespace MyMechanic.DataNHibernate.Mappings
{
    public class TechnicalInspectionMap : ClassMap<TechnicalInspection>
    {
        public TechnicalInspectionMap()
        {
            Schema("dbo");
            Table("TechnicalInspections");

            Id(x => x.Id);
            Map(x => x.UserNote)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.MechanicNote)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Rating)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            References(x => x.Mechanic)
                .Column("MechanicId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            References(x => x.Vehicle)
                .Column("VehicleId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            References(x => x.User)
                .Column("UserId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Status)
                .Column("Status")
                .CustomType<InspectionStatus>()
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
        }
    }
}
