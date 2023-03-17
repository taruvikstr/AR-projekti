using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject fixedJoystick;
    private GameObject verticalJoystick;
    private Rigidbody rigidBody;
    private int eats = 0;
    private AudioSource audioSource;
    private UI ui;

    private void OnEnable()
    {
        fixedJoystick = GameObject.Find("Fixed Joystick");
        verticalJoystick = GameObject.Find("Vertical Joystick");
        rigidBody = gameObject.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        ui = GameObject.Find("UI").GetComponent<UI>();
    }

    private void FixedUpdate()
    {
        float xVal = fixedJoystick.GetComponent<FixedJoystick>().Horizontal;
        float zVal = fixedJoystick.GetComponent<FixedJoystick>().Vertical;
        float yVal = verticalJoystick.GetComponent<FixedJoystick>().Vertical;

        Vector3 movement = new Vector3(xVal, 0, zVal);
        rigidBody.velocity = movement * speed;

        if(xVal != 0 && zVal != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, zVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }

        if(yVal != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + yVal * Time.deltaTime, transform.position.z);

        }
    }

    public void Eat()
    {
        var scaleChange = new Vector3(0.05f, 0.04f, 0.05f);
        Debug.Log("chomp");
        audioSource.Play();
        gameObject.transform.localScale += scaleChange;
        eats++;
        speed += 0.15f;
        
        ui.UpdateUI(speed, eats);
    }
}
