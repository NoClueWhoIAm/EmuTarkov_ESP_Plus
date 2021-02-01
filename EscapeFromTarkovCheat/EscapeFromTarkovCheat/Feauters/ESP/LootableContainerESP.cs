using System;
using System.Collections.Generic;
using System.Reflection;
using Comfort.Common;
using EFT;
using EFT.Interactive;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Utils;
using JsonType;
using UnityEngine;

namespace EscapeFromTarkovCheat.Feauters.ESP
{
    public class LootableContainerESP : MonoBehaviour
    {
        private static readonly float CacheLootItemsInterval = 100;
        private float _nextLootContainerCacheTime;
        private List<GameLootContainer> _gameLootContainers;
        private static readonly Color LootableContainerColor = new Color(1f, 0.2f, 0.09f);

        public void Start()
        {
            _gameLootContainers = new List<GameLootContainer>();
        }

        public void Update()
        {
            if (!Settings.DrawLootableContainers)
                return;
            
            if (Time.time >= _nextLootContainerCacheTime)
            {
                if ((Main.GameWorld != null) && (Main.GameWorld.LootItems != null))
                {
                    _gameLootContainers.Clear();

                    foreach (LootableContainer lootableContainer in FindObjectsOfType<LootableContainer>())
                    {
                        if (!GameUtils.IsLootableContainerValid(lootableContainer) || (Vector3.Distance(Main.MainCamera.transform.position, lootableContainer.transform.position) > Settings.DrawLootableContainersDistance))
                            continue;

                        _gameLootContainers.Add(new GameLootContainer(lootableContainer));
                    }
                    _nextLootContainerCacheTime = (Time.time + CacheLootItemsInterval);
                }
            }

            foreach (GameLootContainer gameLootContainer in _gameLootContainers)
                gameLootContainer.RecalculateDynamics();
        }

        public void OnGUI()
        {
            if (!Settings.DrawLootableContainers)
                return;

            foreach (var gameLootContainer in _gameLootContainers)
            {
                if (!GameUtils.IsLootableContainerValid(gameLootContainer.LootableContainer) || !gameLootContainer.IsOnScreen || gameLootContainer.Distance > Settings.DrawLootableContainersDistance)
                    continue;

                string lootItemName = $"{gameLootContainer.LootableContainer.name} [{gameLootContainer.FormattedDistance}]";
                Render.DrawString(new Vector2(gameLootContainer.ScreenPosition.x - 50f, gameLootContainer.ScreenPosition.y), lootItemName, LootableContainerColor);
            }
        }
    }
}