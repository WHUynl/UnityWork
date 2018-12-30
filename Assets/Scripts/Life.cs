using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour {
    public Transform m_canvas_main;//游戏场景的canvas
    public Text m_text;//时间
    private int life;
    public Player player;

    void Start()
    {
        m_text.text = string.Format("LIFE:{0}", life);
    }

    void Update()
    {
        if (GameManager.Instance.m_isAlive)
        {
            life = player.GetLife();
        }
        m_text.text = string.Format("LIFE:{0}", (int)life);

    }
}
