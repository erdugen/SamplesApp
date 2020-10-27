using System.Collections.Generic;

using Xamarin.Forms;

namespace SamplesApp
{
    public partial class ImagesListViewPage : ContentPage
    {
        List<string> ItemSource { get; set; }

        public ImagesListViewPage()
        {
            InitializeComponent();
            LoadItemSource();
            MainList.ItemsSource = new List<string>();
        }

        private void LoadItemSource()
        {
            ItemSource = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                ItemSource.Add($"Item - {i}");
            }            
        }

        void LoadList_Clicked(System.Object sender, System.EventArgs e)
        {
            MainList.IsRefreshing = false;
            MainList.ItemsSource = ItemSource;
        }

        void ClearList_Clicked(System.Object sender, System.EventArgs e)
        {
            MainList.IsRefreshing = false;
            MainList.ItemsSource = new List<string>();
        }
    }
}
