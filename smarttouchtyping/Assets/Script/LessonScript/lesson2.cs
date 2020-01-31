using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DitzeGames.Effects;

public class lesson2 : MonoBehaviour
{

    public GameObject brid;
    public GameObject Kybrid;
    public GameObject map;
    public GameObject maincam;
    public GameObject space;
    public GameObject star;
    public GameObject star2;
    public GameObject star3;

    public List<GameObject> ob = new List<GameObject>();

    GameObject clone;

    public Text one;
    public Text two;
    public Text three;
    public Text four;
    public Text five;
    public Text corr;
    public Text wrong;
    public Text scores;
    public Text wd , wd2 , wd3 , wd4;
    public Text numb , numb2 , numb3 , numb4;
    public Text took, peed;

    public int Howmany = 1000;

    public float gravity = 10f;
    public float jump = 10f;
    public float speed = 10f;
    public float position = 98.5f;
    public float deleted = 150;
 
    int i = 0;
    int sc = 0; int wr = 0;
    int kumnod = 0;
    int[] sum = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    char[] w1 = { 'a', 'q',' ' , 'f', 'j', 'm', ';', 's', 'x', 'u', 'i', 't', 'p', 'c', 'k', 'n', 'e', 'h', 'b', 'o', 'l', 'w', '.', 'd', 'r', ',', 'g', 'z' };
    bool debug = true; 
    bool debug2 = true;
    bool debug3 = true;
    Vector3 MoveDir = Vector3.zero;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            debug3 = false;
        }

        three.text = KeyData.lesson9[i].ToString();
        four.text = KeyData.lesson9[i + 1].ToString();
        five.text = KeyData.lesson9[i + 2].ToString();
        if (i >= 1)
        {
            two.text = KeyData.lesson9[i - 1].ToString();
            if (i >= 2)
            {
                one.text = KeyData.lesson9[i - 2].ToString();
            }
        }
        fly();
        convert(KeyData.lesson9[i]);
        DoG(Kybrid.transform.position.z);
        Kybrid.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void fly()
    {

        if (Input.GetKeyDown(Wordsdata.lesson9[i]))
        {
            MoveDir = new Vector3(0, 1, 0);
            if(Kybrid.transform.position.y <= 29.99f)
            {
            MoveDir.y *= jump;
            }
            i++; sc++;
        }else if((Input.inputString != Wordsdata.lesson9[i].ToString() && (Input.inputString != "")) && debug3)
        {
            CameraEffects.ShakeOnce();
            wr++; sum[kumnod]++;
        }
        MoveDir.y -= gravity * Time.deltaTime * 2f;
        controller.Move(MoveDir * Time.deltaTime);
    }
    void sort()
    {
        for (int g = 0; g < 28; g++)
        {
            for (int g1 = 0; g1 < 28 - g; ++g1)
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

    void convert(int x)
    {
        switch (x)
        {
            case 'a':
                kumnod = 0;
                break;
            case 'q':
                kumnod = 1;
                break;
            case ' ':
                kumnod = 2;
                break;
            case 'f':
                kumnod = 3;
                break;
            case 'j':
                kumnod = 4;
                break;
            case 'm':
                kumnod = 5;
                break;
            case ';':
                kumnod = 6;
                break;
            case 's':
                kumnod = 7;
                break;
            case 'x':
                kumnod = 8;
                break;
            case 'u':
                kumnod = 9;
                break;
            case 'i':
                kumnod = 10;
                break;
            case 't':
                kumnod = 11;
                break;
            case 'p':
                kumnod = 12;
                break;
            case 'c':
                kumnod = 13;
                break;
            case 'k':
                kumnod = 14;
                break;
            case 'n':
                kumnod = 15;
                break;
            case 'e':
                kumnod = 16;
                break;
            case 'h':
                kumnod = 17;
                break;
            case 'b':
                kumnod = 18;
                break;
            case 'o':
                kumnod = 19;
                break;
            case 'l':
                kumnod = 20;
                break;
            case 'w':
                kumnod = 21;
                break;
            case '.':
                kumnod = 22;
                break;
            case 'd':
                kumnod = 23;
                break;
            case 'r':
                kumnod = 24;
                break;
            case ',':
                kumnod = 25;
                break;
            case 'g':
                kumnod = 26;
                break;
            case 'z':
                kumnod = 27;
                break;
        }
    }

    void DoG(float num)
    {
        debug = true;
        debug2 = true;
        if (num >= position - 20 && debug)
        {
            clone = Instantiate(map);
            clone.transform.position = new Vector3(map.transform.position.x, map.transform.position.y, map.transform.position.z + position);
            clone.transform.localScale = map.transform.lossyScale;
            ob.Add(clone);
            position += 123.5f;
            debug = false;
        }

        if(num >= deleted && debug2)
        {
            GameObject del = ob[1];
            Destroy(del);
            ob.RemoveAt(0);
            debug2 = false;
            deleted += 150;
            debug2 = false;
        }
    }

    void result()
    {
        if(Howmany == sc)
        {
            maincam.SetActive(true);
            sort();
            Grade();
            int real = sc - wr;
            corr.text = sc.ToString();
            scores.text = real.ToString();
            wrong.text = wr.ToString();
            numb.text = sum[0].ToString();
            numb2.text = sum[2].ToString();
            numb3.text = sum[3].ToString();
            numb4.text = sum[4].ToString();
            wd.text = w1[0].ToString();
            wd2.text = w1[1].ToString();
            wd3.text = w1[2].ToString();
            wd4.text = w1[3].ToString();
        }
    }

    void Grade()
    {
        int j2 = sc - wr;
        if ((j2 / Howmany) * 100 >= 80)
        {
            star.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        if ((j2 / Howmany) * 100 >= 60)
        {
            star.SetActive(true);
            star2.SetActive(true);
        }
        if ((j2 / Howmany) * 100 >= 40)
        {
            star.SetActive(true);
        }
    }
}
