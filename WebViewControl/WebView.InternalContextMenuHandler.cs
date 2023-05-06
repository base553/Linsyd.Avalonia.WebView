using Xilium.CefGlue;
using Xilium.CefGlue.Common.Handlers;

namespace WebViewControl {

    public partial class WebView {

        public class InternalContextMenuHandler : ContextMenuHandler {

            private WebView OwnerWebView { get; }

            public InternalContextMenuHandler(WebView webView) {
                OwnerWebView = webView;
            }

            protected override void OnBeforeContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams state, CefMenuModel model) {
                if (OwnerWebView.DisableBuiltinContextMenus) {
                    model.Clear();
                }
            }
        }
    }
}
