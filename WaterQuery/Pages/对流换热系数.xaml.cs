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
    public sealed partial class 对流换热系数 : Page
    {
        public 对流换热系数()
        {
            this.InitializeComponent();
        }




        public void run()
        {




            //double Tw;
            //double Tf;

            //Nu = 0.023 * Math.Pow(Re, 0.8) * Math.Pow(Pr, 0.4);







        }



        //public double gas_fix(double Nu)
        //{
        //    //if gas
        //    if (Tf >= Tw)
        //    {
        //        return 1;//被冷却
        //    }
        //    else
        //    {
        //        return Math.Pow(Tf / Tw, 0.5);//被加热
        //    }
        //}




        //private double _niandu;

        //public double niandu
        //{
        //    get { return _niandu; }
        //    set { _niandu = value; 

        //    }
        //}





        //public double water_fix(double Nu)
        //{

        //    double x = 0;
        //    //if gas
        //    if (Tf >= Tw)
        //    {
        //        //被冷却
        //        x=0.25;
        //    }
        //    else
        //    {//被加热
        //        x = 0.11;

        //    }
        //    //double eta_f;
        //    // double eta_w;

        //    double _P = Convert.ToDouble(tb_P.Text);
        //    double _T = Convert.ToDouble(tb_T.Text);
        //    UEWater.PT2U(_P,_T,out double eta_f,out _);
        //    UEWater.PT2U(_P, _T, out double eta_w, out _);

        //    double fix = Math.Pow(eta_f / eta_w, x);


        //    return fix;

        //}






        private void PT2Niandu(object sender, RoutedEventArgs e)
        {
            try
            {

                double _P = Convert.ToDouble(tb_P.Text);
                double _T = Convert.ToDouble(tb_T.Text);

                UEWater.PT2U(_P, _T, out double _nian, out _);



                tb_niandu.Text = _nian.ToString();
            }
            catch (Exception)
            {


            }
        }

        private void CalRe(object sender, RoutedEventArgs e)
        {


            try
            {

                double v = Convert.ToDouble(tb_v.Text);
                double de = Convert.ToDouble(tb_de.Text);
                double niandu = Convert.ToDouble(tb_niandu.Text);

                double Re = v * de / niandu;

                tb_re.Text = Re.ToString();
            }
            catch (Exception)
            {


            }


        }

        private void PT2Pr(object sender, RoutedEventArgs e)
        {



            try
            {

                double _P = Convert.ToDouble(tb_P2.Text);
                double _T = Convert.ToDouble(tb_T2.Text);

                UEWater.PT2PRN(_P, _T, out double _Pr, out _);


                tb_Pr.Text = _Pr.ToString();
               
            }
            catch (Exception)
            {


            }

        }

        private async void CalNuDB(object sender, RoutedEventArgs e)
        {

            try
            {


                double _Pr = Convert.ToDouble(tb_Pr.Text);
                double _Re = Convert.ToDouble(tb_re.Text); ;


                double n = Convert.ToDouble(tb_n.Text);


                double _Nu = 0.023 * Math.Pow(_Re, 0.8) * Math.Pow(_Pr, n);

                if (use_nu_fix.IsChecked.HasValue && use_nu_fix.IsChecked.Value == true)
                {
                    double _fix = Convert.ToDouble(tb_Ct.Text);

                    _Nu = _Nu * _fix;
                }

                tb_Nu.Text = _Nu.ToString();


            }
            catch (Exception ex)
            {


                await new MessageDialog(ex.Message).ShowAsync();
            }


        }

        private async void CalNuG(object sender, RoutedEventArgs e)
        {
            try
            {


                double _Pr = Convert.ToDouble(tb_Pr.Text);
                double _Re = Convert.ToDouble(tb_re.Text); 


               
                double _f=Math.Pow(1.82*Math.Log10(_Re)-1.64,-2);
                double dl = Convert.ToDouble(tb_dl.Text); 
                double _Nu =(_f/8d)*(_Re-1000)*_Pr/(1+12.7*Math.Pow(_f / 8, 0.5)*(Math.Pow(_Pr,2d/3d)-1))*(1+Math.Pow(dl,2d/3d));

                if (use_nu_fix.IsChecked.HasValue && use_nu_fix.IsChecked.Value == true)
                {
                    double _fix = Convert.ToDouble(tb_Ct.Text);

                    _Nu = _Nu * _fix;
                }

                tb_Nu.Text = _Nu.ToString();


            }
            catch (Exception ex)
            {


                await new MessageDialog(ex.Message).ShowAsync();
            }
        }

        private void PT2Lamd(object sender, RoutedEventArgs e)
        {
            try
            {

                double _P = Convert.ToDouble(tb_P3.Text);
                double _T = Convert.ToDouble(tb_T3.Text);

                UEWater.PT2RAMD(_P, _T, out double _lamd, out _);


                tb_lamd.Text = _lamd.ToString();

            }
            catch (Exception)
            {


            }
        }

        private async void Calh(object sender, RoutedEventArgs e)
        {
            try
            {


                double _Nu = Convert.ToDouble(tb_Nu.Text);
                double _lamd = Convert.ToDouble(tb_lamd.Text);
                double _de = Convert.ToDouble(tb_de.Text);

                double _h = _Nu * _lamd / _de;
                tb_h.Text = _h.ToString();

            }
            catch (Exception ex)
            {

                await new MessageDialog(ex.Message).ShowAsync();
            }
        }
    }
}
