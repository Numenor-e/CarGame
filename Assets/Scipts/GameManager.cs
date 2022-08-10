using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isDead=false;

    public int EnYuksekSkor = 0;

    public int Skor=0;
    public Text SkorText;
    public Text EnYuksek;
    bool Stop=false;

    public GameObject Panel;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Skor"))
        {
            EnYuksekSkor = PlayerPrefs.GetInt("Skor");
        }
    }
    private void Update()
    {
        if (Skor > EnYuksekSkor) { EnYuksekSkor=Skor; }
        if (isDead == true) 
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
        PlayerPrefs.SetInt("Skor", EnYuksekSkor);

        SkorText.text = "Skor : " + Skor.ToString();
        EnYuksek.text = "En Yuksek Skor : " + EnYuksekSkor.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Stop == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        isDead = false;
    }
}
