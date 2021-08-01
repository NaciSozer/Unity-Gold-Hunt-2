using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{

    AudioSource mySong;

    //Atın sesleri
    public AudioClip horseIdea;
    public AudioClip horseDead;


    //Elma arabasının sesi
    public AudioClip appleShot;


    //Altın arabasının sesi
    public AudioClip goldShot;

    //Ateş etme sesi
    public AudioClip arrowShot;

    private void Start()
    {

        mySong = this.GetComponent<AudioSource>();

    }


    public void HorseDead()
    {

        mySong.PlayOneShot(horseDead);

    }

    public void AppleShot()
    {

        mySong.PlayOneShot(appleShot);

    }

    public void GoldShot()
    {

        mySong.PlayOneShot(goldShot);

    }

    public void ArrowShot()
    {
        mySong.PlayOneShot(arrowShot);
    }


}
