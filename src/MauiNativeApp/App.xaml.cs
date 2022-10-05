using Microsoft.Maui.Controls;

namespace MauiNativeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}