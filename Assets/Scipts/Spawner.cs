using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   
    public float Time = 0.99f;
    public List<GameObject> Cars = new List<GameObject>();
    public List<GameObject> SpawnPoint = new List<GameObject>();
    GameObject gameManager;
    
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(Spawn());
        
    }
    private void Update()
    {
        
    }

  

    IEnumerator Spawn()
    {
        float Times = Time;
        while (true)
        {
            yield return new WaitForSeconds(1.5f*Times);
            Times -= 0.005f;
            CarSpawn();
        }
       
    }


    void CarSpawn()
    {
        if (gameManager.GetComponent<GameManager>().isDead == false)
        {
            int SpawnSira;
            int CarSira;

            SpawnSira = Random.Range(0, 3 + 1);
            CarSira = Random.Range(0, 4 + 1);

            Transform Pozisyon = SpawnPoint[SpawnSira].transform;

            Instantiate(Cars[CarSira], new Vector3(Pozisyon.position.x, Pozisyon.position.y, Pozisyon.position.z), Quaternion.Euler(0, (SpawnSira + 1) * 90, 0));

        }
    }
}
