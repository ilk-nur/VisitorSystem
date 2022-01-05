using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorSystem.Shared.Entities.Abstract
{
   public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        //Verdiğimiz bu base değerlerin diğer sınıflarda değişkliğe uğraması gerekebilir o yüzden abstract tanımlıyoruz.
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;//override DateTime CreatedDate=new DateTime(2020/01/01);
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual string CreatedByName { get; set; } = "Admin";

        public virtual string ModifiedByName { get; set; } = "Admin";
        
    }
}
