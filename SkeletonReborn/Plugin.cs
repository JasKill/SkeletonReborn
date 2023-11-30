using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using SkeletonReborn.Configs;
using MEC;


namespace SkeletonReborn
{

    public class Plugin : Plugin<Config>
    {
       
        public static Plugin Instance;
        public override Version RequiredExiledVersion => new Version(8, 3, 9, 0);
        public override Version Version => new Version(1, 2, 5);
        public override string Name => "SkeletonReborn";
        public override string Author => "Nuhxly";
        public override string Prefix => "skeleton_reborn";

        
       ManageScp3114 SkeletonScp = new ManageScp3114();

        List<Player> Scps;


        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;

        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
        }


        //rng
        private static readonly Random random = new Random(); //System.Random

        private void OnRoundStarted()
        {
            
            Scps = Player.List.Where(p => p.IsScp).ToList();
            Player randomScp = Scps[random.Next(Scps.Count)];

            // run the coroutine after a small delay to ensure all players have spawned
            Timing.CallDelayed(0.01f, () =>
            {
                double Chance = random.NextDouble();
                // check if there are any SCPs on the server
                if (Scps.Count > 0)
                {

                    if (Scps.Count <= 3)
                    {
                        if (Chance <= Config.ScpChanceLowPlayers)
                        {
                            SkeletonScp.SkeletonScpSetter(randomScp);
                        }
                    }
                    else if (Scps.Count >= 3)
                    {
                        if (Chance <= Config.ScpChanceHighPlayers)
                        {
                            SkeletonScp.SkeletonScpSetter(randomScp);
                        }
                            
                    }
                    else
                    {
                        Config.SendBroadcast(randomScp, "An error occurred and stopped you from becoming Scp-3114(Skeleton)");
                    }
                    
                }
            });

        }
       
        
    }
    
}
