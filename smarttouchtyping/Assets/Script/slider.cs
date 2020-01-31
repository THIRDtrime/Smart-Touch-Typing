using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider : MonoBehaviour
{
    public GameObject panel;
    public Slider sliderValue;

    public void Scroll(float newvalue)
    {
        sliderValue.minValue = -10;
        Vector3 pos = panel.transform.position;
        pos.x = -newvalue * 17;
        panel.transform.position = pos;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}