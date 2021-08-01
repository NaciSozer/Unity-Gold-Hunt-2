using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    //Oyunun kayıtlarını silmek için PleyerPref.DeleteAll();

    //At arabalarının oluşturulma değişkenleri
    public GameObject appleHorse, goldHorse;
    [SerializeField] float createTime;
    //At arabalarının şansa bağlı oluşma değişkenleri
    public bool apple;
    public bool created;
    public float randomTime;

    //Puan sistemi için değişkenler

    public Text scorText;
    public int scorValue;
    
    //En yüksek skor
    public Text highest;
    public int highestScore = 0;

    //Yemek barı için değişken tanımı
    public Slider food;
    public float foodvalue;

    //Panel işlemleri ayarlanması
    public GameObject panel;

    //Time Scle kontrolü
    public bool gameActive;

    private void Start()
    {

        //PlayerPrefs.DeleteAll();

        created = true;

        scorText.text = scorValue.ToString();

        food.value = foodvalue;

        highest.text = highestScore.ToString();
        highestScore =PlayerPrefs.GetInt("Save");


        gameActive = true;

        Debug.Log(highestScore);
    }


    void Update()
    {
        if (created)//at arabasının oluşması
        {
            Invoke("HorseCreated", 1.5f);
            created = false;

            //Debug.Log(randomTime);

        }


        Invoke("FoodHam", 5f);

        Debug.Log(Time.timeScale);

        if (foodvalue <=0)
        {

            gameActive = false;
            Panel();
        }
        //if (gameActive)
        //{
        //    Time.timeScale = 1;
        //}
        //else if (!gameActive)
        //{
        //    Time.timeScale = 0;
        //}

    }

    private void HorseCreated()//At arabalarının oluşturma sistemi
    {
        randomTime = Random.Range(1, 10);

        if (randomTime <= 2)
        {
            Instantiate(appleHorse, transform.position, Quaternion.identity);
            created = true;
        }

        else if (randomTime >= 3)
        {
            Instantiate(goldHorse, transform.position, Quaternion.identity);
            created = true;
        }




    }

    public void FoodHam()//Yemek çubuğunun değerini azaltma işlemleri
    {

        foodvalue -= 2f * Time.deltaTime;
        food.value = foodvalue;
    }

    public void AddFood(float ham)//Yemek çubuğun değerini artırma işlemleri
    {
        foodvalue += ham;
        food.value = foodvalue;
    }

    public void Scor(int scor)//Puan ekleme işlemleri
    {

        scorValue += scor;
        scorText.text = scorValue.ToString();

        if (scorValue > highestScore)
        {
            highestScore = scorValue;
            PlayerPrefs.SetInt("Save", highestScore);
            highest.text = highestScore.ToString();
            Debug.Log(highestScore);
        }

    }

    public void Panel()
    {
        panel.SetActive(true);
    }

    public void Restart()
    {
        gameActive = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }



}
