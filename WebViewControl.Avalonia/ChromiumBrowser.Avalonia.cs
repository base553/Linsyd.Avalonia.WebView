using Xilium.CefGlue.Avalonia;

namespace WebViewControl {

    public partial class ChromiumBrowser : AvaloniaCefBrowser {

        public new void CreateBrowser(int width, int height) {
            if (IsBrowserInitialized) {
                return;
            }
            base.CreateBrowser(width, height);
        }
    }
}
