using System.ComponentModel.DataAnnotations;

namespace ann_web.Models.DeliverySave
{
  public class RegisterOrderOrderModel
  {
    #region Thông tin người gửi
    [Required(ErrorMessage = "Order ID is required")]
    public string id { get; set; }
    [Required(ErrorMessage = "Order Pick Name is required")]
    public string pick_name { get; set; }
    public int pick_money { get; set; }
    public string pick_address_id { get; set; }
    [Required(ErrorMessage = "Order Pick Address is required")]
    public string pick_address { get; set; }
    [Required(ErrorMessage = "Order Pick Province is required")]
    public string pick_province { get; set; }
    [Required(ErrorMessage = "Order Pick District is required")]
    public string pick_district { get; set; }
    public string pick_ward { get; set; }
    public string pick_street { get; set; }
    [Required(ErrorMessage = "Order Pick Tel is required")]
    public string pick_tel { get; set; }
    public string pick_email { get; set; }
    #endregion

    #region Thông tin người nhận
    [Required(ErrorMessage = "Order Name is required")]
    public string name { get; set; }
    [Required(ErrorMessage = "Order Address is required")]
    public string address { get; set; }
    [Required(ErrorMessage = "Order Province is required")]
    public string province { get; set; }
    [Required(ErrorMessage = "Order District is required")]
    public string district { get; set; }
    public string ward { get; set; }
    public string street { get; set; }
    [Required(ErrorMessage = "Order Tel is required")]
    public string tel { get; set; }
    public string note { get; set; }
    public string email { get; set; }
    #endregion

    #region Thông tin điểm trả hàng
    public int? use_return_address { get; set; }
    public string return_name { get; set; }
    public string return_address { get; set; }
    public string return_province { get; set; }
    public string return_district { get; set; }
    public string return_ward { get; set; }
    public string return_street { get; set; }
    public string return_tel { get; set; }
    public string return_email { get; set; }
    #endregion

    #region Các thông tin thêm
    public int? is_freeship { get; set; }
    public string weight_option { get; set; }
    public double? total_weight { get; set; }
    public int? pick_work_shift { get; set; }
    public int? deliver_work_shift { get; set; }
    public string label_id { get; set; }
    public string pick_date { get; set; }
    public string deliver_date { get; set; }
    public string expired { get; set; }
    public int? value { get; set; }
    public int? opm { get; set; }
    public string pick_option { get; set; }
    public string actual_transfer_method { get; set; }
    public string transport { get; set; }
    #endregion
  }
}