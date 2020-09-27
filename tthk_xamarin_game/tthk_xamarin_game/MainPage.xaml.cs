using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace tthk_xamarin_game
{
    public partial class MainPage : ContentPage
    {
        Image img;
        Grid ground;
        Button restartbtn;
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
                        Source = "krestik.png"
                    };

                    ground.Children.Add(img, i, j);
                    var tap = new TapGestureRecognizer();
                    img.GestureRecognizers.Add(tap);  
                }
            }

            restartbtn = new Button()
            {
                Text = "Reset",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

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
    }
}
