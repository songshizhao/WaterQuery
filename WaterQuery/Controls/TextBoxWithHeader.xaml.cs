using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace WaterPropertyQuery.Controls
{
    public sealed partial class TextBoxWithHeader : UserControl, INotifyPropertyChanged
    {
        public TextBox InputBox { get; set; }


        //Header Property
        private string _HeaderText="";
        public string HeaderText
        {
            get { return _HeaderText; }
            set { SetProperty(ref _HeaderText, value); }
        }
        //InputValue Property


        public double InputValue
        {
            get
            {
                return (double)GetValue(InputValueProperty);
            }
            set
            {
                InputBox.Text = value.ToString();

                SetValue(InputValueProperty, value);
            }
        }

        //Using a DependencyProperty as the backing store for InputValue.This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InputValueProperty =
            DependencyProperty.Register("InputValue", typeof(double), typeof(TextBoxWithHeader), new PropertyMetadata(0d));


        //static void InputValuePropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        //{
        //    Debug.WriteLine("0011");
        //    // Text = "{x:Bind InputValue,Mode=TwoWay,Converter={StaticResource Double2String}}"
        //    (sender as TextBoxWithHeader).InputBox.Text = e.NewValue.ToString();
        //    Debug.WriteLine((sender as TextBoxWithHeader).InputBox.Text = e.NewValue.ToString());
        //}


        ////private string _InputValue = "";
        ////public string InputValue
        ////{
        ////    get { return _InputValue; }
        ////    set { SetProperty(ref _InputValue, value); }
        ////}




        //单位文本
        private string _UnitText = "";
        public string UnitText
        {
            get { return _UnitText; }
            set { SetProperty(ref _UnitText, value); }
        }

        public TextBoxWithHeader()
        {
            this.InitializeComponent();
            InputBox = InputTextBox;
            InputBox.TextChanged += InputBox_TextChanged;
        }

        private void InputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                this.InputValue = Convert.ToDouble((sender as TextBox).Text);
            }
            catch (Exception)
            {

            };
           
        }



        // 实现INotify接口-------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




    }
}
