using System.ComponentModel.DataAnnotations;

public class DeliverySaveCalculateFeeModel
{
    public string pick_address_id {get; set;}
    public string pick_address {get; set;}
    [Required(ErrorMessage = "Pick Province is required")]
    public string pick_province { get; set; }
    [Required(ErrorMessage = "Pick District is required")]
    public string pick_district { get; set; }
    public string pick_ward { get; set; }
    public string pick_street {get; set;}
    public string address { get; set; }
    [Required(ErrorMessage = "Province is required")]
    public string province { get; set; }
    [Required(ErrorMessage = "District is required")]
    public string district { get; set; }
    public string ward {get; set;}
    public string street {get; set;}
    [Required(ErrorMessage = "Weight is required")]
    public int? weight { get; set; }
    public int? value { get; set; }
    public string transport { get; set; }
}