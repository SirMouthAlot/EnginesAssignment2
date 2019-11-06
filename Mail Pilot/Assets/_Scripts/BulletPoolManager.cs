using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!
namespace Util
{
    [System.Serializable]
    public class BulletPoolManager
    {
        //Singleton instance for bulletpoolmanager
        private static BulletPoolManager m_instance;

        //TODO: create a structure to contain a collection of bullets
        public static int max_bullets = 50;
        List<GameObject> bulletPool = new List<GameObject>(max_bullets);


        private BulletPoolManager()
        {
            GameObject bullet = Resources.Load("Bullet", typeof(GameObject)) as GameObject;

            for (int i = 0; i < max_bullets; i++)
            {
                
                //instantiate bullet at (0, 0, 0) and deactiveate it so that you can't see it
                GameObject instBullet = MonoBehaviour.Instantiate(bullet, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                instBullet.SetActive(false);

                //Add our deactivated instantiated bullet to our pool
                bulletPool.Add(instBullet);
            }
        }

        public static BulletPoolManager GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new BulletPoolManager();
                Debug.Log("Singleton instance created");
            }

            return m_instance;
        }

        //TODO: modify this function to return a bullet from the Pool
        public GameObject GetBullet(string name = "bulletOrange")
        {
            GameObject _bullet = bulletPool[bulletPool.Count - 1];
            SpriteRenderer renderer = _bullet.GetComponent<SpriteRenderer>();
            renderer.sprite = Resources.Load(name, typeof(Sprite)) as Sprite;

            bulletPool.RemoveAt(bulletPool.Count - 1);

            return _bullet;
        }

        //TODO: modify this function to reset/return a bullet back to the Pool 
        public void ResetBullet(GameObject _bullet)
        {
            //Adds the bullet back to the pool
            bulletPool.Insert(bulletPool.Count, _bullet);

            //Moves it back to (0, 0, 0) with the rest of the pool
            //Deactivates it
            _bullet.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            _bullet.SetActive(false);
        }
    }
}
