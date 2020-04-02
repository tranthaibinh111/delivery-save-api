namespace ann_web.Models.DeliverySave
{
  public class CalculateFeeResponseModel
  {
    public bool success { get; set; }
    public string message { get; set; }
    public CalculateFeeResponseFeeModel fee { get; set; }
  }
}
