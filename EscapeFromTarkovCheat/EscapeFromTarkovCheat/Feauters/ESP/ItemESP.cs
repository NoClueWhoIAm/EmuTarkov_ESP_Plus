using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Comfort.Common;
using EFT;
using EFT.Interactive;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Utils;
using JsonType;
using UnityEngine;

namespace EscapeFromTarkovCheat.Feauters.ESP
{
    public class ItemESP : MonoBehaviour
    {
        private static readonly float CacheLootItemsInterval = 4f;
        private float _nextLootItemCacheTime;

        private static readonly Color QuestColor = Color.yellow;
        private static readonly Color SuperRareColor = new Color(1f, 0.29f, 0.36f);

        private List<GameLootItem> _gameLootItems = new List<GameLootItem>();
        private Stopwatch _stopwatch = new Stopwatch();
        public void Update()
        {
            if (!Settings.DrawLootItems)
                return;

            if (Time.time >= _nextLootItemCacheTime)
            {
                if ((Main.GameWorld != null) && (Main.GameWorld.LootItems != null))
                {
                    _gameLootItems.Clear();

                    for (int i = 0; i < Main.GameWorld.LootItems.Count; i++)
                    {
                        LootItem lootItem = Main.GameWorld.LootItems.GetByIndex(i);

                        if (!GameUtils.IsLootItemValid(lootItem) || (Vector3.Distance(Main.MainCamera.transform.position, lootItem.transform.position) > Settings.DrawLootItemsDistance))
                            continue;

                        _gameLootItems.Add(new GameLootItem(lootItem));
                    }

                    _nextLootItemCacheTime = (Time.time + CacheLootItemsInterval);
                }
            }

            foreach (GameLootItem gameLootItem in _gameLootItems)
                gameLootItem.RecalculateDynamics();

        }

        private void OnGUI()
        {
            if (Settings.DrawLootItems)
            {
                foreach (var gameLootItem in _gameLootItems)
                {
                    if (!GameUtils.IsLootItemValid(gameLootItem.LootItem) || !gameLootItem.IsOnScreen || gameLootItem.Distance > Settings.DrawLootItemsDistance)
                        continue;

                    string lootItemName = $"{gameLootItem.LootItem.Item.ShortName.Localized()} [{gameLootItem.FormattedDistance}]";

                    if (gameLootItem.LootItem.Item.Template.Rarity == ELootRarity.Superrare)
                        Render.DrawString(new Vector2(gameLootItem.ScreenPosition.x - 50f, gameLootItem.ScreenPosition.y), lootItemName, SuperRareColor);
                    if (gameLootItem.LootItem.Item.Template.QuestItem)
                        Render.DrawString(new Vector2(gameLootItem.ScreenPosition.x - 50f, gameLootItem.ScreenPosition.y), lootItemName, QuestColor);
                }
            }
        }
    }
}