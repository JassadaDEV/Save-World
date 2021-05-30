using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die_2 : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anmin;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anmin = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")//เมื่อ Object ที่ใส่ Script ชนกับ gameObject ที่มีแท็กที่ชื่อว่า NPC
        {
            anmin.SetInteger("Movement", 3);//เล่น animation ที่3
            Destroy(GameObject.Find("Heart (2)"));//ทำลาย Object
            Destroy(GameObject.Find("Heart (1)"));//ทำลาย Object
            Destroy(GameObject.Find("Heart"));//ทำลาย Object
            SceneManager.LoadScene("UnLock_4");////จะโหลดซีน UnLock_4
        }
    }
}
