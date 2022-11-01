using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    
    public class TestSuite
    {
        private Game game;

        // 1
        [UnityTest]
        public IEnumerator AsteroidsMoveDown()
        {
            // 2
            GameObject gameGameObject =
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
            game = gameGameObject.GetComponent<Game>();
            // 3
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();
            // 4
            float initialYPos = asteroid.transform.position.y;
            // 5
            yield return new WaitForSeconds(0.1f);
            // 6
            Assert.Less(asteroid.transform.position.y, initialYPos);
            // 7
            Object.Destroy(game.gameObject);
        }


        [UnityTest]
        public IEnumerator GameOverOccursOnAsteroidCollision()
        {
            GameObject gameGameObject =
               MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
            Game game = gameGameObject.GetComponent<Game>();
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();
            //1
            asteroid.transform.position = game.GetShip().transform.position;
            //2
            yield return new WaitForSeconds(0.1f);

            //3
            Assert.True(game.isGameOver);

            Object.Destroy(game.gameObject);
        }

    }
}

