using Xilium.CefGlue;

namespace WebViewControl {

    public partial class ChromiumBrowser {

        internal CefBrowser GetBrowser() => UnderlyingBrowser;
    }
}
