using System.ComponentModel.DataAnnotations;

namespace ann_web.Models.DeliverySave
{
  public class SuggestionStreetModel
  {

    public int provinceId { get; set; }
    public int districtId { get; set; }
    [Required(ErrorMessage = "Product name is required")]
    public string term { get; set; }
  }
}