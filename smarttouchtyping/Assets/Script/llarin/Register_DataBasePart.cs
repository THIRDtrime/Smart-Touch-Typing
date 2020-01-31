using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Register_DataBasePart : MonoBehaviour
{
    public InputField userField;
    public InputField passwordField;
    public GameObject firstPage;
    public GameObject check_mark;
    public GameObject now;
    public InputField null1; //fn
    public InputField null2; //email
    public InputField null3; //ln

    private bool start_count = false;
    private bool reg_success = false;
    private float count = 2;


    public Button submit_btn;
    public Button back_btn;

    public static Register_DataBasePart ins;

    public string username;
    public string status;

    private void Start()
    {
        if(ins == null) ins = this;

    }
    private void Update()
    {

        username = userField.text;

        if (start_count)
        {
            count -= Time.deltaTime;
        }
        if (reg_success)
        {
            check_mark.SetActive(true);
        }
        if (count <= 0)
        {
            check_mark.SetActive(false);
            now.SetActive(false);
            userField.Select();
            userField.text = "";
            passwordField.Select();
            passwordField.text = "";
            null1.Select();
            null2.Select();
            null3.Select();
            null1.text = "";
            null2.text = "";
            null3.text = "";
            start_count = false;
            count = 2;
        }
    }
    public void Callregister()
    {
        StartCoroutine(Register());
        count = 2;
    }
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", userField.text);
        form.AddField("pass", passwordField.text);
        form.AddField("email",null2.text);
        form.AddField("first",null1.text);
        form.AddField("last",null3.text);
        UnityWebRequest request = UnityWebRequest.Post("http://localhost/Typing/register.php", form);
        yield return request.SendWebRequest();
        status = request.downloadHandler.text;
        
        if (request.downloadHandler.text == "success")
        {
            Debug.Log("User create successfully");

            Take_Picture.ins.Take_Pic();

            start_count = true;
            reg_success = true;
            
        }
        else
        {
            Debug.Log("User ceartion failed. error #" + request.downloadHandler.text);
        }
    }
    public void VerifyInput()
    {
        submit_btn.interactable = (userField.text.Length >= 1 && passwordField.text.Length >= 8);
    }
    public void backfunction()
    {
        now.SetActive(false);
        userField.Select();
        userField.text = "";
        passwordField.Select();
        passwordField.text = "";
        null1.Select();
        null2.Select();
        null3.Select();
        null1.text = "";
        null2.text = "";
        null3.text = "";
    }
}
