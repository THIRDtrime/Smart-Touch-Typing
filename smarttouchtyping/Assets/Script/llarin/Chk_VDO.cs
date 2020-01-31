using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chk_VDO : MonoBehaviour
{

    public float HowlongOfVdo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait(HowlongOfVdo));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator wait(float x)
    {
        while(x > 0)
        {
            yield return new WaitForSeconds(x);
            break;
        }
        SceneManager.LoadScene(7);
    }

    public void skip()
    {
        SceneManager.LoadScene(7);
    }
}
