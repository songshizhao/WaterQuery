using IAPWS.IF97;
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
    public sealed partial class 加热管道 : Page
    {
        public 加热管道()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double _P = Convert.ToDouble(P.Text);
                double _T = Convert.ToDouble(T1.Text);
                double _fai = Convert.ToDouble(fai.Text);
                double _m;// = Convert.ToDouble(m.Text);

                if (m.Text!=null&&m.Text.Length>0)
                {
                    _m = Convert.ToDouble(m.Text);

                }
                else
                {
                    UEWater.PT2V(_P, _T, out double _V, out _);
                    double _v = Convert.ToDouble(v.Text);
                    double _A = Convert.ToDouble(A.Text);
                    _m = _v * _A / _V;
                }



                double _deltaH=_fai/_m*0.001;
                deltaH.Text = _deltaH.ToString();

                UEWater.PT2H(_P,_T,out double _H1,out _);

                H1.Text = _H1.ToString();
                double _H2 = _H1 + _deltaH;
                H2.Text = _H2.ToString();
                UEWater.PH2T(_P, _H2, out double _T2, out _);

                T2.Text= _T2.ToString();

                


            }
            catch (Exception ex)
            {

                await new MessageDialog(ex.Message).ShowAsync();
            }
        }
    }
}
