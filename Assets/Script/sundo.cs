using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sundo : MonoBehaviour {

    public static sundo Instance;

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
        StartCoroutine(SundoRandom());
        isSundoEmpty = false;
    }

    float GetRandomTime()
    {
        return Random.Range(ReturnTime - RandomAmount, ReturnTime + RandomAmount);
    }

    IEnumerator SundoRandom()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetRandomTime());
            s_Anim.SetTrigger("half1");
            yield return new WaitForSeconds(0.5f);
            isSundoEmpty = true;
            yield return new WaitForSeconds(GetRandomTime() * 0.5f);
            s_Anim.SetTrigger("half2");
            yield return new WaitForSeconds(0.5f);
            isSundoEmpty = false;
        }

    }
}
