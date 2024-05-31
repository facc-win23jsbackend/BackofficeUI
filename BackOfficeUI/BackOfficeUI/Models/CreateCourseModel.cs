using System.ComponentModel.DataAnnotations;
using BackOfficeUI.Client.Models;

namespace BackOfficeUI.Models
{
    public class CreateCourseModel
    {
        
        
        [DataType(DataType.Text)]
        [Display(Name = "Title", Prompt = "Enter course title")]
        public string Title { get; set; } = null!;
        

        [DataType(DataType.Text)]
        [Display(Name = "Ingress", Prompt = "Enter an ingress")]
        public string? Ingress { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Hours", Prompt = "Enter hours of content")]
        public string? Hours { get; set; }
        

        [DataType(DataType.Text)]
        [Display(Name = "ImageUri", Prompt = "Enter the ImageUri")]
        public string? ImageUri { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "ImageHeaderUri", Prompt = "Enter the ImageUri of the header")]
        public string? ImageHeaderUri { get; set; }

        [Display(Name = "Is digital")]
        public bool IsDigital { get; set; } = false;
        
        [Display(Name = "Is Bestseller")]
        public bool IsBestseller { get; set; }


        public List<string> Categories { get; set; } = [""];
        
        [Display(Name = "Star rating")]
        public decimal StarRating { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Reviews", Prompt = "Enter reviews")]
        public string? Reviews { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Likes in Percent", Prompt = "Enter Likes in Percent")]
        public string? LikesInPercent { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Likes", Prompt = "Enter THEEE likes")]
        public string? Likes { get; set; }
        
        public virtual List<AuthorModel> Authors { get; set; } = [new AuthorModel()];
        public virtual PriceModel Prices { get; set; } = new();
        public virtual ContentModel? Content { get; set; } = new();
    }
}
