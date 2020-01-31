using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMove : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothCam = 0.5f;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        //if(les1.j1 <= 9)
        transform.position = target.position + new Vector3(-15,7,0);

        if (les1.j1 >= 19)
        {
            transform.position = target.position + new Vector3(0, 7, 15);
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles,new Vector3(transform.rotation.eulerAngles.x,180,0),.3f));
        }
        
        /*if (les1.j1 >= 13)
        {
            transform.position = target.position + new Vector3(-15, 7, 0);
        }*/

    }
    // Update is called once per frame

}
