//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lanit3.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class car
    {
        public long IdC { get; set; }
        public string model { get; set; }
        public int horsepower { get; set; }
        public long Id { get; set; }
    
        public virtual person person { get; set; }
    }
}
