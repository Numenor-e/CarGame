using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public int Hiz=1;
    bool Hizlandi=false;
    GameObject gameManager;
    bool Gecti = false;
    public List<GameObject> Lastik;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(Destroy());
    }
    void Update()
    {
        transform.Translate(0,0,1*Hiz*Time.deltaTime);
        foreach(GameObject Teker in Lastik)
        {
            Teker.transform.Rotate(0.2f*Hiz,0,0);
        }
    }

    private void OnMouseDown()
    {
        if (Hizlandi == false)
        {
            Hiz = Hiz * 3;
            Hizlandi = true;
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Merkez")
        {
            Gecti = true;
        }
        if(other.tag == "Cikis")
        {
            Hiz=Hiz / 3;
            gameManager.GetComponent<GameManager>().Skor++;
            gameManager.GetComponent<GameManager>().Cagir();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Gecti == false)
        {
            if (other.tag == "Car")
            {
                gameManager.GetComponent<GameManager>().isDead = true;
            }
        }
    }

}


