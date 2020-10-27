using System.Collections;
using System.ComponentModel;
using Xamarin.Forms;

namespace SamplesApp.Controls
{
    public partial class ImagedListView : Grid
    {
        public ImagedListView()
        {
            
            InitializeComponent();
        }

        public static readonly BindableProperty BackgroundImageProperty =
          BindableProperty.Create(nameof(BackgroundImage), typeof(ImageSource), typeof(ImagedListView));

        public ImageSource BackgroundImage
        {
            get { return (ImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }

        public static readonly BindableProperty ShowBackgroundImageProperty =
            BindableProperty.Create(nameof(ShowBackgroundImage), typeof(bool), typeof(ImagedListView));

        public bool ShowBackgroundImage
        {
            get { return (bool)GetValue(ShowBackgroundImageProperty); }
            set { SetValue(ShowBackgroundImageProperty, value); }
        }

        public static readonly BindableProperty ListViewProperty =
           BindableProperty.Create(nameof(InnerListView), typeof(ListView), typeof(ImagedListView), propertyChanged: HandleListViewChanged);

        public ListView InnerListView
        {
            get { return (ListView)GetValue(ListViewProperty); }
            set { SetValue(ListViewProperty, value); }
        }

        static void HandleListViewChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ImagedListView)bindable;
            var oldList = (ListView)oldValue;

            if (oldList != null)
            {
                control.Children.Remove(oldList);
                oldList.PropertyChanged -= ListViewPropertyChanged;
            }

            var newList = (ListView)newValue;
            newList.PropertyChanged += ListViewPropertyChanged;

            control.Children.Add(newList);
        }


        static void ListViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != ListView.ItemsSourceProperty.PropertyName) return;

            var listView = (ListView)sender;
            var control = listView.Parent as ImagedListView;

            if (listView.ItemsSource == null || ((listView.ItemsSource != null) && (listView.ItemsSource as ICollection).Count == 0))
            {
                control.ShowBackgroundImage = true;
            }
            else
            {
                control.ShowBackgroundImage = false;
            }
        }
    }
}
