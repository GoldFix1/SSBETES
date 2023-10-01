using SSBETES.Assets;
using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SSBETES.Changes
{
    public static class NetworkHandler
    {
        
        public static void SendUnlockStatus(int who, bool value)
        {
            ModPacket packet = SSBETES.Instance.GetPacket(256);
            packet.Write(1);
            packet.Write(who);
            packet.Write(value);
            packet.Send(-1, -1);
        }
        
        public static void ReceiveUnlockStatus(int who, bool value)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                return;
            }
            Main.player[who].GetModPlayer<BUPPlayer>().Unlocking = true;
        }

        public static void HandlePacket(BinaryReader reader, int fromWho)
        {
            if (reader.ReadByte() == 1)
            {
                int who = reader.ReadInt32();
                bool state = reader.ReadBoolean();
                NetworkHandler.ReceiveUnlockStatus(who, state);
            }
        }

    }
}
