using DitzeGames.Effects;
using SaveData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class les1 : MonoBehaviour // Just Completed at this Sunday
{

    public GameObject result, close, close2, close3, character, newmap, ins,
       text, WPM1, star, star2, star3, Space, our_love_not_ever_old, AllAlpha;

    [Header("Text")]
    public Text score;
    public Text wrong;
    public Text charac;
    public Text charac2;
    public Text charac3;
    public Text charac4;
    public Text charac5;
    public Text num;
    public Text num1;
    public Text num2;
    public Text num3;
    public Text num4;
    public Text WPM;
    public Text sco;
    public Text wro;
    public Text one;
    public Text two;
    public Text three;
    public Text four;
    public Text five;
    public Text alpha;
    public Text alpha2;
    public Text alpha3;

    public GameObject bee;
    public GameObject mark;

    public float how_many;

    public static les1 inst;

    public GameObject Text;
    public float speed = 8.9f;
    public float jump = 12;
    public float gravity = 18;

    public GameObject Cha;

    public ParticleSystem effcorr;
    public AudioSource Jump;
    public AudioSource Wrong;

    Vector3 MoveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    public Slider TimeBar;
    public Slider PlayerBar;
    public float Limit = 60f;
    public float position = 98.5f;

    public List<GameObject> ob = new List<GameObject>();

    float Currtime = 0;
    int kumnod = 0; int color = 0; int a = 0;
    int td = 0, td2 = 0;
    int i = 0, j = 0; int plat = 0;
    public static int j1 = 0;
    float bar = 0;
    int[] sum = { 0, 0, 0, 0, 0, 0, 0, 0 };
    char[] w1 = { 'a', 's', 'd', 'f', 'j', 'k', 'l', ';' };
    int co = 1; double sec = 0;
    int number1 = 111, number2 = 112, number3 = 113;
    double answer;
    bool k = true;
    bool sure = true;
    bool debug = true;
    bool debug2 = true;
    bool debug3 = true;
    bool start = false;
    bool jumpCHK = true;
    bool debug4 = false;
    bool passed = false;

    public Vector3 curr;


    bool once = false;
    KeyCode key; GameObject clone;

    float deltaY = 1.61f;

    public Color[] CHcolor;

    bool checkCase = false, Cwrong = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        StartCoroutine(counttime(k));
        timmer();
        if (inst == null)
            inst = this;

        curr = Cha.transform.position;
    }

    void Update()
    {
        //  CallSaveData();
        Space.SetActive(false);
        if (KeyData.lesson1[i] == ' ')
        {
            Space.SetActive(true);
        }
        if (j1 >= 111) { jumpCHK = false; }
        key = Wordsdata.lesson1[i];
        three.text = KeyData.lesson1[i].ToString();
        four.text = KeyData.lesson1[i + 1].ToString();
        five.text = KeyData.lesson1[i + 2].ToString();
        if (j1 >= 1)
        {
            two.text = KeyData.lesson1[i - 1].ToString();
            if (i >= 2)
            {
                one.text = KeyData.lesson1[i - 2].ToString();
            }
        }
        sco.text = j1.ToString();
        wro.text = j.ToString();

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            how_many = j1; debug2 = false;
        }
        timmer();
        DoG(td);
        jumpsystem();
        Convert(KeyData.lesson1[i]);
        if (j1 > how_many - 1 && k)
        {
            Result();
        }
    }


    void jumpsystem()
    {
        if (jumpCHK) // PATH char
        {
            if (((j1 >= 27 && j1 <= 40) && key != KeyCode.Semicolon && key != KeyCode.Space) && jumpCHK) // char = is Upper
            {
                if (Input.GetKeyDown(key) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                {
                    checkCase = true;
                }
                else if ((Input.inputString != key.ToString() && (Input.inputString != ""))) // Wrong case
                {
                    Cwrong = true; ;
                }
            }
            else if (Input.GetKeyDown(key) && jumpCHK) //normal
            {
                checkCase = true;
            }
            else if ((Input.inputString != key.ToString() && (Input.inputString != "")) && debug2) // Wrong case
            {
                Cwrong = true;
            }
        }
        else // PATH words
        {
            our_love_not_ever_old.SetActive(false);
            if (key == KeyCode.Space)
            {
                AllAlpha.SetActive(false);
                alpha.color = CHcolor[2]; alpha2.color = CHcolor[2]; alpha3.color = CHcolor[2];
            }
            else
            {
                AllAlpha.SetActive(true);
            }
            alpha.text = KeyData.lesson1[number1].ToString(); alpha2.text = KeyData.lesson1[number2].ToString(); alpha3.text = KeyData.lesson1[number3].ToString();
            if (KeyData.lesson1[i] == ' ' && (Wordsdata.lesson1[i] == KeyCode.Space && Input.GetKeyDown(key))) // Space af words
            {
                number1 += 4; number2 += 4; number3 += 4;
                checkCase = true;
            }
            else if (Input.GetKeyDown(key) && !(KeyData.lesson1[i] == ' ')) // word in space
            {
                if (color > 2) { color = 0; }
                switch (color)
                {
                    case 0:
                        {
                            alpha.color = CHcolor[0];
                            break;
                        }
                    case 1:
                        {
                            alpha2.color = CHcolor[0];
                            break;
                        }
                    case 2:
                        {
                            alpha3.color = CHcolor[0];
                            break;
                        }
                }
                i++; j1++; bar++; color++;
            }
            else if ((Input.inputString != key.ToString() && (Input.inputString != "")) && debug2) // Wrong
            {
                Cwrong = true;
                switch (color)
                {
                    case 0:
                        {
                            alpha.color = CHcolor[1];
                            break;
                        }
                    case 1:
                        {
                            alpha2.color = CHcolor[1];
                            break;
                        }
                    case 2:
                        {
                            alpha3.color = CHcolor[1];
                            break;
                        }
                }
            }
        }

        if (checkCase) // Jump action
        {
            bar++;
            anim.SetInteger("condition", 1);
            MoveDir = new Vector3(1, 1, 1);

            if (!once)
            {
                curr = character.transform.position;
                once = true;
            }
            else if (once && passed)
            {
                once = false;
                passed = false;
                curr = Cha.transform.position;

            }

            if (j1 <= 9)
            {
                MoveDir.y = jump;
                MoveDir.z = -speed * 1.5f;
                MoveDir.x *= 0.01f;

            }
            else if (j1 >= 10 && j1 <= 12)
            {
                Cha.transform.rotation = Quaternion.Euler(0, 277, 0);
                MoveDir.y = jump;
                MoveDir.x = -speed * 1.5f;
                MoveDir.z = 0.01f;
            }
            else if (j1 >= 13 && j1 <= 19)
            {
                Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                MoveDir.y = jump;
                MoveDir.z = -speed;
                MoveDir.x = 0.01f;
            }
            else if (j1 == 20)
            {
                Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                MoveDir.y = jump * 1.2f;
                MoveDir.z = -speed;
                MoveDir.x = speed;
            }
            else if (j1 == 21)
            {
                Cha.transform.rotation = Quaternion.Euler(0, 195, 0);
                MoveDir.y = jump * 1.2f;
                MoveDir.z = -speed;
                MoveDir.x = -speed;
            }
            else if (j1 == 22)
            {
                Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                MoveDir.y = jump * 2;
                MoveDir.z = -speed*1.5f;
                MoveDir.x = 0.01f;
            }
            else if (j1 >= 23 && j1 < 27)
            {
                Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                MoveDir.y = jump;
                MoveDir.z = -speed * 1.5f;
                MoveDir.x = 0.01f;
            }
            else if (j1 == 27)
            {
                Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                MoveDir.y = jump;
                MoveDir.z = -speed * 1.5f;
                MoveDir.x = speed * 1.5f;
            }
            else if (j1 == 28)
            {
                Cha.transform.rotation = Quaternion.Euler(0, 195, 0);
                MoveDir.y = jump;
                MoveDir.z = -speed * 1.5f;
                MoveDir.x = -speed * 2f;
            }
            else if (j1 == 29)
            {
                Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                MoveDir.y = jump;
                MoveDir.z = -speed * 1.5f;
                MoveDir.x = speed * 1.5f;
            }
            else if (j1 == 30)
            {
                Cha.transform.rotation = Quaternion.Euler(0, 195, 0);
                MoveDir.y = jump * 2f;
                MoveDir.z = -speed;
                MoveDir.x = -speed * 1.5f;
            }
            else if (j1 == 31)
            {
                Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                MoveDir.y = jump * 2f;
                MoveDir.z = -speed * 1.5f;
                MoveDir.x = speed * 1.5f;
            }
            else if (j1 == 32)
            {
                Cha.transform.rotation = Quaternion.Euler(0, 195, 0);
                MoveDir.y = jump * 2f;
                MoveDir.z = -speed * 1.5f;
                MoveDir.x = -speed * 1.5f;
            }
            else if (j1 == 33)
            {
                Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                MoveDir.y = jump * 2f;
                MoveDir.z = -speed * 2;
                MoveDir.x = speed * 1.5f;
            }
            else if (j1 == 34)
            {
                Cha.transform.rotation = Quaternion.Euler(0, 195, 0);
                MoveDir.y = jump * 2f;
                MoveDir.z = -speed * 1.5f;
            }
            else
            {
                //ทำตั้งนานลืมว่ามี switch = =
                switch (j1)
                {
                    case 35:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump * 2f;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = -speed * 3;
                        break;
                    case 36:
                        Cha.transform.rotation = Quaternion.Euler(0, 195, 0);
                        MoveDir.y = jump * 2f;
                        MoveDir.z = -speed * 0;
                        MoveDir.x = speed * 3;
                        break;
                    case 37:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump * 2f;
                        MoveDir.z = -speed * 0;
                        MoveDir.x = -speed * 3;
                        break;
                    case 38:
                        Cha.transform.rotation = Quaternion.Euler(0, 195, 0);
                        MoveDir.y = jump * 2f;
                        MoveDir.z = -speed * 0;
                        MoveDir.x = speed * 3;
                        break;
                    case 39:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump * 2f;
                        MoveDir.z = -speed * 0;
                        MoveDir.x = -speed * 3;
                        break;
                    case 40:
                        Cha.transform.rotation = Quaternion.Euler(0, 195, 0);
                        MoveDir.y = jump * 2f;
                        MoveDir.z = -speed * 0;
                        MoveDir.x = speed * 3;
                        break;
                    case 41:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump * 2f;
                        MoveDir.z = -speed * 0;
                        MoveDir.x = -speed * 3;
                        break;
                    case 42:
                        Cha.transform.rotation = Quaternion.Euler(0, 195, 0);
                        MoveDir.y = jump * 2f;
                        MoveDir.z = -speed * 0;
                        MoveDir.x = speed * 3;
                        break;
                    case 43:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump * 2f;
                        MoveDir.z = -speed * 0;
                        MoveDir.x = -speed * 3;
                        break;
                    case 44:
                        Cha.transform.rotation = Quaternion.Euler(0, 195, 0);
                        MoveDir.y = jump * 2f;
                        MoveDir.z = -speed * 0;
                        MoveDir.x = speed * 3;
                        break;
                    case 45:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 46:
                        Cha.transform.rotation = Quaternion.Euler(0, 195, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = -speed * 3;
                        break;
                    case 47:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = -speed * 3;
                        break;
                    case 48:
                        Cha.transform.rotation = Quaternion.Euler(0, 195, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = speed * 3;
                        break;
                    case 49:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = speed * 3;
                        break;
                    case 50:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = speed * 3;
                        break;
                    case 51:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.001f;
                        break;
                    case 52:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = -speed * 3;
                        break;
                    case 53:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = -speed * 3;
                        break;
                    case 54:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = -speed * 3;
                        break;
                    case 55:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = -speed * 3;
                        break;
                    case 56:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.001f;
                        break;
                    case 57:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = speed * 3;
                        break;
                    case 58:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = speed * 3;
                        break;
                    case 59:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump * 2f;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = speed * 3;
                        break;
                    case 60:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.001f;
                        break;
                    case 61:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.001f;
                        break;
                    case 62:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = speed * 3;
                        break;
                    case 63:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump * 2f;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = -speed * 3;
                        break;
                    case 64:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = -speed * 3;
                        break;
                    case 65:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump * 2f;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = -speed * 3;
                        break;
                    case 66:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump * 2f;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = speed * 3;
                        break;
                    case 67:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = speed * 3;
                        break;
                    case 68:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = speed * 3;
                        break;
                    case 69:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = -speed * 3;
                        break;
                    case 70:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = speed * 3;
                        break;
                    case 71:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = -speed * 3;
                        break;
                    case 72:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = -speed * 3;
                        break;
                    case 73:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = -speed * 3;
                        break;
                    case 74:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = speed * 3;
                        break;
                    case 75:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = speed * 3;
                        break;
                    case 76:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 77:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 78:
                        Cha.transform.rotation = Quaternion.Euler(0, 165, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 79:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                        bee.transform.position = mark.transform.position;
                    case 80:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 81:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 82:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 83:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 84:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 85:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 86:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 87:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 88:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 89:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 90:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 91:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 92:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 93:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 94:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                    case 95:
                        Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                        MoveDir.y = jump;
                        MoveDir.z = -speed * 3;
                        MoveDir.x = 0.01f;
                        break;
                }
                if (j1 > 95)
                {
                    Cha.transform.rotation = Quaternion.Euler(0, 187, 0);
                    MoveDir.y = jump;
                    MoveDir.z = -speed * 3;
                    MoveDir.x = 0.02f;

                }
            }
            sure = true;
            start = true;
            checkCase = false;
        }
        else if (Cwrong) // Wrong action
        {
            print("Wrong");
            Wrong.Play();
            j++;
            sum[kumnod]++;
            CameraEffects.ShakeOnce();
            Cwrong = false;
        }

        if (Mathf.Abs(curr.z - Cha.transform.position.z) >= 5 && (sure) && j1 <= 9)
        {
            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();

            sure = false; debug4 = true;
        }
        else if (Mathf.Abs(curr.x - Cha.transform.position.x) >= 5 && (sure) && j1 >= 10 && j1 <= 12)
        {

            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();

            sure = false; debug4 = true;
        }
        else if (Mathf.Abs(curr.z - Cha.transform.position.z) >= 5 && (sure) && j1 >= 13 && j1 <= 18)
        {

            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();

            sure = false; debug4 = true;
        }
        else if (Mathf.Abs(curr.z - Cha.transform.position.z) >= 4 && (sure) && j1 >= 19 && j1 <= 21)
        {

            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();

            sure = false; debug4 = true;
        }
        else if (Mathf.Abs(curr.z - Cha.transform.position.z) >= 6 && (sure) && j1 == 22)
        {

            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();

            sure = false; debug4 = true;
        }

        else if (Mathf.Abs(curr.z - Cha.transform.position.z) >= 5.5f && (sure) && j1 >= 23 && j1 <= 27)
        {

            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();
            jump = 17f;
            sure = false; debug4 = true;
        }
        else if (Mathf.Abs(curr.z - Cha.transform.position.z) >= 5f && (sure) && j1 ==28)
        {

            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();
            jump = 17f;
            sure = false; debug4 = true;
        }
        else if (Mathf.Abs(curr.z - Cha.transform.position.z) >= 10 && (sure) && j1 >= 29 && j1 <= 30)
        {

            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();
            jump = 17f;
            sure = false; debug4 = true;
        }
        else if (Mathf.Abs(curr.z - Cha.transform.position.z) >= 15 && (sure) && j1 == 31)
        {

            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();
            jump = 17f;
            sure = false; debug4 = true;
        }
        else if (Mathf.Abs(curr.z - Cha.transform.position.z) >= 13 && (sure) && j1 == 32)
        {

            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();
            jump = 15f;
            sure = false; debug4 = true;
        }
        else if (Mathf.Abs(curr.z - Cha.transform.position.z) >= 10 && (sure) && j1 == 33)
        {

            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();
            jump = 15f;
            sure = false; debug4 = true;
        }
        else if (Mathf.Abs(curr.z - Cha.transform.position.z) >= 15 && (sure) && j1 == 34)
        {

            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();
            jump = 15f;
            sure = false; debug4 = true;
        }
        else if (Mathf.Abs(curr.z - Cha.transform.position.z) >= 7 && (sure) && j1 == 35)
        {

            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();
            jump = 15f;
            sure = false; debug4 = true;
        }
        else if (Mathf.Abs(curr.x - Cha.transform.position.x) >= 7.5f && (sure) && j1 >= 36 && j1 < 45)
        {

            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();
            jump = 15f;
            sure = false; debug4 = true;
        }
        else if (Mathf.Abs(curr.z - Cha.transform.position.z) >= 5 && (sure) && j1 >= 45 && j1 <= 200)
        {

            MoveDir.z *= 0;
            MoveDir.x *= 0;
            passed = true;
            anim.SetInteger("condition", 0);
            i++; ++td; j1++; td2++;
            effcorr.Play();
            Jump.Play();
            jump = 15f;
            sure = false; debug4 = true;
        }


        MoveDir.y -= gravity * Time.deltaTime * 3f;
        controller.Move(MoveDir * Time.deltaTime);
        /*print(curr);
        print("once  " + once);
        print("passed  " + passed);*/
    }

    void timmer()
    {
        if (Currtime < Limit)
        {
            if (TimeBar.value < PlayerBar.value - 0.01)
            {
                Currtime += Time.deltaTime;
                TimeBar.value = Currtime / Limit;
            }
            else
            {

            }
        }
        if (bar < how_many)
        {
            PlayerBar.value = (float)j1 / how_many;
        }
    }
    int res = 0;

    void Result()
    {
        if (j1 == how_many)//num of word in one lesson
        {
            sort();
            Grade();
            int j2 = j1 - j;
            res = j2;
            int ans2 = (int)answer;
            score.text = j1.ToString();
            wrong.text = j.ToString();
            num.text = sum[0].ToString();
            num1.text = sum[1].ToString();
            num2.text = sum[2].ToString();
            num3.text = sum[3].ToString();
            num4.text = sum[4].ToString();
            charac.text = w1[0].ToString();
            charac2.text = w1[1].ToString();
            charac3.text = w1[2].ToString();
            charac4.text = w1[3].ToString();
            charac5.text = w1[4].ToString();
            close.SetActive(false);
            result.SetActive(true);
            WPM.text = j2.ToString();
            WPM1.SetActive(true);
            k = false;
            upload.IncreaseScore(j2);
            upload.Newtime(sec);
            StartCoroutine(SavePlayerData());
        }
    }

    void sort()
    {
        for (int g = 0; g < 7; g++)
        {
            for (int g1 = 0; g1 < 7 - g; ++g1)
            {
                if (sum[g1] < sum[g1 + 1])
                {
                    int co = sum[g1];
                    sum[g1] = sum[g1 + 1];
                    sum[g1 + 1] = co;
                    char temp = w1[g1];
                    w1[g1] = w1[g1 + 1];
                    w1[g1 + 1] = temp;
                }
            }
        }
    }

    void DoG(int num)
    {
        debug = true;
        debug3 = true;
        if (num == 150 && debug)
        {
            clone = Instantiate(ins);
            clone.transform.position = new Vector3(ins.transform.position.x, ins.transform.position.y, ins.transform.position.z - position);
            clone.transform.localScale = ins.transform.lossyScale;
            position += 98.5f; ;
            debug = false;
            td = 0;
            num = 0;
        }
        else if (td2 == 60 && debug3)
        {
            Destroy(ob[a], 1f);
            td2 = 0;
            debug3 = false; a++;
        }
    }

    IEnumerator counttime(bool k)
    {
        while (k)
        {
            if (j1 != how_many)
            {
                yield return new WaitForSeconds(0.1f);
                sec += 0.1f;
            }
            else
            {
                break;
            }
        }

    }

    void Convert(char x)
    {
        switch (x)
        {
            case 'a':
                kumnod = 0;
                break;
            case 's':
                kumnod = 1;
                break;
            case 'd':
                kumnod = 2;
                break;
            case 'f':
                kumnod = 3;
                break;
            case 'j':
                kumnod = 4;
                break;
            case 'k':
                kumnod = 5;
                break;
            case 'l':
                kumnod = 6;
                break;
            case ';':
                kumnod = 7;
                break;
        }
    }

    void Grade()
    {
        int j2 = j1 - j;
        if ((j2 / how_many) * 100 >= 80)
        {
            star.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        if ((j2 / how_many) * 100 >= 60)
        {
            star.SetActive(true);
            star2.SetActive(true);
        }
        if ((j2 / how_many) * 100 >= 40)
        {
            star.SetActive(true);
        }
    }
    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    public IEnumerator SavePlayerData()
    {
        string final = "score:" + res + "," + charac.text + ":" + num.text + "," + charac2.text + ":" + num1.text + "," + charac3.text + ":" + num2.text + "," + charac4.text + ":" + num3.text + "," + charac5.text + ":" + num4.text;
        WWWForm form = new WWWForm();
        form.AddField("user", Login_next_page.ins.user);
        form.AddField("fname","les1.sav");
        form.AddField("score", final);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/Typing/sav_data.php", form);
        yield return www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);
    }
}