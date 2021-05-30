using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRT_Player : MonoBehaviour
{
    public float speed = 2f;
    float inputX;
    bool chackPressButt = false;
    public bool isGround = false;
    public float gravity = 20f;

    SpriteRenderer sr;
    Animator anmin;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anmin = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            inputX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            MoveHorizontal();
            anmin.SetInteger("Movement", 1);
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            anmin.SetInteger("Movement", 0);
        }

        if (chackPressButt)
        {
            MoveHorizontal();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            anmin.SetInteger("Movement", 2);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7.5f), ForceMode2D.Impulse);
            
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anmin.SetInteger("Movement", 0);
        }
    }
    public void LeftPressButt()
    {
        inputX = -speed * Time.deltaTime;
        chackPressButt = true;
    }
    public void MoveHorizontal()
    {
        transform.Translate(inputX, 0, 0);
    }
    public void RightPressButt()
    {
        inputX = speed * Time.deltaTime;
        chackPressButt = true;
    }
    public void upButt()
    {
        chackPressButt = false;
    }
    public void JumpCharecter()
    {
        transform.position += new Vector3(0, 100, 0) * Time.deltaTime;
        chackPressButt = true;
    }
}
