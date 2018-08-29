using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class 圆管导热 : Page
    {
        public 圆管导热()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double dt = 0;
                if (deltaT.Text.Length > 0)
                {
                    dt = Convert.ToDouble(deltaT.Text);
                }
                else
                {
                    dt = Convert.ToDouble(T1.Text) - Convert.ToDouble(T2.Text);
                }
                double _lamd = Convert.ToDouble(lamd.Text);
                double _L = Convert.ToDouble(L.Text);
                double _d2= Convert.ToDouble(d2.Text);
                double _d1 = Convert.ToDouble(d1.Text);
                double _r = Math.Log(_d2/_d1)/(_lamd*_L*Math.PI*2);
                double _fai = dt / _r;




                R.Text = _r.ToString();
                fai.Text = _fai.ToString();
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();

            }
        }
    }
}
