using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject dragonPrefab;
    [SerializeField] private Vector3 prefabOffset;

    private GameObject dragon;
    private ARTrackedImageManager aRTrackedImageManager;
    [SerializeField] private GameObject flyPrefab;

    private float timer = 0;
    private bool gameON = false;

    private void OnEnable()
    {
        aRTrackedImageManager = GetComponent<ARTrackedImageManager>();

        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach(ARTrackedImage image in obj.added)
        {
            dragon = Instantiate(dragonPrefab, image.transform);
            dragon.transform.position += prefabOffset;
            StartGame();
        }
    }

    private void Update()
    {
        if (gameON)
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
        randomLocation.position = new Vector3(randomLocation.transform.position.x + Random.Range(0.5f, 2), randomLocation.transform.position.y, randomLocation.transform.position.z + Random.Range(0.5f, 2));
        Instantiate(flyPrefab, randomLocation);
        //Instantiate(flyPrefab, dragon.transform);
        timer = 0;
    }
}
