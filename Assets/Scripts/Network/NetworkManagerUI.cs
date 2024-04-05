using Unity.Netcode;
using UnityEngine;

namespace Network
{
    public class NetworkManagerUI : MonoBehaviour
    {
        public void OnServerClick()
        {
            NetworkManager.Singleton.StartServer();
        }
        
        public void OnClientClick()
        {
            NetworkManager.Singleton.StartClient();
        }

        public void OnHostClick()
        {
            NetworkManager.Singleton.StartHost();
        }
    }
}
