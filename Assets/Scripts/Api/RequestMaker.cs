using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using Newtonsoft.Json;
using System.Collections;
namespace Duelno.Api
{
    public static class RequestMaker
    {
        public static string url => ApiManager.instance.apiUrl;


        static UnityWebRequest ARequest(string path, object o, string method)
        {
            var request = new UnityWebRequest(url + path, method);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            if (o != null)
            {
                request.uploadHandler = new UploadHandlerRaw(UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(o, CustomJsonSettings.singleton)));
            }
            return request;
        }

        public static UnityWebRequest POST(string path, object o) => ARequest(path, o, "POST");
        public static UnityWebRequest GET(string path, object o) => ARequest(path, o, "GET");
        public static UnityWebRequest PUT(string path, object o) => ARequest(path, o, "PUT");
        public static UnityWebRequest PATCH(string path, object o) => ARequest(path, o, "PATCH");
        public static UnityWebRequest DELETE(string path, object o) => ARequest(path, o, "DELETE");

    }
}