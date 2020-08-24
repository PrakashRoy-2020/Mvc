using MvcWithAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWithAuth.ViewModel
{
    public class NewCustViewModel
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}