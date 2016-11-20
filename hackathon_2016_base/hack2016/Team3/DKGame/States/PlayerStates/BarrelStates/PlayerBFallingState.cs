
using System;
/**
* THIS FILE WAS GENERATED USING Scripts/statecreator.py
* PLEASE USE THE SCRIPT TO GENERATE OTHER SUCH FILES, DO NOT CREATE THEM MANUALLY
**/
namespace DKGame
{
    public abstract class PlayerBFallingState : PlayerBaseStateBarrel
    {
        private const double MOVEMENT_THRESHOLD = 0.0001;

        public override void Update()
        {
            base.Update();

            if (player.HasCollisionFlag(PlayerCollisionState.Ground))
            {
                if (Math.Abs(player.HorizontalImpulse) > MOVEMENT_THRESHOLD)
                {
                    transitionSet.ToBarrelWalking(player);
                }
                else
                {
                    transitionSet.ToBarrelIdle(player);
                }
            }
        }

        public override void ProcessLeft()
        {
            base.ProcessLeft();
        }

        public override void ProcessRight()
        {
            base.ProcessRight();
        }

        public override void ProcessUp()
        {
            // No-Op
        }

        public override void ProcessDown()
        {
            // No-Op
        }

        public override void PerformAction()
        {
            // No-Op
        }

        public override void ChangePlayer()
        {
            // No-Op
        }

        public override void MountRambi()
        {
            // No-Op
        }

        public override void DismountRambi()
        {
            // No-Op
        }

        public override void HorizontalIdle()
        {
            // No-Op
        }

        public override void VerticalIdle()
        {
            // No-Op
        }
    }
}
