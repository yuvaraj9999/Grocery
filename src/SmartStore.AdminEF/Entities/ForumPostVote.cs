//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartStore.AdminEF.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ForumPostVote
    {
        public int Id { get; set; }
        public int ForumPostId { get; set; }
        public bool Vote { get; set; }
    
        public virtual CustomerContent CustomerContent { get; set; }
        public virtual Forums_Post Forums_Post { get; set; }
    }
}