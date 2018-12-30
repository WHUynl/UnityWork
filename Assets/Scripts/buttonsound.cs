using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;
public class buttonsound : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip m_clip;
    public AudioSource m_audio;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerEnter(PointerEventData eventData)
    {
     m_audio.Play();   
    }

}
