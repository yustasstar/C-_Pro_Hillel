//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseEntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class LECTURE
    {
        public int lecPK { get; set; }
        public Nullable<int> TchFK { get; set; }
        public int GrpFK { get; set; }
        public Nullable<int> SbjFK { get; set; }
        public Nullable<int> RomFK { get; set; }
        public int id_type { get; set; }
        public decimal Week { get; set; }
        public string Day_week { get; set; }
        public Nullable<decimal> Lesson { get; set; }
    
        public virtual SGROUP SGROUP { get; set; }
        public virtual ROOM ROOM { get; set; }
        public virtual SUBJECT SUBJECT { get; set; }
        public virtual TEACHER TEACHER { get; set; }
        public virtual LECTURE_TYPE LECTURE_TYPE { get; set; }
    }
}
