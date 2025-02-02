﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using TBC.Common.Resources;
using TBC.Domain.Enums;

namespace TBC.Application.Features.Persons.Commands.CreatePerson
{
    /// <summary>
    /// Persons Create Model 
    /// </summary>
    public class CreatePersonModel
    {
        /// <summary>
        /// Firstname
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "FirstName")]
        public string FirstName { get; set; }


        /// <summary>
        /// Lastname
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "LastName")]
        public string LastName { get; set; }


        /// <summary>
        /// Personal Number
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "PersonalNumber")]
        public string PersonalNumber { get; set; }

        /// <summary>
        /// Date of Birth
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "BirthDate")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Person Gender
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "Gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Person Image
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "Image")]
        public IFormFile Image { get; set; }

        /// <summary>
        /// The Id of the City of the Person
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "CityId")]
        public int CityId { get; set; }

    }
}
