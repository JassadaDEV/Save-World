using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trash_Score : MonoBehaviour
{
    public int increaseCoin;
    int trash;
    public Text ScoreText;
    int HP;
    public GameObject[] HP_Player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Bin_Data.trash += increaseCoin;
            ScoreText.text = Bin_Data.trash.ToString();
            Debug.Log(HP);
            Destroy(this.gameObject);
        }
    }
}
