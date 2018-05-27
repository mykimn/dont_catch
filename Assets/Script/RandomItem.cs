using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour {

    public GameObject[] gooditem = new GameObject[6];
    public GameObject[] baditem = new GameObject[6];
    public GameObject[] showitem = new GameObject[12];

    // Use this for initialization
    void Start()
    {
        showitem[0] = gooditem[0];
        showitem[1] = gooditem[1];
        showitem[2] = gooditem[2];
        showitem[3] = gooditem[3];
        showitem[4] = gooditem[4];
        showitem[5] = gooditem[5];
        showitem[6] = baditem[0];
        showitem[7] = baditem[1];
        showitem[8] = baditem[2];
        showitem[9] = baditem[3];
        showitem[10] = baditem[4];
        showitem[11] = baditem[5];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            CreateRandomItem();
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {

        }

    }

    void CreateRandomItem()
    {
        //좌표 중복 없애기
        Vector2 pos;

        for (int i = 0; i < 8; i++)
        {
            pos = new Vector2(Random.Range(-17, 17f), Random.Range(-2.5f, 2.5f));
            Instantiate(showitem[Random.Range(0, 12)], pos, Quaternion.identity);
        }

    }

    void DestroyItem()
    {

    }
}
