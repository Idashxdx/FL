//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlowerSmell
{
    using System;
    using System.Collections.Generic;
    
    public partial class Range
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Range()
        {
            this.Sales = new HashSet<Sales>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public int ID_TypePerfume { get; set; }
        public int ID_Brend { get; set; }
        public int ID_Volume { get; set; }
        public decimal Price { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public byte[] Image { get; set; }
    
        public virtual Brend Brend { get; set; }
        public virtual TypeParfume TypeParfume { get; set; }
        public virtual Volume Volume { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
