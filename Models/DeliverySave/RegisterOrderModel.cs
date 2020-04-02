
using System.Collections.Generic;

namespace ann_web.Models.DeliverySave
{
  public class RegisterOrderModel
  {
    public List<RegisterOrderProductModel> products { get; set; }
    public RegisterOrderOrderModel order { get; set; }
  }
}