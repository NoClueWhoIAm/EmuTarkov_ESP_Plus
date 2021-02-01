using System;
using System.Linq;
using Diz.Skinning;
using EFT;
using EFT.Interactive;
using UnityEngine;

namespace EscapeFromTarkovCheat.Utils
{

    public static class GameUtils
    {
        public static float Map(float value, float sourceFrom, float sourceTo, float destinationFrom, float destinationTo)
        {
            return (value - sourceFrom) / (sourceTo - sourceFrom) * (destinationTo - destinationFrom) + destinationFrom;
        }
        public static bool IsPlayerValid(Player player)
        {
            return player != null && player.Transform != null && player.PlayerBones != null && player.PlayerBones.transform != null;
        }
        public static bool IsExfiltrationPointValid(ExfiltrationPoint lootItem)
        {
            return lootItem != null;
        }
        public static bool IsLootItemValid(LootItem lootItem)
        {
            return lootItem != null && lootItem.Item != null && lootItem.Item.Template != null;
        }

        public static bool IsLootableContainerValid(LootableContainer lootableContainer)
        {
            return lootableContainer != null && lootableContainer.Template != null;
        }

        public static bool IsPlayerAlive(Player player)
        {
            if (!IsPlayerValid(player))
                return false;

            if (player.HealthController == null)
                return false;

            return player.HealthController.IsAlive;
        }

        public static Vector3 WorldPointToScreenPoint(Vector3 worldPoint)
        {
            Vector3 screenPoint = Main.MainCamera.WorldToScreenPoint(worldPoint);

            screenPoint.y = Screen.height - screenPoint.y;

            return screenPoint;
        }

        public static bool IsScreenPointVisible(Vector3 screenPoint)
        {
            return screenPoint.z > 0.01f && screenPoint.x > -5f && screenPoint.y > -5f && screenPoint.x < Screen.width && screenPoint.y < Screen.height;
        }

        public static Vector3 GetBonePosByID(Player player, int id)
        {
            Vector3 result;
            try
            {
                result = SkeletonBonePos(player.PlayerBones.AnimatedTransform.Original.gameObject.GetComponent<PlayerBody>().SkeletonRootJoint, id);
            }
            catch (Exception)
            {
                result = Vector3.zero;
            }
            return result;
        }

        public static Vector3 SkeletonBonePos(Skeleton skeleton, int id)
        {
            return skeleton.Bones.ElementAt(id).Value.position;
        }

    }

}