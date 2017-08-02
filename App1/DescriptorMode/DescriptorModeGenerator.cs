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
    class DescriptorModeGenerator
    {
        public List<DescriptorWordGroups> words { get; private set; }
        public static Random random = new Random();

        public DescriptorModeGenerator()
        {
            words = new List<DescriptorWordGroups>();

            List<string> descriptions = new List<string>();

            descriptions.Add("It is a domestic animal.");
            descriptions.Add("It is a type of bird.");
            descriptions.Add("It lays eggs.");
            descriptions.Add("It can be a Hen or a Rooster.");
            descriptions.Add("Mostly found on farms.");
            descriptions.Add("Starts with the letter C and has 6 more letters.");
            words.Add(new DescriptorWordGroups(descriptions, "chicken"));

            descriptions.Clear();

            descriptions.Add("It is a type of metal.");
            descriptions.Add("It's chemical symbol is Cu");
            descriptions.Add("It has a reddish color.");
            descriptions.Add("Starts with the letter C and has 5 more letters.");
            words.Add(new DescriptorWordGroups(descriptions, "copper"));

            descriptions.Clear();

        }

    }
}