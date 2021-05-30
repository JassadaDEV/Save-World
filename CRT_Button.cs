using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CRT_Button : MonoBehaviour
{
    public GameObject Player;
    CRT_Player movePlayer;

    private void Start()//ต้องมี
    {
        movePlayer = Player.GetComponent<CRT_Player>();
    }
    public void MoveLeft()//ต้องมี
    {
        movePlayer.LeftPressButt();
    }
    public void StopMove()//ต้องมี
    {
        movePlayer.upButt();
    }
    public void MoveRight()//ต้องมี
    {
        movePlayer.RightPressButt();
    }
    public void Jump()
    {
        movePlayer.JumpCharecter();
    }
}
