//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace primer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Manufacturer_id { get; set; }
        public string Description { get; set; }
        public Nullable<int> Discount { get; set; }
        public string Photo { get; set; }
    
        public virtual Manufacturer Manufacturer { get; set; }
    }
}