using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_MENU : MonoBehaviour
{

    public GameObject Lesson;
    public GameObject Setting;
    public GameObject MiniGame;
    public GameObject Proflie;
    public GameObject Back;
    public GameObject Firstpage;
    public GameObject Menu;

    public Button btnlesson;
    public Button btnset;
    public Button btnmini;
    public Button btnpro;
    public Button btnback;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Update is called once per frame
    void Update()
    {
        btnlesson = Lesson.GetComponent<Button>();
        btnset = Setting.GetComponent<Button>();
        btnmini = MiniGame.GetComponent<Button>();
        btnpro = Proflie.GetComponent<Button>();
        btnset = Setting.GetComponent<Button>();

        btnback.onClick.AddListener(back01);
    }

    private void back01()
    {
        Firstpage.SetActive(true);
        Menu.SetActive(false);
    }
    public void loadscene()  //Build Setting and add scene....
    {
        SceneManager.LoadScene(1);
    }
    public void loadscene2()
    {
        //SceneManager.LoadScene(1);
    }
    public void loadscene3()
    {
        //SceneManager.LoadScene(3);
    }
    public void loadscene4()
    {
        SceneManager.LoadScene(8);
    }
}
