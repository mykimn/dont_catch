using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GamePause : MonoBehaviour,
IPointerClickHandler
{
	Image myImageComponent;
	public Sprite pauseImg;
	public Sprite playImg;

	bool isPaused = false;
	// Use this for initialization
	void Start () {
		myImageComponent = GetComponent<Image> ();
	}
	// Update is called once per frame
	void Update () {
	}
	public void OnPointerClick(PointerEventData eventData)
	{
		// pause되어 있을 때 
		if (isPaused == true) {
			myImageComponent.sprite = pauseImg; 
			Time.timeScale = 1;
			isPaused = false;
		}
		// play되어 있을 때 
		else if (isPaused == false) {
			myImageComponent.sprite = playImg;
			Time.timeScale = 0;
			isPaused = true;
		}
	}
}
