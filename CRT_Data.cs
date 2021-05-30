using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //Input,Output
using System.Runtime.Serialization.Formatters.Binary; //เปลี่ยนจากภาษามนุษย์เป็นภาษาเครื่อง

using UnityEngine.UI; //เรียกใช้ UI

public class CRT_Data : MonoBehaviour
{
    public Game_Data data; //เรียกใช้สริปที่ 2 มาใช้ใน data
    string dataFilePath; //ที่เก็บชื่อไฟล์หรือ location File
    BinaryFormatter bf; //เก็บข้อมูลแบบ Binary ***bf เป็นชื่ออะไรก็ได้*** *** BinaryFormatter = ตัวแปลง ***

    private void Awake() //ก่อน Start
    {
        bf = new BinaryFormatter(); //เอาค่า bf มาตั้งค่า
        dataFilePath = Application.persistentDataPath + "/game.dat"; //ไม่ว่าไฟล์จะอยู่ที่ไหน หามาให้ฉัน
    }

    public void UpdataData() //แก้ตามเกม
    {
        data.Trash = Score_Data.Trash; //***แก้ตามเกม*** ***update ก่อนจะ save*** ***ชื่อไฟล์ตัวแรกที่เป็น static***
        data.HP = Score_Data.HP;
    }

    public void SaveData()
    {
        UpdataData(); //ต้องมี
        FileStream fs = new FileStream(dataFilePath, FileMode.Create); //สร้างไฟล์ FileStream *** FileMode.Create สร้างไฟล์ขึ้นมา 1 ไฟล์ชื่อ game.dat ใส่ไว้ใน fs ***
        bf.Serialize(fs, data); //เอา data ใส่ในไฟล์ fs โดยใช้ bf.Serialize
        fs.Close(); //ปิด fs
    }
    public void LoadData()
    {
        if (File.Exists(dataFilePath)) //มีไฟล์มั้ย
        {
            FileStream fs = new FileStream(dataFilePath, FileMode.Open); //เปิดไฟล์
            data = (Game_Data)bf.Deserialize(fs); //แปลงจากภาษาคอมมาเป็นภาษาคน
            fs.Close(); //ปิด fs
            DisplayData(); //วิ่งไปที่ DisplayData
        }
    }

    public void DisplayData() //เปลี่ยนตามตัวแปลของเกม ***เอาข้อมูลมาแสดงผล ***
    {
        GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>().text = data.Trash.ToString(); //โชว์เหรียญ
        Score_Data.Trash = data.Trash; //ประมวลผลเหรียญ
    }

    private void OnEnable() //เมื่อเปิดเกม
    {
        LoadData(); //โหลดข้อมูลจากไฟล์
    }

    private void OnDisable() //เมื่อปิดเกม
    {
        SaveData(); //เซฟข้อมูลให้ด้วย
    }
}
