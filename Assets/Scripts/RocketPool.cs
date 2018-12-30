using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPool : MonoBehaviour
{
    public static RocketPool rocketPool;
    public Rocket rocket;
    public int poolAmount = 10;
    public bool isLockPool = false;

    private List<Rocket> pooledRocket;

    private int currentIndex = 0;

    private void Awake()
    {
        rocketPool = this;
    }

    private void Start()//初始化子弹池大小
    {
        pooledRocket = new List<Rocket>();

        for(int i=0;i<poolAmount;i++)
        {
            Rocket initRocket = Instantiate(rocket);
            initRocket.gameObject.SetActive(false);
            pooledRocket.Add(initRocket);
        }
    }

    public Rocket GetRocket()//从池中得到子弹
    {
        for(int i=0;i<pooledRocket.Count;i++)
        {
            int index = (currentIndex + i) % pooledRocket.Count;

            if(!pooledRocket[index].gameObject.activeInHierarchy)
            {
                currentIndex = (index + 1) % pooledRocket.Count;
                return pooledRocket[index];
            }
        }

        if(!isLockPool)
        {
            Rocket initRocket = Instantiate(rocket);
            pooledRocket.Add(initRocket);
            return initRocket;
        }

        return null;
    }
}
