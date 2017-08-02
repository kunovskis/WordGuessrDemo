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
    public class DescriptorMode
    {
        public Words w;
        public List<string> DescWords { get; private set; }
        public string result { get; private set; }
        public List<string> prevGuess { get; private set; }
        public int points;
        public int guesses;

        public DescriptorMode()
        {

        }


    }
}