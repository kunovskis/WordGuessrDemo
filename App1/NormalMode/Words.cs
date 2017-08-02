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
    public class Words
    {
        public List<Groups> groups { get; private set; } 
        public static Random random = new Random();

        public Words()
        {
            groups = new List<Groups>();

            groups.Add(new Groups("Alarm", "Hour", "Minute", "Time", "Clock"));
            groups.Add(new Groups("Alarm", "Lunch", "School", "Ring", "Bell"));
            groups.Add(new Groups("Bad", "Fortune", "Good", "Stroke", "Luck"));
            groups.Add(new Groups("Assignment", "Job", "Labor", "Task", "Work"));
            groups.Add(new Groups("Aid", "Class", "Hand", "Place", "First"));
            groups.Add(new Groups("Beef", "Chicken", "Lamb", "Pork", "Meat"));
            groups.Add(new Groups("Club", "Spade", "Diamond", "Heart", "Ace"));
        }

        public Groups getGroup()
        {
            int a = random.Next(0, groups.Count);
            Groups g = groups.ElementAt(a);
            groups.RemoveAt(a);
            return g;
        }
    }
}