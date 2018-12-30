using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform m_canvas;
    public Transform m_canvas2;
    public Transform m_canvas3;
    public Text m_text_gameover;
    protected Player m_player;
    public bool m_isPause = false;
    public Slider m_slider;
    public Text m_text;
    public Button m_button;
    public bool m_isAlive = true;
    public Button m_restart_button;
    // Use this for initialization

    void OnEnable()
    {
        if(!m_isAlive)
        {
            m_isAlive = true;
        }
    }

    void Start()
    {
        Instance = this;

        m_slider = m_canvas2.transform.Find("slider").GetComponent<Slider>();
        m_button = m_canvas2.transform.Find("button_backmenu").GetComponent<Button>();

        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        ESC();
    }
    public void Dead(bool a)
    {
        if (a)
        {
            m_canvas3.gameObject.SetActive(true);
            m_isAlive = false;
            Time.timeScale = 0;
        }
    }
    public void ESC()
    {
        {
            if (Input.GetKeyUp(KeyCode.Escape))
                m_isPause = !m_isPause;
            if (m_isPause)
            {
                m_canvas2.gameObject.SetActive(true);
                Time.timeScale = 0;
            }

            else
            {
                m_canvas2.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        EnemyPool.SetCount(0);
    }
    public void OnButtonBack()
    {
        SceneManager.LoadScene("StartMenu");
    }

}
