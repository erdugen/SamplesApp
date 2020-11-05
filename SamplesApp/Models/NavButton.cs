using System.Windows.Input;
using Xamarin.Forms;

namespace SamplesApp.Models
{
    public class NavButton : BindableObject
    {
        public string Title { get; set; }
        public ICommand ButtonCommand { get; set; }
        public string ImageSource { get; set; }        
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
