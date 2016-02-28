using System;

using Xamarin.Forms;

namespace static_carousel
{
    public class App : Application
    {
        public static App Self { get; private set; }

        public static Size ScreenSize { get; set; }

        public App()
        {
            App.Self = this;

            // The root page of your application
            MainPage = new Carousel();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

