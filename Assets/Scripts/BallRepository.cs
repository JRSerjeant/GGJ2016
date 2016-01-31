using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public static class BallRepository
    {
        private static int RedBallCount = 0;
        private static int BlueBallCount = 0;

        public static int MaxBalls = Configuration.MaxBalls;

        public static bool IsRedPlayerBallsMax
        {
            get
            {
                return RedBallCount >= Configuration.MaxBalls;
            }
        }

        public static bool IsBluePlayerBallsMax
        {
            get
            {
                return BlueBallCount >= Configuration.MaxBalls;
            }
        }

        public static void ConsumeRedBall()
        {
            RedBallCount++;
        }

        public static void ConsumeBlueBall()
        {
            BlueBallCount++;
        }

        public static void ResetAllBalls()
        {
            BlueBallCount = 0;
            RedBallCount = 0;
        }

        public static void Replinish()
        {
            //MaxBalls++;
            RedBallCount--;
            BlueBallCount--;
        }
    }
}
