using System;
using System.Xml;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace DKGame
{
    public static class DKLevelParser
	{
		private static readonly string PLATFORM_XPATH = "/map/objectgroup[@name='Platforms']";
		private static readonly string ITEM_XPATH = "/map/objectgroup[@name='ItemLayer']";
		private static readonly string ENEMY_XPATH = "/map/objectgroup[@name='EnemyLayer']";

		private static Dictionary<string, Type> itemMap = new Dictionary<string, Type> 
		{ 
			{ "banana_bunch" , typeof(DKBananaGroup) },
			{ "banana_single" , typeof(DKBanana) },
			{ "balloon_life" , typeof(DKBalloon) },
			{ "barrel_check" , typeof(DKCheckpointBarrel) },
			{ "barrel_dk" , typeof(DKPlayerBarrel) },
			{ "barrel_reg" , typeof(DKStandardBarrel) },
			{ "crate_rambi" , typeof(DKRambiCrate) },
			{ "token_ost" , typeof(DKTrophy) },
			{ "token_k" , typeof(DKKongTileK) },
            { "token_o" , typeof(DKKongTileO) },
            { "token_n" , typeof(DKKongTileN) },
            { "token_g", typeof(DKKongTileG) },
            { "sign_exit", typeof(DKExitSign) },
			{ "teleporter" , typeof(DKTeleporter) },
		};

		private static Dictionary<string, Type> enemyMap = new Dictionary<string, Type>
		{
			{ "enemy_gnawty" , typeof(Gnawty) },
			{ "enemy_klump" , typeof(Klump) },
			{ "enemy_kritter" , typeof(Kritter) },
			{ "enemy_necky" , typeof(Necky) }
		};

		public static void ParseLevel(string levelFile, out List<IGameObject> gameObjects)
		{
            gameObjects = new List<IGameObject>();

			XmlDocument doc = new XmlDocument();
			try 
			{ 
				doc.Load(levelFile); 
			}
			catch (System.IO.FileNotFoundException)
			{
				throw new System.IO.FileNotFoundException("Unable to find level map file " + levelFile);
			}

			XmlNode platformsXml = doc.DocumentElement.SelectSingleNode(PLATFORM_XPATH);

			foreach (XmlNode platformNode in platformsXml.ChildNodes)
			{
				XmlElement platformElement = (XmlElement)platformNode;
                string objectType = platformElement.GetAttribute("type");

                IBlock newBlock;

                Tuple<Vector2, Vector2> posAndSize = GetPositionAndSizeFromXmlElement(platformElement);
                if (objectType.Equals("island"))
                {
                    newBlock = new IslandBlock(posAndSize.Item1, posAndSize.Item2);
                }
                else
                {
                    newBlock = new LevelBlock(posAndSize.Item1, posAndSize.Item2);
                }
				gameObjects.Add(newBlock);

			}

			XmlNode itemsXml = doc.DocumentElement.SelectSingleNode(ITEM_XPATH);
			foreach (XmlNode itemNode in itemsXml.ChildNodes)
			{
				XmlElement itemElement = (XmlElement)itemNode;

                gameObjects.Add(GetGameObjectFromXmlElement(itemElement, itemMap));
			}

			XmlNode enemiesXml = doc.DocumentElement.SelectSingleNode(ENEMY_XPATH);
			foreach (XmlNode enemyNode in enemiesXml.ChildNodes)
			{
				XmlElement enemyElement = (XmlElement)enemyNode;

                gameObjects.Add(GetGameObjectFromXmlElement(enemyElement, enemyMap));
			}

		}

		private static IGameObject GetGameObjectFromXmlElement(XmlElement element, Dictionary<string, Type> objectMap)
		{
			string objectType = element.GetAttribute("type");
			Tuple<Vector2, Vector2> posAndSize = GetPositionAndSizeFromXmlElement(element);

            IGameObject gameObject = (IGameObject)Activator.CreateInstance(objectMap[objectType]);
            gameObject.SetInitialPosition(posAndSize.Item1);

			if (objectType.Equals("teleporter"))
			{
				DKTeleporter teleporter = (DKTeleporter)gameObject;
				teleporter.Destination = element.GetAttribute("destination");
				gameObject = teleporter;
			}

			return gameObject;
		}

		private static Tuple<Vector2, Vector2> GetPositionAndSizeFromXmlElement(XmlElement element)
		{
			float x = float.Parse(element.GetAttribute("x"));
			float y = float.Parse(element.GetAttribute("y"));
			float width = float.Parse(element.GetAttribute("width"));
			float height = float.Parse(element.GetAttribute("height"));
			return new Tuple<Vector2, Vector2>(new Vector2(x+width/2, y), new Vector2(width, height));
		}
	}
}
