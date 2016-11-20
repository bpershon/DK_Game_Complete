using Microsoft.Xna.Framework;
using System;

namespace DKGame
{
    public class EnemyIdleState : IEnemyState
    {

        private const float ENEMY_IDLE_SPEED = 0;
        private IEnemy enemy;
        public EnemyIdleState(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public void Idle()
        {
            enemy.Body.ApplyForce(new Vector2(ENEMY_IDLE_SPEED, ENEMY_IDLE_SPEED));
        }

        public void Walk()
        {
            // No-op
        }

        public void Shoot()
        {
            // No-op
        }
    }
}
