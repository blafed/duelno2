namespace Duelno.Api
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "ApiConfig", menuName = "Duelno/ApiConfig", order = 0)]
    public class ApiConfig : SingletonSO<ApiConfig>
    {
        [SerializeField]
        internal string _apiUrl = "http://localhost:3000";
        [SerializeField]
        internal string _apiUrlDev = "http://localhost:3000";
    }
}