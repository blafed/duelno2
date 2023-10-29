using System.Collections;
using UnityEngine;

namespace Duelno.Atlas
{
    /// <summary>
    /// Organize the atlas scene (dont access this class when other scenes)
    /// </summary>
    public class AtlasOrganizer : SingletonScene<AtlasOrganizer>
    {
        public IAtlasApi api;

        protected override void OnAwake()
        {
            base.OnAwake();

            api = GetComponent<IAtlasApi>();
            if (api == null)
            {
                Debug.LogError("no AtlasApi found within the components. Atlas organizer wont work properly", this);
                enabled = false;
            }
        }


        IEnumerator Start()
        {
            //TODO joining random lobby at start and do the other suitable actions
            yield break;
        }
    }
}