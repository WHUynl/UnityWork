using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class music : MonoBehaviour {

    // Use this for initialization
    public Slider bgSlider;	//背景音乐的Slider
    public AudioSource bgAudioSource;
    public void command()
    {
        bgAudioSource.volume = bgSlider.value;
    }

}
