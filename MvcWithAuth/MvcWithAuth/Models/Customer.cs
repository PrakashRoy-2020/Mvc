using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWithAuth.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //annotations
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        public bool IsSubscribed { get; set; }
        //cng it to datetime
        public string DOB { get; set; }
        //foreign key
        public MemberShipType MemberShipType { get; set; }
        public int MemberShipTypeId { get; set; }
    }
}