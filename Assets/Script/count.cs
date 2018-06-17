using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count : MonoBehaviour {
    private Text myTextComponent;
    // Use this for initialization
    void Start () {

        myTextComponent = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        myTextComponent.text = "획득한 아이템수 : " + Player_Move.cnt;
    }
}
