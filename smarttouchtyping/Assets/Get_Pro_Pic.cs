using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Get_Pro_Pic : MonoBehaviour
{
    private Image im;
    // Start is called before the first frame update
    void Start()
    {
        im = GetComponent<Image>();
        StartCoroutine(Get_Profile_Pic());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Get_Profile_Pic()
    {
        UnityWebRequest req = UnityWebRequest.Get(@"C:\\Users\\OMEN\\Desktop\\STT\\" + Login_next_page.ins.user + "\\profile.png");


        DownloadHandlerTexture dht = new DownloadHandlerTexture();

        req.downloadHandler = dht;
        yield return req.SendWebRequest();

        im.sprite = Sprite.Create(dht.texture, new Rect(0.0f, 0.0f, dht.texture.width, dht.texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
}
