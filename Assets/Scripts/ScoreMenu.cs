using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
    public GameObject L0;
    public GameObject[] newIndexs;

    public GameObject Panel;

    void Start()
    {
        SetScore();
    }

    private void SetScore()
    {
        newIndexs[0] = Instantiate(L0, transform.position, transform.rotation) as GameObject;
        newIndexs[0].transform.SetParent(Panel.transform);
        newIndexs[0].GetComponent<Text>().text = "积分榜";
        //将数据显示到场景UI中
        for (int i = 1; i <= 8; i++)
        {
            newIndexs[i] = Instantiate(L0, transform.position, transform.rotation) as GameObject;
            newIndexs[i].transform.SetParent(Panel.transform);
            newIndexs[i].GetComponent<Text>().text = "NO" + i + "\t" + PlayerPrefs.GetInt("NO." + i).ToString();
        }
    }
}
