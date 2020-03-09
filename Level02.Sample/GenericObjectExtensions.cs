using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level02.Sample
{
    public static class GenericObjectExtensions
    {
        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>System.String.</returns>
        public static string Serialize<T>(this T obj)
        {
            var result = JsonConvert.SerializeObject(obj);
            return result;
        }

        /// <summary>
        /// Deserializes the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        public static T Deserialize<T>(string value)
        {
            var result = JsonConvert.DeserializeObject<T>(value);
            return result;
        }
    }
}