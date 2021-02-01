using System.Collections.Generic;
using Comfort.Common;
using EFT;
using EFT.Interactive;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Utils;
using JsonType;
using UnityEngine;

namespace EscapeFromTarkovCheat.Feauters.ESP
{
    public class ExfiltrationPointsESP : MonoBehaviour
    {
        private List<GameExfiltrationPoint> _gameExfiltrationPoints= new List<GameExfiltrationPoint>();
        private static readonly float CacheExfiltrationPointInterval = 5f;
        private float _nextLootItemCacheTime;

        private static readonly Color ExfiltrationPointColour = Color.green;

        public void Update()
        {
            if (!Settings.DrawExfiltrationPoints) 
                return;

            if (Time.time >= _nextLootItemCacheTime)
            {
                if ((Main.GameWorld != null) && (Main.GameWorld.ExfiltrationController.ExfiltrationPoints != null))
                {
                    _gameExfiltrationPoints.Clear();
                    foreach (var exfiltrationPoint in Main.GameWorld.ExfiltrationController.ExfiltrationPoints)
                    {
                        if (!GameUtils.IsExfiltrationPointValid(exfiltrationPoint))
                            continue;

                        _gameExfiltrationPoints.Add(new GameExfiltrationPoint(exfiltrationPoint));
                    }

                    _nextLootItemCacheTime = (Time.time + CacheExfiltrationPointInterval);
                }
            }

            foreach (GameExfiltrationPoint gameExfiltrationPoint in _gameExfiltrationPoints)
                gameExfiltrationPoint.RecalculateDynamics();

        }
        private void OnGUI()
        {
            if (Settings.DrawExfiltrationPoints)
            {
                foreach (var exfiltrationPoint in _gameExfiltrationPoints)
                {
                    if (!GameUtils.IsExfiltrationPointValid(exfiltrationPoint.ExfiltrationPoint) || !exfiltrationPoint.IsOnScreen)
                        continue;

                    string exfiltrationPointText = $"{exfiltrationPoint.ExfiltrationPoint.Settings.Name} [{exfiltrationPoint.FormattedDistance}]";

                    Render.DrawString(new Vector2(exfiltrationPoint.ScreenPosition.x - 50f, exfiltrationPoint.ScreenPosition.y), exfiltrationPointText, ExfiltrationPointColour);
                }
            }
        }

    }
}
