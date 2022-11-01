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

        [SetUp]
        public void Setup()
        {
            GameObject gameGameObject =
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
            game = gameGameObject.GetComponent<Game>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(game.gameObject);
        }

        // Asteroids Move Down
        [UnityTest]
        public IEnumerator AsteroidsMoveDown()
        {
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();
            float initialYPos = asteroid.transform.position.y;
            yield return new WaitForSeconds(0.1f);

            Assert.Less(asteroid.transform.position.y, initialYPos);
        }

        // GameOver Occurs On Asteroid Collision
        [UnityTest]
        public IEnumerator GameOverOccursOnAsteroidCollision()
        {
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();
            asteroid.transform.position = game.GetShip().transform.position;
            yield return new WaitForSeconds(0.1f);

            Assert.True(game.isGameOver);
        }

        // New/Restart Game
        [UnityTest]
        public IEnumerator NewGameRestartsGame()
        {
            //1
            game.isGameOver = true;
            game.NewGame();
            //2
            Assert.False(game.isGameOver);
            yield return null;
        }

    }

}

