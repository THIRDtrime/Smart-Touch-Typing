using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;
using DitzeGames.Effects;

public class les2 : MonoBehaviour // Just Completed at this Sunday
{

    public GameObject result;
    public GameObject close;
    public GameObject close2;
    public GameObject close3;
    public GameObject character;
    public GameObject newmap;
    public GameObject ins;
    public GameObject res;
    public GameObject text;

    public Text alpha;
    public Text alpha1;
    public Text alpha2;
    public Text alpha3;
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

    public Transform traget;
    public Transform deleter;

    public int how_many;

    public static les1 inst;

    public bool stampe = true;
    public bool chkwrong;

    public GameObject cam;
    public GameObject aksorn;
    public GameObject npsorn;
    public GameObject Text;
    float speed = 9.2f;
    float jump = 12;
    float gravity = 18;

    public GameObject Cha;

    public ParticleSystem effcorr;
    public AudioSource Jump;
    public AudioSource Wrong;

    Vector3 MoveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    int td = 0;
    int i, i1, i2, i3, j, j1;
    int[] sum = { 0, 0, 0, 0, 0, 0, 0, 0 };
    char[] w1 = { 'a', 's', 'd', 'f', 'j', 'k', 'l', ';' };
    int co = 1;
    int sec = 0;
    double answer;
    bool k = true;
    bool sure = true;
    bool debug = false;
    KeyCode key;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        StartCoroutine(counttime(k));
        i = 7; i1 = 6; i2 = 5; i3 = 4;
    }

    // Update is called once per frame
    void Update()
    {
        key = Wordsdata.lesson1[i];
        if (i == 7)
        {
            alpha.text = ";";
        }
        else if (i == 2)
        {
            alpha.text = "d";
        }
        else
        {
            alpha.text = Wordsdata.lesson1[i].ToString().ToLower();
        }
        if (i1 == 7)
        {
            alpha1.text = ";";
        }
        else if (i1 == 2)
        {
            alpha1.text = "d";
        }
        else
        {
            alpha1.text = Wordsdata.lesson1[i1].ToString().ToLower();
        }
        if (i2 == 7)
        {
            alpha2.text = ";";
        }
        else if (i2 == 2)
        {
            alpha2.text = "d";
        }
        else
        {
            alpha2.text = Wordsdata.lesson1[i2].ToString().ToLower();
        }
        if (i3 == 7)
        {
            alpha3.text = ";";
        }
        else if (i3 == 2)
        {
            alpha3.text = "d";
        }
        else
        {
            alpha3.text = Wordsdata.lesson1[i3].ToString().ToLower();
        }

        DoG(td);
        count();
    }

    void count()
    {
        if (Input.GetKeyDown(key))
        {
            print("Correct");
            anim.SetInteger("condition", 1);

            MoveDir = new Vector3(1, 1, 1);
            MoveDir.y *= jump;

            MoveDir.z *= -speed;

            if(j1%2 == 0)
            {
                if(Cha.transform.position.x >= 1f)
                {
                    MoveDir.x *= -8.3f;
                }else
                MoveDir.x *= -4f;
            }else if(j1%2 != 0)
            {
                if(Cha.transform.position.x <= -2.1f)
                {
                    MoveDir.x *= 8f;
                }else
                MoveDir.x *= 4.5f;
            }

            //  MoveDir = transform.TransformDirection(MoveDir);
            debug = true;
            sure = true;
        }
        else if (Input.inputString != key.ToString() && (Input.inputString != ""))
        {
            print("Wrong");
            Wrong.Play();
            chkwrong = true;
            j++;
            sum[i]++;
            CameraEffects.ShakeOnce();
        }
        if (character.transform.position.z <= text.transform.position.z + 0.95f && (sure))
        {
            if(j1 > 7)
            {
                if(stampe)
                {
                    i = 7; i1 = 6; i2 = 5; i3 = 4;
                }
                i--; i1 = i-1; i2 = i-2; i3 = i-3; j1++;
                if(i == 1)
                {
                    i1 = 7;
                }
            }
            else
            {
                i++; i1++; i2++; i3++; ++td; j1++;
            }
            effcorr.Play();
            Jump.Play();
            if(j1%2 == 0)
            {
                alpha.rectTransform.Translate(2.8f, 0, 0);
                alpha1.rectTransform.Translate(-2.8f, 0, 0);
                alpha2.rectTransform.Translate(2.8f, 0, 0);
                alpha3.rectTransform.Translate(-2.8f, 0, 0);
            }else if(j1%2 != 0)
            {
                alpha.rectTransform.Translate(-2.8f, 0, 0);
                alpha1.rectTransform.Translate(2.8f, 0, 0);
                alpha2.rectTransform.Translate(-2.8f, 0, 0);
                alpha3.rectTransform.Translate(2.8f, 0, 0);
            }
            npsorn.transform.Translate(-0.03f, 0, -3.84f);
            sure = false;
        }
        if (i > 7)
        {
            i = 0;
        }
        if (i1 > 7)
        {
            i1 = 0;
        }
        if (i2 > 7)
        {
            i2 = 0;
        }
        if (i3 > 7)
        {
            i3 = 0;
        }
        if(i < 0)
        {
            i = 7;
        }
        if (i1 < 0)
        {
            i1 = 6;
        }
        if (i2 < 0)
        {
            i2 = 7;
        }
        if (i3 < 0)
        {
            i3 = 7;
        }
        if (j1 == how_many && k)//num of word in one lesson
        {
            // Debug.Log(sec);
            answer = how_many * 60 / (float)sec;
            int ans2 = (int)answer;
            Debug.Log(ans2);
            WPM.text = ans2.ToString();
            sort();
            int j2 = j1 - j;
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
            k = false;
        }
        MoveDir.y -= gravity * Time.deltaTime * 3f;
        controller.Move(MoveDir * Time.deltaTime);
        if (Cha.transform.position.y < 1.61)
        {
            MoveDir.x *= 0;
            MoveDir.z *= 0;
            anim.SetInteger("condition", 0);
        }
        chkwrong = false;
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
        if (num == 9)
        {
            newmap = Instantiate(ins);
            newmap.transform.position = transform.position + new Vector3((float)-4019.2, (float)-1416.19, (float)-331.9264); // add spawn position (x,y,z)
            newmap.transform.localScale = transform.localScale + new Vector3((float)505.5598, (float)316.4669, (float)174.6981);
            for (int q = 0; q < 3; q++)
            {

                if (ins.transform.position == transform.position + new Vector3(0, 0, 101)) // add delete position (x,y,z)
                {
                    if (co <= 27)
                    {
                        Destroy(ins, 1);
                    }
                    else
                    {
                        Destroy(newmap, 1);
                        break;
                    }
                }
            }
            td = 0;
            num = 0;
        }
    }

    IEnumerator counttime(bool k)
    {
        while (k)
        {
            if (j1 == how_many)
            {
                break;
            }
            yield return new WaitForSeconds(1);
            ++sec;
         //   Debug.Log(sec);
        }

    }
}