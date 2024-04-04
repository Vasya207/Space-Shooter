using System;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class OnlineGameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject player;
        [SerializeField] private Transform startpoint;
        
        public override void InstallBindings()
        {
            Player playerInstance = 
                Container.InstantiatePrefabForComponent<Player>(
                    player, startpoint.position, Quaternion.identity, null);

            Container.Bind<Player>().FromInstance(playerInstance).AsSingle();
        }
    }
}
