using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour {

    public static Gauge Instance;
    private void Awake()
    {
        Gauge.Instance = this;
    }

    public Image slider;
   // public GameObject ReplayIm;
    public bool isDead = false;
    public float increaseAmount;
    public float decreaseAmount;

    private void Start()
    {
    }

    private void Update()
    {
        if(slider.fillAmount <= 0 && !isDead)
        {
            GameObject.Find("Canvas").transform.Find("GameOver").gameObject.SetActive(true);
            Time.timeScale = 1;
            isDead = true;

        }
    }

    public void increaseGauge(bool tof)
    {
        if (tof)
        {
            SFXMng.instance.SFXPlay(0);
        }
        else
        {
            SFXMng.instance.SFXPlay(1);
            slider.fillAmount -= decreaseAmount;
        }
    }
    public void Init()
    {
        slider.fillAmount = 1f;
    }
}
