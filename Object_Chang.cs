using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Object_Chang : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")//เมื่อ Object ที่ใส่ collision ชนกับ gameObject ที่มีแท็กที่ชื่อว่า Player
        {
            SceneManager.LoadScene("UnLock_2");//จะโหลดซีน UnLock_2
        }
    }

}
