using System.ComponentModel.DataAnnotations;

public class DeliverySaveSuggestionStreetModel {

    public int provinceId {get; set;}
    public int districtId {get; set;}
    [Required(ErrorMessage = "Product name is required")]
    public string term {get; set;}
}