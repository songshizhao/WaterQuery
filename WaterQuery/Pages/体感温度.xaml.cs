using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Lights;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace WaterQuery.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class 体感温度 : Page
    {
        public 体感温度()
        {
            this.InitializeComponent();
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double _t = Convert.ToDouble(temp.Text);
                double _wet = Convert.ToDouble(wet.Text);
                double _wind = Convert.ToDouble(wind.Text);
               

                at.Text=ApparentTemperature.AT.Get(_t, _wet, _wind).ToString();

            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();

            }
        }
    }
}
