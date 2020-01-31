using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Take_Picture : MonoBehaviour
{
    public RawImage raw;
    private WebCamTexture cam;
    //private RenderTexture rt;
    private Texture2D tex;

    public static Take_Picture ins;
    // Start is called before the first frame update
    void Start()
    {
        raw = GetComponent<RawImage>();
        cam = new WebCamTexture();

        if (ins == null) ins = this;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            raw.texture = cam;
            cam.Play();
        }
    }

    public void Take_Pic()
    {
        tex = new Texture2D(cam.width, cam.height, TextureFormat.RGBA32, false);

        RenderTexture currentRT = RenderTexture.active;

        RenderTexture renderTexture = new RenderTexture(cam.width, cam.height, 32);

        Graphics.Blit(cam, renderTexture);

        RenderTexture.active = renderTexture;

        tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);

        tex.Apply();

        Color[] buffer = tex.GetPixels();

        RenderTexture.active = currentRT;

        tex.SetPixels(buffer);

        var path = Path.Combine("C:\\Users\\OMEN\\Desktop\\STT\\" + Register_DataBasePart.ins.username, "profile.png");
        File.WriteAllBytes(path, tex.EncodeToPNG());

        renderTexture.Release();

        cam.Stop();
    }
}
