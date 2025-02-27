using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aivftw.Utils
{
    public class Animations
    {
        public static async Task FadeIn(Button fadeInButton, string text)
        {
            fadeInButton.Text = text;

            if (fadeInButton.Visible) return;

            fadeInButton.BackColor = Color.FromArgb(0, fadeInButton.BackColor);
            fadeInButton.Visible = true;

            for (int i = 100; i < 255; i++)
            {

                fadeInButton.BackColor = Color.FromArgb(i, fadeInButton.BackColor);
                fadeInButton.ForeColor = Color.FromArgb(i, fadeInButton.ForeColor);

                await Task.Delay(TimeSpan.FromMilliseconds(0.5));
            }

            fadeInButton.Visible = false;
        }

        public static async Task FadeInAndOut(Button fadeInOutButton, string text)
        {
            fadeInOutButton.Text = text;

            if (fadeInOutButton.Visible) return;

            fadeInOutButton.BackColor = Color.FromArgb(0, fadeInOutButton.BackColor);
            fadeInOutButton.Visible = true;

            for (int i = 155; i < 255; i++)
            {

                fadeInOutButton.BackColor = Color.FromArgb(i, fadeInOutButton.BackColor);
                fadeInOutButton.ForeColor = Color.FromArgb(i, fadeInOutButton.ForeColor);

                await Task.Delay(TimeSpan.FromMilliseconds(0.5));
            }

            await Task.Delay(TimeSpan.FromMilliseconds(250));

            for (int i = 155; i > 0; i--)
            {
                fadeInOutButton.BackColor = Color.FromArgb(i, fadeInOutButton.BackColor);
                fadeInOutButton.ForeColor = Color.FromArgb(i, fadeInOutButton.ForeColor);

                if (fadeInOutButton.Text.Length >= i)
                {
                    fadeInOutButton.Text = fadeInOutButton.Text.Remove(fadeInOutButton.Text.Length - 1);
                }
                await Task.Delay(TimeSpan.FromMilliseconds(0.5));
            }

            fadeInOutButton.Visible = false;
        }
    }
}
