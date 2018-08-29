using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public sealed partial class 平板导热 : Page, INotifyPropertyChanged
    {
        // 实现INotify接口
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public 平板导热()
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

                double _r = _L / _lamd;
                double _q = dt / _r;

                R.Text = _r.ToString();
                q.Text = _q.ToString();
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
                
            }

        }



        //private double? _lamd=null;

        //public double? Lamd
        //{
        //    get { return _lamd; }
        //    set { _lamd = value; OnPropertyChanged(); }
        //}


        //private double _T1;

        //public double T1
        //{
        //    get { return _T1; }
        //    set { _T1 = value; OnPropertyChanged(); }
        //}
        //private double _T2;

        //public double T2
        //{
        //    get { return _T2; }
        //    set { _T2 = value; OnPropertyChanged(); }
        //}
        //private double? _L;

        //public double? L
        //{
        //    get { return _L; }
        //    set { _L = value; OnPropertyChanged(); }
        //}

        ////热阻
        //private double _R;

        //public double R
        //{
        //    get { return _R; }
        //    set { _R = value; OnPropertyChanged(); }
        //}


        ////热流密度
        //private double _q;

        //public double q
        //{
        //    get { return _q; }
        //    set { _q = value; OnPropertyChanged(); }
        //}

    }
}
