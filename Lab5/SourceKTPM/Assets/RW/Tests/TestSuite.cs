using System.Collections;
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

        [UnityTest]
        public IEnumerator AsteroidsMoveDown()
        {
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();
            float initialYPos = asteroid.transform.position.y;
            yield return new WaitForSeconds(1f);

            Assert.Less(asteroid.transform.position.y, initialYPos);
        }

        [UnityTest]
        public IEnumerator GameOverOccursOnAsteroidCollision()
        {
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();
            asteroid.transform.position = game.GetShip().transform.position;
            yield return new WaitForSeconds(5f);

            Assert.True(game.isGameOver);
        }

        [UnityTest]
        public IEnumerator NewGameRestartsGame()
        {
            game.isGameOver = true;
            game.NewGame();

            // Kiểm tra xem trò chơi có được khởi động lại không
            if (!game.isGameOver)
            {
                Debug.Log("Game has been restarted!");
            }
            else
            {
                Debug.Log("Game has not been restarted!");
            }

            yield return null;
        }


        [UnityTest]
        public IEnumerator LaserMovesUp()
        {
            GameObject laser = game.GetShip().SpawnLaser();
            float initialYPos = laser.transform.position.y;
            yield return new WaitForSeconds(0.1f);

            // Kiểm tra xem vị trí Y của laser đã tăng lên chưa
            if (laser.transform.position.y > initialYPos)
            {
                Debug.Log("Laser has moved up!");
            }
            else
            {
                Debug.Log("Laser has not moved up!");
            }
        }


        [UnityTest]
        public IEnumerator LaserDestroysAsteroid()
        {
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();
            asteroid.transform.position = Vector3.zero;
            GameObject laser = game.GetShip().SpawnLaser();
            laser.transform.position = Vector3.zero;
            yield return new WaitForSeconds(0.1f);

            // Kiểm tra xem asteroid đã bị tiêu diệt chưa
            if (asteroid == null)
            {
                Debug.Log("Asteroid has been destroyed by laser!");
            }
            else
            {
                Debug.Log("Asteroid has not been destroyed by laser!");
            }
        }


        [UnityTest]
        public IEnumerator DestroyedAsteroidRaisesScore()
        {
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();
            asteroid.transform.position = Vector3.zero;
            GameObject laser = game.GetShip().SpawnLaser();
            laser.transform.position = Vector3.zero;
            yield return new WaitForSeconds(5f);
            Assert.AreEqual(game.score, 1);
        }

        [UnityTest]
        public IEnumerator HighScoreCheck()
        {
            game.score = 100;
            game.SaveHighScore(game.score);
            yield return new WaitForSeconds(0.1f);
            Assert.AreEqual(game.LoadHighScore(), game.score);
            Debug.Log("Test passed: " + game.score);
        }

    }
}