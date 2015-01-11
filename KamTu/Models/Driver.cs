using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KamTu.Models
{   
    [Table("Driver")]
    public class Driver : Person
    {
        public string Origin { set; get; }

    }
}