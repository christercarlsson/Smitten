using System;
using System.ComponentModel.DataAnnotations;

namespace Smitten.Api.ViewModels
{
    public class SmiteCreateDto
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
