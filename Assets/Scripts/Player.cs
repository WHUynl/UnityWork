using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int m_speed;//速度
    public Transform m_transform;//组件管理
    public AudioClip m_shootClip;//声音
    protected AudioSource m_audio;//声音源
    public Transform m_explosionFX;//爆炸特效
    public float m_rocketTimer = 0;
    private Vector3 pos;
    private int life = 100;

    void Start()
    {
        m_transform = this.transform;
        m_audio = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        pos = Camera.main.WorldToViewportPoint(transform.position);
        float input_h = Input.GetAxisRaw("Horizontal");
        float input_v = Input.GetAxisRaw("Vertical");
        float curSpeed = m_speed * input_v * Time.deltaTime;
        transform.Rotate(new Vector3(0, input_h * 2, 0));
        transform.Translate(new Vector3(0, 0, curSpeed));
        m_rocketTimer -= Time.deltaTime;
        if (m_rocketTimer <= 0)
        {
            m_rocketTimer = 0.075f;
            //按空格或鼠标左键发射子弹
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                Rocket rocket = RocketPool.rocketPool.GetRocket();
                if (rocket != null)                  //不为空时执行
                {
                    rocket.gameObject.SetActive(true);         //激活子弹并初始化子弹的位置
                    rocket.transform.position = m_transform.position;
                    rocket.transform.rotation = m_transform.rotation;
                }
                //播放射击音效
                //m_audio.PlayOneShot(m_shootClip);
            }
        }
        //屏幕限制，主角不能冲出界面
        if (m_transform.transform.position.x >= 10)
        {
            m_transform.transform.position = new Vector3(10f, m_transform.transform.position.y, m_transform.transform.position.z);
        };
        if (m_transform.transform.position.x <= -10)
        {
            m_transform.transform.position = new Vector3(-10f, m_transform.transform.position.y, m_transform.transform.position.z);
        };
        if (m_transform.transform.position.z >= 5.5)
        {
            m_transform.transform.position = new Vector3(m_transform.transform.position.x, m_transform.transform.position.y, 5.5f);
        };
        if (m_transform.transform.position.z <= -5.5)
        {
            m_transform.transform.position = new Vector3(m_transform.transform.position.x, m_transform.transform.position.y, -5.5f);
        };
    }

    public int GetLife()
    {
        return life;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Enemy") == 0)
        {
            if (life <= 0)
            {
                //添加爆炸效果
                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                GameManager.Instance.Dead(true);
            }
            else
            {
                life -= 5;
            }
        }
        else if (other.tag.CompareTo("EnemyRocket") == 0)
        {
            if (life <= 0)
            {
                //添加爆炸效果
                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                GameManager.Instance.Dead(true);
            }
            else
            {
                life--;
            }
        }
        else if (other.tag.CompareTo("SecondRocket") == 0)
        {
            if (life <= 0)
            {
                //添加爆炸效果
                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                GameManager.Instance.Dead(true);
            }
            else
            {
                life--;
            }
        }
    }
}
