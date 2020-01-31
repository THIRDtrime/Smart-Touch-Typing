using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mydatabase;

namespace SaveData
{
    public class upload : MonoBehaviour
    {
        public static void IncreaseScore(int x)
        {
            if(x > 0)
            {
                if(x > DBmanager.score)
                DBmanager.score = x;
            }
        }
        public static void Newtime(double x)
        {
            if(x < DBmanager.time)
            {
                DBmanager.time = x;
            }
        }
    }

}
// Show the data from database in Text box
/* if(DBmanager.LoggedIn)
{
    name.text = DBmanager.username;
} */
