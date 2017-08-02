using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using Android.Preferences;

namespace App1
{
    [Activity(Label = "WordGuessr", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button NormalModeButton = FindViewById<Button>(Resource.Id.NormalMode);
            Button DescriptorModeButton = FindViewById<Button>(Resource.Id.DescriptorModeB);
            TextView Username = FindViewById<TextView>(Resource.Id.Username);

            NormalModeButton.Click += (sender, e) =>
            {
                StartActivity(typeof(NormalModeActivity));
            };

            DescriptorModeButton.Click += (sender, e) =>
            {
                StartActivity(typeof(DescriptorModeActivity));
            };



            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("Username", "kunovskis");
            editor.Apply();

            Username.Text = prefs.GetString("Username", "default");
            

        }
    }
}

