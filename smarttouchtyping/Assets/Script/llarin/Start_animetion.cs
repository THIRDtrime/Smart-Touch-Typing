using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_animetion : MonoBehaviour
{

    public GameObject pic;
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    Vector3 check;
    public int speed = 4;
    public float position = 270;
    public float scale_min = 0.3f;
    public float scale_max = 0.5f;
    public float zoomSpeed = 0.01f;
    bool fix = true;
    bool fix2 = false;
    bool co = true;
    bool ca = false;

    // Start is called before the first frame update
    void Start()
    {
        check = new Vector3(0, position, 0);
        btn1.transform.localScale = new Vector3(0, 0, 0);
        btn2.transform.localScale = new Vector3(0, 0, 0);
        btn3.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(pic.transform.position.y > check.y)
        {
            pic.transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        else if(pic.transform.position.y <= check.y)
        {
            if(pic.transform.lossyScale.x < scale_max && fix)
            pic.transform.localScale += new Vector3(zoomSpeed, zoomSpeed, zoomSpeed);
            else if(pic.transform.lossyScale.x > scale_min)
            {
                fix = false;
                fix2 = true;
                pic.transform.localScale -= new Vector3(zoomSpeed, zoomSpeed, zoomSpeed);
            }
        }
       if(btn1.transform.lossyScale.x < 1.1f && co)
        {
            btn1.transform.localScale += new Vector3(zoomSpeed, zoomSpeed, zoomSpeed);
        }
        if (btn1.transform.lossyScale.x > 0.7f && btn2.transform.localScale.x < 0.8f)
        {
            btn2.transform.localScale += new Vector3(zoomSpeed, zoomSpeed, zoomSpeed);
        }
        if (btn2.transform.lossyScale.x > 0.4f && btn3.transform.localScale.x < 0.8f)
        {
            btn3.transform.localScale += new Vector3(zoomSpeed, zoomSpeed, zoomSpeed);
        }
        if(btn1.transform.lossyScale.x >= 1.1f || ca)
        {
            ca = true;
            co = false;
           
            if(btn1.transform.lossyScale.x > 0.75f)
            {
                btn1.transform.localScale -= new Vector3(zoomSpeed, zoomSpeed, zoomSpeed);
            }
        }
    }
}
