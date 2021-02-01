using BehaviourMachine;
using EFT.InventoryLogic;
using EscapeFromTarkovCheat.Feauters.ESP;
using UnityEngine;

namespace EscapeFromTarkovCheat
{
    public class Loader
    {
        public static GameObject HookObject;

        public static void Load()
        {
            HookObject = new GameObject();
            HookObject.AddComponent<Main>();
            Object.DontDestroyOnLoad(HookObject);
        }

        public static void Unload()
        {
            Object.Destroy(HookObject);
        }
    }

}
