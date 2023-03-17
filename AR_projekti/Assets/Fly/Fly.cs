using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<DragonController>().Eat();
        Destroy(gameObject, 0.2f);
    }
}
