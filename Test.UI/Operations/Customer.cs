namespace Test.UI.Operations
{
    #region << Using >>

    //using System;
    using Incoding.Data;

    #endregion

    public class Customer : IncEntityBase
    {
        public new virtual string Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

      

        public class Map : NHibernateEntityMap<Customer>
        {
            protected Map()
            {
                Table("Customer");
                IdGenerateByGuid(r => r.Id);
                Map(r => r.Name);
                Map(r => r.Surname);
                
            }
        }
    }
}