using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelperMethods.Models
{
    [DisplayName("New Person")]
    public partial class PersonMetadata
    {
        [HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }

        [DisplayName("姓")]
        public string FirstName { get; set; }

        [DisplayName("名")]
        public string LastName { get; set; }

        [DisplayName("出生日期")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Approved")]
        public bool IsApproved { get; set; }

        [UIHint("Enum")]
        public Role Role { get; set; }
    }
}