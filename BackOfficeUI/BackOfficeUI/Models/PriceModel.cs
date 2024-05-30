using System.ComponentModel.DataAnnotations;

namespace BackOfficeUI.Models;

public class PriceModel
{
    [DataType(DataType.Text)]
    [Display(Name = "Currency", Prompt = "Enter Currency")]
    public string? Currency { get; set; }
    [DataType(DataType.Text)]
    [Display(Name = "Price", Prompt = "Enter Price")]
    public decimal Price { get; set; }
    [DataType(DataType.Text)]
    [Display(Name = "Discount", Prompt = "Enter Discount")]
    public decimal Discount { get; set; }
}