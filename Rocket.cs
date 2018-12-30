using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float m_speed = 10;//子弹飞行速度
    public float m_liveTime = 3;//生存时间
    protected Transform m_transform;
    private float m_timer = 0;

    void Start()
    {
        m_transform = this.transform;
    }

    void Update()
    {
        //子弹一段时间后自动消除
        m_timer += Time.deltaTime;
        if (m_timer >= m_liveTime)
        {
            this.gameObject.SetActive(false);
            m_timer = 0;//计时器重置
        }

        //向前移动
        m_transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Enmey") == 0)
        {
            other.gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
