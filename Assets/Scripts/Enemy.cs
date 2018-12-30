using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float m_speed;//速度
    Transform m_transform;//组件配置
    Player m_player;//主角
    public Transform m_explosionFX;//爆炸组件
    private int kindOfMove;//敌机运动方式
    private bool isInScreen;//判断敌机是否进入屏幕
    public Transform m_enemyrocket;//敌人子弹
    public float timer = 2.0f;//定时器数据准备
    private Vector3 pos;
    private float xNumber;
    private float zNumber;
    private float secondTimer = 10.0f;
    private int life = 10;

    void Start()
    {
        isInScreen = false;
        kindOfMove = Random.Range(0, 2);
        m_transform = this.transform;
        //获得主角
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        xNumber = m_transform.position.x - m_player.m_transform.position.x;
        zNumber = m_transform.position.z - m_player.m_transform.position.z;
    }

    void Update()
    {
        pos = Camera.main.WorldToViewportPoint(transform.position);
        IsInScreen();
        UpdateMove();
        //定时发射子弹
        timer -= Time.deltaTime;
        if (timer <= 0 && GameManager.Instance.m_isAlive)
        {
            //Instantiate(m_enemyrocket, m_transform.position, m_transform.rotation);//实例化子弹
            EnemyRocket rocket = EnemyRocketPool.enemyRocketPool.GetRocket();
            if (rocket != null)                  //不为空时执行
            {
                rocket.transform.position = m_transform.position;
                rocket.transform.rotation = m_transform.rotation;
                rocket.gameObject.SetActive(true);         //激活子弹并初始化子弹的位置
            }
            timer = 1.0f;//定时器初始化
        }
        secondTimer -= Time.deltaTime;
        if (secondTimer <= 0 && GameManager.Instance.m_isAlive)
        {
            for (int i = 0; i < 36; i++)
            {
                SecondEnemyRocket secondRocket = SecondRocketPool.enemyRocketPool.GetRocket();
                secondRocket.transform.position = m_transform.position;
                secondRocket.transform.localEulerAngles = new Vector3(0, i * 10, 0);
                secondRocket.gameObject.SetActive(true);
            }
            secondTimer = 10.0f;
        }
    }

    protected virtual void UpdateMove()
    {
        //左右移动
        float rx = Mathf.Sin(Time.time) * Time.deltaTime * Mathf.Cos(0.1f * Time.time) * Mathf.Cos(0.07f * Time.time);
        //前进
        KindOfMove();
        if (isInScreen)
        {
            switch (kindOfMove)
            {
                case 0:
                    transform.Translate(new Vector3(m_speed * Time.deltaTime, 0, rx * 5));
                    break;
                case 1:
                    transform.Translate(new Vector3(-m_speed * Time.deltaTime, 0, rx * 5));
                    break;
                case 2:
                    transform.Translate(new Vector3(rx * 5, 0, m_speed * Time.deltaTime));
                    break;
                case 3:
                    transform.Translate(new Vector3(rx * 5, 0, -m_speed * Time.deltaTime));
                    break;
            }
        }
        else
        {
            m_transform.Translate(new Vector3(-0.001f * (xNumber - 0.3f * zNumber * Mathf.Sin(10 * Time.time)), 0, -0.001f * (zNumber + 0.3f * xNumber * Mathf.Sin(10 * Time.time))));
        }
    }

    private void IsInScreen()
    {
        if (pos.x < 0 || pos.x > 1 || pos.y < 0 || pos.y > 1)
        {
        }
        else
        {
            isInScreen = true;
        }
    }

    private void KindOfMove()
    {
        if (isInScreen)
        {
            if (pos.x < 0)
            {
                kindOfMove = 0;
            }
            else if (pos.x > 1)
            {
                kindOfMove = 1;
            }
            else if (pos.y < 0)
            {
                kindOfMove = 2;
            }
            else if (pos.y > 1)
            {
                kindOfMove = 3;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayerRocket") == 0)
        {
            if (life <= 0)
            {
                //添加爆炸效果
                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                Score.AddScore();
                EnemyPool.SubCount();
                life = 10;
                timer = 2.0f;
                secondTimer = 10.0f;
            }
            else
            {
                life--;
            }

        }
        else if (other.tag.CompareTo("Player") == 0)//撞到主角
        {

            //添加爆炸效果
            Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Score.AddScore();
            EnemyPool.SubCount();
            life = 10;
            timer = 2.0f;
            secondTimer = 10.0f;
        }
    }
}
