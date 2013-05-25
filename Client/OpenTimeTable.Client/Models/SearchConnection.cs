using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace OpenTimeTable.Client.Models
{
    public class SearchConnection
    {
        [Required(ErrorMessage = "From is required.")]
        public string From { get; set; }
        [Required(ErrorMessage = "To is required.")]
        public string To { get; set; }
        public string Via { get; set; }

        [DataType(DataType.DateTime)]
        [Required(AllowEmptyStrings = true)]
        public DateTime When { get; set; }

        public SearchConnection() {
            this.When = DateTime.Now;
        }
        }
}