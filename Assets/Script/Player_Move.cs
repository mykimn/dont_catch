using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour
{
    bool isMoving;
    bool SundoCheck;
    public bool isPlayer;
    Vector3 targetPos;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
            if (!sundo.Instance.
                isSundoEmpty && SundoCheck)
            {
                SundoCheck = false;
            }
            //transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeed);
            /*if (transform.position == targetPos)
            {
                isMoving = false;
                if (isPlayer)
                {
                    if (SundoCheck)
                        SundoCheck = false;
                    else
                        //Gauge.Instance.increaseGauge(true);
                        Debug.Log("게이지 늘리기");
                }
            }*/
        }
    }
    void MoveObject()
    {
        int speed = 10;
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float distanceY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.LeftArrow)) //왼쪽일 때
        {
            this.gameObject.transform.Translate(distanceX, 0, 0);
            changePlayer("left1");
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow)) //오른쪽일 때
        {
            this.gameObject.transform.Translate(distanceX, 0, 0);
            changePlayer("right");
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.UpArrow))//위일 때
        {
            this.gameObject.transform.Translate(0, distanceY, 0);
            changePlayer("back");
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))//아래일 때
        {
            this.gameObject.transform.Translate(0, distanceY, 0);
            changePlayer("front");
            isMoving = true;
        }

        //화면 안에서만 움직이게 하기
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
        transform.position = worldPos; //좌표를 적용한다.
    }
    void changePlayer(string name)
    {
        Sprite spr;
        spr = (Sprite)Resources.Load(name, typeof(Sprite));
        gameObject.GetComponent<SpriteRenderer>().sprite = spr;
    }
}
