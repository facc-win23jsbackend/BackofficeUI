using BackOfficeUI.Client.Components.Courses;
using BackOfficeUI.Client.Models;

namespace BackOfficeUI.Models;

public class ContentModel
{
    public string? Description { get; set; }
    public List<string> Includes { get; set; } = [""];
    public List<string> Learn { get; set; } = [""];
    public virtual List<ProgramDetailModel> ProgramDetails { get; set; } = [new ProgramDetailModel()];
}