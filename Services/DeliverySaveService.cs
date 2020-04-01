using Newtonsoft.Json;
using System;  
using System.IO;
using System.Net;

class DeliverySaveService {
    private String _token;

    public DeliverySaveService() {
        _token = "25afFFFE67Be86FFEB81C1CC4cC7Acd386263A73";
    }

    public DeliverySaveSuggestionStreetResponseModel suggestionStreet(DeliverySaveSuggestionStreetModel data) {
        // Init token
        var headers = new WebHeaderCollection();
        headers.Add("Token", _token);


        // Create url
        var url = "https://khachhang.giaohangtietkiem.vn/khach-hang/services/tim-dia-chi?";
        url += String.Format("&provinceId={0}", data.provinceId);
        url += String.Format("&districtId={0}", data.districtId);
        url += String.Format("&term={0}", Uri.EscapeDataString(data.term));

        // Excute API
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.Headers = headers;

        var response = (HttpWebResponse)request.GetResponse();

        if (response != null && response.StatusCode == HttpStatusCode.OK) 
        {
            using (var reader = new StreamReader(response.GetResponseStream())) 
            {
                var result = JsonConvert.DeserializeObject<DeliverySaveSuggestionStreetResponseModel>(reader.ReadToEnd());

                return result;
            }
        }

        return null;
    }
    public DeliverySaveCalculateFeeResponseModel calculateFee(DeliverySaveCalculateFeeModel data) {
        // Init token
        var headers = new WebHeaderCollection();
        headers.Add("Token", _token);
        
        // Create url
        var url = "https://services.giaohangtietkiem.vn/services/shipment/fee?";
        // pick_address_id
        if (String.IsNullOrEmpty(data.pick_address_id))
            url += String.Format("&pick_address_id={0}", data.pick_address_id);
        // pick_address
        if (String.IsNullOrEmpty(data.pick_address))
            url += String.Format("&pick_address={0}", Uri.EscapeDataString(data.pick_address));
        // pick_province
        url += String.Format("&pick_province={0}", Uri.EscapeDataString(data.pick_province));
        // pick_district
        url += String.Format("&pick_district={0}", Uri.EscapeDataString(data.pick_district));
        // pick_ward
        if (String.IsNullOrEmpty(data.pick_ward))
            url += String.Format("&pick_ward={0}", Uri.EscapeDataString(data.pick_ward));
        // pick_street
        if (String.IsNullOrEmpty(data.pick_street))
            url += String.Format("&pick_street={0}", Uri.EscapeDataString(data.pick_street));
        // address
        if (!String.IsNullOrEmpty(data.address))
            url += String.Format("&address={0}", Uri.EscapeDataString(data.address));
        // province
        url += String.Format("&province={0}", Uri.EscapeDataString(data.province));
        // district
        url += String.Format("&district={0}", Uri.EscapeDataString(data.district));
        // ward
        if (String.IsNullOrEmpty(data.ward))
            url += String.Format("&ward={0}", Uri.EscapeDataString(data.ward));
        // street
        if (String.IsNullOrEmpty(data.street))
            url += String.Format("&ward={0}", Uri.EscapeDataString(data.street));
        url += String.Format("&weight={0}", data.weight.Value);
        if (data.value.HasValue)
            url += String.Format("&value={0}", data.value.Value);
        if (!String.IsNullOrEmpty(data.transport))
            url += String.Format("&transport={0}", data.transport);

        // Excute API
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.Headers = headers;

        var response = (HttpWebResponse)request.GetResponse();

        if (response != null && response.StatusCode == HttpStatusCode.OK) 
        {
            using (var reader = new StreamReader(response.GetResponseStream())) 
            {
                var result = JsonConvert.DeserializeObject<DeliverySaveCalculateFeeResponseModel>(reader.ReadToEnd());

                return result;
            }
        }

        return null;
    }
}