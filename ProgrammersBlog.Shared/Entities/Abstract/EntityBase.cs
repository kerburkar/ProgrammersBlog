using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Entities.Abstract
{
    //abstract olma sebebi; verdiğimiz base değerlerin diğer sınıflarda değişikliğe uğramasını isteyebiliriz.
   public abstract class EntityBase
    {
        public virtual int Id { get; set; }

        //oluşturulma tarihi.
        public virtual DateTime DateTime { get; set; } = DateTime.Now; // kendimiz tarih vermek istediğimizde; ovveride CreatedDate = new DateTime(2022/01/07);
        
        //tarihimizi güncellemek/düzeltmek için.
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;

        //entity'de silinip silinmediğinin kontrolü için.
        public virtual bool IsDeleted { get; set; } = false;

        //aktifliği kontrol etmek için.
        public virtual bool IsActive { get; set; } = true;

        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual string ModifiedByName { get; set; } = "Admin";

        //yorum tutmak için.
        public virtual string Note { get; set; }

    }

}
