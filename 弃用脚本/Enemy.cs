using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public float m_speed;//速度
    Transform m_transform;//组件配置
    Player m_player;//主角
    internal Renderer m_renderer;//模型渲染组件
    internal bool m_isActive = false;//是否激活渲染组件
    public Transform m_explosionFX;//爆炸组件
    public Transform m_enemyrocket;//敌人子弹
    public float timer = 1.0f;//定时器数据准备
   
	void Start () {
        m_transform = this.transform;
        //获得主角
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        m_renderer = this.GetComponent<Renderer>();//获得模型渲染组件
	}

    private void OnBecameVisible()//模型进入屏幕中
    {
        m_isActive = true;
    }

    void Update () {
        if (GameManager.Instance.m_isAlive)
        {
            UpdateMove();

            if (m_isActive && !this.m_renderer.isVisible)//进入屏幕后移动到屏幕外
            {
                Destroy(this.gameObject);
            }
            //定是发射子弹
            timer -= Time.deltaTime;
            if (timer <= 0 && m_player.gameObject != null)
            {
                Instantiate(m_enemyrocket, m_transform.position, m_transform.rotation);//实例化子弹
                timer = 2.0f;//定时器初始化
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void UpdateMove() {
        //左右移动
        float rx = Mathf.Sin(Time.time) * Time.deltaTime;
        //前进
        m_transform.Translate(new Vector3(rx, 0, -m_speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayerRocket") == 0)
        {
                //添加爆炸效果
                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
                Destroy(this.gameObject);//销毁自身
        }
        else if (other.tag.CompareTo("Player") == 0)//撞到主角
        {
            //添加爆炸效果
            Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
