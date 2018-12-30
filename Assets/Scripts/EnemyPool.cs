using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{

    public static EnemyPool enemyPool;
    public Enemy enemy;
    public int poolAmount = 5;
    public bool isLockPool = false;
    private static int enemyCount = 0;


    private List<Enemy> pooledEnemy;

    private int currentIndex = 0;

    private void Awake()
    {
        enemyPool = this;
    }

    private void Start()//初始化敌人池大小
    {
        pooledEnemy = new List<Enemy>();

        for (int i = 0; i < poolAmount; i++)
        {
            Enemy initEnemy = Instantiate(enemy);
            initEnemy.gameObject.SetActive(false);
            pooledEnemy.Add(initEnemy);
        }
    }

    public static void AddCount()
    {
        enemyCount++;
    }

    public static void SubCount()
    {
        enemyCount--;
    }

    public static int GetCount()
    {
        return enemyCount;
    }

    public static void SetCount(int count)
    {
        enemyCount = count;
    }

    public Enemy GetEnemy()//从池中得到敌人
    {
        for (int i = 0; i < pooledEnemy.Count; i++)
        {
            int index = (currentIndex + i) % pooledEnemy.Count;

            if (!pooledEnemy[index].gameObject.activeInHierarchy)
            {
                currentIndex = (index + 1) % pooledEnemy.Count;
                return pooledEnemy[index];
            }
        }

        if (!isLockPool)
        {
            Enemy initEnemy = Instantiate(enemy);
            pooledEnemy.Add(initEnemy);
            return initEnemy;
        }

        return null;
    }
}
