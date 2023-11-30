using System.ComponentModel;
using Exiled.API.Interfaces;
using Exiled.API.Features;

namespace SkeletonReborn.Configs
{
    public class Config : IConfig
    {

        // all of this is work in progress it currently does not work
        // i am too lazy and tired of scp:sl to fix this, someone else do it for me in a pull request xd
        
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = true;
        
        public void SendBroadcast(Player pl, string message) => pl.Broadcast(new Exiled.API.Features.Broadcast(message, 7), true);

        //These two ScpChances work though, idk why
        [Description("Skeleton % Chance of spawning in a game of 11 players, Default is 0.10 (10%)")]
        public double ScpChanceLowPlayers { get; set; } = 0.10; // set to 1 for debug

        [Description("Skeleton % Chance of spawning in a game of 16 players, Default is 0.15 (15%)")]
        public double ScpChanceHighPlayers { get; set; } = 0.15; // set to 1 for debug

        //BUG: HumeShield does not change even if i edit the config file
        //[Description("Shield of the Skeleton SCP")]
        //public float ScpHumeShield { get; set; } = 500;

        //BUG: health does not change even if i edit the config file
        //[Description("Artificial Health that starts with the scp")]
        //public int ScpAhp { get; set; } = 165;

        //BUG: health does not change even if i edit the config file
        //[Description("Scp's Health")]
        //public int ScpHealth { get; set; } = 1000;


    }
}
