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
    class DescriptorWordGroups
    {
        List<string> descriptions;
        string word;

        public DescriptorWordGroups(List<string> desc, string w)
        {
            descriptions = desc;
            word = w;
        }


    }
}