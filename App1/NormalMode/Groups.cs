using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    public class Groups
    {
        public List<string> words { get; private set; }
        public string result { get; private set; }

        public Groups(string a, string b, string c, string d, string res)
        {
            words = new List<string>();
            words.Add(a);
            words.Add(b);
            words.Add(c);
            words.Add(d);
            result = res;
        }


    }
}