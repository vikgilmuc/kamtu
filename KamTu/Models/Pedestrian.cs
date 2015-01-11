using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KamTu.Models
{
    [Table("Pedestrian")]
    public class Pedestrian : Person
    {
        public string Origin { set; get; }
    }
}