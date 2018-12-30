using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private int level = 1;
    private int count = 0;
    private float levelTimer;//升级时间
    private float gapTime;

    private void Start()
    {
        levelTimer = 0;
    }

    void Update()
    {
        if(GameManager.Instance.m_isAlive)
        {
            gapTime -= Time.deltaTime;
            levelTimer += Time.deltaTime;
            if (EnemyPool.GetCount() < (5 * level + 1) && gapTime <= 0)
            {
                Enemy enemy = EnemyPool.enemyPool.GetEnemy();
                enemy.transform.position = SetPosition();
                enemy.gameObject.SetActive(true);
                EnemyPool.AddCount();
                gapTime = 5 - level;
            }
            if (levelTimer >= 60 * level)
            {
                level++;
            }
        }
    }

    public int GetLevel()
    {
        return level;
    }

    private Vector3 SetPosition()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                return new Vector3(Random.Range(-16, 16), 5, 8);
            case 1:
                return new Vector3(Random.Range(-16, 16), 5, -8);
            case 2:
                return new Vector3(16, 5, Random.Range(-8, 8));
            default:
                return new Vector3(-16, 5, Random.Range(-8, 8));
        }
    }
}
