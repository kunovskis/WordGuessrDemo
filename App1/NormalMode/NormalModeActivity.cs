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
using Android.Preferences;

namespace App1
{
    [Activity(Label = "NormalModeActivity")]
    public class NormalModeActivity : Activity
    {

        public NormalMode game;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.NormalModeLayout);

            game = new NormalMode();
            game.newWords();

            newHighScore();

            Button Word1 = FindViewById<Button>(Resource.Id.Word1);
            Button Word2 = FindViewById<Button>(Resource.Id.Word2);
            Button Word3 = FindViewById<Button>(Resource.Id.Word3);
            Button Word4 = FindViewById<Button>(Resource.Id.Word4);
            EditText GuessedWord = FindViewById<EditText>(Resource.Id.GuessedWord);
            Button Check = FindViewById<Button>(Resource.Id.Check);
            TextView Result = FindViewById<TextView>(Resource.Id.Result);
            TextView Points = FindViewById<TextView>(Resource.Id.Points);
            TextView PrevGuess1 = FindViewById<TextView>(Resource.Id.PrevGuess1);
            TextView PrevGuess2 = FindViewById<TextView>(Resource.Id.PrevGuess2);
            TextView PrevGuess3 = FindViewById<TextView>(Resource.Id.PrevGuess3);
            Points.Text = "Points: 0";

            Word1.Click += (sender, e) =>
            {
                click(Word1, 0);
            };

            Word2.Click += (sender, e) =>
            {
                click(Word2, 1);
            };

            Word3.Click += (sender, e) =>
            {
                click(Word3, 2);
            };

            Word4.Click += (sender, e) =>
            {
                click(Word4, 3);
            };

            Check.Click += (sender, e) =>
            {
                string result = game.result;
                string guess = GuessedWord.Text.Trim();
                if (guess.ToLower().Equals(game.result.ToLower()))
                {
                    GuessedWord.Text = "";
                    Result.Text = guess + " was correct";
                    game.guesses = 0;
                    getPoints();
                    reset();
                }
                else
                {
                    if (!game.guessedBefore(guess))
                    {
                        game.addGuess(guess);
                        addGuess(guess);
                        GuessedWord.Text = "";
                        Result.Text = guess + " is not correct";
                        if (game.guesses == 2)
                        {
                            openNew();
                        }
                        else
                            game.guesses++;
                    }
                }
            };
        }

        public void reset()
        {
            Button Word1 = FindViewById<Button>(Resource.Id.Word1);
            Button Word2 = FindViewById<Button>(Resource.Id.Word2);
            Button Word3 = FindViewById<Button>(Resource.Id.Word3);
            Button Word4 = FindViewById<Button>(Resource.Id.Word4);
            EditText GuessedWord = FindViewById<EditText>(Resource.Id.GuessedWord);
            Button Check = FindViewById<Button>(Resource.Id.Check);
            TextView Result = FindViewById<TextView>(Resource.Id.Result);
            TextView PrevGuess1 = FindViewById<TextView>(Resource.Id.PrevGuess1);
            TextView PrevGuess2 = FindViewById<TextView>(Resource.Id.PrevGuess2);
            TextView PrevGuess3 = FindViewById<TextView>(Resource.Id.PrevGuess3);

            PrevGuess1.Text = "";
            PrevGuess2.Text = "";
            PrevGuess3.Text = "";

            game.resetPrevGuess();

            if (game.w.groups.Count > 0)
                game.newWords();
            else
            {
                Result.Text = "No more words for you!";
                Check.Enabled = false;
                newHighScore();
                return;
            }

            Word1.Text = "A";
            Word2.Text = "B";
            Word3.Text = "C";
            Word4.Text = "D";
            Word1.Enabled = true;
            Word2.Enabled = true;
            Word3.Enabled = true;
            Word4.Enabled = true;
        }

        public void addGuess(string s)
        {
            TextView PrevGuess1 = FindViewById<TextView>(Resource.Id.PrevGuess1);
            TextView PrevGuess2 = FindViewById<TextView>(Resource.Id.PrevGuess2);
            TextView PrevGuess3 = FindViewById<TextView>(Resource.Id.PrevGuess3);

            if (game.prevGuess.Count <= 5)
            {
                PrevGuess1.Text += s + "\n";
            }
            else if(game.prevGuess.Count <= 10)
            {
                PrevGuess2.Text += s + "\n";
            }
            else
            {
                PrevGuess3.Text += s + "\n";
            }
        }

        public void click(Button b, int a)
        {
            b.Enabled = false;
            b.Text = game.words.ElementAt(a);
            game.guesses = 0;
        }

        public void openNew()
        {
            Button Word1 = FindViewById<Button>(Resource.Id.Word1);
            Button Word2 = FindViewById<Button>(Resource.Id.Word2);
            Button Word3 = FindViewById<Button>(Resource.Id.Word3);
            Button Word4 = FindViewById<Button>(Resource.Id.Word4);
            
            if (Word1.Enabled)
                click(Word1, 0);
            else if (Word2.Enabled)
                click(Word2, 1);
            else if (Word3.Enabled)
                click(Word3, 2);
            else if (Word4.Enabled)
                click(Word4, 3);
            else
            {
                newHighScore();
                TextView Result = FindViewById<TextView>(Resource.Id.Result);
                Result.Text = "You ran out of guesses";
                TextView Points = FindViewById<TextView>(Resource.Id.Points);
                Points.Text = "Points: 0";
                EditText GuessedWord = FindViewById<EditText>(Resource.Id.GuessedWord);
                GuessedWord.Text = "";
                game = new NormalMode();
                reset();
            }
        }

        public void getPoints()
        {
            int correct = 0;
            Button Word1 = FindViewById<Button>(Resource.Id.Word1);
            Button Word2 = FindViewById<Button>(Resource.Id.Word2);
            Button Word3 = FindViewById<Button>(Resource.Id.Word3);
            Button Word4 = FindViewById<Button>(Resource.Id.Word4);
            TextView Points = FindViewById<TextView>(Resource.Id.Points);
            if (Word1.Enabled)
                correct++;
            if (Word2.Enabled)
                correct++;
            if (Word3.Enabled)
                correct++;
            if (Word4.Enabled)
                correct++;
            if (correct == 0)
                game.points += 1;
            else if (correct == 1)
                game.points += 3;
            else if (correct == 2)
                game.points += 6;
            else
                game.points += 10;
            Points.Text = "Points: " + game.points;
        }

        public void newHighScore()
        {
            int highscore;

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();

            highscore = prefs.GetInt("NormalHS", 0);

            if(game.points > highscore)
            {
                highscore = game.points;
                editor.PutInt("NormalHS", highscore);
                editor.Apply();
                Toast.MakeText(this.ApplicationContext, "New High Score: " + highscore.ToString(), ToastLength.Short).Show();
            }

            TextView HS = FindViewById<TextView>(Resource.Id.HighScore);
            HS.Text = "High Score: " + highscore;
        }

    }
}