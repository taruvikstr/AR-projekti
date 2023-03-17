using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_Text speedTXT, sizeTXT;

    public void UpdateUI(float speed, int size)
    {
        speedTXT.text = "Speed: " + speed.ToString();
        sizeTXT.text = "Size increased " + size.ToString() + " times";
    }
}
