using System.ComponentModel.DataAnnotations;

namespace BackOfficeUI.Models
{
    public class CreateCourseModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Title", Prompt = "Enter course title")]
        public string Title { get; set; } = null!;

        [DataType(DataType.Text)]
        [Display(Name = "Description", Prompt = "Enter a description")]
        public string? Description { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Ingress", Prompt = "Enter an ingress")]
        public string? Ingress { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Hours", Prompt = "Enter hours of content")]
        public string? Hours { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Price", Prompt = "Enter the price")]
        public string? Price { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Currency", Prompt = "Enter the currency")]
        public string? Currency { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "ImageUri", Prompt = "Enter the ImageUri")]
        public string? ImageUri { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "ImageHeaderUri", Prompt = "Enter the ImageUri of the header")]
        public string? ImageHeaderUri { get; set; }

        [Display(Name = "Is digital")]
        public bool IsDigital { get; set; } = false;
    }
}
