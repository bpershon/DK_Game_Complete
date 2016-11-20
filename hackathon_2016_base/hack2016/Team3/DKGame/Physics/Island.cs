using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace DKGame
{
    /// <summary>
    /// FOR INTERNAL USE ONLY!
    /// In physics engine parlance, an "island" is a group of objects touching each other, 
    /// but this has been generalized to be all awake objects.
    /// </summary>
    public class Island
    {
        private readonly Vector2 MAX_VELOCITY = new Vector2(50, 200);

        private List<IBody> bodies;
        public Island(List<IBody> bodies)
        {
            this.bodies = bodies;
        }

        public void Solve(GameTime gameTime)
        {
            float dt = (float) gameTime.ElapsedGameTime.TotalSeconds;
            foreach (IBody body in bodies)
            {
                /*
                 * Physics Explanation:
                 *
                 * We are given a net force F, mass m, velocity v, accelration a_0, and linear damping l
                 *
                 * Using a kinematic equation, we can compute the position update.
                 * x = x_0 + v * dt  + 1/2 * a_0 * t^2
                 * x - x_0 = v * t  + 1/2 * a_0 * t^2
                 * dx = v * t  + 1/2 * a_0 * t^2
                 *
                 * Then, we compute the new acceleration using Newton's Second Law of Motion (g is gravity)
                 * a = F / m + g
                 *
                 * For verlet integration, we compute the average acceleration a_avg and use another kinematic
                 * equation to compute the velocity update.
                 * a_avg = 1/2 * (a_0 + a)
                 * v = v_0 + a_avg * t
                 * v - v_0 = a_avg * t
                 * dv = a_avg * t
                 *
                 * We decided to use Verlet intergration over Euler's Method because it produces more accurate 
                 * results without any significant cost increase.
                 */
                Vector2 oldAccel = body.Acceleration;
                body.BottomCenter += body.Velocity * dt + 0.5f * oldAccel * dt * dt;

                if (body.Type == BodyType.Kinematic) continue;

                body.Acceleration = body.Force * body.InverseMass + PhysicsWorld.Instance.Gravity;
                Vector2 avgAccel = 0.5f * (oldAccel + body.Acceleration);
                body.Velocity += avgAccel * dt;

                /*
                 * Regarding Linear Damping:
                 *
                 * We use a scaling function, in the X direction only, to account for l
                 * 1 / (1 + t*l)
                 *
                 * This ensures that when l = 0, the scaling factor is (1, 1)
                 */
                body.Velocity *= new Vector2(1.0f / (1.0f + dt * body.LinearDamping), 1);
                body.Velocity = Vector2.Clamp(body.Velocity, -MAX_VELOCITY, MAX_VELOCITY);
            }
        }
    }
}
