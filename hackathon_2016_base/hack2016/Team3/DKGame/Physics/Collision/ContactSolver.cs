using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace DKGame
{
    /// <summary>
    /// FOR INTERNAL USE ONLY!
    /// </summary>
    public class ContactSolver
    {
        private const float PERCENT_ALONG_NORMAL = 0.1f;
        private const float SLOP = 0.01f;

        private List<Contact> contacts;
        public List<Contact> Contacts
        {
            get { return contacts; }
            set { contacts = value; }
        }

        public ContactSolver()
        {
            contacts = new List<Contact>();
        }

        public void Solve()
        {
            foreach (Contact contact in contacts)
            {
                Vector2 relativeVelocity = contact.BodyB.Velocity - contact.BodyA.Velocity;
                float speedAlongNormal = Vector2.Dot(relativeVelocity, contact.Normal);

                float resultVelocityMagnitude = -(1.0f + contact.Restitution) * speedAlongNormal;
                resultVelocityMagnitude /= contact.BodyA.InverseMass + contact.BodyB.InverseMass;

                Vector2 impulse = resultVelocityMagnitude * contact.Normal;
                contact.BodyA.ApplyImpulse(-impulse);
                contact.BodyB.ApplyImpulse(impulse);

                Vector2 tangentVector = relativeVelocity - Vector2.Dot(relativeVelocity, contact.Normal) * contact.Normal;
                if (tangentVector != Vector2.Zero) tangentVector.Normalize();
                float frictionMagnitude = -Vector2.Dot(relativeVelocity, tangentVector);
                frictionMagnitude /= contact.BodyA.InverseMass + contact.BodyB.InverseMass;
                frictionMagnitude *= contact.Friction;

                Vector2 frictionalImpulse = frictionMagnitude * tangentVector;
                contact.BodyA.ApplyImpulse(-frictionalImpulse);
                contact.BodyB.ApplyImpulse(frictionalImpulse);

                PositionCorrection(contact);
            }
        }

        private void PositionCorrection(Contact contact)
        {
            float percentNormalDisplacement = contact.Normal.Y != 0 ? PERCENT_ALONG_NORMAL / 2.0f : PERCENT_ALONG_NORMAL;
            Vector2 correction = Math.Max(contact.Depth - SLOP, 0) / (contact.BodyA.InverseMass + contact.BodyB.InverseMass) * percentNormalDisplacement * contact.Normal;
            contact.BodyA.BottomCenter += contact.BodyA.InverseMass * correction;
            contact.BodyB.BottomCenter -= contact.BodyB.InverseMass * correction;
        }
    }
}
