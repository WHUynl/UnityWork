using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnemyRocket : MonoBehaviour
{
    public float m_speed = 10;//子弹飞行速度
    protected Transform m_transform;
    Player m_player;//主角
    public float m_livetime = 3.0f;
    private float m_timer;

    void Start()
    {
        m_transform = this.transform;
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        m_speed -= Time.deltaTime * 3.3f;
        if (!GameManager.Instance.m_isPause)
        {
            m_transform.Translate(new Vector3(0, 0, m_speed * Time.deltaTime));
        }
        if (!GameManager.Instance.m_isAlive)
        {
            gameObject.SetActive(false);
        }
        if (m_timer >= m_livetime)
        {
            gameObject.SetActive(false);
            m_timer = 0;
            m_speed = 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Player") == 0)
        {
            gameObject.SetActive(false);
            m_timer = 0;
            m_speed = 10;
        }
        else if (other.tag.CompareTo("PlayerRocket") == 0)
        {
            gameObject.SetActive(false);
            m_timer = 0;
            m_speed = 10;
        }
        else
        {
            return;
        }
    }
}
