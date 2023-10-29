namespace Duelno.Atlas
{
    using UnityEngine;

    /// <summary>
    /// Keep the state between atlas scene and other scenes
    /// </summary>
    public class AtlasManager : Singleton<AtlasManager>
    {
        public int lobby { get; set; }
        public bool alreadyInLobby { get; set; }
    }
}