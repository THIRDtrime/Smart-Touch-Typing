using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class Get_Info : MonoBehaviour
{
    public TextMeshProUGUI user, full;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Get_data());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Get_data()
    {
        WWWForm form = new WWWForm();
        form.AddField("user",Login_next_page.ins.user);

        UnityWebRequest req = UnityWebRequest.Post("http://localhost/Typing/get_prof_data.php",form);

        yield return req.SendWebRequest();

        string ans = req.downloadHandler.text;

        user.text = Login_next_page.ins.user;

        string full_name = ans.Replace("|"," ");
        full.text = full_name;

    }
}
