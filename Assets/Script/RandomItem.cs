using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{

    public GameObject[] gooditem = new GameObject[6];
    public GameObject[] baditem = new GameObject[6];
    public GameObject[] showitem = new GameObject[12];

    public GameObject[] print = new GameObject[12];

    // Use this for initialization
    void Start()
    {
        showitem[0] = baditem[0];
        showitem[1] = baditem[1];
        showitem[2] = baditem[2];
        showitem[3] = baditem[3];
        showitem[4] = baditem[4];
        showitem[5] = baditem[5];
        showitem[6] = gooditem[0];
        showitem[7] = gooditem[1];
        showitem[8] = gooditem[2];
        showitem[9] = gooditem[3];
        showitem[10] = gooditem[4];
        showitem[11] = gooditem[5];
    }

    // Update is called once per frame
    public int flag = 1;
    void Update()
    {

        //아이템 나오는 소스
        if (!sundo.Instance.isSundoEmpty && flag == 0)
        {
            print = new GameObject[12];
            for (int i = 0; i < 12; i++)
            {
                print[i] = showitem[i];
            }

            CreateRandomItem();

            flag = 1;
        }

        //아이템 삭제
        if (sundo.Instance.isSundoEmpty && flag == 1) //시작부터 계속 들어와
        {
            for (int i = 0; i < print.Length; i++)
            {
                if (print[i] != null)
                {
                    DestroyImmediate(print[i].gameObject, true);
                }
              
            }

            flag = 0;
        }
    }


    void CreateRandomItem()
    {
        //좌표 중복 없애기
        Vector2 pos;

        for (int i = 0; i < 12; i++)
        {
            pos = new Vector2(Random.Range(-6.5f, 6.5f), Random.Range(-4.7f, 0f));
            print[i] = Instantiate(showitem[i], pos, Quaternion.identity) as GameObject;
            Debug.Log("createRancomItem()");
        }

    }
}