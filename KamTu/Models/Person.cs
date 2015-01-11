using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KamTu.Models
{
    [Table("Person")]
    public abstract class Person
    {
        public int PersonId { set; get; }
        public string Name { set; get; }
        public string eMail { set; get; }

        public int CommunityId { set; get; }

        public virtual Community Community { set; get; }



        public Person()
        {
            // TODO: Complete member initialization
        }
    }
}