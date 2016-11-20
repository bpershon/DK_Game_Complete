using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DKGame
{
    public class ContactEventArgs : EventArgs
    {
        public IBody Object1 { get; set; }
        public IBody Object2 { get; set; }
        public CollisionEngine.CollisionSide Side { get; set; }
    }


    public class PhysicsWorld
    {
        private static PhysicsWorld physicsWorld = new PhysicsWorld();
        public static PhysicsWorld Instance
        {
            get { return physicsWorld; }
        }

        private List<Contact> contacts;
        public List<Contact> Contacts
        {
            get { return contacts; }
        }

        private List<IBody> bodies;
        public List<IBody> Bodies
        {
            get { return bodies; }
        }

        private Vector2 gravity;
		private readonly float DEFAULT_GRAVITY = 200.0f;

        public Vector2 Gravity
        {
            get { return gravity; }
            set { gravity = value; }
        }

        private CollisionEngine collisionEngine;
        private ContactSolver contactSolver;

        public event EventHandler<ContactEventArgs> OnContact = delegate { };

        private PhysicsWorld()
        {
            collisionEngine = new CollisionEngine();
            contactSolver = new ContactSolver();
            contacts = new List<Contact>();
            bodies = new List<IBody>();
            gravity = new Vector2(0, DEFAULT_GRAVITY);
        }

        public IBody CreateBody(BodyDefinition bodyDef)
        {
            IBody body = BodyFromDef(bodyDef);
            bodies.Add(body);
            if (body.Type == BodyType.Dynamic) collisionEngine.DynamicBodies.Add(body);
            else collisionEngine.NonDynamicBodies.Add(body);
            return body;
        }

        public void DestroyBody(IBody body)
        {
            bodies.Remove(body);
            if (body.Type == BodyType.Dynamic) collisionEngine.DynamicBodies.Remove(body);
            else collisionEngine.NonDynamicBodies.Remove(body);
        }

        public void DestroyAllBodies()
        {
            bodies.Clear();
            collisionEngine.DynamicBodies.Clear();
            collisionEngine.NonDynamicBodies.Clear();
        }

        public void Update(GameTime gameTime)
        {
            contactSolver.Contacts.Clear();
            contacts.Clear();

            Queue<ContactEventArgs> eventQueue = new Queue<ContactEventArgs>();
            collisionEngine.Collide();
            contacts = collisionEngine.Contacts;
            contactSolver.Contacts.AddRange(contacts.Where(c => c.BodyA.Type != BodyType.Kinematic && c.BodyB.Type != BodyType.Kinematic));
            contactSolver.Solve();

            List<IBody> awakeBodies = new List<IBody>();
            awakeBodies.AddRange(bodies.Where(b => b.Awake && b.Type != BodyType.Static));

            Island island = new Island(awakeBodies);
            island.Solve(gameTime);

            foreach (Contact contact in contacts)
            {
                eventQueue.Enqueue(new ContactEventArgs { Object1 = contact.BodyA, Object2 = contact.BodyB, Side = NormalToSide(contact.Normal) });
            }

            ClearForces();

            while (eventQueue.Count > 0)
            {
                OnContact(null, eventQueue.Dequeue());
            }
        }

        public void ClearForces()
        {
            foreach (IBody body in bodies)
            {
                body.Force = Vector2.Zero;
            }
        }

        private IBody BodyFromDef(BodyDefinition bodyDef)
        {
            Body body = new Body(bodyDef.BottomCenter, bodyDef.Type);
            body.Dimensions = bodyDef.Dimensions;
            body.Filter = bodyDef.Filter;
            if (body.Type == BodyType.Dynamic)
            {
                body.Mass = bodyDef.Mass;
                body.InverseMass = 1.0f / bodyDef.Mass;
            }
            else if (body.Type == BodyType.Static)
            {
                body.InverseMass = 0;
            }
            else
            {
                body.Mass = 0;
            }
            return body;
        }

        private CollisionEngine.CollisionSide NormalToSide(Vector2 normal)
        {
            if (normal.Equals(-Vector2.UnitY)) return CollisionEngine.CollisionSide.BOTTOM;
            else if (normal.Equals(Vector2.UnitY)) return CollisionEngine.CollisionSide.TOP;
            else if (normal.Equals(-Vector2.UnitX)) return CollisionEngine.CollisionSide.RIGHT;
            else return CollisionEngine.CollisionSide.LEFT;
        }
    }
}
