using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WaterQuery.Pages;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace WaterQuery
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //mainFrame.Navigate(typeof(Page1));


            var appTitleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            Window.Current.SetTitleBar(MyTitle);
            
            //gwp = new GetWaterProperty();
            //var result=gwp.GetH(5,15);
            //Debug.WriteLine("!!!"+result);
            
        }

        private void menu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mainSplitView.IsPaneOpen = !mainSplitView.IsPaneOpen;
        }

        private void mainNavigationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var lb = sender as ListBox;
            //switch (lb.SelectedIndex)
            //{
            //    case 0:
            //        //本地计算页
            //        mainFrame.Navigate(typeof(Page1));
            //        break;
            //    case 1:
            //        mainFrame.Navigate(typeof(Page2));
            //        break;
            //    default:
            //        Debug.WriteLine(lb.SelectedIndex);
            //        break;
            //}
            // Debug.WriteLine(sender.GetType().ToString());
       
        }
    }
}

