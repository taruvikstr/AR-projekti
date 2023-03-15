using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject flyPrefab;
    private GameObject dragon;
    private float timer = 0;
    private bool gameON;

    private void Update()
    {
        if(gameON)
        {
            timer += Time.deltaTime;
            if (timer > 10f) StartGame();
        }
    }
    public void StartGame()
    {
        Transform randomLocation = dragon.transform;
        randomLocation.position = new Vector3(randomLocation.transform.position.x + Random.Range(2,5), randomLocation.transform.position.y, randomLocation.transform.position.z + Random.Range(2, 5));
        Instantiate(flyPrefab, randomLocation);
        timer = 0;
    }
}
