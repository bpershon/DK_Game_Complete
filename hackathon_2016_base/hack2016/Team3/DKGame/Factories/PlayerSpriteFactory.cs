using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DKGame
{
    public class PlayerSpriteFactory : ISpriteFactory
    {
        private static readonly string DK_FILE_PATH = "Player/Donkey/dk_";
        private static readonly string DD_FILE_PATH = "Player/Diddy/dd_";
        private static readonly string STANDING_STILL = "standing_still";
        private static readonly string BARREL_PICKUP = "barrel_pickup";
        private static readonly string BARREL_THROW_PT1 = "barrel_throw_pt1";
        private static readonly string BARREL_THROW_PT2 = "barrel_throw_pt2";
        private static readonly string BARREL_WALK = "barrel_walk";
        private static readonly string CROUCH = "crouch";
        private static readonly string JUMP = "jump";
        private static readonly string ROLL = "roll";
        private static readonly string RUN = "run";
        private static readonly string SWAP_LEAD = "swap_lead";
        private static readonly string SWAP_FOLLOW = "swap_follow";
        private static readonly string WALK = "walk";
        private static readonly string DEAD = "damaged";
        private static readonly string RIDING_IDLE = "ridingrambi_idle";
        private static readonly string RIDING_JUMP = "ridingrambi_jump";
        private static readonly string RIDING_WALK = "ridingrambi_walk";
        private static readonly string RIDING_HIT = "ridingrambi_hit";
        private static readonly string RIDING_DISMOUNT = "ridingrambi_dismount";
        private static readonly string WIN = "win";
        private Texture2D dkBarrelPickupSpriteSheet;
        private Texture2D dkBarrelThrowPt1SpriteSheet;
        private Texture2D dkBarrelThrowPt2SpriteSheet;
        private Texture2D dkBarrelwalkSpriteSheet;
        private Texture2D dkcrouchSpriteSheet;
        private Texture2D dkjumpSpriteSheet;
        private Texture2D dkRidingDismountSpriteSheet;
        private Texture2D dkRidingIdleSpriteSheet;
        private Texture2D dkRidingJumpSpriteSheet;
        private Texture2D dkRidingWalkSpriteSheet;
        private Texture2D dkRidingHitSpriteSheet;
        private Texture2D dkRollSpriteSheet;
        private Texture2D dkRunSpriteSheet;
        private Texture2D dkStandingStillSpriteSheet;         
        private Texture2D dkSwapFollowerSpriteSheet;
        private Texture2D dkSwapLeaderSpriteSheet;
        private Texture2D dkWalkSpriteSheet;
        private Texture2D dkDeadSpriteSheet;
        private Texture2D dkWinSpriteSheet;
        private Texture2D ddBarrelPickupSpriteSheet;
        private Texture2D ddBarrelThrowPt1SpriteSheet;
        private Texture2D ddBarrelThrowPt2SpriteSheet;
        private Texture2D ddBarrelwalkSpriteSheet;
        private Texture2D ddcrouchSpriteSheet;
        private Texture2D ddjumpSpriteSheet;
        private Texture2D ddRidingDismountSpriteSheet;
        private Texture2D ddRidingIdleSpriteSheet;
        private Texture2D ddRidingJumpSpriteSheet;
        private Texture2D ddRidingWalkSpriteSheet;
        private Texture2D ddRidingHitSpriteSheet;
        private Texture2D ddRollSpriteSheet;
        private Texture2D ddStandingStillSpriteSheet;
        private Texture2D ddSwapFollowerSpriteSheet;
        private Texture2D ddSwapLeaderSpriteSheet;
        private Texture2D ddWalkSpriteSheet;
        private Texture2D ddDeadSpriteSheet;
        private Texture2D ddRunSpriteSheet;
        private Texture2D ddWinSpriteSheet;

        private static PlayerSpriteFactory instance = new PlayerSpriteFactory();

        public static PlayerSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private PlayerSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            #region DK Textures
            dkStandingStillSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + STANDING_STILL);
            dkBarrelPickupSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + BARREL_PICKUP);
            dkBarrelThrowPt1SpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + BARREL_THROW_PT1);
            dkBarrelThrowPt2SpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + BARREL_THROW_PT2);
            dkBarrelwalkSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + BARREL_WALK);
            dkcrouchSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + CROUCH);
            dkjumpSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + JUMP);
            dkRidingDismountSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + RIDING_DISMOUNT);
            dkRidingIdleSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + RIDING_IDLE);
            dkRidingJumpSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + RIDING_JUMP);
            dkRidingWalkSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + RIDING_WALK);
            dkRidingHitSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + RIDING_HIT);
            dkRollSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + ROLL);
            dkRunSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + RUN);
            dkSwapLeaderSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + SWAP_LEAD);
            dkSwapFollowerSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + SWAP_FOLLOW);
            dkWalkSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + WALK);
            dkDeadSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + DEAD);
            dkWinSpriteSheet = content.Load<Texture2D>(DK_FILE_PATH + WIN);
            #endregion

            #region DD Textures
            ddBarrelPickupSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + BARREL_PICKUP);
            ddBarrelThrowPt1SpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + BARREL_THROW_PT1);
            ddBarrelThrowPt2SpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + BARREL_THROW_PT2);
            ddBarrelwalkSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + BARREL_WALK);
            ddcrouchSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + CROUCH);
            ddjumpSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + JUMP);
            ddRidingDismountSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + RIDING_DISMOUNT);
            ddRidingIdleSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + RIDING_IDLE);
            ddRidingJumpSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + RIDING_JUMP);
            ddRidingWalkSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + RIDING_WALK);
            ddRidingHitSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + RIDING_HIT);
            ddRollSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + ROLL);
            ddStandingStillSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + STANDING_STILL);
            ddSwapLeaderSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + SWAP_LEAD);
            ddSwapFollowerSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + SWAP_FOLLOW);
            ddWalkSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + WALK);
            ddDeadSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + DEAD);
            ddRunSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + RUN);
            ddWinSpriteSheet = content.Load<Texture2D>(DD_FILE_PATH + WIN);
            #endregion
        }

        #region DK Sprite functions
        public ISprite CreateDKIdleSprite()
        {
            int totalFrames = 62;
            return new GenericSprite(dkStandingStillSpriteSheet, totalFrames);
        }
        public ISprite CreateDKMotionlessSprite()
        {
            int totalFrames = 1;
            return new GenericSprite(dkStandingStillSpriteSheet, totalFrames);
        }
        public ISprite CreateDKBarrelPickupSprite()
        {
            int totalFrames = 8;
            int updatesPerFrame = 3;
            return new GenericSprite(dkBarrelPickupSpriteSheet, totalFrames, updatesPerFrame);
        }
        public ISprite CreateDKBarrelIdleSprite()
        {
            int totalFrames = 14;
            List<int> dkBarrelIdleAnimationFrames = new List<int> { 0 };
            return new GenericSprite(dkBarrelwalkSpriteSheet, totalFrames,dkBarrelIdleAnimationFrames);
        }
        public ISprite CreateDKWalkSprite()
        {
            int totalFrames = 20;
            int updatesPerFrame = 3;
            return new GenericSprite(dkWalkSpriteSheet, totalFrames, updatesPerFrame);
        }
        public ISprite CreateDKBarrelThrowPt1Sprite()
        {
            int totalFrames = 11;
            int updatesPerFrame = 3;
            return new GenericSprite(dkBarrelThrowPt1SpriteSheet, totalFrames, updatesPerFrame);
        }
        public ISprite CreateDKBarrelThrowPt2Sprite()
        {
            int totalFrames = 8;
            int updatesPerFrame = 3;
            return new GenericSprite(dkBarrelThrowPt2SpriteSheet, totalFrames, updatesPerFrame);
        }
        public ISprite CreateDKBarrelWalkSprite()
        {
            int totalFrames = 14;
            int updatesPerFrame = 4;
            return new GenericSprite(dkBarrelwalkSpriteSheet, totalFrames, updatesPerFrame);
        }
        public ISprite CreateDKBarrelJumpSprite()
        {
            int totalFrames = 14;
            List<int> dkBarrelJumpFrames = new List<int> { 2 };
            return new GenericSprite(dkBarrelwalkSpriteSheet, totalFrames, dkBarrelJumpFrames);
        }
        public ISprite CreateDKCrouchSprite()
        {
            int totalFrames = 24;
            return new GenericSprite(dkcrouchSpriteSheet, totalFrames);
        }
        public ISprite CreateDKDeadSprite()
        {
            int totalFrames = 18;
            List<int> dkDeadAnimationFrames = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 16, 15, 14, 15, 16, 17, 16, 15, 14, 15, 16, 17 };
            return new GenericSprite(dkDeadSpriteSheet, totalFrames, dkDeadAnimationFrames);
        }
        public ISprite CreateDKJumpSprite()
        {
            int totalFrames = 20;
            return new GenericSprite(dkjumpSpriteSheet, totalFrames);
        }
        public ISprite CreateDKRidingDismountSprite()
        {
            int totalFrames = 4;
            int updatesPerFrame = 9;
            List<int> dkRidingDismountFrames = new List<int> { 3, 2, 1, 0 };
            return new GenericSprite(dkRidingDismountSpriteSheet, totalFrames, dkRidingDismountFrames, updatesPerFrame);
        }
        public ISprite CreateDKRidingIdleSprite()
        {
            int totalFrames = 1;
            return new GenericSprite(dkRidingIdleSpriteSheet, totalFrames);
        }
        public ISprite CreateDKRidingJumpSprite()
        {
            int totalFrames = 7;
            List<int> dkRidingJumpFrames = new List<int> { 6, 5, 4, 3, 2, 1, 0 };
            return new GenericSprite(dkRidingJumpSpriteSheet, totalFrames, dkRidingJumpFrames);
        }
        public ISprite CreateDKRidingWalkSprite()
        {
            int totalFrames = 8;
            List<int> dkRidingWalkFrames = new List<int> { 7, 6, 5, 4, 3, 2, 1, 0 };
            return new GenericSprite(dkRidingWalkSpriteSheet, totalFrames, dkRidingWalkFrames);
        }
        public ISprite CreateDKRidingHitSprite()
        {
            int totalFrames = 8;
            List<int> dkRidingHitFrames = new List<int> { 7, 6, 5, 4, 3, 2, 1, 0 };
            return new GenericSprite(dkRidingHitSpriteSheet, totalFrames, dkRidingHitFrames);
        }
        public ISprite CreateDKRollSprite()
        {
            int totalFrames = 14;
            int updatesPerFrame = 4;
            return new GenericSprite(dkRollSpriteSheet, totalFrames, updatesPerFrame);
        }
        public ISprite CreateDKRunSprite()
        {
            int totalFrames = 20;
            return new GenericSprite(dkRunSpriteSheet, totalFrames);
        }
        public ISprite CreateDKSwapToLeadSprite()
        {
            int totalFrames = 10;
            return new GenericSprite(dkSwapFollowerSpriteSheet, totalFrames);
        }
        public ISprite CreateDKSwapToFollowSprite()
        {
            int totalFrames = 5;
            return new GenericSprite(dkSwapLeaderSpriteSheet, totalFrames);
        }
        public ISprite CreateDKWinSprite()
        {
            int totalFrames = 14;
            List<int> dkWinAnimationFrames = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2};
            int updatesPerFrame = 5;
            return new GenericSprite(dkWinSpriteSheet, totalFrames, dkWinAnimationFrames, updatesPerFrame);
        }
        #endregion

        #region DD Sprite functions
        //Diddy Functions
        public ISprite CreateDDMotionlessSprite()
        {
            int totalFrames = 1;
            return new GenericSprite(ddStandingStillSpriteSheet, totalFrames);
        }
        public ISprite CreateDDBarrelPickupSprite()
        {
            int totalFrames = 4;
            int updatesPerFrames = 6;
            return new GenericSprite(ddBarrelPickupSpriteSheet, totalFrames, updatesPerFrames);
        }
        public ISprite CreateDDBarrelThrowPt1Sprite()
        {
            int totalFrames = 10;
            int updatesPerFrame = 3;
            return new GenericSprite(ddBarrelThrowPt1SpriteSheet, totalFrames, updatesPerFrame);
        }
        public ISprite CreateDDBarrelThrowPt2Sprite()
        {
            int totalFrames = 10;
            int updatesPerFrame = 3;
            return new GenericSprite(ddBarrelThrowPt2SpriteSheet, totalFrames, updatesPerFrame);
        }
        public ISprite CreateDDBarrelWalkSprite()
        {
            int totalFrames = 10;
            int updatesPerFrame = 4;
            return new GenericSprite(ddBarrelwalkSpriteSheet, totalFrames, updatesPerFrame);
        }
        public ISprite CreateDDBarrelIdleSprite()
        {
            int totalFrames = 10;
            List<int> ddBarrelAnimationFrames = new List<int> { 0 };
            return new GenericSprite(ddBarrelwalkSpriteSheet, totalFrames, ddBarrelAnimationFrames);
        }
        public ISprite CreateDDBarrelJumpSprite()
        {
            int totalFrames = 10;
            List<int> ddBarrelAnimationFrames = new List<int> { 3 };
            return new GenericSprite(ddBarrelwalkSpriteSheet, totalFrames, ddBarrelAnimationFrames);
        }
        public ISprite CreateDDCrouchSprite()
        {
            int totalFrames = 13;
            return new GenericSprite(ddcrouchSpriteSheet, totalFrames);
        }
        public ISprite CreateDDDeadSprite()
        {
            int totalFrames = 16;
            List<int> ddDeadAnimationFrames = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 14, 15, 14, 15, 14, 15 };
            return new GenericSprite(ddDeadSpriteSheet, totalFrames, ddDeadAnimationFrames);
        }
        public ISprite CreateDDJumpSprite()
        {
            int totalFrames = 20;
            return new GenericSprite(ddjumpSpriteSheet, totalFrames);
        }
        public ISprite CreateDDRidingDismountSprite()
        {
            int totalFrames = 4;
            int updatesPerFrame = 9;
            List<int> ddRidingDismountFrames = new List<int> {3, 2, 1, 0 };
            return new GenericSprite(ddRidingDismountSpriteSheet, totalFrames, ddRidingDismountFrames, updatesPerFrame);
        }
        public ISprite CreateDDRidingIdleSprite()
        {
            int totalFrames = 1;
            return new GenericSprite(ddRidingIdleSpriteSheet, totalFrames);
        }
        public ISprite CreateDDRidingJumpSprite()
        {
            int totalFrames = 7;
            List<int> ddRidingJumpFrames = new List<int> { 6, 5, 4, 3, 2, 1, 0 };
            return new GenericSprite(ddRidingJumpSpriteSheet, totalFrames, ddRidingJumpFrames);
        }
        public ISprite CreateDDRidingWalkSprite()
        {
            int totalFrames = 8;
            List<int> ddRidingWalkFrames = new List<int> { 7, 6, 5, 4, 3, 2, 1, 0 };
            return new GenericSprite(ddRidingWalkSpriteSheet, totalFrames, ddRidingWalkFrames);
        }
        public ISprite CreateDDRidingHitSprite()
        {
            int totalFrames = 8;
            List<int> ddRidingHitFrames = new List<int> { 7, 6, 5, 4, 3, 2, 1, 0 };
            return new GenericSprite(ddRidingHitSpriteSheet, totalFrames, ddRidingHitFrames);
        }
        public ISprite CreateDDRollSprite()
        {
            int totalFrames = 20;
            int updatesPerFrame = 3;
            return new GenericSprite(ddRollSpriteSheet, totalFrames, updatesPerFrame);
        }
        public ISprite CreateDDRunSprite()
        {
            int totalFrames = 13;
            return new GenericSprite(ddRunSpriteSheet, totalFrames);
        }
        public ISprite CreateDDIdleSprite()
        {
            int totalFrames = 39;
            return new GenericSprite(ddStandingStillSpriteSheet, totalFrames);
        }
        public ISprite CreateDDSwapToLeadSprite()
        {
            int totalFrames = 17;
            return new GenericSprite(ddSwapFollowerSpriteSheet, totalFrames);
        }
        public ISprite CreateDDSwapToFollowSprite()
        {
            int totalFrames = 8;
            return new GenericSprite(ddSwapLeaderSpriteSheet, totalFrames);
        }
        public ISprite CreateDDWalkSprite()
        {
            int totalFrames = 16;
            int updatesPerFrame = 3;
            return new GenericSprite(ddWalkSpriteSheet, totalFrames, updatesPerFrame);
        }
        public ISprite CreateDDWinSprite()
        {
            int totalFrames = 20;
            List<int> ddWinAnimationFrames = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8 };
            return new GenericSprite(ddWinSpriteSheet, totalFrames, ddWinAnimationFrames);
        }
        #endregion
    }
}