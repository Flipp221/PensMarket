//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PensMarket
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id_Order { get; set; }
        public Nullable<int> id_Customer { get; set; }
        public Nullable<int> id_Pen { get; set; }
        public Nullable<System.DateTime> DateOrder { get; set; }
        public Nullable<bool> Buy_Done { get; set; }
        public string PriceOrder { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Pen Pen { get; set; }
    }
}