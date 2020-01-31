using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Mydatabase;

public class Login_next_page : MonoBehaviour
{

    public GameObject email ;
    public GameObject password;
    public GameObject Login;
    public GameObject Regis;
    public GameObject Regis2;
    public GameObject Forgot;
    public GameObject firstPage;
    public GameObject Menu;
    public GameObject al;
    public GameObject RegisterPage;
    public GameObject ForgotPage;
    public GameObject panel;

    public InputField use;
    public InputField pass;

    public Button Login_butt;
    public Button Regis_butt2;
    public Button Regis_butt;
    public Button forgot_butt;
    public Button start;

    private string Email ;
    private string Password ;

    public string user;

    public static Login_next_page ins;

    //public static bool Islogin = false;

    bool x,c;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        if (ins == null) ins = this;
        DontDestroyOnLoad(this);
    }
    // Update is called once per frame
    void Update()
    {
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        Login_butt = Login.GetComponent<Button>();
        Regis_butt = Regis.GetComponent<Button>();
        Regis_butt2 = Regis2.GetComponent<Button>();
        forgot_butt = Forgot.GetComponent<Button>();
        start.onClick.AddListener(gotologin);
        Regis_butt.onClick.AddListener(GotoRegister);
        forgot_butt.onClick.AddListener(Recall);
        Regis_butt2.onClick.AddListener(firstRegister);
    }
    private void GotoRegister()
    {
        RegisterPage.SetActive(true);
    }
    private void gotologin()
    {
        panel.SetActive(true);
    }
    private void Recall()
    {
        ForgotPage.SetActive(true);
    }
    private void firstRegister()
    {
        RegisterPage.SetActive(true);
    }
    public void toggle_Remember(bool x)
    {
       if(x == true)
        {
            c = false;
        }else
        {
            c = true;
        }
    }
    public void CallLogin()
    {
        StartCoroutine(login());
    }
    IEnumerator login()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", use.text);
        form.AddField("pass", pass.text);
        UnityWebRequest request = UnityWebRequest.Post("http://localhost/Typing/verify.php", form);
        yield return request.SendWebRequest();
        Debug.Log(request.downloadHandler.text);



        if (request.downloadHandler.text == "success")
        {
            //Islogin = true;
            /*DBmanager.username = use.text;
            DBmanager.score = int.Parse(request.downloadHandler.text.Split('\t')[1]);
            DBmanager.time = double.Parse(request.downloadHandler.text.Split('\t')[2]);*/
            firstPage.SetActive(false);
            Menu.SetActive(true);
            al.SetActive(false);
            user = use.text;
            if (c == false)
            {
                use.Select();
                pass.Select();
                use.text = "";
                pass.text = "";
            }
        }
        else
        {
            Debug.Log("User login failed.error#" + request.downloadHandler.text);
            al.SetActive(true);
        }
    }
    public void VerifyInput()
    {
        Login_butt.interactable = (use.text.Length >= 1 && pass.text.Length >= 8);
    }
}

namespace SavingData
{
    public class Islogin : MonoBehaviour
    {
        int i = 0;
        public static int[] lev;
        //DBmanager.lessondata.sc[

    }
}
