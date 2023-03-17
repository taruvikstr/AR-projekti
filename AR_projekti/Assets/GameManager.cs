using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject flyPrefab;
    private GameObject dragon;
    private float timer = 0;
    private bool gameON = false;

    private void Update()
    {
        if(gameON)
        {
            timer += Time.deltaTime;
            if (timer > 10f) SpawnFly();
        }
    }
    public void StartGame()
    {
        dragon = GameObject.Find("Blue");
        gameON = true;
        SpawnFly();
    }

    public void SpawnFly()
    {
        Transform randomLocation = dragon.transform;
        randomLocation.position = new Vector3(randomLocation.transform.position.x + Random.Range(2, 5), randomLocation.transform.position.y, randomLocation.transform.position.z + Random.Range(2, 5));
        //Instantiate(flyPrefab, randomLocation);
        Instantiate(flyPrefab, dragon.transform);
        timer = 0;
    }
}
