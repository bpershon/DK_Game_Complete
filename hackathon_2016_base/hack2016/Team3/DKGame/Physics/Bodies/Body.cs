using Microsoft.Xna.Framework;

namespace DKGame
{
    /// <summary>
    /// FOR INTERNAL USE ONLY!
    /// If you need a Body, configure it and let PhysicsWorld create one for you and don't forget to destroy it
    /// </summary>
    public class Body : IBody
    {
        #region Properties
        private readonly BodyType bodyType;
        public BodyType Type
        {
            get { return bodyType; }
        }

        private bool awake;
        public bool Awake
        {
            get { return awake; }
            set { awake = value; }
        }

        private float linearDamping;
        public float LinearDamping
        {
            get { return linearDamping; }
            set { linearDamping = value; }
        }

        private int mass;
        public int Mass
        {
            get { return mass; }
            set { mass = value; }
        }

        private float inverseMass;
        public float InverseMass
        {
            get { return inverseMass; }
            set { inverseMass = value; }
        }

        private Vector2 acceleration;
        public Vector2 Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }

        private Vector2 force;
        public Vector2 Force
        {
            get { return force; }
            set { force = value; }
        }

        private float restitution;
        public float Restitution
        {
            get { return restitution; }
            set { restitution = value; }
        }


        private Vector2 bottomCenter;
        public Vector2 BottomCenter
        {
            get { return bottomCenter; }
            set
            {
                bottomCenter = value;
                topLeft = new Vector2(bottomCenter.X - 0.5f * dimensions.X, bottomCenter.Y - dimensions.Y);
                bottomRight = new Vector2(bottomCenter.X + 0.5f * dimensions.X, bottomCenter.Y);
            }
        }

        private Vector2 velocity;
        public Vector2 Velocity
        {
            get { return velocity; }
            set
            {
                if (bodyType == BodyType.Static) return;
                if (Vector2.Dot(value, value) > 0) awake = true;
                velocity = value;
            }
        }

        private Vector2 dimensions;
        public Vector2 Dimensions
        {
            get { return dimensions; }
            set
            {
                dimensions = value;
                topLeft = new Vector2(bottomCenter.X - 0.5f * dimensions.X, bottomCenter.Y - dimensions.Y);
                bottomRight = new Vector2(bottomCenter.X + 0.5f * dimensions.X, bottomCenter.Y);
            }
        }

        private Vector2 topLeft;
        public Vector2 TopLeft
        {
            get { return topLeft; }
        }

        private Vector2 bottomRight;
        public Vector2 BottomRight
        {
            get { return bottomRight; }
        }

        private float friction;
        public float Friction
        {
            get { return friction; }
            set { friction = value; }
        }

        private Filter filter;
        public Filter Filter
        {
            get { return filter; }
            set { filter = value; }
        }

        private object userData;
        public object UserData
        {
            get { return userData; }
            set { userData = value; }
        }


        #endregion

        public Body(Vector2 initialPosition, BodyType bodyType = BodyType.Static)
        {
            bottomCenter = initialPosition;
            this.bodyType = bodyType;

            topLeft = new Vector2(bottomCenter.X - 0.5f * dimensions.X, bottomCenter.Y - dimensions.Y);
            bottomRight = new Vector2(bottomCenter.X + 0.5f * dimensions.X, bottomCenter.Y);
        }

        public void ApplyForce(Vector2 appliedForce, bool wake = true)
        {
            if (bodyType != BodyType.Dynamic) return;
            if (wake) awake = true;
            
            if (awake)
            {
                force += appliedForce;
            }
        }

        public void ApplyImpulse(Vector2 impulse, bool wake = true)
        {
            if (bodyType != BodyType.Dynamic) return;
            if (wake) awake = true;

            if (awake)
            {
                velocity += inverseMass * impulse;
            }
        }

        public void ApplyScaledImpulse(Vector2 impulse, bool wake = true)
        {
            ApplyImpulse(impulse * mass, wake);
        }
    }
}
