using System.Collections.Generic;

namespace ann_web.Models.DeliverySave
{
  public class RegisterResponseOrderModel
  {
    public string partner_id { get; set; }
    public string label { get; set; }
    public string area { get; set; }
    public string fee { get; set; }
    public string insurance_fee { get; set; }
    public string estimated_pick_time { get; set; }
    public string estimated_deliver_time { get; set; }
    public List<RegisterOrderProductModel> products { get; set; }
    public int status_id { get; set; }
  }
}
