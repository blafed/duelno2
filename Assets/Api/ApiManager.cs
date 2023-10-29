using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System;
namespace Duelno
{
    using Api;
    public class ApiManager : Singleton<ApiManager>
    {
        public bool isDev = true;
        public string apiUrl
        {
            get
            {
                if (isDev)
                    return ApiConfig.instance._apiUrlDev;
                else
                    return ApiConfig.instance._apiUrl;
            }
        }

        IEnumerator SendCoroutine<T>(UnityWebRequest request, Response<T> response) where T : new()
        {
            yield return request.SendWebRequest();

            string text;
            try
            {
                text = request.downloadHandler.text;
                JsonConvert.PopulateObject(text, response, CustomJsonSettings.singleton);
            }
            catch (Exception e)
            {
                Debug.LogWarning("couldn't populate response due to exception " + e);
            }
            if (request.responseCode >= 400 || request.responseCode < 100)
            {
                Debug.LogError("FAILED TO " + request.method + " " + request.url + " | ERROR: " + request.error + " | " + request.downloadHandler.text);
                response.isFail = true;
                response.isDone = true;
                response._InvokeOnDone();
            }
            else
            {
                text = request.downloadHandler.text;
                Debug.Log($" {request.Print()} -> {($"({request.responseCode}): " + text)}");
                response.data = JsonConvert.DeserializeObject<T>(text,
                    CustomJsonSettings.singleton
                );

                response.isDone = true;
                response._InvokeOnDone();
            }
        }


        public Response<T> Send<T>(UnityWebRequest request) where T : new()
        {
            var response = new Response<T>();
            response._coroutineRef = SendCoroutine(request, response);
            StartCoroutine(response._coroutineRef);
            return response;
        }

    }

}