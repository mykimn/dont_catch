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
           // ReplayIm.SetActive(true);
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
