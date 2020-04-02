using System.Collections.Generic;

namespace ann_web.Models.DeliverySave
{
  public class SuggestionStreetResponseModel
  {
    public bool more { get; set; }
    public List<SuggetionStreetResponseItemModel> items { get; set; }
  }
}