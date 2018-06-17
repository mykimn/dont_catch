using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private float startTime;
	private string textTime;
	private Text myTextComponent;

	// Use this for initialization
	void Start () {
		myTextComponent = GetComponent<Text> ();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float guiTime = Time.time - startTime;

		int minute = (int)(guiTime / 60);
		int second = (int)(guiTime % 60);
		int fraction = (int)((guiTime * 100) % 100);

		textTime = string.Format ("{0:00}:{1:00}:{2:00}",
			minute, second, fraction);
		myTextComponent.text = textTime;
	}
}
