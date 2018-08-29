using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml.Linq;
using WaterQuery.Pages;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Store;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace WaterQuery
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MenuPage : Page
    {
        public MenuPage()
        {
            this.InitializeComponent();

            myframe.Navigate(typeof(IF97Page));

        }

        private async void ListViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {

            var li = sender as ListViewItem;
            switch (li.Tag.ToString())
            {

                case "平板导热":

                    myframe.Navigate(typeof(平板导热));
                    break;
                case "圆管导热":

                    myframe.Navigate(typeof(圆管导热));
                    break;
                case "体感温度":

                    myframe.Navigate(typeof(体感温度));
                    break;
                case "水物性":

                    myframe.Navigate(typeof(IF97Page));
                    break;
                case "管道加热":

                    myframe.Navigate(typeof(加热管道));
                    break;
                case "沿程阻力":

                    myframe.Navigate(typeof(沿程阻力));
                    break;


                case "热辐射发射率":

                    myframe.Navigate(typeof(热辐射发射率));
                    break;



                case "金属材料热物性":

                    myframe.Navigate(typeof(金属材料热物性));
                    break;


                case "其他材料热物性":

                    myframe.Navigate(typeof(其他材料热物性));
                    break;


                case "空气和烟气":

                    myframe.Navigate(typeof(空气和烟气));
                    break;
                case "单质气体":

                    myframe.Navigate(typeof(单质气体));
                    break;
                case "几种液体":

                    myframe.Navigate(typeof(几种液体));
                    break;
                case "液态金属":

                    myframe.Navigate(typeof(液态金属));
                    break;
                case "对流换热系数":

                    myframe.Navigate(typeof(对流换热系数));
                    break;
                //

                case "review":


                    StoreSendRequestResult result = await StoreRequestHelper.SendRequestAsync(
                        StoreContext.GetDefault(), 16, String.Empty);
                    if (result.ExtendedError == null)
                    {
                        JObject jsonObject = JObject.Parse(result.Response);

                        if (jsonObject.SelectToken("status").ToString() == "success")
                        {

                            // The customer rated or reviewed the app.

                            await new MessageDialog("你最好给的是好评😈！").ShowAsync();

                        }
                    }



                    break;


                //    

                //    


                //    



                default:
                    break;
            }

        }
    }
}
