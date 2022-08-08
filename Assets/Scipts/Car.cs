using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public int Hiz=1;
    bool Hizlandi=false;
    GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(Destroy());
    }
    void Update()
    {
        transform.Translate(0,0,1*Hiz*Time.deltaTime);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car")
        gameManager.GetComponent<GameManager>().isDead = true;
    }

}


