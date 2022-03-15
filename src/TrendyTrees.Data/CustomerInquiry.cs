using System;
using System.ComponentModel.DataAnnotations;

namespace TrendyTrees.Data
{
    public class CustomerInquiry
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string InquiryText { get; set; }

        public string IpAddress { get; set; }
        
        [Required]
        public DateTime InquiryDate { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

    }
}