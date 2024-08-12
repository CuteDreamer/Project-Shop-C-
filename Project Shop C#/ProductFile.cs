using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Project_Shop_C_
{
    static class ProductFile
    {
        public static void SaveToJson(string filename, Store store)
        {
            var sw = new StreamWriter(filename);
            sw.Write(JsonSerializer.Serialize(store));
            sw.Close();
        }
        public static Store LoadFromJson(string filename)
        {
            var sr = new StreamReader(filename);
            var result = JsonSerializer.Deserialize<Store>(sr.ReadToEnd());
            sr.Close();
            return result;
        }
    }
}