using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace DKGame
{
    public static class SoundPool
    {
        private static readonly string SOUND_DIR = "Sound/";
        private static readonly string COLLECTIBLE = SOUND_DIR + "Collectible/";
        private static readonly string ENEMY = SOUND_DIR + "Enemy/";
        private static readonly string MISC = SOUND_DIR + "Miscellaneous/";
        private static readonly string PLAYER = SOUND_DIR + "Player/";
        private static readonly string RAMBI = SOUND_DIR + "Rambi/";

        private static ContentManager manager;
        private static Dictionary<Sound, SoundEffect> sounds = new Dictionary<Sound, SoundEffect>();
        private static SoundEffect background;
        private static SoundEffectInstance backgroundInstance;

        public static void LoadContent(ContentManager manager)
        {
            #region Loading Sounds
            SoundPool.manager = manager;
            background = LoadMiscSound("04-dk-island-swing");

            sounds.Add(Sound.CollectibleBanana, LoadCollectibleSound("banana"));
            sounds.Add(Sound.CollectibleBananaGroup, LoadCollectibleSound("banana_bunch"));
            sounds.Add(Sound.CollectibleBarrelBreak, LoadCollectibleSound("barrel_break"));
            sounds.Add(Sound.CollectibleBarrelRoll, LoadCollectibleSound("barrel_roll"));
            sounds.Add(Sound.CollectibleBarrelSave, LoadCollectibleSound("barrel_save"));
            sounds.Add(Sound.CollectibleLetterG, LoadCollectibleSound("letter_g"));
            sounds.Add(Sound.CollectibleLetterK, LoadCollectibleSound("letter_k"));
            sounds.Add(Sound.CollectibleLetterN, LoadCollectibleSound("letter_n"));
            sounds.Add(Sound.CollectibleLetterO, LoadCollectibleSound("letter_o"));
            sounds.Add(Sound.CollectibleLifeGained, LoadCollectibleSound("life_gained"));
            sounds.Add(Sound.CollectibleTrophy1, LoadCollectibleSound("trophy_1"));
            sounds.Add(Sound.CollectibleTrophy2, LoadCollectibleSound("trophy_2"));
            sounds.Add(Sound.CollectibleTrophy3, LoadCollectibleSound("trophy_3"));
            sounds.Add(Sound.CollectibleTrophyAll, LoadCollectibleSound("trophy_all"));

            sounds.Add(Sound.EnemyGnawtyDie, LoadEnemySound("gnawty_die"));
            sounds.Add(Sound.EnemyKlumpDie, LoadEnemySound("klump_die"));
            sounds.Add(Sound.EnemyKritterDie, LoadEnemySound("kritter_die"));
            sounds.Add(Sound.EnemyNeckyDie, LoadEnemySound("necky_die"));

            sounds.Add(Sound.MiscMenuAccept, LoadMiscSound("menu_accept"));
            sounds.Add(Sound.MiscMenuMove, LoadMiscSound("menu_move"));

            sounds.Add(Sound.PlayerDDHit, LoadPlayerSound("diddy_hit"));
            sounds.Add(Sound.PlayerDKHit, LoadPlayerSound("dk_hit"));
            sounds.Add(Sound.PlayerDKLand, LoadPlayerSound("dk_land"));
            sounds.Add(Sound.PlayerDKVictory, LoadPlayerSound("dk_victory"));
            sounds.Add(Sound.PlayerSwitch, LoadPlayerSound("switch_player"));

            sounds.Add(Sound.RambiAttack, LoadRambiSound("rambi_attack"));
            sounds.Add(Sound.RambiCrateOpen, LoadRambiSound("rambi_crate_open"));
            sounds.Add(Sound.RambiJump, LoadRambiSound("rambi_jump"));
            #endregion
        }

        public static void PlaySound(Sound sound)
        {
            if (sounds.ContainsKey(sound))
            {
                sounds[sound].Play();
            }
        }

        public static void PlayBackgroundMusic()
        {
            backgroundInstance = background.CreateInstance();
            backgroundInstance.IsLooped = true;
            backgroundInstance.Play();
        }

        public static void StopBackgroundMusic()
        {
            backgroundInstance.Stop();
            backgroundInstance.Dispose();
        }

        #region Sound Loading Convenience Methods
        private static SoundEffect LoadCollectibleSound(string name)
        {
            return manager.Load<SoundEffect>(COLLECTIBLE + name);
        }

        private static SoundEffect LoadEnemySound(string name)
        {
            return manager.Load<SoundEffect>(ENEMY + name);
        }

        private static SoundEffect LoadMiscSound(string name)
        {
            return manager.Load<SoundEffect>(MISC + name);
        }

        private static SoundEffect LoadPlayerSound(string name)
        {
            return manager.Load<SoundEffect>(PLAYER + name);
        }

        private static SoundEffect LoadRambiSound(string name)
        {
            return manager.Load<SoundEffect>(RAMBI + name);
        }
        #endregion
    }
}
