using Mvvm;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using XamlBrewer.Uwp.SqLiteEntityFrameworkSample.ViewModels;

namespace XamlBrewer.Uwp.SqLiteEntityFrameworkSample
{
    public sealed partial class MainPage : Page
    {
        private MenuItem resetItem;
        private MenuItem viewItem;

        public MainPage()
        {
            this.InitializeComponent();
            resetItem = new MenuItem()
            {
                Glyph = Symbol.Setting,
                Text = "Reset DB",
                Command = (DataContext as MainPageViewModel).CreateCommand
            };
            viewItem = new MenuItem()
            {
                Glyph = Symbol.View,
                Text = "View all",
                Command = (DataContext as MainPageViewModel).SelectCommand
            };
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            (this.DataContext as ViewModelBase).Menu.Add(resetItem);
            (this.DataContext as ViewModelBase).Menu.Add(viewItem);
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            (this.DataContext as ViewModelBase).Menu.Remove(resetItem);
            (this.DataContext as ViewModelBase).Menu.Remove(viewItem);
            base.OnNavigatedFrom(e);
        }

    }
}
