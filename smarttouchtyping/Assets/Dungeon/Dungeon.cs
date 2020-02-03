using System.IO;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dungeon : MonoBehaviour
{
    [Header("Words File")]
    public string path = "Assets/Dungeon/Dungeon.txt";
    public string[] Words;

    [Header("GameObject")]
    public GameObject mother;
    public Canvas Rendering_canvas;
    public InputField ans;
    public TextMeshProUGUI Correct_word;
    public TextMeshProUGUI Word_List;
    public Image Monster;
    public Image Witch;

    [Header("Sprite")]
    public Sprite witch_atk;
    public Sprite mon_atked;

    [Header("ETC..")]
    public Animate_Sprite mon_anim;
    public Animate_Sprite witch_anim;

    private List<string> Words_no_space = new List<string>();

    private int ind = 0;

    private float count = .3f;

    private bool animate = false;

    private Vector3 ini;

    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        ReadAndGenerate();
        rigid = Monster.GetComponent<Rigidbody2D>();
        ini = Monster.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ans.ActivateInputField();

        if(Correct_word.text.Length > 10)
        {
            Correct_word.text = Correct_word.text.Substring(2);
        }

        if (animate)
        {
            count -= Time.deltaTime;
        }
        if(count <= 0)
        {
            animate = false;
            count = .3f;
            witch_anim.Play = true;
            mon_anim.Play = true;

        }

        Monster.transform.position -= new Vector3(30f * Time.fixedDeltaTime,0); 

        Monster.transform.position = new Vector2(Mathf.Clamp(Monster.transform.position.x,0,ini.x),Monster.transform.position.y);
    }

    void ReadAndGenerate()
    {
        StreamReader reader = new StreamReader(path);

        string s = reader.ReadToEnd();

        Words = s.Split(' ');


        foreach (string word in Words)
        {
            Word_List.text += " " +word;
        }

        for (int i = 0; i < Words.Length; i++)
        {
            if (Words[i].Contains("space"))
            {
                Words_no_space.Add(" ");
            }
            else
            {
                Words_no_space.Add(Words[i]);
            }
        }

    }

    public void Eval()
    {
        if (ans.text == Words_no_space[ind] && ans.text != "" && ans.text.Length <= Words_no_space[ind].Length)
        {
            Correct_word.text += " " + Words[ind];
            Witch.sprite = witch_atk;
            Monster.sprite = mon_atked;

            Monster.transform.position = new Vector2(Monster.transform.position.x + 100,Monster.transform.position.y);
            witch_anim.Play = false;
            animate = true;
            mon_anim.Play = false;
            if (!Words[ind].Contains("space")) {
                Word_List.text = Word_List.text.Substring(2);
            }
            else if(Words[ind].Contains("space"))
            {
                Word_List.text = Word_List.text.Substring(8);
            }
            else
            {
                Word_List.text = Word_List.text.Substring(Words[ind].Length);
            }

            ans.text = "";
            ind++;

        }
        else if (ans.text != "" && ans.text != Words_no_space[ind] && ans.text.Length <= Words_no_space[ind].Length)
        {
            ans.text = "";
        }
    }

}
