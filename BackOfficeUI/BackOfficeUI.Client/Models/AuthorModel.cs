using System.ComponentModel.DataAnnotations;

namespace BackOfficeUI.Client.Models;

public class AuthorModel
{
    [DataType(DataType.Text)]
    [Display(Name = "Name", Prompt = "Enter author name")]
    public string Name { get; set; } = "";

    [DataType(DataType.Text)]
    [Display(Name = "Image Url", Prompt = "Enter author image url")]
    public string AuthorImageUri { get; set; } = "";
}