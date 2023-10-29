using System.Collections.Generic;
using Duelno.Api;

namespace Duelno.Atlas
{
    //TODO add documentation
    public interface IAtlasApi
    {
        Response<PlayerData> GetPlayerData(string playerId);
        Response<List<SpotData>> GetSpotsInLobby();
        Response<string> InvitePlayer(string otherPlayerId, long bet);
        Response<List<string>> GetIncomingInvitations();
        Response<List<string>> GetSentInvitations();
        Response<int> AcceptInvitation(string invitationId);
        Response<int> DeclineInvitation(string invitationId);
        Response<int> JoinRandomLobby();
        Response<int> JoinLobby(int lobby);
        Response<int> Login();
        Response<int> Logout();
        Response<int> RefreshMyExistanceInLobby();
    }
}