using System;

using Xamarin.Forms;

namespace static_carousel
{
    public class Carousel : ContentPage
    {
        public Carousel()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            if (Device.OS == TargetPlatform.iOS)
                Padding = new Thickness(0, 20, 0, 0);
            BackgroundColor = Color.Green;

            var view1 = CreateView("aquarius.jpg", "The Aquarius", "The 1970s computer for the 1980s", 1, .55);
            var view2 = CreateView("Atari65XE.jpg", "Atari 65XE", "Not bad, not good", .95, .63, .25);
            var view3 = CreateView("ComC4.jpg", "Commodore plus 4", "Brought out to fight against the MSX invasion", .85, .85, .4);
            var view4 = CreateView("ComPet.jpg", "Commodore Pet", "Just don't toggle the tape too quickly... mmm, burning....", .87, .83, .25);
            var view5 = CreateView("olliedog.png", "Ollie Dog", "Our new puppy", .87, .83, .5);

            var slider = new SliderView(view1, App.ScreenSize.Height * 0.8, App.ScreenSize.Width)
            {
                BackgroundColor = Color.Green,
                TransitionLength = 200,
                StyleId = "SliderView",
                MinimumSwipeDistance = 50
            };

            slider.Children.Add(view2);
            slider.Children.Add(view3);
            slider.Children.Add(view4);
            slider.Children.Add(view5);

            var content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = App.ScreenSize.Height * .85,
                Children =
                {
                    slider,
                }
            };

            var relView = new RelativeLayout
            {
                VerticalOptions = LayoutOptions.Start/*CenterAndExpand*/,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };


            relView.Children.Add(content, Constraint.Constant(0), Constraint.Constant(0), Constraint.Constant(App.ScreenSize.Width), Constraint.RelativeToParent((parent) => App.ScreenSize.Height * .75));

            Content = relView;
        }

        ContentView CreateView(string imageName, string mainHeading, string text, double width = 1, double multiplier = .8, double height = .35)
        {
            return new ContentView
            {
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    VerticalOptions = LayoutOptions.Start,
                    Children =
                    {
                        new StackLayout
                        {
                            Padding = new Thickness(0, height == .35 ? 0 : (height < .35 ? 42 : -12), 0, 0),
                            Children =
                            {
                                new Image
                                {
                                    Source = imageName,
                                    HeightRequest = App.ScreenSize.Height * height,
                                    WidthRequest = App.ScreenSize.Width * width,
                                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                                    Aspect = width == 1 ? Aspect.AspectFit : Aspect.Fill
                                }
                            }
                        },
                        new StackLayout
                        {
                            //WidthRequest = App.ScreenSize.Width * .5,
                            VerticalOptions = LayoutOptions.Start,
                            Padding = new Thickness(0, height == .35 ? 20 : (height < .35 ? 42 : 8), 0, 0),
                            Children =
                            {
                                new StackLayout
                                {
                                    Children =
                                    {
                                        new Label
                                        {
                                            Text = mainHeading,
                                            TextColor = Color.White,
                                            FontSize = 24,
                                            LineBreakMode = LineBreakMode.WordWrap,
                                            WidthRequest = App.ScreenSize.Width *  width / 1.75,
                                            HorizontalTextAlignment = TextAlignment.Center,
                                            HorizontalOptions = LayoutOptions.Center
                                        },
                                        new Label
                                        {
                                            Text = text,
                                            TextColor = Color.White,
                                            FontSize = 16,
                                            HorizontalTextAlignment = TextAlignment.Center,
                                            WidthRequest = App.ScreenSize.Width * (width >= 1 ? multiplier : width * multiplier),
                                            LineBreakMode = LineBreakMode.WordWrap,
                                            HorizontalOptions = LayoutOptions.Center
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            };
        }
    }
}


