using Microsoft.Xna.Framework;
using System;

namespace DKGame
{
    public class EnemyWalkingState : IEnemyState
    {
        private const float ENEMY_WALK_SPEED = 50;
        private IEnemy enemy;
        public EnemyWalkingState(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public void Idle()
        {
            // No-op
        }

        public void Walk()
        {
            if (enemy.FacingRight)
            {
                enemy.Body.Velocity = new Vector2(0, enemy.Body.Velocity.Y);
                enemy.Body.ApplyScaledImpulse(new Vector2(-ENEMY_WALK_SPEED, 0));
            } else
            {
                enemy.Body.Velocity = new Vector2(0, enemy.Body.Velocity.Y);
                enemy.Body.ApplyScaledImpulse(new Vector2(ENEMY_WALK_SPEED, 0));
            }
        }

        public void Shoot()
        {
            // No-op 
        }

    }
}
