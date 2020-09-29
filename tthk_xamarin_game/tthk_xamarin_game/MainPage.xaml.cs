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
        Button restartbtn;
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
                Text = "Reset",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            restartbtn.Clicked += RestartbtnOnClicked;

            StackLayout BtnLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = { restartbtn }
            };

            StackLayout MainLayout = new StackLayout()
            {
                Children = { ground, BtnLayout }
            };
            
            Content = MainLayout;
        }

        private void RestartbtnOnClicked(object sender, EventArgs e)
        {
            Random rnd = new Random();
            
            player = rnd.Next(1, 3);
            restartbtn.Text = player.ToString();
            
        }

        private void TapOnTapped(object sender, EventArgs e)
        {
            Image img = sender as Image;

            if (img.Source == ImageSource.FromFile("empty.png"))
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

