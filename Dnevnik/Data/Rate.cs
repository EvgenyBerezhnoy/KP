//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dnevnik.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rate
    {
        public int ID { get; set; }
        public int SubjectCode { get; set; }
        public int StudentCode { get; set; }
        public int Mark { get; set; }
    
        public virtual Students Students { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
