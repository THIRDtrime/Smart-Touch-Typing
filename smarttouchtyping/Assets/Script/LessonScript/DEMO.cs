using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DitzeGames.Effects;

public class DEMO : MonoBehaviour
{
    public GameObject ThisPage;
    public GameObject T, F;
    public GameObject[] lesson;
    public GameObject[] aksorn;
    public GameObject[] pressaksorn;
    public AudioSource[] narator;
    public AudioSource[] rec;
    public AudioSource[] character;
    public GameObject TV;
    public AudioSource clip;
    bool debug = true; bool debug2 = true; bool check = true; bool check2 = false;
    bool check3 = true; bool debug3 = true; bool check4 = true; bool debug4 = true;
    bool check5 = true; bool debug5 = true; bool check6 = true; bool debug6 = true;
    bool check7 = false; bool debug7 = true; bool check8 = true; bool debug8 = true;
    bool check9 = true; bool debug9 = true; bool check10 = true; bool debug10 = true;
    bool chan = false;
    KeyCode[] key = { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Semicolon };
    int i = 0;

    // Update is called once per frame
    void Update()
    {
        if(ThisPage.activeSelf)
        {
            TV.SetActive(true); clip.Play();
            if(i > 7)
            {
                i = 0;
            }

            if(Input.GetKeyDown(key[i]))
            {
                F.SetActive(false);
                switch(i)
                {
                    case 0:
                        {
                            pressaksorn[0].SetActive(true);
                            aksorn[0].SetActive(false);
                            T.SetActive(true);
                            break;
                        }
                    case 1:
                        {
                            pressaksorn[1].SetActive(true);
                            aksorn[1].SetActive(false);
                            T.SetActive(true);
                            break;
                        }
                    case 2:
                        {
                            pressaksorn[2].SetActive(true);
                            aksorn[2].SetActive(false);
                            T.SetActive(true);
                            break;
                        }
                    case 3:
                        {
                            pressaksorn[3].SetActive(true);
                            aksorn[3].SetActive(false);
                            T.SetActive(true);
                            break;
                        }
                    case 4:
                        {
                            pressaksorn[4].SetActive(true);
                            aksorn[4].SetActive(false);
                            T.SetActive(true);
                            break;
                        }
                    case 5:
                        {
                            pressaksorn[5].SetActive(true);
                            aksorn[5].SetActive(false);
                            T.SetActive(true);
                            break;
                        }
                    case 6:
                        {
                            pressaksorn[6].SetActive(true);
                            aksorn[6].SetActive(false);
                            T.SetActive(true);
                            break;
                        }
                    case 7:
                        {
                            pressaksorn[7].SetActive(true);
                            aksorn[7].SetActive(false);
                            T.SetActive(true);
                            break;
                        }
                }
                rec[Random.Range(1,3)].Play();
                chan = true;
            }
            else if(Input.inputString != key[i].ToString() && Input.inputString != "")
            {
            rec[Random.Range(3,5)].Play();
                T.SetActive(false);
                F.SetActive(true);
                CameraEffects.ShakeOnce();
            }

            if (Notxor(!rec[1].isPlaying, !rec[2].isPlaying) && chan)
            {
                ++i;
                chan = false;
            }

            switch (i)
            {
                case 0:
                    {
                        F.SetActive(false);
                        if (check)
                        {
                            narator[0].Play(); check = false;
                        }
                        if (!narator[0].isPlaying && debug)
                        {
                            narator[1].Play(); if (narator[1].isPlaying) { check2 = true; } debug = false;
                        }
                        if((!narator[1].isPlaying && debug2) && check2)
                        {
                            character[0].Play(); debug2 = false;
                        }
                        break;
                    }
                 case 1:
                    {
                        pressaksorn[0].SetActive(false);
                        aksorn[1].SetActive(true);
                        if (check3)
                        {
                            narator[2].Play(); check3 = false; T.SetActive(false);
                        }
                        if(!narator[2].isPlaying && debug3)
                        {
                            character[1].Play(); debug3 = false;
                        }
                        break;
                    }
                case 2:
                    {
                        pressaksorn[1].SetActive(false);
                        aksorn[2].SetActive(true);
                        if (check4)
                        {
                            narator[3].Play(); check4 = false; T.SetActive(false);
                        }
                        if(!narator[3].isPlaying && debug4)
                        {
                            character[2].Play(); debug4 = false;
                        }
                        break;
                    }
                case 3:
                    {
                        pressaksorn[2].SetActive(false);
                        aksorn[3].SetActive(true);
                        if (check5)
                        {
                            narator[4].Play(); check5 = false; T.SetActive(false);
                        }
                        if (!narator[4].isPlaying && debug5)
                        {
                            character[3].Play(); debug5 = false;
                        }
                        break;
                    }
                case 4:
                    {
                        pressaksorn[3].SetActive(false);
                        aksorn[4].SetActive(true);
                        if (check6)
                        {
                            narator[5].Play(); check6 = false; T.SetActive(false);
                        }
                        if (!narator[5].isPlaying && debug6)
                        {
                            narator[6].Play(); if (narator[6].isPlaying) { check7 = true; }
                            debug6 = false;
                        }
                        if ((!narator[6].isPlaying && debug7) && check7)
                        {
                            character[4].Play(); debug7 = false;
                        }
                        break;
                    }
                case 5:
                    {
                        pressaksorn[4].SetActive(false);
                        aksorn[5].SetActive(true);
                        if (check8)
                        {
                            narator[7].Play(); check8 = false; T.SetActive(false);
                        }
                        if(!narator[7].isPlaying && debug8)
                        {
                            character[5].Play(); debug8 = false;
                        }
                        break;
                    }
                case 6:
                    {
                        pressaksorn[5].SetActive(false);
                        aksorn[6].SetActive(true);
                        if (check9)
                        {
                            narator[8].Play(); check9 = false; T.SetActive(false);
                        }
                        if(!narator[8].isPlaying && debug9)
                        {
                            character[6].Play(); debug9 = false;
                        }
                        break;
                    }
                case 7:
                    {
                        pressaksorn[6].SetActive(false);
                        aksorn[7].SetActive(true);
                        if (check10)
                        {
                            narator[9].Play(); check10 = false; T.SetActive(false);
                        }
                        if(!narator[9].isPlaying && debug10)
                        {
                            character[7].Play(); debug10 = false;
                        }
                        break;
                    }
            }
        }else
        {
            i = 0; check = true; debug = true; debug2 = true;
            check2 = false; check3 = true; debug3 = true; check4 = true; debug4 = true;
            check5 = true; debug5 = true; check6 = true; check7 = false; debug6 = true; debug7 = true;
            check8 = true; debug8 = true; check9 = true; debug9 = true; chan = false;
            aksorn[0].SetActive(true);
            aksorn[1].SetActive(false);
            aksorn[2].SetActive(false);
            aksorn[3].SetActive(false);
            aksorn[4].SetActive(false);
            aksorn[5].SetActive(false);
            aksorn[6].SetActive(false);
            aksorn[7].SetActive(false);

            pressaksorn[0].SetActive(false);
            pressaksorn[1].SetActive(false);
            pressaksorn[2].SetActive(false);
            pressaksorn[3].SetActive(false);
            pressaksorn[4].SetActive(false);
            pressaksorn[5].SetActive(false);
            pressaksorn[6].SetActive(false);
            pressaksorn[7].SetActive(false);

            T.SetActive(false);
            F.SetActive(true);

            TV.SetActive(false); clip.Stop();
        }
    }

    public void infoBTN()
    {
        lesson[0].SetActive(true);
    }
    public void next1BTN()
    {
        lesson[1].SetActive(true);
        lesson[0].SetActive(false);
    }
    public void next2BTN()
    {
        lesson[2].SetActive(true);
        lesson[1].SetActive(false);
    }
    public void close()
    {
        lesson[0].SetActive(false);
        lesson[1].SetActive(false);
        lesson[2].SetActive(false);
    }
    public void back1BTN()
    {
        lesson[0].SetActive(true);
        lesson[1].SetActive(false);
    }
    public void back2BTN()
    {
        lesson[1].SetActive(true);
        lesson[2].SetActive(false);
    }
    private bool Notxor(bool x , bool y)
    {
        return (!x || y) && (!y || x);
    }
}
