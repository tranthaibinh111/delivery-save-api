
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ann_web.Models.DeliverySave
{
  public class RegisterOrderModel
  {
    [Required(ErrorMessage = "Product List is required")]
    public List<RegisterOrderProductModel> products { get; set; }
    [Required(ErrorMessage = "Order is required")]
    public RegisterOrderOrderModel order { get; set; }
  }
}