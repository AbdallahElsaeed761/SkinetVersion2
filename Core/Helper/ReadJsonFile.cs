using Core.Entities.Products;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Helper
{
    public class ReadJsonFile
    {
        public async  static Task<List<Product>> LoadJson(string path)
        {
            //using (StreamReader r = new StreamReader(path))
            //{
            //    string json = r.ReadToEnd();
            //    List<ProductType> items = JsonConvert.DeserializeObject<List<ProductType>>(json);
            //    return items;
            //}
            var item = await ReadAsync<List<Product>>(path);

            return item;
        }

        
            public static async Task<T> ReadAsync<T>(string filePath)
            {
                using FileStream stream = File.OpenRead(filePath);
                return await JsonSerializer.DeserializeAsync<T>(stream);
            }
        
    }
}
