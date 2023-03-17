using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed;
    private FixedJoystick fixedJoystick;
    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private GameManager gameManager;

    private void OnEnable()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>();
        rigidBody = gameObject.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //gameManager.StartGame();
    }

    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal;
        float yVal = fixedJoystick.Vertical;

        Vector3 movement = new Vector3(xVal, 0, yVal);
        rigidBody.velocity = movement * speed;

        if(xVal != 0 && yVal != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
    }

    public void Eat()
    {
        var scaleChange = new Vector3(0.05f, 0.05f, 0.05f);
        Debug.Log("chomp");
        audioSource.Play();
        gameObject.transform.localScale += scaleChange;
        speed += 0.1f;
    }
}
