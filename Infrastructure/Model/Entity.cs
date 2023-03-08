using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public abstract class Entity:IEntity
    {
        public virtual int ID { get; set; }

        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual DateTime? DeletedDate { get; set; }

        public virtual bool IsDeleted { get; set; }
    }
}
