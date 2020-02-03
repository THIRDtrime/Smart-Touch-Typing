using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class Sentence : MonoBehaviour
{
    [Header("Data")]
    public string path;
    public string[] Sentences;

    [Header("GameObject")]
    public TMP_InputField ans;
    public TextMeshProUGUI sentence_display;

    private int score;
    private int ind = 0;
    private int wrong;

    // Start is called before the first frame update
    void Start()
    {
        Read();
        sentence_display.text = Sentences[ind];
    }

    // Update is called once per frame
    void Update()
    {
        ans.ActivateInputField();

        sentence_display.text = Sentences[ind];

        if (ans.text != "" && Input.GetKeyDown(KeyCode.Return))
        {
            Eval();
            ind++;
        }
    }

    void Eval()
    {
        if (ans.text == sentence_display.text)
        {
            score += sentence_display.text.Length;

        }
        else
        {

        }

        ans.text = "";
    }

    void Read()
    {
        StreamReader reader = new StreamReader(path);

        Sentences = reader.ReadToEnd().Split('.');

        // Add Full stop (.)
        for (int i = 0; i < Sentences.Length; i++)
        {
            Sentences[i] = Sentences[i] + ".";
        }
    }
}
