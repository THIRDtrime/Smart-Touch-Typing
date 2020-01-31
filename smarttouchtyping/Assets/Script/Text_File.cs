using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Text_File : MonoBehaviour
{
    [Header("Words List")]
    public string[] Words4;
    public string[] Words6;
    public string[] Words8;

    [Header("Words Display")]
    public TextMeshProUGUI Word4_text;
    public TextMeshProUGUI Word6_text;
    public TextMeshProUGUI Word8_text;

    [Header("Input")]
    public TMP_InputField ANS;

    [Header("Status")]
    public TextMeshProUGUI timer;
    public TextMeshProUGUI Player_HP;
    public TextMeshProUGUI Enemy_HP;
    public TextMeshProUGUI Player_taken_dmg;
    public TextMeshProUGUI Enemy_taken_dmg;
    public TextMeshProUGUI Enemy_usage;
    public Slider Enemy_slider;
    public Slider Player_slider;
    public int player_hp_int = 40;
    public int enemy_hp_int = 40;

    private float turn_counter = 10f;
    private float effect_counter = 3f;

    bool start_count = false;
    bool start_effect = false;


    private void Start()
    {
        Enemy_taken_dmg.text = "";
        Player_taken_dmg.text = "";
        Enemy_usage.text = "";

        ReadString();
    }

    public void RandomWord()
    {
        int i, j, k;
        i = Random.Range(0, Words4.Length);
        j = Random.Range(0, Words6.Length);
        k = Random.Range(0, Words8.Length);

        Word4_text.text = char.ToUpper(Words4[i][0]) + Words4[i].Substring(1);
        Word6_text.text = char.ToUpper(Words6[j][0]) + Words6[j].Substring(1);
        Word8_text.text = char.ToUpper(Words8[k][0]) + Words8[k].Substring(1);

        Word4_text.color = new Color(255, 255, 255);
        Word6_text.color = new Color(255, 255, 255);
        Word8_text.color = new Color(255, 255, 255);

        start_count = true;
        turn_counter = 10;
    }
    private void Update()
    {
        Enemy_HP.text = enemy_hp_int.ToString();
        Player_HP.text = player_hp_int.ToString();

        Player_slider.value = player_hp_int;
        Enemy_slider.value = enemy_hp_int;

        ANS.ActivateInputField();

        if (start_count)
        {
            turn_counter -= Time.deltaTime;

        }
        if (start_effect)
        {
            effect_counter -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.PageUp))
        {
            RandomWord();
            start_count = true;
        }

        if (ANS.text != "" && Input.GetKey(KeyCode.Return))
        {
            EvalANS();
        }

        timer.text = Mathf.Ceil(turn_counter).ToString();

        if (effect_counter <= 0)
        {
            RandomWord();
            Enemy_taken_dmg.text = "";
            Player_taken_dmg.text = "";
            Enemy_usage.text = "";
            start_effect = false;
            effect_counter = 3;

        }
        if (turn_counter <= 0)
        {
            Punish();
        }
    }
    public void EvalANS()
    {
        if (ANS.text == Word4_text.text.Remove(Word4_text.text.Length - 1))
        {
            Word4_text.color = new Color(0, 255, 0);
            print("Word 4 matched");
            start_count = false;
            start_effect = true;
            Enemy_taken_dmg.text = "-4";
            enemy_hp_int -= 4;
        }
        else if (ANS.text == Word6_text.text.Remove(Word6_text.text.Length - 1))
        {
            Word6_text.color = new Color(0, 255, 0);
            print("Word 6 matched");
            start_count = false;
            start_effect = true;
            Enemy_taken_dmg.text = "-6";
            enemy_hp_int -= 6;
        }
        else if (ANS.text == Word8_text.text.Remove(Word8_text.text.Length - 1))
        {
            Word8_text.color = new Color(0, 255, 0);
            print("Word 8 matched");
            start_count = false;
            start_effect = true;
            Enemy_taken_dmg.text = "-8";
            enemy_hp_int -= 8;
        }
        else
        {
            Punish();
        }

        ANS.text = "";
    }

    public void Punish()
    {
        Word4_text.color = new Color(255, 0, 0);
        Word6_text.color = new Color(255, 0, 0);
        Word8_text.color = new Color(255, 0, 0);

        start_count = false;
        start_effect = true;

        turn_counter = 10;

        int chance = Random.Range(0, 101);
        int randword = Random.Range(0, Words4.Length);

        if (chance < 50)
        {
            Player_taken_dmg.text = "-4";
            player_hp_int -= 4;
            Enemy_usage.text = char.ToUpper(Words4[randword][0]) + Words4[randword].Substring(1);
        }
        else if (chance >= 50 && chance < 80)
        {
            Player_taken_dmg.text = "-6";
            player_hp_int -= 6;
            Enemy_usage.text = char.ToUpper(Words6[randword][0]) + Words6[randword].Substring(1);
        }
        else if (chance >= 80)
        {
            Player_taken_dmg.text = "-8";
            player_hp_int -= 8;
            Enemy_usage.text = char.ToUpper(Words8[randword][0]) + Words8[randword].Substring(1);
        }
        ANS.text = "";
    }


    public void ReadString()
    {
        string[] paths = { "Assets/Text4.txt", "Assets/Text6.txt", "Assets/Text8.txt" };
        foreach (var path in paths)
        {
            StreamReader reader = new StreamReader(path);
            if (path.Contains("4"))
            {
                Words4 = reader.ReadToEnd().Split('\n');
            }else if (path.Contains("6"))
            {
                Words6 = reader.ReadToEnd().Split('\n');
            }
            else if (path.Contains("8"))
            {
                Words8 = reader.ReadToEnd().Split('\n');
            }
            reader.Close();
        }

    }
}
