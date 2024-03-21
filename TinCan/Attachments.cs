//Added by david@widid.fr for the account of WiDiD SAS
//Last modified 02/02/2024
using System;
using TinCan.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace TinCan
{
    public class Attachments : JsonModel
    {
        public List<Attachment> attachments { get; set; }

        public Attachments() : base(){}
        public Attachments(StringOfJSON json ):this(json.toJObject()) { }
        public Attachments(JObject jobj)
        {
            if (jobj["attachments"] != null)
            {
                attachments = new List<Attachment>();
                foreach(JObject jattachment in jobj["attachments"])
                {
                    attachments.Add(new Attachment());
                }
            }
        }

        public override JObject ToJObject(TCAPIVersion version)
        {
            JObject result = new JObject();
            if (attachments != null && attachments.Count > 0)
            {
                var jattachments = new JArray();
                result.Add("attachments", jattachments);
                foreach (Attachment attachment in attachments)
                {
                    jattachments.Add(attachment.ToJObject(version));
                }
            }
            return result;
        }

        public static explicit operator Attachments(JObject jobj)
        {
            return new Attachments(jobj);
        }
    }
}
