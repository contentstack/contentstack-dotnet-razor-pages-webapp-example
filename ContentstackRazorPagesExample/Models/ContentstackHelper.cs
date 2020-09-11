using System;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace ContentstackRazorPagesExample.Models
{
    public class ContentstackHelper
    {
        public static string GetDescription(Enum en)
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());
            if (memInfo.Length <= 0) return en.ToString();
            
            var attrs = memInfo[0].GetCustomAttributes(typeof(DisplayNameAttribute), false);
            return attrs.Length > 0 ? ((DisplayNameAttribute)attrs[0]).DisplayName : en.ToString();
        }

        public static bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    }
}