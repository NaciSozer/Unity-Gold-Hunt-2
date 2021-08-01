using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //Puan sistemi için değişken tanımı
    GameControl scors;

    //Ses işlemleri
    SoundsController songs;

    private void Start()
    {
        scors = GameObject.Find("GM").GetComponent<GameControl>();

        songs = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundsController>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {

            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("AppleCar"))
        {
            songs.AppleShot();
            scors.AddFood(1.5f);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("GoldCar"))
        {

            songs.GoldShot();
            scors.Scor(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Horse"))
        {
            songs.HorseDead();

            Time.timeScale = 0;
            scors.Panel();
        }
    }
}
