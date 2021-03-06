﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelperMethods.Models
{
    [DisplayName("New Person")]
    [MetadataType(typeof(PersonMetadata))]
    public partial class Person
    {
        [HiddenInput(DisplayValue =false)]
        public int PersonId { get; set; }

        [DisplayName("姓")]
        public string FirstName { get; set; }

        [DisplayName("名")]
        public string LastName { get; set; }

        [DisplayName("出生日期")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public Address HomeAddress { get; set; }

        [Display(Name = "Approved")]
        public bool IsApproved { get; set; }

        [UIHint("Enum")]
        public Role Role { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }
    }

    public enum Role
    {
        Admin,
        User,
        Guest,
    }
}