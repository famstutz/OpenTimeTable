namespace OpenTimeTable.Client.Models {
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SearchConnection {
        [Required(ErrorMessage = "From is required.")]
        public string From { get; set; }

        [Required(ErrorMessage = "To is required.")]
        public string To { get; set; }

        public string Via { get; set; }

        [DataType(DataType.DateTime)]
        [Required(AllowEmptyStrings = true)]
        public DateTime When { get; set; }
    }
}