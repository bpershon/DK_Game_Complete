using Microsoft.Xna.Framework;
using System;

namespace DKGame
{
    public enum BodyType
    {
        Static, Kinematic, Dynamic
    }

    public struct Filter
    {
        [Flags]
        public enum Categories
        {
            Player = 0x80,
            Enemy = 0x40,
            Projectile = 0x20,
            LevelBlock = 0x10,
            Collectible = 0x08,
            Interactive = 0x04,
            Throwable = 0x02
        }

        /* Category dictates which collision categories this body belongs to
         * Categories for collision are listed from msb to lsb:
         * Player, Enemy, EnemyProjectile, LevelBlock, CollectibleItem, InteractiveItem, ThrowableItem, (have another bit for static / dynamic?, defaulting to 0)
         */
        public byte Category { get; set; }
        //Mask dictates which collision categories this body collides with
        public byte Mask { get; set; }
        public bool AlwaysCollide { get; set; }
    }

    public struct BodyDefinition
    {
        public BodyType Type { get; set; }
        public int Mass { get; set; }
        public Filter Filter { get; set; }
        public Vector2 BottomCenter { get; set; }
        public Vector2 Dimensions { get; set; }
    }

    public interface IBody
    {
        BodyType Type { get; }
        bool Awake { get; set; }
        float LinearDamping { get; set; }
        float Restitution { get; set; }
        float Friction { get; set; }
        int Mass { get; set; }
        float InverseMass { get; set; }
        Filter Filter { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }
        Vector2 Force { get; set; }
        Vector2 BottomCenter { get; set; }
        Vector2 TopLeft { get; }
        Vector2 BottomRight { get; }
        Vector2 Dimensions { get; set; }
        object UserData { get; set; }

        void ApplyForce(Vector2 force, bool wake = true);
        void ApplyImpulse(Vector2 impulse, bool wake = true);
        void ApplyScaledImpulse(Vector2 impulse, bool wake = true);
    }
}
