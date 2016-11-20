using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace DKGame
{
    public class CollisionEngine
    {
        public enum CollisionSide { LEFT, RIGHT, TOP, BOTTOM };

        private SortedSet<Tuple<int, IBody>> endpoints;
        private List<IBody> activeObjects;

        private List<IBody> dynamicBodies;
        public List<IBody> DynamicBodies
        {
            get { return dynamicBodies; }
        }

        private List<IBody> nonDynamicBodies;
        public List<IBody> NonDynamicBodies
        {
            get { return nonDynamicBodies; }
        }

        private List<Contact> contacts;
        public List<Contact> Contacts
        {
            get { return contacts; }
        }

        public CollisionEngine()
        {
            dynamicBodies = new List<IBody>();
            nonDynamicBodies = new List<IBody>();
            contacts = new List<Contact>();
            IComparer<Tuple<int, IBody>> comparer = Comparer<Tuple<int, IBody>>.Create((obj1, obj2) => obj1.Item1.CompareTo(obj2.Item1));
            endpoints = new SortedSet<Tuple<int, IBody>>(comparer);
            activeObjects = new List<IBody>();
        }

        public void Collide()
        {
            /*
             * For collision checking, we employ a sweep line algorithm that reduces the 2D rectangles
             * into 1D intervals along the Y axis. We then iterate through all of the endpoints. If
             * we encounter an endpoint denoting the start of a Rectangle, we add it to the 'activeObjects' queue.
             * If we encounter an endpoint denoting the end of a Rectangle, we remove it from the 'activeObjects' queue.
             * At any point in time, all objects in the queue have a chance of intersecting; check all of objects in the queue.
             *
             * We used SortedSet because its underlying implementation is a Red-Black Tree, which has O(log n) insertion and deletion
             */
            foreach (IBody body in dynamicBodies)
            {
                endpoints.Add(Tuple.Create((int)body.TopLeft.X, body));
                endpoints.Add(Tuple.Create((int)body.BottomRight.X, body));
            }

            foreach (var tuple in endpoints)
            {
                if (tuple.Item1 == (int) tuple.Item2.TopLeft.X)
                {
                    activeObjects.Add(tuple.Item2);
                }
                else if (tuple.Item1 == (int) tuple.Item2.BottomRight.X)
                {
                    activeObjects.Remove(tuple.Item2);
                }

                if (activeObjects.Count < 2) continue;
                
                for (int i = 0; i < activeObjects.Count; i++)
                {
                    for (int j = i + 1; j < activeObjects.Count; j++)
                    {
                        IBody dynamic1Body = activeObjects[i];
                        IBody dynamic2Body = activeObjects[j];
                        if (!ShouldCollide(dynamic1Body.Filter, dynamic2Body.Filter)) continue;

                        Rectangle dynamic1Rect = new Rectangle((int)dynamic1Body.TopLeft.X, (int)dynamic1Body.TopLeft.Y, (int)dynamic1Body.Dimensions.X, (int)dynamic1Body.Dimensions.Y);
                        Rectangle dynamic2Rect = new Rectangle((int)dynamic2Body.TopLeft.X, (int)dynamic2Body.TopLeft.Y, (int)dynamic2Body.Dimensions.X, (int)dynamic2Body.Dimensions.Y);
                        Rectangle intersection = Rectangle.Intersect(dynamic1Rect, dynamic2Rect);

                        if (!intersection.IsEmpty) contacts.Add(new Contact(dynamic1Body, dynamic2Body));
                    }
                }
            }

            endpoints.Clear();
            activeObjects.Clear();

            foreach (IBody dynamicBody in dynamicBodies)
            {
                foreach (IBody nonDynamicBody in nonDynamicBodies)
                {
                    if (!ShouldCollide(dynamicBody.Filter, nonDynamicBody.Filter)) continue;

                    Rectangle staticRect = new Rectangle((int)nonDynamicBody.TopLeft.X, (int)nonDynamicBody.TopLeft.Y, (int)nonDynamicBody.Dimensions.X, (int)nonDynamicBody.Dimensions.Y);
                    Rectangle dynamicRect = new Rectangle((int)dynamicBody.TopLeft.X, (int)dynamicBody.TopLeft.Y, (int)dynamicBody.Dimensions.X, (int)dynamicBody.Dimensions.Y);
                    Rectangle intersection = Rectangle.Intersect(dynamicRect, staticRect);

                    if (!intersection.IsEmpty) contacts.Add(new Contact(dynamicBody, nonDynamicBody));
                }
            }
        }

        public void Clear()
        {
            nonDynamicBodies.Clear();
            dynamicBodies.Clear();
            contacts.Clear();
        }

        private bool ShouldCollide(Filter filterA, Filter filterB)
        {
            return (filterA.Mask & filterB.Category) != 0 && (filterA.Category & filterB.Mask) != 0;
        }
    }
}
