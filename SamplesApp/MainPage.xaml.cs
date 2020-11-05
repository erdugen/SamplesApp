using Xamarin.Forms;

namespace SamplesApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void ImagedListView_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ImagesListViewPage());
        }

        async void CustomNavigationBar_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CustomNavigationBarPage());
        }
    }
}
