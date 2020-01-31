using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boxing : MonoBehaviour
{
    [Header("Words from file")]
    public string[] Words;

    [Header("Timer Default Value")]
    public float Turn_default;
    public float Effect_default;

    private float effect_count;
    private float turn_count;
    bool start_count;
    bool start_effect;
    private string player_ans;
    private string enemy_ans;

    [Header("Slider")]
    public Slider player_hp_bar;
    public Slider enemy_hp_bar;

    [Header("Max/Current HP")]
    public int player_hp_int;
    public int enemy_hp_int;

    [Header("Text")]
    public TextMeshProUGUI block_word;
    public TextMeshProUGUI atk_word;
    public TextMeshProUGUI enemy_taken_dmg;
    public TextMeshProUGUI player_taken_dmg;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI Enemy_HP;
    public TextMeshProUGUI Player_HP;
    public TextMeshProUGUI Enemy_usage;
    public TextMeshProUGUI player_usage;
    public TextMeshProUGUI enemy_skill;
    public TextMeshProUGUI player_skill;
    public TextMeshProUGUI result;

    [Header("Input Field")]
    public TMP_InputField input_field;

    [Header("Color")]
    public Color Red = new Color(255, 0, 0);
    public Color Green = new Color(0, 255, 0);
    public Color White = new Color(255,255,255);

    [Header("Files")]
    public string path = "Assets/500.txt";


    // Start is called before the first frame update
    void Start()
    {
        Read500();
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_HP.text = enemy_hp_int.ToString();
        Player_HP.text = player_hp_int.ToString();

        player_hp_bar.value = player_hp_int;
        enemy_hp_bar.value = enemy_hp_int;

        

        if (start_count)
        {
            turn_count -= Time.deltaTime;
            input_field.ActivateInputField();
        }
        if (start_effect)
        {
            effect_count -= Time.deltaTime;
            input_field.DeactivateInputField();
        }

        if (Input.GetKey(KeyCode.PageUp))
        {
            RandomWord();
            start_count = true;
        }

        if (input_field.text != "" && Input.GetKey(KeyCode.Return))
        {
            EvalANS();
        }

        timer.text = Mathf.Ceil(turn_count).ToString();

        if (effect_count <= 0)
        {
            RandomWord();
            enemy_taken_dmg.text = "";
            player_taken_dmg.text = "";
            start_effect = false;
            effect_count = Effect_default;
            player_ans = "";
            enemy_ans = "";
            result.text = "";
            player_usage.text = "";
            Enemy_usage.text = "";
            enemy_skill.text = "";
            player_skill.text = "";
        }
        if (turn_count <= 0)
        {
            Punish();
        }
    }

    public void EvalANS()
    {
        if (input_field.text == block_word.text.Remove(block_word.text.Length - 1))
        {
            block_word.color = Green;
            print("Block");
            player_usage.text = input_field.text;
            start_count = false;
            start_effect = true;
            player_ans = "b";

        }
        else if (input_field.text == atk_word.text.Remove(atk_word.text.Length - 1))
        {
            atk_word.color = Green;
            print("Attack");
            player_usage.text = input_field.text;
            start_count = false;
            start_effect = true;
            player_ans = "a";
        }
        /*else if (input_field.text == cta_word.text.Remove(cta_word.text.Length - 1))
        {
            cta_word.color = new Color(0, 255, 0);
            print("Counter_attack");
            start_count = false;
            start_effect = true;
            player_ans = "d";
        }*/
        else
        {
            block_word.color = Red;
            atk_word.color = Red;

            Punish();
        }

        string enemy_word = Words[Random.Range(0, Words.Length)];
        int enemy_word_count = enemy_word.Length -1;

        Enemy_usage.text = char.ToUpper(enemy_word[0]) + enemy_word.Substring(1);

        System.Random rand = new System.Random();
        enemy_ans = new string(Enumerable.Repeat("ab", 1).Select(s => s[rand.Next(s.Length)]).ToArray());

        if (player_ans == enemy_ans) // Both Atk
        {
            result.text = "Traded!!";
            Punish();
            enemy_hp_int -= player_usage.text.Length;
        }
        else if (player_ans == "a" && enemy_ans == "b") //Player Blocked
        {
            result.text = "Enemy Blocked!!";

        }
        else if (player_ans == "b" && enemy_ans == "a") // Enemy Blocked
        {
            result.text = "Player Blocked!!";
        }

        switch (player_ans)
        {
            case "a": player_skill.text = "Attack"; break;
            case "b": player_skill.text = "Block"; break;
                //case "d": player_skill.text = "Dodge"; break;
        }
        switch (enemy_ans)
        {
            case "a": enemy_skill.text = "Attack"; break;
            case "b": enemy_skill.text = "Block"; break;
                //case "d": enemy_skill.text = "Dodge"; break;
        }
        input_field.text = "";
    }


    /// <summary>
    /// Deals Damage to player with random word with chance of Idle
    /// </summary>
    public void Punish()
    {

        start_count = false;
        start_effect = true;

        turn_count = Turn_default;

        int randword = Random.Range(0, Words.Length);

        int randIdle = Random.Range(0, 100);


        if (randIdle <= 60)
        {
            Enemy_usage.text = char.ToUpper(Words[randword][0]) + Words[randword].Substring(1);

            player_hp_int -= Words[randword].Remove(Words[randword].Length - 1).Length;
        }
        else
        {
            Enemy_usage.text = "(Missed)";
        }


        input_field.text = "";
    }
    void Read500()
    {
        StreamReader reader = new StreamReader(path);

        Words = reader.ReadToEnd().Split('\n');

        reader.Close();
    }

    public void RandomWord()
    {
        int i, j, k;
        i = Random.Range(0, Words.Length);
        j = Random.Range(0, Words.Length);
        k = Random.Range(0, Words.Length);

        atk_word.text = char.ToUpper(Words[i][0]) + Words[i].Substring(1);
        block_word.text = char.ToUpper(Words[j][0]) + Words[j].Substring(1);
        //cta_word.text = char.ToUpper(Words[k][0]) + Words[k].Substring(1);

        atk_word.color = new Color(255, 255, 255);
        block_word.color = new Color(255, 255, 255);
        //cta_word.color = new Color(255, 255, 255);

        start_count = true;
        turn_count = Turn_default;
    }
}
