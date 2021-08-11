using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WebViewFreeze
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var editorUri = Editor.BuildLocalStreamUri("Editor", "index.html");
            var resolver = new ContentResolver();
            Editor.NavigateToLocalStreamUri(editorUri, resolver);
        }

        private async void OnNewWindowClicked(object sender, RoutedEventArgs e)
        {
            var newView = CoreApplication.CreateNewView();
            int newViewId = -1;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(typeof(SecondaryPage), null);
                Window.Current.Content = frame;
                Window.Current.Activate();
                var applicationView = ApplicationView.GetForCurrentView();
                applicationView.Consolidated += OnApplicationViewConsolidated;
                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            if (newViewId != -1)
            {
                await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
            }
        }

        private void OnApplicationViewConsolidated(ApplicationView sender, ApplicationViewConsolidatedEventArgs args)
        {
            sender.Consolidated -= OnApplicationViewConsolidated;
            Window.Current.Close();
        }
    }
}
