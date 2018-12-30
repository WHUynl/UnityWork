using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform m_canvas_main;//游戏场景的canvas
    public Text m_socre;//分数
    private int score;
    public EnemySpawn enemySpawn;
    private static int count;
    private float timer;

    void Start()
    {
        score = 0;
        timer = 0;
        m_socre.text = string.Format("SCORE:{0}", score);
    }

    void Update()
    {
        timer += Time.deltaTime;
        enemySpawn.GetLevel();
        if (GameManager.Instance.m_isAlive && timer >= 1)
        {
            score += enemySpawn.GetLevel() * 100;
            timer = 0;
        }
        if(count>0)
        {
            score += enemySpawn.GetLevel() * 500;
            count--;
        }
        m_socre.text = string.Format("SCORE:{0}", score);
    }

    public static void AddScore()
    {
        count += 1;
    }

    public int GetScore()
    {
        return score;
    }
}
