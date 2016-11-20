using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DKGame
{
    public class Necky : IEnemy
    {
        private const int MASS = 5;
        private const int RANGE = 0;

        private ISprite sprite;

        public ISprite Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        private IEnemyState state;
        public IEnemyState State
        {
            get { return state; }
            set { state = value; }
        }

        private bool facingRight = false;
        public bool FacingRight
        {
            get { return facingRight; }
            set { facingRight = value; }
        }

        private float range = RANGE;
        public float Range
        {
            get { return range; }
            set { range = value; }
        }

        public GameObjectType GameObjType
        {
            get { return GameObjectType.Enemy; }
        }

        private IBody body;
        public IBody Body
        {
            get { return body; }
            set { body = value; }
        }

        public Necky()
        {
            sprite = EnemySpriteFactory.Instance.CreateDKNeckySprite();
            BodyDefinition bodyDef = new BodyDefinition() { BottomCenter = new Vector2(425, 300), Type = BodyType.Dynamic, Dimensions = sprite.Dimensions };
            Filter filter = new Filter();
            filter.Category = (byte)Filter.Categories.Enemy;
            filter.Mask = (byte)Filter.Categories.Player + (byte)Filter.Categories.LevelBlock + (byte)Filter.Categories.Throwable;
            bodyDef.Filter = filter;
            bodyDef.Mass = MASS;
            body = PhysicsWorld.Instance.CreateBody(bodyDef);
            body.UserData = this;
            state = new EnemyIdleState(this);
            PhysicsWorld.Instance.OnContact += OnContact;
        }

        private void OnContact(object sender, ContactEventArgs e)
        {
            //Temp bool statements for sprint 4 - 1 object is enemy && other is not player or level block. Fix on refactor.
            bool obj1IsEnemyNoPlayer = e.Object1.UserData is Necky && !(e.Object2.UserData is Player || e.Object2.UserData is LevelBlock);
            bool obj2IsEnemyNoPlayer = !(e.Object1.UserData is Player || e.Object1.UserData is LevelBlock) && e.Object2.UserData is Necky;
            if (obj1IsEnemyNoPlayer || obj2IsEnemyNoPlayer)
            {
                EnemyCollisionHandler.CollisionResponse(e.Object1.UserData as IGameObject, e.Object2.UserData as IGameObject, e.Side);
            }
        }

        public void ChangeDirection()
        {
            facingRight = !facingRight;
        }

        public void Update()
        {
            if (body.Awake)
            {
                if (state is EnemyIdleState)
                {
                    state = new EnemyWalkingState(this);
                }

                sprite.Update();

            }
            else
            {

                if (state is EnemyWalkingState)
                {
                    state = new EnemyIdleState(this);
                    state.Idle();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, body.BottomCenter, facingRight);
        }

        public void SetInitialPosition(Vector2 pos)
        {
            body.BottomCenter = pos;
        }

        public void Kill()
        {
            state = new EnemyDeadState();
            PhysicsWorld.Instance.DestroyBody(this.Body);
            WorldManager.Instance.RemoveObject(this);
            SoundPool.PlaySound(Sound.EnemyNeckyDie);
            //body.UpdateVelocity(body.Velocity.X, body.Velocity.Y + 1);
        }
    }
}
