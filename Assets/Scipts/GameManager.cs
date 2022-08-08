using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public bool isDead=false;

    public GameObject Panel;
    private void Update()
    {
        if (isDead == true) 
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        isDead = false;
    }
}
