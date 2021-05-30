using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Move : MonoBehaviour//การเคลื่อนที่ของพื้น
{
    public GameObject[] Floor;
    float X;//กำหนดตัวแปล
    string Move = "Left";
    float Left, Right;//กำหนดตัวแปล
    void Start()
    {
        Left = -5;
        Right = -2;
    }

    // Update is called once per frame
    void Update()
    {
        MoveFloor(Floor[0], Left, Right); 
    }
    void MoveFloor(GameObject Floor,float Left,float Right)
    {
        if(Floor.transform.position.x >= Right)
        {
            Move = "Left";
        }
        if (Floor.transform.position.x <= Left)
        {
            Move = "Right";
        }

        if(Move == "Left")
        {
            X = -0.02f;
        }
        if (Move == "Right")
        {
            X = 0.02f;
        }
        Floor.transform.position += new Vector3(X, 0, 0);
    }
}
