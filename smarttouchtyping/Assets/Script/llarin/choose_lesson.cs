using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class choose_lesson : MonoBehaviour
{

    public GameObject ui1;
    int i = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void l1()
    {
        SceneManager.LoadScene(4);
    }

    public void l2()
    {
        SceneManager.LoadScene(3);
    }

    public void l3()
    {
        SceneManager.LoadScene(6);
    }

    public void next1()
    {
        SceneManager.LoadScene(3);
    }
    public void allLesson()
    {
        SceneManager.LoadScene(1);
    }
}
