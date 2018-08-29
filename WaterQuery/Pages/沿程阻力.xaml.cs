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
    public sealed partial class 沿程阻力 : Page
    {
        public 沿程阻力()
        {
            this.InitializeComponent();
        }




   

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                double _ccd;
                double _d;//直径
                _d = Convert.ToDouble(直径.Text);
                _ccd= Convert.ToDouble(ccd.Text);

                ccdperd.Text = Convert.ToString(0.001 * _ccd/ _d);
            }
            catch (Exception ex)
            {
                ccdperd.Text = ex.Message;
                //await new MessageDialog(ex.Message).ShowAsync();
            }
          
        }
    }
}
