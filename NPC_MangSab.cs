using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_MangSab : MonoBehaviour
{
    Animator anmin; //
    SpriteRenderer sr; //

    [SerializeField] int speed = 1; // [SerializeField] เหมือน Arry แต่ใช้ได้แต่ในคาสนี้
    [SerializeField] Transform Player; // เช็ค Position Player
    [SerializeField] float closeDistance = 5f; //เส้นใกล้
    [SerializeField] float longDistance = 7f; //เส้นไกล

    float distanceToPlayer = Mathf.Infinity; //หาความหมายมา

    void Start()
    {
        anmin = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        DetectPlayer(); //ตรวจว่า Player เข้ามาใกล้แล้วยัง
    }
    public void DetectPlayer()
    {
        distanceToPlayer = Vector3.Distance(Player.position, transform.position); //Player.position ตำแหน่งผู้เล่น  transform.position ตำแหน่งของปลาแดง

        if (distanceToPlayer <= longDistance) //ถ้าเข้าวงเขียวจะแสดงท่า 1
        {
            anmin.SetInteger("Status", 1);
            

            if (distanceToPlayer <= closeDistance) //ถ้าเข้าวงแดงจะแสดงท่า 0
            {
                anmin.SetInteger("Status", 0);
                FollowPlayer(); //ตามผู้เล่น
            }
        }
        else
        {
            
            anmin.SetInteger("Status", 1); //ถ้าออกนอกวงจะกลับมาท่า 1
        }
    }
    public void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime); //MoveTowards เคลื่อนที่ไปข้างหน้าตาม Player.position
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, closeDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, longDistance);
    }
}
