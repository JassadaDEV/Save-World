using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public int increaseCoin;
    int trash;
    int HP;
    public GameObject[] HP_Player;

    private void Update()
    {
        if (HP == 2)
        {
            HP_Player[0].SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Bin_Data.trash += increaseCoin;
            HP -= 1;
            Debug.Log(HP);
            Destroy(GameObject.Find("Heart (2)"));
            Destroy(this.gameObject);
        }  
    }
}
