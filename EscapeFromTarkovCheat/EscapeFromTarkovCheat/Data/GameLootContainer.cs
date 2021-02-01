using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFT.Interactive;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat.Data
{
    class GameLootContainer
    {
        public LootableContainer LootableContainer { get;}
        public Vector3 ScreenPosition => screenPosition;

        public bool IsOnScreen { get; private set; }

        public float Distance { get; private set; }

        public string FormattedDistance => $"{Math.Round(Distance)}m";

        private Vector3 screenPosition;

        public GameLootContainer(LootableContainer lootableContainer)
        {
            if (lootableContainer == null)
                throw new ArgumentNullException(nameof(lootableContainer));

            LootableContainer = lootableContainer;
            screenPosition = default;
            Distance = 0f;
        }

        public void RecalculateDynamics()
        {
            if (!GameUtils.IsLootableContainerValid(LootableContainer))
                return;

            screenPosition = GameUtils.WorldPointToScreenPoint(LootableContainer.transform.position);
            IsOnScreen = GameUtils.IsScreenPointVisible(screenPosition);
            Distance = Vector3.Distance(Main.MainCamera.transform.position, LootableContainer.transform.position);
        }
    }
}
