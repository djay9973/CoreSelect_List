using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreSelect_List.Data;
using CoreSelect_List.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreSelect_List.ViewModel
{
    public class CustomerCreateModel
    {
        public Customer Customer { get; set;}
        public IEnumerable<SelectListItem> Countries { get; set;}
        public IEnumerable<SelectListItem> Cities { get; set;}
    }
}
