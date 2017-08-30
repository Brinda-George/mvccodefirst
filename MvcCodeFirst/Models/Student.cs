using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirst.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Remote("IsValidName","Student",ErrorMessage="Name Already exists")]
        public string Name { get; set; }
        public string Email { get; set; }
        public int departmentId { get; set; }
    }
}