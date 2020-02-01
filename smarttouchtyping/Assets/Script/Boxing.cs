using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boxing : MonoBehaviour
{
    [Header("Words List")]
    public string[] Words4;
    public string[] Words6;
    public string[] Words8;

    [Header("Timer Default Value")]
    public float Turn_default;
    public float Effect_default;

    private float effect_count;
    private float turn_count;
    bool start_count;
    bool start_effect;

    [Header("Slider")]
    public Slider player_hp_bar;
    public Slider enemy_hp_bar;

    [Header("Max/Current HP")]
    public int player_hp_int;
    public int enemy_hp_int;

    [Header("Text")]
    public TextMeshProUGUI l_atk_word;
    public TextMeshProUGUI n_atk_word;
    public TextMeshProUGUI h_atk_word;
    public TextMeshProUGUI enemy_taken_dmg;
    public TextMeshProUGUI player_taken_dmg;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI Enemy_HP;
    public TextMeshProUGUI Player_HP;
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

    [Header("GameObject")]
    public GameObject Enemy_Character;
    public GameObject Player_Character;
    public GameObject Text_l;
    public GameObject Text_n;
    public GameObject Text_h;

    private Animator player_anim;
    private Animator enemy_anim;

    [Header("Audio")]
    public AudioClip Bell_Once;
    public AudioClip Bell_End;
    public AudioClip Crowd;
    public AudioClip Hit;

    // Start is called before the first frame update
    void Start()
    {
        Read500();
        enemy_anim = Enemy_Character.GetComponent<Animator>();
        player_anim = Player_Character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_HP.text = enemy_hp_int.ToString();
        Player_HP.text = player_hp_int.ToString();

        player_hp_bar.value = player_hp_int;
        enemy_hp_bar.value = enemy_hp_int;

        if (player_hp_int <= 0)
        {
            result.text = "Defeated";
            player_anim.SetBool("Defeat",true);
            enemy_anim.SetBool("Victory", true);
        }
        if (enemy_hp_int <= 0)
        {
            result.text = "Victory!";
            enemy_anim.SetBool("Defeat",true);
            player_anim.SetBool("Victory", true);
        }

        if (start_count)
        {
            input_field.gameObject.SetActive(true);
            Text_l.SetActive(true);
            Text_n.SetActive(true);
            Text_h.SetActive(true);
            l_atk_word.gameObject.SetActive(true);
            n_atk_word.gameObject.SetActive(true);
            h_atk_word.gameObject.SetActive(true);

            turn_count -= Time.deltaTime;
            input_field.ActivateInputField();
        }
        if (start_effect)
        {
            effect_count -= Time.deltaTime;
            input_field.DeactivateInputField();
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
            result.text = "";
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
        if (input_field.text == l_atk_word.text.Remove(l_atk_word.text.Length - 1))
        {
            l_atk_word.color = Green;
            start_count = false;
            start_effect = true;
            enemy_hp_int -= 4;
            player_anim.SetTrigger("Punch");

            input_field.gameObject.SetActive(false);
            Text_l.SetActive(true);
            Text_n.SetActive(false);
            Text_h.SetActive(false);
            l_atk_word.gameObject.SetActive(true);
            n_atk_word.gameObject.SetActive(false);
            h_atk_word.gameObject.SetActive(false);

        }
        else if (input_field.text == n_atk_word.text.Remove(n_atk_word.text.Length - 1))
        {
            n_atk_word.color = Green;
            enemy_hp_int -= 6;
            start_count = false;
            start_effect = true;
            player_anim.SetTrigger("Punch");

            input_field.gameObject.SetActive(false);
            Text_l.SetActive(false);
            Text_n.SetActive(true);
            Text_h.SetActive(false);
            l_atk_word.gameObject.SetActive(false);
            n_atk_word.gameObject.SetActive(true);
            h_atk_word.gameObject.SetActive(false);
        }
        else if (input_field.text == h_atk_word.text.Remove(h_atk_word.text.Length - 1))
        {
            h_atk_word.color = Green;
            enemy_hp_int -= 8;
            start_count = false;
            start_effect = true;
            player_anim.SetTrigger("Punch");

            input_field.gameObject.SetActive(false);
            Text_l.SetActive(false);
            Text_n.SetActive(false);
            Text_h.SetActive(true);
            l_atk_word.gameObject.SetActive(false);
            n_atk_word.gameObject.SetActive(false);
            h_atk_word.gameObject.SetActive(true);
        }
        else
        {
            l_atk_word.color = Red;
            n_atk_word.color = Red;
            h_atk_word.color = Red;

            Punish();
        }

        /*string enemy_word = Words[Random.Range(0, Words.Length)];
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
            case "a": enemy_skill.text = "Attack"; enemy_anim.SetTrigger("Punch"); break;
            case "b": enemy_skill.text = "Block"; player_anim.SetTrigger("Block"); break;
                //case "d": enemy_skill.text = "Dodge"; break;
        }
        */
        input_field.text = "";
    }

    public void Punish()
    {

        start_count = false;
        start_effect = true;

        turn_count = Turn_default;

        player_hp_int -= 5;


        input_field.text = "";
    }
    void Read500()
    {
        string[] paths = { "Assets/Text4.txt", "Assets/Text6.txt", "Assets/Text8.txt" };
        foreach (var path in paths)
        {
            StreamReader reader = new StreamReader(path);
            if (path.Contains("4"))
            {
                Words4 = reader.ReadToEnd().Split('\n');
            }
            else if (path.Contains("6"))
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

    public void RandomWord()
    {
        int i, j, k;
        i = Random.Range(0, Words4.Length);
        j = Random.Range(0, Words6.Length);
        k = Random.Range(0, Words8.Length);

        h_atk_word.text = char.ToUpper(Words8[i][0]) + Words8[i].Substring(1);
        n_atk_word.text = char.ToUpper(Words6[i][0]) + Words6[i].Substring(1);
        l_atk_word.text = char.ToUpper(Words4[j][0]) + Words4[j].Substring(1);
        //cta_word.text = char.ToUpper(Words[k][0]) + Words[k].Substring(1);

        h_atk_word.color = new Color(255, 255, 255);
        l_atk_word.color = new Color(255, 255, 255);
        n_atk_word.color = new Color(255, 255, 255);

        start_count = true;
        turn_count = Turn_default;
    }
}
