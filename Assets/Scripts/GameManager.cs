using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Platform;
    [SerializeField] private GameObject Pota;
    [SerializeField] private GameObject PotaBuyume;
    [SerializeField] private GameObject[] PBSpawns;
    [SerializeField] private AudioSource[] Sesler;
    [SerializeField] private ParticleSystem[] Efektler;
  


    [SerializeField] private Image[] GorevGorselleri;
    [SerializeField] private GameObject[] Paneller;
    [SerializeField] private TextMeshProUGUI LevelAd;

    [SerializeField] private Sprite GorevTamamlandýSprite;
    [SerializeField] private int HedefTop;
    float ParmakPozX;

    int BasketSayisi;


    void Start()
    {
       LevelAd.text = "LEVEL: "+SceneManager.GetActiveScene().name;

       
        for (int i = 0; i < HedefTop; i++)
        {
            GorevGorselleri[i].gameObject.SetActive(true);  
        }
        //Invoke("PBOlustur", 3f);
    }
    void PBOlustur()
    {

        int RandomSayi = Random.Range(0, PBSpawns.Length-1);
        PotaBuyume.transform.position = PBSpawns[RandomSayi].transform.position;
        PotaBuyume.SetActive(true);
    }

    void Update()
    {
        if (Time.timeScale!=0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Platform.transform.position.x > -1.236)
                {
                    Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x - 0.1f, Platform.transform.position.y, Platform.transform.position.z), 050f);
                }

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Platform.transform.position.x < 1.236)
                {
                    Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x + 0.1f, Platform.transform.position.y, Platform.transform.position.z), 050f);
                }
            }
        }
        
    }
    public void Basket(Vector3 Poz)
    {
        Sesler[1].Play();
        
        BasketSayisi++;
        GorevGorselleri[BasketSayisi - 1].sprite = GorevTamamlandýSprite;
        Efektler[0].transform.position = Poz;
        Efektler[0].gameObject.SetActive(true);  
        //BasketSayisi
        // GorevGorselleri[i]
        if (BasketSayisi==HedefTop)
        {
            Kazandin();
        }
        if (BasketSayisi==1)
        {
            PBOlustur();
        }
    }
    public void Kazandin()
    {
        Time.timeScale = 0;
        Sesler[3].Play();
        Paneller[1].SetActive(true);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        
    }
    public void Kaybettin()
    {
        
        Paneller[2].SetActive(true);
        Time.timeScale = 0;

    }
    public void PotaBuyut(Vector3 Poz)
    {
        Efektler[1].transform.position = Poz;
        Efektler[1].gameObject.SetActive(true);
        Pota.transform.localScale = new Vector3(55, 55, 55);
        Sesler[0].Play();
    }
    public void Butonlarinislemleri(string Deger)
    {
        switch (Deger) 
        { 
            case "Durdur":
                Time.timeScale = 0;
                Paneller[0].SetActive(true);
                break;
            case "DevamEt":
                Time.timeScale = 1;
                Paneller[0].SetActive(false);
                break;
            case "Tekrar":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                break;
            case "SonrakiLevel":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
                Time.timeScale = 1;
                break;
            case "Ayarlar":
                //isteðe baðlý 
            case "Cikis":
                Application.Quit();
                break;
        }

    }

}
