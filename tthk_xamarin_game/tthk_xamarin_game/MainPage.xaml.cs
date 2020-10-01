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
        int[,] WinOrLose = new int[3,3];
        public MainPage()
        {
            PlayGround();


            


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
        private void PlayGround()
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
                    WinOrLose[i, j] = 0;
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += TapOnTapped;
                    ground.Children.Add(img, i, j);
                    img.GestureRecognizers.Add(tap);
                }
            }
        }

        private void ClearbuttonOnClicked(object sender, EventArgs e)
        {
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
            restartbtn.Opacity = 1;
            player = 0;
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
            restartbtn.Opacity = 0;

        }

        private void TapOnTapped(object sender, EventArgs e)
        {
            Image img = sender as Image;
            var imageSource = (Image)sender;
            var selectedImage = imageSource.Source as FileImageSource;

            if (selectedImage == "empty.png")
            {
                if (player == 1)
                {
                    img.Source = ImageSource.FromFile("krestik.png");
                    WinOrLose[Grid.GetRow(img), Grid.GetColumn(img)] = 1;
                    player = 2;
                    WinCheck()
                }
                else if (player == 2)
                {
                    img.Source = ImageSource.FromFile("nolik.png");
                    WinOrLose[Grid.GetRow(img), Grid.GetColumn(img)] = 2;
                    player = 1;
                    WinCheck()
                }
            }
            else
            {
                DisplayAlert ("Занята", "Здесь нельза поставить", "ок");
            }
        }
        public int WinCheck()
        {
            int win = 0;

            if (win == 0)
            {
                if(WinOrLose[0,0] == 1 && WinOrLose[0,1] == 1 && WinOrLose[0,2] == 1)
                {
                    win = 1;
                }
                else if (WinOrLose[1,0] == 1 && WinOrLose[1,1] == 1 && WinOrLose[1,2] == 1)
                {
                    win = 1;
                }
                else if (WinOrLose[2,0] == 1 && WinOrLose[2,1] == 1 && WinOrLose [2,2] == 1)
                {
                    win = 1;
                }
                else if (WinOrLose[0,0] == 1 && WinOrLose[1,1] == 1 && WinOrLose[2,2] == 1)
                {
                    win = 1;
                }
                else if (WinOrLose[0,2] == 1 && WinOrLose[1,1] == 1 && WinOrLose[2,0] == 1)
                {
                    win = 1;
                }
                
                return win;
            }
            else if (win == 1)
            {
                DisplayAlert ("Победа", "X выйграл", "ок");
            }



            if(WinOrLose[0,0] == 1 && WinOrLose[0,1] == 1 && WinOrLose[0,2] == 1)
            {
                win = 1;
            }
            else if (WinOrLose[1,0] == 1 && WinOrLose[1,1] == 1 && WinOrLose[1,2] == 1)
            {
                win = 1;
            }
            else if (WinOrLose[2,0] == 1 && WinOrLose[2,1] == 1 && WinOrLose [2,2] == 1)
            {
                win = 1;
            }
            else if (WinOrLose[0,0] == 1 && WinOrLose[1,1] == 1 && WinOrLose[2,2] == 1)
            {
                win = 1;
            }
            else if (WinOrLose[0,2] == 1 && WinOrLose[1,1] == 1 && WinOrLose[2,0] == 1)
            {
                win = 1;
            }
            return win;
        }
        
    }
}

