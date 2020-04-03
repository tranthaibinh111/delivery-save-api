using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net;

using ann_web.Models.DeliverySave;

using Newtonsoft.Json;

namespace ann_web.Services
{
  class DeliverySaveService
  {
    private bool _test;
    private string _token;
    private string _tokenDev;

    public DeliverySaveService()
    {
      _test = true;
      _token = "25afFFFE67Be86FFEB81C1CC4cC7Acd386263A73";
      _tokenDev = "93D2dc1B2FE8102d9eB98244aCd7d513D9db6760";
    }

    public SuggestionStreetResponseModel suggestionStreet(SuggestionStreetModel data)
    {
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
          var result = JsonConvert.DeserializeObject<SuggestionStreetResponseModel>(reader.ReadToEnd());

          return result;
        }
      }

      return null;
    }

    public CalculateFeeResponseModel calculateFee(CalculateFeeModel data)
    {
      // Init token
      var headers = new WebHeaderCollection();
      headers.Add("Token", _test ? _tokenDev : _token);

      // Create url
      var url = String.Format("https://{0}/services/shipment/fee?", _test ? "dev.ghtk.vn" : "services.giaohangtietkiem.vn");
      // pick_address_id
      if (!String.IsNullOrEmpty(data.pick_address_id))
        url += String.Format("&pick_address_id={0}", data.pick_address_id);
      // pick_address
      if (!String.IsNullOrEmpty(data.pick_address))
        url += String.Format("&pick_address={0}", Uri.EscapeDataString(data.pick_address));
      // pick_province
      url += String.Format("&pick_province={0}", Uri.EscapeDataString(data.pick_province));
      // pick_district
      url += String.Format("&pick_district={0}", Uri.EscapeDataString(data.pick_district));
      // pick_ward
      if (!String.IsNullOrEmpty(data.pick_ward))
        url += String.Format("&pick_ward={0}", Uri.EscapeDataString(data.pick_ward));
      // pick_street
      if (!String.IsNullOrEmpty(data.pick_street))
        url += String.Format("&pick_street={0}", Uri.EscapeDataString(data.pick_street));
      // address
      if (!String.IsNullOrEmpty(data.address))
        url += String.Format("&address={0}", Uri.EscapeDataString(data.address));
      // province
      url += String.Format("&province={0}", Uri.EscapeDataString(data.province));
      // district
      url += String.Format("&district={0}", Uri.EscapeDataString(data.district));
      // ward
      if (!String.IsNullOrEmpty(data.ward))
        url += String.Format("&ward={0}", Uri.EscapeDataString(data.ward));
      // street
      if (!String.IsNullOrEmpty(data.street))
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
          var result = JsonConvert.DeserializeObject<CalculateFeeResponseModel>(reader.ReadToEnd());

          return result;
        }
      }

      return null;
    }

    public RegisterResponseModel registerOrder(List<RegisterOrderProductModel> products, RegisterOrderOrderModel order)
    {
      // Init token
      var headers = new WebHeaderCollection();
      headers.Add("Token", _test ? _tokenDev : _token);
      headers.Add("Content-Type", "application/json");

      // Create url
      var url = String.Format("https://{0}/services/shipment/order/?ver=1.5", _test ? "dev.ghtk.vn" : "services.giaohangtietkiem.vn");
      // Excute API
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      request.Method = "POST";
      request.Headers = headers;

      using (var streamWriter = new StreamWriter(request.GetRequestStream()))
      {
        dynamic register = new ExpandoObject();

        register.products = products;
        register.order = new ExpandoObject();
        register.order.id = order.id;
        
        #region Thông tin lấy hàng
        register.order.pick_name = order.pick_name;
        register.order.pick_money = order.pick_money;
        if (!String.IsNullOrEmpty(order.pick_address_id))
          register.order.pick_address_id = order.pick_address_id;
        register.order.pick_address = order.pick_address;
        register.order.pick_province = order.pick_province;
        register.order.pick_district = order.pick_district;
        if (!String.IsNullOrEmpty(order.pick_ward))
            register.order.pick_ward = order.pick_ward;
        if (!String.IsNullOrEmpty(order.pick_street))
            register.order.pick_street = order.pick_street;
        register.order.pick_tel = order.pick_tel;
        if (!String.IsNullOrEmpty(order.pick_email))
            register.order.pick_email = order.pick_email;
        #endregion
        
        #region Thông tin điểm giao hàng
        register.order.name = order.name;
        register.order.address = order.address;
        register.order.province = order.province;
        register.order.district = order.district;
        if (!String.IsNullOrEmpty(order.ward))
            register.order.ward = order.ward;
        if (!String.IsNullOrEmpty(order.street))
            register.order.street = order.street;
        register.order.pick_tel = order.pick_tel;
        if (!String.IsNullOrEmpty(order.note))
            register.order.note = order.note;
        if (!String.IsNullOrEmpty(order.email))
            register.order.email = order.email;
        #endregion
        
        #region Thông tin điểm trả hàng
        if (order.use_return_address.HasValue && order.use_return_address.Value != 0) {
            register.order.use_return_address = order.use_return_address.Value;
            register.order.return_name = order.return_name;
            register.order.return_address = order.return_address;
            register.order.return_province = order.return_province;
            register.order.return_district = order.return_district;
            if (!String.IsNullOrEmpty(order.return_ward))
                register.order.return_ward = order.return_ward;
            if (!String.IsNullOrEmpty(order.return_street))
                register.order.return_street = order.return_street;
            register.order.return_tel = order.return_tel;
            if (!String.IsNullOrEmpty(order.return_email))
                register.order.return_email = order.return_email;
        }
        #endregion

        #region Các thông tin thêm
        if (order.is_freeship.HasValue)
            register.order.is_freeship = order.is_freeship.Value;
        if (!String.IsNullOrEmpty(order.weight_option))
            register.order.weight_option = order.weight_option;
        if (order.total_weight.HasValue)
            register.order.total_weight = order.total_weight;
        if (order.pick_work_shift.HasValue)
            register.order.pick_work_shift = order.pick_work_shift.Value;
        if (order.deliver_work_shift.HasValue)
            register.order.deliver_work_shift = order.deliver_work_shift;
        if (!String.IsNullOrEmpty(order.label_id))
            register.order.label_id = order.label_id;
        if (!String.IsNullOrEmpty(order.pick_date))
            register.order.pick_date = order.pick_date;
        if (!String.IsNullOrEmpty(order.deliver_date))
            register.order.deliver_date = order.deliver_date;
        if (!String.IsNullOrEmpty(order.expired))
            register.order.expired = order.expired;
        if (order.value.HasValue)
            register.order.value = order.value;
        if (order.opm.HasValue)
            register.order.opm = order.opm;
        if (!String.IsNullOrEmpty(order.pick_option))
            register.order.pick_option = order.pick_option;
        if (!String.IsNullOrEmpty(order.actual_transfer_method))
            register.order.actual_transfer_method = order.actual_transfer_method;
        if (!String.IsNullOrEmpty(order.transport))
            register.order.transport = order.transport;
        #endregion

        string json = JsonConvert.SerializeObject(register);
        streamWriter.Write(json);
      }

      var response = (HttpWebResponse)request.GetResponse();

      if (response != null && response.StatusCode == HttpStatusCode.OK)
      {
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
          var result = JsonConvert.DeserializeObject<RegisterResponseModel>(reader.ReadToEnd());

          return result;
        }
      }

      return null;
    }

  }
}