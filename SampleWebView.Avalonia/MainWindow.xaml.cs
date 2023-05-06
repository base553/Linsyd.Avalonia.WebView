using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using WebViewControl;

namespace SampleWebView.Avalonia {

    internal class MainWindow : Window {

        public MainWindow() {
            WebView.Settings.OsrEnabled = false;
            WebView.Settings.LogFile = "ceflog.txt";
            AvaloniaXamlLoader.Load(this);
            var context = this.FindControl<Decorator>("webview");
            context.Child = new WebView(false, true);
            DataContext = new MainWindowViewModel((WebView)context.Child);
        }
    }
}