using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public GameObject character;
    public GameObject text;

    public AudioSource jump;

    void Start()
    {

    }

    void Update()
    {   if(Input.GetKeyDown(KeyCode.Space))
       // if (character.transform.position.z <= text.transform.position.z + 0.7f)
        {
            jump.Play();
        }
    }
}
