//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Animax
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category_Product
    {
        public int category_id { get; set; }
        public int product_id { get; set; }
        public long id { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
