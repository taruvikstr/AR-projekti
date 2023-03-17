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
            if (timer > 5f) SpawnFly();
        }
    }
    public void StartGame()
    {
        //dragon = GameObject.FindGameObjectWithTag("Player");
        gameON = true;
        SpawnFly();
    }

    public void SpawnFly()
    {
        Instantiate(flyPrefab, new Vector3(dragon.transform.position.x + Random.Range(-4f, 4), dragon.transform.position.y + Random.Range(-2f, 2), dragon.transform.position.z + Random.Range(-4, 4)), Quaternion.identity);
        //Instantiate(flyPrefab, dragon.transform);
        timer = 0;
    }

}
