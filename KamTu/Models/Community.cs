using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KamTu.Models
{
    [Table("Community")]
    public class Community
    {
        
        public int CommunityId { set; get; }

        public string Name { set; get; }

        public virtual ICollection<Person> Persons { set; get; }

    }
}