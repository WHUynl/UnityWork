using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRocketPool : MonoBehaviour
{
    public static SecondRocketPool enemyRocketPool;
    public SecondEnemyRocket enemyRocket;
    public int poolAmount = 16;
    public bool isLockPool = false;


    private List<SecondEnemyRocket> pooledEnemyRocket;

    private int currentIndex = 0;

    private void Awake()
    {
        enemyRocketPool = this;
    }

    private void Start()//初始化子弹池大小
    {
        pooledEnemyRocket = new List<SecondEnemyRocket>();

        for (int i = 0; i < poolAmount; i++)
        {
            SecondEnemyRocket initEnemyRocket = Instantiate(enemyRocket);
            initEnemyRocket.gameObject.SetActive(false);
            pooledEnemyRocket.Add(initEnemyRocket);
        }
    }

    public SecondEnemyRocket GetRocket()//从池中得到子弹
    {
        for (int i = 0; i < pooledEnemyRocket.Count; i++)
        {
            int index = (currentIndex + i) % pooledEnemyRocket.Count;

            if (!pooledEnemyRocket[index].gameObject.activeInHierarchy)
            {
                currentIndex = (index + 1) % pooledEnemyRocket.Count;
                return pooledEnemyRocket[index];
            }
        }

        if (!isLockPool)
        {
            SecondEnemyRocket initEnemyRocket = Instantiate(enemyRocket);
            pooledEnemyRocket.Add(initEnemyRocket);
            return initEnemyRocket;
        }

        return null;
    }
}
