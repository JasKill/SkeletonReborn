using Exiled.API.Features;
using SkeletonReborn.Configs;
using Exiled.API.Enums;
using Exiled.API.Features.Doors;
using PlayerRoles;

namespace SkeletonReborn
{
    public class ManageScp3114
    {
        public RoleTypeId SkeletonRole { get; set; } = RoleTypeId.Scp3114;

        Config scpConfig = new Config();
        

        public Player SkeletonScpSetter(Player ScpPlayer)
        {
            
            // change the player role to SCP-3114(skeleton)
            ScpPlayer.Role.Set(SkeletonRole);

            // Display a message at the top of the screen
            scpConfig.SendBroadcast(ScpPlayer, "The Skeleton Appears!");

            //BUG: i dont know how this works but After taking damage, hume shield does not respect the value and go back to 500 it goes to default 350.
            //     I assume this happens because there is no "MaxHumeShield" float Variable
            ScpPlayer.HumeShield = 512;
            
            //max health, UI bar only shows it to be removing health instead of displaying max health. this sucks idk how to fix it
            ScpPlayer.MaxHealth = 1000;
            ScpPlayer.Health = 1000;

            //temporary health for balance
            ScpPlayer.ArtificialHealth = 165;
            ScpPlayer.MaxArtificialHealth = 165;

            //Teleport to heavy containment at Scp-049 Gate, also for balancing reasons
            ScpPlayer.Teleport(Door.Get(DoorType.Scp049Gate));

            return ScpPlayer;
        }
    }
}
