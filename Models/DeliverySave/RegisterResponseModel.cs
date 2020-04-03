namespace ann_web.Models.DeliverySave
{
  public class RegisterResponseModel
  {
    public bool success { get; set; }
    public string message { get; set; }
    public RegisterResponseOrderModel order { get; set; }
    public RegisterResponseErrorModel error { get; set; }
  }
}