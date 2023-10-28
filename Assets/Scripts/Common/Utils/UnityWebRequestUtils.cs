using System.Text;
using UnityEngine.Networking;

public static class UnityWebRequestUtils
{
    public static string Print(this UnityWebRequest request)
    {
        return $"(Request) url: {request.url} || data : {(request.uploadHandler != null ? UTF8Encoding.UTF8.GetString(request.uploadHandler.data) : "NOTHING")}";
    }
}