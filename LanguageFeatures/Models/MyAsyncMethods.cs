using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        // ИСПОЛЬЗОВАНИЕ АСИНХРОННЫХ МЕТОДОВ.
        // Работа с задачами напрямую.
        /*
        public static Task<long?> GetPageLenght()
        {
            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("http://apress.com");
            return httpTask.ContinueWith((Task<HttpResponseMessage> anrecedent) =>
            {
                return anrecedent.Result.Content.Headers.ContentLength;
            });
        }
        */




        // Применение ключевых слов async и await.

        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://apress.com");
            return httpMessage.Content.Headers.ContentLength;
        }

    }
}
