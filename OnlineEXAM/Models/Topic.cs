//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineEXAM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Topic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Topic()
        {
            this.QuestionSets = new HashSet<QuestionSet>();
        }
    
        public int Topic_id { get; set; }
        public string TopicName { get; set; }
        public int MainCateogryID { get; set; }
        public int Subject_id { get; set; }
    
        public virtual maincateogry maincateogry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionSet> QuestionSets { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
