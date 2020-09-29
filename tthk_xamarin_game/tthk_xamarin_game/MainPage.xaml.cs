using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace tthk_xamarin_game
{
    public partial class MainPage : ContentPage
    {
        Image img;
        Grid ground;
        Button restartbtn, clearbutton;
        Label CrossOrZero;
        static int player;
        public MainPage()
        {
            ground = new Grid()
            {
                HeightRequest = 400
            };
            for (int i = 0; i < 3; i++)
            {
                ground.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                ground.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    img = new Image
                    {
                        HeightRequest = 125,
                        Source = "empty.png"
                    };
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += TapOnTapped;
                    ground.Children.Add(img, i, j);
                    img.GestureRecognizers.Add(tap);  
                }
            }

            restartbtn = new Button()
            {
                Text = "X || O",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            restartbtn.Clicked += RestartbtnOnClicked;
            
            clearbutton = new Button()
            {
                Text = "Новая игра",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            clearbutton.Clicked += ClearbuttonOnClicked;

            StackLayout BtnLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = { restartbtn, clearbutton }
            };

            CrossOrZero = new Label()
            {
                TextColor = Color.White
            };

            StackLayout MainLayout = new StackLayout()
            {
                Children = { ground, BtnLayout, CrossOrZero }
            };
            
            Content = MainLayout;
        }

        private void ClearbuttonOnClicked(object sender, EventArgs e)
        {
            
        }

        private void RestartbtnOnClicked(object sender, EventArgs e)
        {
            Random rnd = new Random();
            player = rnd.Next(1, 3);
            if (player == 1)
            {
                DisplayAlert("X || O ", "Первый начинает X", "ок");
            }
            else
            {
                DisplayAlert("X || O ", "Первый начинает O", "ок");
            }

        }

        private void TapOnTapped(object sender, EventArgs e)
        {
            Image img = sender as Image;
            var imageSource = (Image)sender;//get image source here
            var selectedImage = imageSource.Source as FileImageSource;

            if (selectedImage == "empty.png")
            {
                if (player == 1)
                {
                    img.Source = ImageSource.FromFile("krestik.png");
                    player = 2;
                }
                else if (player == 2)
                {
                    img.Source = ImageSource.FromFile("nolik.png");
                    player = 1;
                }
            }
            else
            {
                DisplayAlert ("Занята", "Здесь нельза поставить", "ок");
            }

        }
    }
}

