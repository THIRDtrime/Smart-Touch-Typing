using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destory : MonoBehaviour
{

    public Image ballon;
    float MaxTimes = 3f;
    float CurTime = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(CurTime < MaxTimes)
        {
            CurTime += Time.deltaTime;
            ballon.fillAmount = CurTime / MaxTimes;
        }
    }
}
