using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace WaterQuery.Helpper
{



    public class MyDoubleConverter : IValueConverter
    {

        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {

            string result = "111";

            try
            {
                result = value.ToString();
            }
            catch (Exception)
            {
                Debug.WriteLine("转换失败");
                result ="";
            }

            return result;


        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            double result = 0;
            try
            {
                result = Convert.ToDouble(value);
            }
            catch (Exception)
            {
                Debug.WriteLine("逆向转换失败");

                result = 0d;
            }

            return result;
        }
    }



    public class MyBool2StringConverter : IValueConverter
    {

        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {

            if ((bool)value)
            {
                return Visibility.Visible;
                
            }
            else
            {
                return Visibility.Collapsed;
            }


        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if ((Visibility)value== Visibility.Visible)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }




    public class LoginStateConverter : IValueConverter
    {

        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if ((bool)value)
            {
                //return "0xEA8C";               
                return "\uEA8C";
            }

            else
            {
                return "\uE13D";
            }



        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }




}
