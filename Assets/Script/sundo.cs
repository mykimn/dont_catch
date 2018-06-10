using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sundo : MonoBehaviour
{

    public static sundo Instance;
    public GameObject gameObject;
    public GameObject gameobject2;
    private void Awake()
    {
        sundo.Instance = this;
    }


    public float ReturnTime;
    public float RandomAmount;
    public bool isSundoEmpty;
    public Animator s_Anim;


    void Start()
    {
        gameobject2.SetActive(false);
        StartCoroutine(SundoRandom());
        isSundoEmpty = true;
    }

    float GetRandomTime()
    {
        return Random.Range(ReturnTime - RandomAmount, ReturnTime + RandomAmount);
    }

    IEnumerator SundoRandom()
    {
        while (true)
        {
            gameObject.SetActive(false);
            gameobject2.SetActive(true);
            yield return new WaitForSeconds(GetRandomTime());
            s_Anim.SetTrigger("half1");
            yield return new WaitForSeconds(0.5f);
            isSundoEmpty = false;
            gameobject2.SetActive(false);
            gameObject.SetActive(true);
            yield return new WaitForSeconds(GetRandomTime() * 0.5f);
            s_Anim.SetTrigger("half2");
            yield return new WaitForSeconds(0.5f);
            isSundoEmpty = true;
        }

    }
}
