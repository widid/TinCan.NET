//Added by david@widid.fr for the account of WiDiD SAS
//Last modified 02/02/2024
using System;
using TinCan.Json;
using Newtonsoft.Json.Linq;

namespace TinCan
{
    public class Attachment : JsonModel
    {
        public Uri usageType { get; set; }
        public LanguageMap display { get; set; }
        public LanguageMap description { get; set; }
        public string contentType { get; set; }
        public long length { get; set; } 
        public string sha2 { get; set; }
        public Uri fileUrl { get; set; }

        public Attachment() :base() {}

        public Attachment(StringOfJSON json):this(json.toJObject()) {}

        public Attachment(JObject jobj)
        {
            if (jobj["usageType"] != null)
            {
                usageType = new Uri(jobj.Value<String>("usageType"));
            }
            if (jobj["display"] != null)
            {
                display = (LanguageMap)jobj.Value<JObject>("display");
            }
            if (jobj["description"] != null)
            {
                description = (LanguageMap)jobj.Value<JObject>("description");
            }
            if (jobj["contentType"] != null)
            {
                contentType = jobj.Value<string>("contentType");
            }
            if (jobj["length"] != null)
            {
                length = jobj.Value<long>("length");
            }
            if (jobj["sha2"] != null)
            {
                sha2 = jobj.Value<string>("sha2");
            }
            if (jobj["fileUrl"] != null)
            {
                fileUrl = new Uri(jobj.Value<String>("fileUrl"));
            }
        }

        public override JObject ToJObject(TCAPIVersion version)
        {
            JObject result = new JObject();

            if(usageType!= null)
            {
                result.Add("usageType",usageType.ToString());
            }

            if(display!= null)
            {
                result.Add("display", display.ToJObject(version));
            }
            if(description!= null)
            {
                result.Add("description",description.ToJObject(version));
            }
            if(contentType!= null)
            {
                result.Add("contentType",contentType.ToString());
            }
            if(length>0)
            {
                result.Add("length",length.ToString());
            }
            if(sha2!=null)
            {
                result.Add("sha2",sha2.ToString());
            }
            if(fileUrl!=null)
            {
                result.Add("fileUrl",fileUrl.ToString());
            }
            return result;
        }

        public static explicit operator Attachment(JObject jobj)
        {
            return new Attachment(jobj);
        }
    }
}
