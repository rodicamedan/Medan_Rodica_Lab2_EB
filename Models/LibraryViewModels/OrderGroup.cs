using System;
using System.ComponentModel.DataAnnotations;
namespace Medan_Rodica_Lab2_EB.Models.LibraryViewModels
{
    public class OrderGroup
    {
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public int BookCount { get; set; }

    }
}