using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFT.Visual;
using EscapeFromTarkovCheat.Feauters;
using UnityEngine;

namespace EscapeFromTarkovCheat.Utils
{
    class Settings
    {
        internal static bool DrawLootItems = false;
        internal static bool DrawLootableContainers = false;
        internal static bool DrawExfiltrationPoints = true;

        internal static bool DrawPlayers = true;
        internal static bool DrawPlayerName = true;
        internal static bool DrawPlayerHealth = false;
        internal static bool DrawPlayerBox = true;
        internal static bool DrawPlayerLine = true;

        internal static float DrawLootItemsDistance = 300f;
        internal static float DrawLootableContainersDistance = 10f;
        internal static float DrawPlayersDistance = 200f;


        internal static bool Aimbot = true;
        internal static KeyCode AimbotKey = KeyCode.LeftControl;
        internal static float AimbotFOV = 10f;
        internal static float AimbotSmooth = 50f;
        internal static bool NoRecoil = true;
        internal static bool AimbotDrawFOV = true;

        internal static KeyCode UnlockDoors = KeyCode.Keypad4;
    }
}