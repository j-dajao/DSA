using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace jerjer
{
    public partial class MainPage : ContentPage
    {
        private int messageStep = 0;

        private readonly List<(string sender, string message)> conversationSteps = new()
        {
            ("user", "Hello"),
            ("support", "Hello! Good Evening this is Jessica Codilla\nFrom LostTrack’s Contact Support team!\nHow may I help you?"),
            ("user", "Where can I find the matched users contact info?"),
            ("support", ""), // Placeholder image-only response
            ("user", "Oh ok, thanks!")
        };

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSendClicked(object sender, EventArgs e)
        {
            if (messageStep >= conversationSteps.Count)
                return;

            var (senderType, message) = conversationSteps[messageStep];

            if (senderType == "user")
            {
                ChatLayout.Children.Add(CreateUserMessage(message));
            }
            else if (senderType == "support")
            {
                if (string.IsNullOrEmpty(message))
                {
                    ChatLayout.Children.Add(CreateSupportImageOnlyBubble());
                }
                else
                {
                    ChatLayout.Children.Add(CreateSupportMessage(message));
                }
            }

            messageStep++;
            MessageEntry.Text = string.Empty;
        }

        private View CreateUserMessage(string text)
        {
            return new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.End,
                Children =
                {
                    new Frame
                    {
                        Padding = 10,
                        BackgroundColor = Color.FromArgb("#3366FF"),
                        CornerRadius = 20,
                        Content = new Label
                        {
                            Text = text,
                            TextColor = Colors.White
                        }
                    }
                }
            };
        }

        private View CreateSupportMessage(string text)
        {
            return new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                Children =
                {
                    new Frame
                    {
                        HeightRequest = 40,
                        WidthRequest = 40,
                        Padding = 0,
                        CornerRadius = 20,
                        IsClippedToBounds = true,
                        HasShadow = false,
                        BackgroundColor = Colors.Transparent,
                        Content = new Image
                        {
                            Source = "profile.jpg",
                            Aspect = Aspect.AspectFill
                        }
                    },
                    new Frame
                    {
                        Padding = 10,
                        BackgroundColor = Colors.White,
                        CornerRadius = 20,
                        HasShadow = false,
                        BorderColor = Colors.Gray,
                        Content = new Label
                        {
                            Text = text
                        }
                    }
                }
            };
        }

        private View CreateSupportImageOnlyBubble()
        {
            return new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                Children =
                {
                    new Frame
                    {
                        HeightRequest = 40,
                        WidthRequest = 40,
                        Padding = 0,
                        CornerRadius = 20,
                        IsClippedToBounds = true,
                        HasShadow = false,
                        BackgroundColor = Colors.Transparent,
                        Content = new Image
                        {
                            Source = "profile.jpg",
                            Aspect = Aspect.AspectFill
                        }
                    },
                    new Frame
                    {
                        HeightRequest = 120,
                        WidthRequest = 120,
                        BackgroundColor = Color.FromArgb("#F1F1F1"),
                        CornerRadius = 20,
                        BorderColor = Colors.LightGray
                    }
                }
            };
        }

        private void OnBackTapped(object sender, EventArgs e)
        {
            // You can add navigation logic here
            Console.WriteLine("Back button tapped.");
        }
    }
}
