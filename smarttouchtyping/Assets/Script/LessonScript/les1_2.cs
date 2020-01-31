using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;
using DitzeGames.Effects;

public class les1_2 : MonoBehaviour // Just Completed at this Sunday
{

    public GameObject result;
    public GameObject close;
    public GameObject close2;
    public GameObject close3;
    public GameObject character;
    public GameObject newmap;
    public GameObject ins;
    public GameObject text;
    public GameObject WPM1;
    public GameObject star;
    public GameObject star2;
    public GameObject star3;
    public GameObject BEE;
    public GameObject SpaceBar;

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

    public Transform traget;
    public Transform deleter;

    public float how_many;

    public bool stampe;
    public bool chkwrong;

    public GameObject cam;
    public GameObject aksorn;
    public GameObject npsorn;
    public GameObject Text;
    float speed = 8.9f;
    float jump = 12;
    float gravity = 18;

    public GameObject Cha;

    public ParticleSystem effcorr;
    public AudioSource Jump;
    public AudioSource Wrong;
    GameObject clone;

    Vector3 MoveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    public Slider TimeBar;
    public Slider PlayerBar;
    public float Limit = 60f;
    public float position = 98.5f;
    float Currtime = 0;

    int kumnod = 0;
    int td = 0;
    int i = 0, i1 = 1, i2 = 2, i3 = 3, j = 0, j1 = 0;
    float bar = 0;
    int[] sum = { 0, 0, 0, 0, 0, 0, 0, 0 };
    char[] w1 = { 'a', 's', 'd', 'f', 'j', 'k', 'l', ';',' ' };
    int co = 1;
    int sec = 0;
    double answer;
    bool k = true;
    bool sure = true;
    bool debug = true;
    bool debug2 = true;
    bool start = false;
    KeyCode key;

    void Start()
    {
        WPM1.SetActive(false);
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        StartCoroutine(counttime(k));
        timmer();
    }

    // Update is called once per frame
    void Update()
    {
        if(KeyData.lesson2[i] == ' ')
        {
            SpaceBar.SetActive(true);
        }
        else { SpaceBar.SetActive(false); }
     
        key = Wordsdata.lesson2[i];
        three.text = KeyData.lesson2[i].ToString();
        four.text = KeyData.lesson2[i + 1].ToString();
        five.text = KeyData.lesson2[i + 2].ToString();
        if (j1 >= 1)
        {
            two.text = KeyData.lesson2[i - 1].ToString();
            if (i >= 2)
            {
                one.text = KeyData.lesson2[i - 2].ToString();
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
        count();
        Convert(KeyData.lesson1[i]);
        if (j1 > how_many - 1 && k)
        {
            Result();
        }
    }

    void count()
    {
        if (Input.GetKeyDown(key))
        {
            bar++;
            print("Correct");
            anim.SetInteger("condition", 1);

            MoveDir = new Vector3(1, 1, 1);
            MoveDir.y *= jump;

            MoveDir.z *= -speed;

            if (j1 % 2 == 0)
            {
                if (Cha.transform.position.x >= 1f)
                {
                    MoveDir.x *= -8.3f;
                }
                else
                    MoveDir.x *= -4f;
            }
            else if (j1 % 2 != 0)
            {
                if (Cha.transform.position.x <= -2.1f)
                {
                    MoveDir.x *= 8f;
                }
                else
                    MoveDir.x *= 4.5f;
            }
            sure = true;
            stampe = true;
            start = true;
        }
        else if ((Input.inputString != key.ToString() && (Input.inputString != "")) && debug2)
        {
            print("Wrong");
            Wrong.Play();
            chkwrong = true;
            j++;
            sum[kumnod]++;
            CameraEffects.ShakeOnce();
        }
        if (character.transform.position.z <= text.transform.position.z + 0.95f && (sure))
        {
            i++; i1++; i2++; i3++; ++td; j1++;
            effcorr.Play();
            Jump.Play();
            npsorn.transform.Translate(-0.01f, +0.0655f, -3.74f);
            sure = false;
        }
        MoveDir.y -= gravity * Time.deltaTime * 3f;
        controller.Move(MoveDir * Time.deltaTime);
        if (Cha.transform.position.y < 1.61)
        {
            MoveDir.z *= 0;
            MoveDir.x *= 0;
            anim.SetInteger("condition", 0);
        }
        chkwrong = false;
        stampe = false;
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
                if (BEE.transform.position.z >= Cha.transform.position.z - 7.8f)
                {
                    BEE.transform.Translate(0, 0, -50 * Time.deltaTime);
                }
            }
        }
        if (bar < how_many)
        {
            PlayerBar.value = (float)j1 / how_many;
        }
    }

    void Result()
    {
        if (j1 == how_many)//num of word in one lesson
        {
            sort();
            Grade();
            int j2 = j1 - j;
            //answer = how_many * 60 / (float)sec;
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
        if (num == 15 && debug)
        {
            clone = Instantiate(ins);
            clone.transform.position = new Vector3(ins.transform.position.x, ins.transform.position.y, ins.transform.position.z - position);
            clone.transform.localScale = ins.transform.lossyScale;
            position += 98.5f; ;
            debug = false;
            td = 0;
            num = 0;
        }
    }

    IEnumerator counttime(bool k)
    {
        while (k)
        {
            if (j1 != how_many)
            {
                yield return new WaitForSeconds(1);
                ++sec;
            }
            else
            {
                break;
            }

            Debug.Log(sec);
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
            case ' ':
                kumnod = 8;
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
}