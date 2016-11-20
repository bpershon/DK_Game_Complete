using Microsoft.Xna.Framework;
using System;

namespace DKGame {

    public class Contact
    {
        private const int SAT_BIAS = 12;

        private IBody bodyA;

        public IBody BodyA
        {
            get { return bodyA; }
        }

        private IBody bodyB;
        public IBody BodyB
        {
            get { return bodyB; }
        }

        private float friction;
        public float Friction
        {
            get { return friction; }
            set { friction = value; }
        }

        private float restitution;
        public float Restitution
        {
            get { return restitution; }
            set { restitution = value; }
        }

        private Vector2 normal;
        public Vector2 Normal
        {
            get { return normal; }
        }

        private float depth;
        public float Depth
        {
            get { return depth; }
        }


        public Contact(IBody bodyA, IBody bodyB)
        {
            this.bodyA = bodyA;
            this.bodyB = bodyB;

            friction = CombineFriction(bodyA.Friction, bodyB.Friction);
            restitution = CombineRestitution(bodyA.Restitution, bodyB.Restitution);
            ComputeManifold(bodyA, bodyB);
        }

        private float CombineFriction(float frictionA, float frictionB)
        {
            return (float) Math.Sqrt(frictionA * frictionA + frictionB * frictionB);
        }

        private float CombineRestitution(float restitutionA, float restitutionB)
        {
            return Math.Max(restitutionA, restitutionB);
        }

        private void ComputeManifold(IBody bodyAParam, IBody bodyBParam)
        {
            Rectangle rA = new Rectangle((int)bodyAParam.TopLeft.X, (int)bodyAParam.TopLeft.Y, (int)bodyAParam.Dimensions.X, (int)bodyAParam.Dimensions.Y);
            Rectangle rB = new Rectangle((int)bodyBParam.TopLeft.X, (int)bodyBParam.TopLeft.Y, (int)bodyBParam.Dimensions.X, (int)bodyBParam.Dimensions.Y);

            if (!rA.Intersects(rB)) return;

            float halfWidthA = rA.Width / 2.0f;
            float halfHeightA = rA.Height / 2.0f;
            float halfWidthB = rB.Width / 2.0f;
            float halfHeightB = rB.Height / 2.0f;

            Point distance = rB.Center - rA.Center;
            float overlapX = halfWidthA + halfWidthB - Math.Abs(distance.X);
            float overlapY = halfHeightA + halfHeightB - Math.Abs(distance.Y);

            if (overlapX > 0 && overlapY > 0)
            {
                if (overlapX < overlapY - SAT_BIAS)
                {
                    if (distance.X > 0) normal = -Vector2.UnitX;
                    else normal = Vector2.UnitX;
                    depth = overlapX;
                }
                else
                {
                    if (distance.Y >= -SAT_BIAS) normal = -Vector2.UnitY;
                    else normal = Vector2.UnitY;
                    depth = overlapY + SAT_BIAS;
                }
            }
        }
    }
}
