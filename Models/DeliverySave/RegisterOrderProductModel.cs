using System.ComponentModel.DataAnnotations;

namespace ann_web.Models.DeliverySave
{
  public class RegisterOrderProductModel
  {
    [Required(ErrorMessage = "Product name is required")]
    public string name { get; set; }
    public int? price { get; set; }
    [Required(ErrorMessage = "Product weight is required")]
    public double weight { get; set; }
    public int? quantity { get; set; }
  }
}