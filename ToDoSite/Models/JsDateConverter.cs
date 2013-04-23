using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoSite.Models
{
    public class JsDateConverter : DateTimeConverterBase
    {
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.Integer)
            {
                throw new Exception("Unexpected token");
            }

            return new DateTime(1970, 1, 1).AddMilliseconds((long)reader.Value);
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (!(value is DateTime))
            {
                throw new Exception("Unexpected type, shame on you");
            }

            var unix = new DateTime(1970, 1, 1);
            var delta = ((DateTime)value) - unix;

            if (delta.TotalSeconds < 0)
            {
                throw new Exception("1970.01.01, let me google that for you");
            }

            writer.WriteValue((long)delta.TotalMilliseconds);
        }
    }
}