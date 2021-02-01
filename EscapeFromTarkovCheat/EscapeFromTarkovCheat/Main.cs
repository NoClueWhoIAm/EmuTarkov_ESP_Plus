using System;
using System.Collections.Generic;
using Comfort.Common;
using EFT;
using EFT.Interactive;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Feauters;
using EscapeFromTarkovCheat.Feauters.ESP;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat
{
    class Main : MonoBehaviour
    {
        public static List<GamePlayer> GamePlayers = new List<GamePlayer>();
        public static Player LocalPlayer;
        public static GameWorld GameWorld;
        public static Camera MainCamera;

        private float _nextPlayerCacheTime;
        private static readonly float _cachePlayersInterval = 4f;

        public void Awake()
        {
            GameObject hookObject = new GameObject();

            hookObject.AddComponent<Menu.UI.Menu>();
            hookObject.AddComponent<PlayerESP>();
            hookObject.AddComponent<ItemESP>();
            hookObject.AddComponent<LootableContainerESP>();
            hookObject.AddComponent<ExfiltrationPointsESP>();
            hookObject.AddComponent<Aimbot>();
            DontDestroyOnLoad(hookObject);
        }

        public void Update()
        {
            if (Settings.DrawPlayers)
            {
                if (Time.time >= _nextPlayerCacheTime)
                {
                    GameWorld = Singleton<GameWorld>.Instance;
                    MainCamera = Camera.main;

                    if ((GameWorld != null) && (GameWorld.RegisteredPlayers != null))
                    {
                        GamePlayers.Clear();

                        foreach (Player player in GameWorld.RegisteredPlayers)
                        {
                            if (player.IsYourPlayer())
                            {
                                LocalPlayer = player;
                                continue;
                            }

                            if (!GameUtils.IsPlayerAlive(player) || (Vector3.Distance(MainCamera.transform.position, player.Transform.position) > Settings.DrawPlayersDistance))
                                continue;

                            GamePlayers.Add(new GamePlayer(player));
                        }

                        _nextPlayerCacheTime = (Time.time + _cachePlayersInterval);
                    }
                }

                foreach (GamePlayer gamePlayer in GamePlayers)
                    gamePlayer.RecalculateDynamics();
            }


            if (Input.GetKeyDown(Settings.UnlockDoors))
            {
                foreach (var door in FindObjectsOfType<Door>())
                {
                    if (door.DoorState == EDoorState.Open || Vector3.Distance(door.transform.position, LocalPlayer.Position) > 20f)
                        continue;

                    door.DoorState = EDoorState.Shut;
                }
            }
        }
    }
}
