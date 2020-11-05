using System.Collections.ObjectModel;
using SamplesApp.Models;
using Xamarin.Forms;

namespace SamplesApp
{
    public partial class CustomNavigationBarPage : ContentPage
    {
        public NavButton LeftButton { get; set; }
        public ObservableCollection<NavButton> RightButtons { get; set; }

        public CustomNavigationBarPage()
        {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);

            Title = "Hi";
            LeftButton = new NavButton
            {
                ImageSource = "icons8-back-50.png",
                ButtonCommand = new Command(async () => await Navigation.PopAsync()),
                Width = 24,
                Height = 24
            };

            RightButtons = new ObservableCollection<NavButton>();

            InitializeComponent();
        }

        void AddRightButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (RightButtons.Count == 3)
                return;


            RightButtons.Add(new NavButton
            {
                ImageSource =  GetImageSource(),
                ButtonCommand = new Command(async () => await DisplayAlert("Dynamic Button", "Alert", "Okay")),
                Width = 24,
                Height = 24
            });

            pageNav.UpdateTitleMargin();
        }

        string GetImageSource()
        {
            switch (RightButtons.Count)
            {
                case 0: return "icons8-minus-50.png";
                case 1: return "icons8-plus-50.png";
                case 2: return "icons8-zoom-in-50.png";
                default:
                    return "icons8-minus-50.png";
            }            
        }
    }
}