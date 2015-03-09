using Incoding.Data;
namespace Test.UI.Operations.Entity
{
    public class User : IncEntityBase
    {
        public new virtual string Id { get; set; }
        public virtual string Sername { get; set; }
        public virtual string Name { get; set; }
        public virtual string FatherName { get; set; }

        public class UserMap : NHibernateEntityMap<User>
        {
            protected UserMap()
            {
                Table("Users");
                IdGenerateByGuid(r => r.Id);
                Map(r => r.Sername);
                Map(r => r.Name);
                Map(r => r.FatherName);
            }
        }
    }
}