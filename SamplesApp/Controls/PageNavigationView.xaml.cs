using System.Collections.ObjectModel;
using System.Windows.Input;
using SamplesApp.Models;
using Xamarin.Forms;

namespace SamplesApp.Controls
{
    public partial class PageNavigationView : ContentView
    {
        public ICommand ReturnCommand => new Command<NavButton>(async (model) =>
        {
            if (model.ButtonCommand != null && model.ButtonCommand.CanExecute(null))
                model.ButtonCommand.Execute(null);
        });

        public PageNavigationView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty HeaderTitleProperty = BindableProperty.Create(nameof(HeaderTitle), typeof(string), typeof(PageNavigationView), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var control = (PageNavigationView)bindable;
            control.lblTitle.Text = (newVal as string);
            control.UpdateTitleMargin();
        });

        public string HeaderTitle
        {
            get
            {
                return (string)GetValue(HeaderTitleProperty);
            }
            set
            {
                SetValue(HeaderTitleProperty, value);
            }
        }

        public static readonly BindableProperty LeftButtonProperty = BindableProperty.Create(nameof(LeftButton), typeof(NavButton), typeof(PageNavigationView), defaultBindingMode: BindingMode.OneWay);

        public NavButton LeftButton
        {
            get
            {
                return (NavButton)GetValue(LeftButtonProperty);
            }
            set
            {
                SetValue(LeftButtonProperty, value);
            }
        }

        public static readonly BindableProperty RightButtonsProperty = BindableProperty.Create(nameof(RightButtons), typeof(ObservableCollection<NavButton>), typeof(PageNavigationView), null, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var control = (PageNavigationView)bindable;
            control.RightButtons = (ObservableCollection<NavButton>)newVal;
            control.UpdateTitleMargin();
        });

        public ObservableCollection<NavButton> RightButtons
        {
            get
            {
                return (ObservableCollection<NavButton>)GetValue(RightButtonsProperty);
            }
            set
            {
                SetValue(RightButtonsProperty, value);
            }
        }

        public void UpdateTitleMargin()
        {   
            double leftPadding = 1;
            double rightPadding = 0;

            if (RightButtons == null || RightButtons.Count == 0)
                rightPadding = 36;
            else
            {
                if (RightButtons.Count > 1)
                    leftPadding = (RightButtons.Count - 1) * 36;
            }

            lblTitle.Padding = new Thickness(leftPadding, 0, rightPadding, 0);
            lblTitle.IsVisible = false;
            lblTitle.IsVisible = true;

        }
    }
}
