using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EmployeeRecord.Models;

namespace EmployeeRecord.ViewModel
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }
        public string ContactNo { get; set; }
        public List<tblEducation> EducationDetails { get; set; }
        public virtual tblEducation Education { get; set; }
    }
}