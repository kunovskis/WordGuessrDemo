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
    public class NormalMode
    {
        public Words w;
        public List<string> words { get; private set; }
        public string result { get; private set; }
        public List<string> prevGuess { get; private set; }
        public int points;
        public int guesses;

        public NormalMode()
        {
            prevGuess = new List<string>();
            w = new Words();
            words = new List<string>();
            points = 0;
            guesses = 0;
        }

        public void newWords()
        {
            Groups g = w.getGroup();
            words = g.words;
            result = g.result;
        }

        public void addGuess(string s)
        {
            prevGuess.Add(s);
        }

        public void resetPrevGuess()
        {
            prevGuess = new List<string>();
        }

        public bool guessedBefore(string s)
        {
            return prevGuess.Contains(s);
        }

    }
}