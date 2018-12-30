using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour
{
    public float m_speed = 10;//子弹飞行速度
    public float xNumber;//子弹的发射角度矢量值
    public float zNumber;//子弹的发射角度矢量值
    protected Transform m_transform;
    Player m_player;//主角
    public float m_livetime = 5.0f;
    private float m_timer;

    void OnEnable()
    {
        SetAngle();
    }

    void Start()
    {
        m_transform = this.transform;
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //为子弹的发射角度做准备
        xNumber = m_transform.position.x - m_player.m_transform.position.x;
        zNumber = m_transform.position.z - m_player.m_transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        //向主角方向移动
        if (!GameManager.Instance.m_isPause)
        {
            //浮游炮
            m_transform.Translate(new Vector3(-0.01f * (xNumber - 0.3f * zNumber * Mathf.Sin(10 * Time.time)), 0, -0.01f * (zNumber + 0.3f * xNumber * Mathf.Sin(10 * Time.time))));
        }
        if (!GameManager.Instance.m_isAlive)
        {
            gameObject.SetActive(false);
        }
        if (m_timer >= m_livetime)
        {
            gameObject.SetActive(false);
            m_timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Player") == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }

    private void SetAngle()
    {
        if (m_transform != null && m_player != null)
        {
            //为子弹的发射角度做准备
            xNumber = m_transform.position.x - m_player.m_transform.position.x;
            zNumber = m_transform.position.z - m_player.m_transform.position.z;
        }
    }
}
