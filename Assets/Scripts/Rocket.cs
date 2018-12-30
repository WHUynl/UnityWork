using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    public float m_speed = 1;//子弹飞行速度
    public float m_liveTime = 5;//生存时间
    private float m_timer = 0;
    protected Transform m_transform;
    Player m_player;
    void Start () {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        m_transform = this.transform;
    }
	
	// Update is called once per frame
	void Update () {
        //子弹一段时间后自动消除
        m_timer += Time.deltaTime;
        if (m_timer >= m_liveTime)
        {
            gameObject.SetActive(false);
            m_timer = 0;//计时器重置
        }

        //向前移动 
        m_transform.Translate(new Vector3(0, 0, m_speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Enemy") == 0)
        {
            gameObject.SetActive(false);
        }
        else if(other.tag.CompareTo("SecondRocket") == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
