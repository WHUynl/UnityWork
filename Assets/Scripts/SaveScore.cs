using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : MonoBehaviour
{
    public Score score;
    private List<int> list = new List<int>();
    private int Count;

    private void Start()
    {
        for (int i = 1; i <= 8; i++)
        {
            if (!PlayerPrefs.HasKey("NO." + i))
            {
                PlayerPrefs.SetInt("NO." + i, 0);
            }
            list.Add(PlayerPrefs.GetInt("NO." + i));
        }
        Count = 0;
    }

    void Update()
    {
        if (!GameManager.Instance.m_isAlive && Count == 0)
        {
            Save();
        }
    }

    private void Save()
    {
        int scoreNum = score.GetScore();
        list.Add(scoreNum);
        list.Sort(delegate (int a, int b) { return a.CompareTo(b); });
        list.Sort((a, b) => b.CompareTo(a));
        for (int i = 1; i <= 8; i++)
        {
            PlayerPrefs.SetInt("NO." + i, list[i - 1]);
        }
        Count++;
    }
}
