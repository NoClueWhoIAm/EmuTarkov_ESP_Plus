using System;
using System.Runtime.InteropServices;
using EscapeFromTarkovCheat;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace Menu.UI
{
    public class Menu : MonoBehaviour
    {
        private Rect _mainWindow;
        private Rect _playerVisualWindow;
        private Rect _miscVisualWindow;
        private Rect _aimbotVisualWindow;
        private bool _visible = true;
        private bool _playerEspVisualVisible;
        private bool _miscVisualVisible;
        private bool _aimbotVisualVisible;

        private void Start()
        {
            AllocConsoleHandler.Open();
            _mainWindow = new Rect(20f, 60f, 250f, 150f);
            _playerVisualWindow = new Rect(20f, 220f, 250f, 150f);
            _miscVisualWindow = new Rect(20f, 260f, 250f, 150f);
            _aimbotVisualWindow = new Rect(20f, 260f, 250f, 150f);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
                _visible = !_visible;

            if (Input.GetKeyDown(KeyCode.Delete))
                Loader.Unload();
        }

        private void OnGUI()
        {
            if (!_visible)
                return;

            _mainWindow = GUILayout.Window(0, _mainWindow, RenderUi, "Menu");

            if (_playerEspVisualVisible)
                _playerVisualWindow = GUILayout.Window(1, _playerVisualWindow, RenderUi, "Player Visual");
            if (_miscVisualVisible)
                _miscVisualWindow = GUILayout.Window(2, _miscVisualWindow, RenderUi, "Misc Visual");
            if (_aimbotVisualVisible)
                _aimbotVisualWindow = GUILayout.Window(3, _aimbotVisualWindow, RenderUi, "Aimbot");
        }

        private void RenderUi(int id)
        {
            switch (id)
            {
                case 0:
                    GUILayout.Label("Insert For Menu");

                    if (GUILayout.Button("Player Visual"))
                        _playerEspVisualVisible = !_playerEspVisualVisible;
                    if (GUILayout.Button("Misc Visual"))
                        _miscVisualVisible = !_miscVisualVisible;
                    if (GUILayout.Button("Aimbot"))
                        _aimbotVisualVisible = !_aimbotVisualVisible;
                    break;

                case 1:
                    Settings.DrawPlayers = GUILayout.Toggle(Settings.DrawPlayers, "Draw Players");
                    Settings.DrawPlayerBox = GUILayout.Toggle(Settings.DrawPlayerBox, "Draw Player Box");
                    Settings.DrawPlayerName = GUILayout.Toggle(Settings.DrawPlayerName, "Draw Player Name");
                    Settings.DrawPlayerLine = GUILayout.Toggle(Settings.DrawPlayerLine, "Draw Player Line");
                    Settings.DrawPlayerHealth = GUILayout.Toggle(Settings.DrawPlayerHealth, "Draw Player Health");
                    GUILayout.Label($"Player Distance {(int)Settings.DrawPlayersDistance} m");
                    Settings.DrawPlayersDistance = GUILayout.HorizontalSlider(Settings.DrawPlayersDistance,0f, 2000f);
                    break;

                case 2:
                    Settings.DrawLootItems = GUILayout.Toggle(Settings.DrawLootItems, "Draw Loot Items");
                    GUILayout.Label($"Loot Item Distance {(int)Settings.DrawLootItemsDistance} m");
                    Settings.DrawLootItemsDistance = GUILayout.HorizontalSlider(Settings.DrawLootItemsDistance, 0f, 1000f);

                    Settings.DrawLootableContainers = GUILayout.Toggle(Settings.DrawLootableContainers, "Draw Containers");
                    GUILayout.Label($"Container Distance {(int)Settings.DrawLootableContainersDistance} m");
                    Settings.DrawLootableContainersDistance = GUILayout.HorizontalSlider(Settings.DrawLootableContainersDistance, 0f, 1000f);

                    Settings.DrawExfiltrationPoints = GUILayout.Toggle(Settings.DrawExfiltrationPoints, "Draw Exits");
                    break;

                case 3:
                    Settings.Aimbot = GUILayout.Toggle(Settings.Aimbot, "Aimbot");
                    GUILayout.Label($"Aimbot Smooth {(int)Settings.AimbotSmooth} m");
                    Settings.AimbotSmooth = GUILayout.HorizontalSlider(Settings.AimbotSmooth, 0f, 100);
                    Settings.AimbotDrawFOV = GUILayout.Toggle(Settings.AimbotDrawFOV, "Draw Fov");
                    GUILayout.Label($"Aimbot FOV {(int)Settings.AimbotFOV} m");
                    Settings.AimbotFOV = GUILayout.HorizontalSlider(Settings.AimbotFOV, 0f, 180);
                    Settings.NoRecoil = GUILayout.Toggle(Settings.NoRecoil, "No Recoil");
                    break;
            }
            GUI.DragWindow();
        }
    }
}
