using UnityEngine;
namespace Assets.Scripts
{
    public static class Configuration
    {
        public static readonly int BlockLimit = 5;
        public static readonly int BlockLife = 3;
        public static readonly int BlockRegenerationPerSecond = 2;
        public static readonly int GameLengthInSeconds = 30;
        public static readonly int MaxBalls = 10;
        public static readonly int BallLife = 3;
        public static readonly int PlayerSpeed = 200;
        public static readonly int ballForce = 600;
        public static readonly float CannonRotationSpeed = 60;
        public static readonly float menVelocity = 0.5f;
        public static readonly float menClimbVelocity = 0.65f;

        public const float PeoplePerSecond = 1f;
        public enum playerColourEnum { Red, Blue };

    }
}