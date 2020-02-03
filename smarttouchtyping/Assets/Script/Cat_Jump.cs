using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cat_Jump : MonoBehaviour
{
    [Header("Sprite to Random")]
    public Sprite[] Balloons;

    [Header("Words Data")]
    public string path = "Assets/Cat_les.txt";
    public string[] Words;

    [Header("GameObject")]
    public Image mother;
    public Image Cat;
    public Canvas canvas;
    public Canvas Rendering_canvas;
    public InputField ans;
    public Image Space;

    [Header("Cat Frame")]
    public Sprite[] cat_frame;

    [Header("Default Values")]
    public int Cat_fps;
    public Color Green = new Color(0, 255, 0);
    public Color Red = new Color(255, 0, 0);

    [HideInInspector]
    public int ind = 0;

    private int score = 0;

    private Vector3 offset;
    private Vector3 rendering_offset;

    private float count = 1f;

    bool cat_move = false;

    [HideInInspector]
    public List<Image> stored = new List<Image>();

    public static Cat_Jump ins;

    private void Awake()
    {
        ReadAndGenerate();

    }

    // Start is called before the first frame update
    void Start()
    {


        offset = canvas.transform.position - Camera.main.transform.position;
        rendering_offset = Rendering_canvas.transform.position - Camera.main.transform.position;

        if( ins == null)
            ins = this;

    }

    // Update is called once per frame
    void Update()
    {
        var index = (Time.time * Cat_fps) % cat_frame.Length;
        Cat.sprite = cat_frame[(int)index];

        ans.ActivateInputField();

    }
    private void LateUpdate()
    {
        canvas.transform.position = Camera.main.transform.position + offset;
    }


    void ReadAndGenerate()
    {
        StreamReader reader = new StreamReader(path);

        string s = reader.ReadToEnd();

        Words = s.Split(' ');
        int j = 1;

        foreach (string word in Words)
        {
            var i = Instantiate(mother, new Vector3(mother.gameObject.transform.position.x + j * 250, mother.gameObject.transform.position.y + 50 * Random.Range(-2, 1), -10), Quaternion.identity, Rendering_canvas.transform);
            i.sprite = Balloons[Random.Range(0, Balloons.Length)];
            j++;

            TextMeshProUGUI text = i.GetComponentInChildren<TextMeshProUGUI>();
            if (!word.Contains("space"))
            {
                text.text = word;
                i.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                i.transform.GetChild(1).gameObject.SetActive(true);
                text.text = " ";
            }


            stored.Add(i);
        }

    }

    public void MoveCam()
    {

        if (ans.text == stored[ind].GetComponentInChildren<TextMeshProUGUI>().text && ans.text != "" && ans.text.Length <= stored[ind].GetComponentInChildren<TextMeshProUGUI>().text.Length)
        {
            stored[ind].GetComponentInChildren<TextMeshProUGUI>().color = Green;
            cat_move = true;

            ans.text = "";
            score++;
            ind++;

            if (score == 2)
            {
                Camera.main.transform.position += new Vector3(Mathf.Abs(stored[ind].transform.position.x - stored[ind+1].transform.position.x),0,0);
            }
            else if (score > 2)
            {
                Camera.main.transform.position  += new Vector3(Mathf.Abs(stored[ind].transform.position.x - stored[ind + 1].transform.position.x), 0, 0);
            }
        }
        else if (ans.text != "" && ans.text != stored[ind].GetComponentInChildren<TextMeshProUGUI>().text && ans.text.Length <= stored[ind].GetComponentInChildren<TextMeshProUGUI>().text.Length)
        {
            stored[ind].GetComponentInChildren<TextMeshProUGUI>().color = Red;
            ans.text = "";
        }

    }
}
