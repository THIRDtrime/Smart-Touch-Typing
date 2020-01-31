using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mydatabase
{
    public static class DBmanager
    {
        public static string username;
        public static int score;
        public static double time;

        struct lessondata
        {
            public static int[] sc;
            public static double[] tm;
        }

        public static bool LoggedIn { get { return username != null; } }

        public static void LogOut()
        {
            username = null;
        }

    }
}


