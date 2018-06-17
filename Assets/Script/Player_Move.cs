using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour
{
    bool isMoving;
    public static bool SundoCheck;
    public bool isPlayer;
    Vector3 targetPos;
    GameObject Sundo = null;
    int sum = 0;
    int cnt = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Sundo = GameObject.Find("Sundo");
        isMoving = false;
        MoveObject();
        if (isMoving)
        {
            if (sundo.Instance.isSundoEmpty && !SundoCheck && isPlayer)
            {
                Debug.Log("들킴");
                Gauge.Instance.increaseGauge(false);
                SundoCheck = true;
            }
            if (!sundo.Instance.isSundoEmpty && SundoCheck)
            {
                SundoCheck = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "GoodItem")
        {
            Destroy(c.gameObject);
        }
        else if (c.gameObject.tag == "BadItem")
        {
            Destroy(c.gameObject);
            Gauge.Instance.increaseGauge(false);
        }
    }
    void MoveObject()
    {
        int speed = 10;
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float distanceY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Vector3 pos = this.gameObject.transform.position;

        if (Input.GetKey(KeyCode.LeftArrow)) //왼쪽일 때
        {
            if (pos.x > -6.55)
            {
                this.gameObject.transform.Translate(distanceX, 0, 0);
                changePlayer("left1");
                isMoving = true;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow)) //오른쪽일 때
        {
            if (pos.x < 6.55)
            {
                this.gameObject.transform.Translate(distanceX, 0, 0);
                changePlayer("right");
                isMoving = true;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))//위일 때
        {
            if (pos.y < 1.47)
            {
                this.gameObject.transform.Translate(0, distanceY, 0);
                changePlayer("back");
                isMoving = true;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))//아래일 때
        {
            if (pos.y > -3.28)
            {
                this.gameObject.transform.Translate(0, distanceY, 0);
                changePlayer("front");
                isMoving = true;
            }
        }

        Vector3 pos_sundo = Sundo.gameObject.transform.position;

        if (Input.GetKey(KeyCode.Space) && cnt >= 0 && pos.x > -0.8 && pos.x < 0.6)
        {
            float su_y = pos_sundo.y;
            float y = pos.y;
            Vector3 target_sundo = new Vector3((float)0.13, (float)-3.2, 0);
            Vector3 start_sundo = new Vector3((float)0.13, (float)1.47, 0);
            Vector3 target = new Vector3((float)0.13, (float)-3.28, 0);
            Vector3 start = new Vector3((float)0.13, pos.y, 0);


            changePlayer("front");
            this.gameObject.transform.position = Vector3.MoveTowards(start, target, speed + 50);
            Sundo.transform.position = Vector3.MoveTowards(start_sundo, target_sundo, speed + 50);


            Sundo.transform.position = new Vector3((float)0.13, (float)1.47);
        }
    }
    void changePlayer(string name)
    {
        Sprite spr;
        spr = (Sprite)Resources.Load(name, typeof(Sprite));
        gameObject.GetComponent<SpriteRenderer>().sprite = spr;

    }
}
