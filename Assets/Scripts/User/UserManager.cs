using System;

namespace Duelno
{
    //TODO implement this
    public class UserManager : Singleton<UserManager>
    {
        /// <summary>
        /// invoked when the user is not logged in and the game needs to ask for login (should show UI)
        /// </summary>
        public event Action onAskForLogin;
        /// <summary>
        /// invoked when the user is logged in, the userId is set 
        /// </summary>
        public event Action onLogin;
        /// <summary>
        /// invoked when the user is logged out, the userId is set and can be accessed while this event is invoked
        /// afterwards the userId is set to null
        /// when loading the main scene onAskForLogin will be invoked
        /// </summary>
        public event Action onLogout;

        public string userId { get; private set; }
        public bool isLoggedIn { get; private set; }
    }
}