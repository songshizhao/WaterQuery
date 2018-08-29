using IAPWS.IF97;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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


namespace WaterQuery.Pages
{

    public sealed partial class IF97Page : Page, INotifyPropertyChanged
    {

        // 实现INotify接口
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<DataModel> data_list=new ObservableCollection<DataModel>();

        public ObservableCollection<DataModel> DataList
        {
            get { return data_list; }
            set { data_list = value;OnPropertyChanged(); }
        }





        public IF97Page()
        {
            this.InitializeComponent();
            // IF97
            UEWater.SETSTD_WASP(97);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            DataList.Clear();

            try
            {
                // 压力温度主导
                double _P = Convert.ToDouble(P.Text);
                double _T = Convert.ToDouble(T.Text);
                // 使用IF97
                UEWater.SETSTD_WASP(97);

                UEWater.PT2H(_P, _T, out double _H, out _);
                DataList.Add(new DataModel
                {


                    name = "比焓(kJ/kg)",
                    value = _H,
                    desc = "根据温度,压力计算比焓",

                });
                // 
                UEWater.PT2ETA(_P, _T, out double _ETA, out _);
                DataList.Add(new DataModel
                {
                    desc = "已知压力(MPa)和温度(℃)，求动力粘度(Pa.s)",
                    name = "动力粘度",
                    value = _ETA,
                });
                // 
                UEWater.PT2U(_P, _T, out double _U, out _);
                DataList.Add(new DataModel
                {
                    desc = "已知压力(MPa)和温度(℃)，求运动粘度(m^2/s)",
                    name = "运动粘度",
                    value = _U,
                });
                // 
                UEWater.PT2CP(_P, _T, out double _CP, out _);
                DataList.Add(new DataModel
                {
                    desc = "已知压力(MPa)和温度(℃)，求定压比热(kJ/(kg.℃))",
                    name = "求定压比热",
                    value = _CP,
                });
                // 
                UEWater.PT2V(_P, _T, out double _V, out _);
                DataList.Add(new DataModel
                {
                    desc = "已知压力(MPa)和温度(℃)，求比容(m^3/kg)",
                    name = "比容",
                    value = _V,
                });
                // 
                UEWater.PT2RAMD(_P, _T, out double RAMD, out _);
                DataList.Add(new DataModel
                {
                    desc = "已知压力(MPa)和温度(℃)，求热传导系数(W/(m.℃))",
                    name = "热传导系数",
                    value = RAMD,
                });

                // 
                UEWater.PT2PRN(_P, _T, out double _PRN, out _);
                DataList.Add(new DataModel
                {
                    desc = "已知压力(MPa)和温度(℃)，求普朗特数",
                    name = "普朗特数",
                    value = _PRN,
                });
                // 
                UEWater.PT2X(_P, _T, out double _X, out _);
                DataList.Add(new DataModel
                {
                    desc = "已知压力(MPa)和温度(℃)，求干度(100%)",
                    name = "干度",
                    value = _X,
                });



                UEWater.PT2S(_P, _T, out double _S, out _);
                DataList.Add(new DataModel
                {
                    desc = "已知压力(MPa)和温度(℃)，求比熵(kJ/(kg.℃))",
                    name = "比熵",
                    value = _S,
                });


                // 已知压力(MPa)和温度(℃)，求比焓(kJ/kg)、比熵(kJ/(kg.℃))、比容(m^3/kg)
                //UEWater.PT(_P, double T, out double H, out double S, out double V, out double X, out _);


                // 
                UEWater.PT2CV(_P, _T, out double _CV, out _);
                DataList.Add(new DataModel
                {
                    desc = "已知压力(MPa)和温度(℃)，求定容比热(kJ/(kg.℃))",
                    name = "求定容比热",
                    value = _CV,
                });
                // 
                UEWater.PT2E(_P, _T, out double _E, out _);
                DataList.Add(new DataModel
                {
                    desc = "已知压力(MPa)和温度(℃)，求内能(kJ/kg)",
                    name = "内能",
                    value = _E,
                });
                // 
                UEWater.PT2SSP(_P, _T, out double _SSP, out _);
                DataList.Add(new DataModel
                {
                    desc = "已知压力(MPa)和温度(℃)，求音速(m/s)",
                    name = "介质内音速",
                    value = _SSP,
                });
                // 
                UEWater.PT2KS(_P, _T, out double _k, out _);
                DataList.Add(new DataModel
                {
                    desc = "已知压力(MPa)和温度(℃)，求定熵指数",
                    name = "定熵指数",
                    value = _k,
                });



                //
                UEWater.PT2EPS(_P, _T, out double _EPS, out _);
                DataList.Add(new DataModel
                {
                    desc = "已知压力(MPa)和温度(℃)，求介电常数",
                    name = "介电常数",
                    value = _EPS,
                });





                ////////////////////////////////////////////////////////
                ////饱和
                ////////////////////////////////////////////////////////
                //
                UEWater.P2T(_P, out double _Ts, out _);
                DataList.Add(new DataModel
                {

                    desc = $"压力{_P}Mpa下水的饱和温度℃",
                    name = "饱和水温度",
                    value = _Ts,


                });
                // 
                UEWater.T2P(_T, out double _Ps, out _);
                DataList.Add(new DataModel
                {
                    desc = $"{_T}℃下饱和压力(MPa)",
                    name = "饱和压力",
                    value = _Ps,
                });
                //
                UEWater.P2HL(_P, out double _HL, out _);
                DataList.Add(new DataModel
                {
                    desc = $"{_P}Mpa下饱和水比焓(kJ/kg)",
                    name = "饱和水比焓",
                    value = _HL,
                });


                //
                UEWater.P2HG(_P, out double _Hg, out _);
                DataList.Add(new DataModel
                {
                    desc = $"{_P}Mpa下饱和汽比焓(kJ/kg)",
                    name = "饱和汽比焓",
                    value = _Hg,
                });

                //

                UEWater.P2SL(_P, out double _Sl, out _);
                DataList.Add(new DataModel
                {
                    desc = $"{_P}Mpa下饱和水比熵(kJ/(kg.℃))",
                    name = "饱和水比熵",
                    value = _Sl,
                });
                // 

                UEWater.P2SG(_P, out double _Sg, out _);
                DataList.Add(new DataModel
                {
                    desc = $"{_P}Mpa下饱和汽比熵(kJ/(kg.℃))",
                    name = "饱和汽比熵",
                    value = _Sg,
                });


            }
            catch (Exception ex)
            {

                await new MessageDialog(ex.Message).ShowAsync();
            }
            

            #region 压力比焓主导




            #endregion


            //[DllImport("UEwasp.dll", EntryPoint = "PH2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            // 已知压力(MPa)和比焓(kJ/kg)，求温度(℃)
            //UEWater.PH2T(_P, double H, out double T, out _);

            //[DllImport("UEwasp.dll", EntryPoint = "PH2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            // 已知压力(MPa)和比焓(kJ/kg)，求比熵(kJ/(kg.℃))
            //UEWater.PH2S(_P, double H, out double S, out _);

            //[DllImport("UEwasp.dll", EntryPoint = "PH2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            // 已知压力(MPa)和比焓(kJ/kg)，求比容(m^3/kg)
            //UEWater.PH2V(_P, double H, out double V, out _);

            //[DllImport("UEwasp.dll", EntryPoint = "PH2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            // 已知压力(MPa)和比焓(kJ/kg)，求干度(100%)
            //UEWater.PH2X(_P, double H, out double X, out _);

            //[DllImport("UEwasp.dll", EntryPoint = "PH", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            // 已知压力(MPa)和比焓(kJ/kg)，求温度(℃)、比熵(kJ/(kg.℃))、比容(m^3/kg)、干度(100%)
            //UEWater.PH(_P, out double T, double H, out double S, out double V, out double X, out _);

            //[DllImport("UEwasp.dll", EntryPoint = "PS2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            // 已知压力(MPa)和比熵(kJ/(kg.℃))，求温度(℃)
            //UEWater.PS2T(_P, double S, out double T, out _);


            // 已知压力(MPa)和比熵(kJ/(kg.℃))，求比焓(kJ/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "PS2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.PS2H(_P, double S, out double H, out _);

            // 已知压力(MPa)和比熵(kJ/(kg.℃))，求比容(m^3/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "PS2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.PS2V(_P, double S, out double V, out _);

            // 已知压力(MPa)和比熵(kJ/(kg.℃))，求干度(100%)
            //[DllImport("UEwasp.dll", EntryPoint = "PS2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.PS2X(_P, double S, out double X, out _);

            //!!!!已知压力(MPa)和比熵(kJ/(kg.℃))，求温度(℃)、比焓(kJ/kg)、比容(m^3/kg)、干度(100%)
            //!!!! UEWater.PsAlias "PS" (_P,out double T,out double H,double S,out double V,out double X,out _);

            // 已知压力(MPa)和比容(m^3/kg)，求温度(℃)
            //[DllImport("UEwasp.dll", EntryPoint = "PV2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.PV2T(_P, double V, out double T, out _);

            // 已知压力(MPa)和比容(m^3/kg)，求比焓(kJ/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "PV2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.PV2H(_P, double V, out double H, out _);

            // 已知压力(MPa)和比容(m^3/kg)，求比容(m^3/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "PV2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.PV2S(_P, double V, out double S, out _);

            // 已知压力(MPa)和比容(m^3/kg)，求干度(100%)
            //[DllImport("UEwasp.dll", EntryPoint = "PV2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.PV2X(_P, double V, out double X, out _);

            // 已知压力(MPa)和比容(m^3/kg)，求温度(℃)、比焓(kJ/kg)、比容(m^3/kg)、干度(100%)
            //[DllImport("UEwasp.dll", EntryPoint = "PV", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.PV(_P, out double T, out double H, out double S, double V, out double X, out _);

            // 已知压力(MPa)和干度(100%)，求温度(℃)
            //[DllImport("UEwasp.dll", EntryPoint = "PX2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.PX2T(_P, double X, out double T, out _);

            // 已知压力(MPa)和干度(100%)，求比焓(kJ/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "PX2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.PX2H(_P, double X, out double H, out _);

            // 已知压力(MPa)和干度(100%)，求比熵(kJ/(kg.℃))
            //[DllImport("UEwasp.dll", EntryPoint = "PX2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.PX2S(_P, double X, out double S, out _);

            // 已知压力(MPa)和干度(100%)，求比容(m^3/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "PX2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.PX2V(_P, double X, out double V, out _);

            // 已知压力(MPa)和干度(100%)，求温度(℃)、比焓(kJ/kg)、比熵(kJ/(kg.℃))、比容(m^3/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "PX", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.PX(_P, out double T, out double H, out double S, out double V, double X, out _);



            // 已知温度(℃)，求饱和水比焓(kJ/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "T2HL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2HL(double T, out double H, out _);

            // 已知温度(℃)，求饱和汽比焓(kJ/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "T2HG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2HG(double T, out double H, out _);

            // 已知温度(℃)，求饱和水比熵(kJ/(kg.℃))
            //[DllImport("UEwasp.dll", EntryPoint = "T2SL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2SL(double T, out double S, out _);

            // 已知温度(℃)，求饱和汽比熵(kJ/(kg.℃))
            //[DllImport("UEwasp.dll", EntryPoint = "T2SG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2SG(double T, out double S, out _);

            // 已知温度(℃)，求饱和水比容(m^3/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "T2VL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2VL(double T, out double V, out _);

            // 已知温度(℃)，求饱和汽比容(m^3/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "T2VG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2VG(double T, out double V, out _);

            // 已知温度(℃)，求饱和水比焓(kJ/kg)、饱和水比熵(kJ/(kg.℃))、饱和水比容(m^3/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "T2L", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2L(out double P, double T, out double H, out double S, out double V, out double X, out _);

            // 已知温度(℃)，求饱和汽比焓(kJ/kg)、饱和汽比熵(kJ/(kg.℃))、饱和汽比容(m^3/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "T2G", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2G(out double P, double T, out double H, out double S, out double V, out double X, out _);

            // 已知温度(℃)，求饱和水定压比热(kJ/(kg.℃))
            //[DllImport("UEwasp.dll", EntryPoint = "T2CPL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2CPL(double T, out double CP, out _);

            // 已知温度(℃)，求饱和汽定压比热(kJ/(kg.℃))
            //[DllImport("UEwasp.dll", EntryPoint = "T2CPG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2CPG(double T, out double CP, out _);

            // 已知温度(℃)，求饱和水定容比热(kJ/(kg.℃))
            //[DllImport("UEwasp.dll", EntryPoint = "T2CVL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2CVL(double T, out double CV, out _);

            // 已知温度(℃)，求饱和汽定容比热(kJ/(kg.℃))
            //[DllImport("UEwasp.dll", EntryPoint = "T2CVG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2CVG(double T, out double CV, out _);

            // 已知温度(℃)，求饱和水内能(kJ/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "T2EL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2EL(double T, out double E, out _);

            // 已知温度(℃)，求饱和汽内能(kJ/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "T2EG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2EG(double T, out double E, out _);

            // 已知温度(℃)，求饱和水音速(m/s)
            //[DllImport("UEwasp.dll", EntryPoint = "T2SSPL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2SSPL(double T, out double SSP, out _);

            // 已知温度(℃)，求饱和汽音速(m/s)
            //[DllImport("UEwasp.dll", EntryPoint = "T2SSPG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2SSPG(double T, out double SSP, out _);

            // 已知温度(℃)，求饱和水定熵指数
            //[DllImport("UEwasp.dll", EntryPoint = "T2KSL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2KSL(double T, out double KS, out _);

            // 已知温度(℃)，求饱和汽定熵指数
            //[DllImport("UEwasp.dll", EntryPoint = "T2KSG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2KSG(double T, out double KS, out _);

            // 已知温度(℃)，求饱和水动力粘度(Pa.s)
            //[DllImport("UEwasp.dll", EntryPoint = "T2ETAL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2ETAL(double T, out double ETA, out _);

            // 已知温度(℃)，求饱和汽动力粘度(Pa.s)
            //[DllImport("UEwasp.dll", EntryPoint = "T2ETAG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2ETAG(double T, out double ETA, out _);

            // 已知温度(℃)，求饱和水运动粘度(m^2/s)
            //[DllImport("UEwasp.dll", EntryPoint = "T2UL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2UL(double T, out double U, out _);

            // 已知温度(℃)，求饱和汽运动粘度(m^2/s)
            //[DllImport("UEwasp.dll", EntryPoint = "T2UG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2UG(double T, out double U, out _);

            // 已知温度(℃)，求饱和水导热系数(W/(m.℃))
            //[DllImport("UEwasp.dll", EntryPoint = "T2RAMDL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2RAMDL(double T, out double RAMD, out _);

            // 已知温度(℃)，求饱和汽导热系数(W/(m.℃))
            //[DllImport("UEwasp.dll", EntryPoint = "T2RAMDG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2RAMDG(double T, out double RAMD, out _);

            // 已知温度(℃)，求饱和水普朗特数
            //[DllImport("UEwasp.dll", EntryPoint = "T2PRNL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2PRNL(double T, out double PRN, out _);

            // 已知温度(℃)，求饱和汽普朗特数
            //[DllImport("UEwasp.dll", EntryPoint = "T2PRNG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2PRNG(double T, out double PRN, out _);

            // 已知温度(℃)，求饱和水介电常数
            //[DllImport("UEwasp.dll", EntryPoint = "T2EPSL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2EPSL(double T, out double EPS, out _);

            // 已知温度(℃)，求饱和汽介电常数
            //[DllImport("UEwasp.dll", EntryPoint = "T2EPSG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2EPSG(double T, out double EPS, out _);

            // 已知温度(℃)，求饱和水折射率
            //[DllImport("UEwasp.dll", EntryPoint = "T2NL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2NL(double T, double Lanm, out double N, out _);

            // 已知温度(℃)，求饱和汽折射率
            //[DllImport("UEwasp.dll", EntryPoint = "T2NG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2NG(double T, double Lanm, out double N, out _);

            // 已知温度(℃)，求饱和水表面张力(N/m)
            //[DllImport("UEwasp.dll", EntryPoint = "T2SURFT", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.T2SURFT(double T, out double SurfT, out _);

            // 已知温度(℃)和比焓(kJ/kg)，求压力(MPa)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TH2PLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TH2PLP(double T, double H, out double P, out _);

            // 已知温度(℃)和比焓(kJ/kg)，求压力(MPa)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TH2PHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TH2PHP(double T, double H, out double P, out _);

            // 已知温度(℃)和比焓(kJ/kg)，求压力(MPa)(缺省为低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TH2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TH2P(double T, double H, out double P, out _);

            // 已知温度(℃)和比焓(kJ/kg)，求比熵(kJ/(kg.℃))(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TH2SLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TH2SLP(double T, double H, out double S, out _);

            // 已知温度(℃)和比焓(kJ/kg)，求比熵(kJ/(kg.℃))(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TH2SHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TH2SHP(double T, double H, out double S, out _);

            // 已知温度(℃)和比焓(kJ/kg)，求比熵(kJ/(kg.℃))(缺省为低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TH2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TH2S(double T, double H, out double S, out _);

            // 已知温度(℃)和比焓(kJ/kg)，求比容(m^3/kg)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TH2VLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TH2VLP(double T, double H, out double V, out _);

            // 已知温度(℃)和比焓(kJ/kg)，求比容(m^3/kg)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TH2VHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TH2VHP(double T, double H, out double V, out _);

            // 已知温度(℃)和比焓(kJ/kg)，求比容(m^3/kg)(缺省为低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TH2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TH2V(double T, double H, out double V, out _);

            // 已知温度(℃)和比焓(kJ/kg)，求干度(100%)
            //[DllImport("UEwasp.dll", EntryPoint = "TH2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TH2X(double T, double H, out double X, out _);

            // 已知温度(℃)和比焓(kJ/kg)，求压力(MPa)、比熵(kJ/(kg.℃))、比容(m^3/kg)、干度(100%)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "THLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.THLP(out double P, double T, double H, out double S, out double V, out double X, out _);

            // 已知温度(℃)和比焓(kJ/kg)，求压力(MPa)、比熵(kJ/(kg.℃))、比容(m^3/kg)、干度(100%)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "THHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.THHP(out double P, double T, double H, out double S, out double V, out double X, out _);

            // 已知温度(℃)和比焓(kJ/kg)，求压力(MPa)、比熵(kJ/(kg.℃))、比容(m^3/kg)、干度(100%)(缺省为低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TH", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TH(out double P, double T, double H, out double S, out double V, out double X, out _);

            // 已知温度(℃)和比熵(kJ/(kg.℃))，求压力(MPa)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TS2PLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TS2PLP(double T, double S, out double P, out _);

            // 已知温度(℃)和比熵(kJ/(kg.℃))，求压力(MPa)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TS2PHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TS2PHP(double T, double S, out double P, out _);

            // 已知温度(℃)和比熵(kJ/(kg.℃))，求压力(MPa)(缺省为低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TS2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TS2P(double T, double S, out double P, out _);

            // 已知温度(℃)和比熵(kJ/(kg.℃))，求比焓(kJ/kg)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TS2HLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TS2HLP(double T, double S, out double H, out _);

            // 已知温度(℃)和比熵(kJ/(kg.℃))，求比焓(kJ/kg)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TS2HHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TS2HHP(double T, double S, out double H, out _);

            // 已知温度(℃)和比熵(kJ/(kg.℃))，求比焓(kJ/kg)(缺省为低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TS2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TS2H(double T, double S, out double H, out _);

            // 已知温度(℃)和比熵(kJ/(kg.℃))，求比容(m^3/kg)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TS2VLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TS2VLP(double T, double S, out double V, out _);

            // 已知温度(℃)和比熵(kJ/(kg.℃))，求比容(m^3/kg)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TS2VHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TS2VHP(double T, double S, out double V, out _);

            // 已知温度(℃)和比熵(kJ/(kg.℃))，求比容(m^3/kg)(缺省为低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TS2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TS2V(double T, double S, out double V, out _);

            // 已知温度(℃)和比熵(kJ/(kg.℃))，求干度(100%)
            //[DllImport("UEwasp.dll", EntryPoint = "TS2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TS2X(double T, double S, out double X, out _);

            // 已知温度(℃)和比熵(kJ/(kg.℃))，求压力(MPa)、比焓(kJ/kg)、比容(m^3/kg)、干度(100%)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TSLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TSLP(out double P, double T, out double H, double S, out double V, out double X, out _);

            // 已知温度(℃)和比熵(kJ/(kg.℃))，求压力(MPa)、比焓(kJ/kg)、比容(m^3/kg)、干度(100%)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TSHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TSHP(out double P, double T, out double H, double S, out double V, out double X, out _);

            // 已知温度(℃)和比熵(kJ/(kg.℃))，求压力(MPa)、比焓(kJ/kg)、比容(m^3/kg)、干度(100%)(缺省为低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "TS", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TS(out double P, double T, out double H, double S, out double V, out double X, out _);

            // 已知温度(℃)和比容(m^3/kg)，求压力(MPa)
            //[DllImport("UEwasp.dll", EntryPoint = "TV2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TV2P(double T, double V, out double P, out _);

            // 已知温度(℃)和比容(m^3/kg)，求比焓(kJ/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "TV2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TV2H(double T, double V, out double H, out _);

            // 已知温度(℃)和比容(m^3/kg)，求比熵(kJ/(kg.℃))
            //[DllImport("UEwasp.dll", EntryPoint = "TV2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TV2S(double T, double V, out double S, out _);

            // 已知温度(℃)和比容(m^3/kg)，求干度(100%)
            //[DllImport("UEwasp.dll", EntryPoint = "TV2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TV2X(double T, double V, out double X, out _);

            // 已知温度(℃)和比容(m^3/kg)，求压力(MPa)、比焓(kJ/kg)、比熵(kJ/(kg.℃))、干度(100%)
            //[DllImport("UEwasp.dll", EntryPoint = "TV", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TV(out double P, double T, out double H, out double S, double V, out double X, out _);


            // 已知温度(℃)和干度(100%)，求压力(MPa)
            //[DllImport("UEwasp.dll", EntryPoint = "TX2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TX2P(double T, double X, out double P, out _);

            // 已知温度(℃)和干度(100%)，求比焓(kJ/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "TX2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TX2H(double T, double X, out double H, out _);

            // 已知温度(℃)和干度(100%)，求比熵(kJ/(kg.℃))
            //[DllImport("UEwasp.dll", EntryPoint = "TX2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TX2S(double T, double X, out double S, out _);

            // 已知温度(℃)和干度(100%)，求比容(m^3/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "TX2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TX2V(double T, double X, out double V, out _);

            // 已知温度(℃)和干度(100%)，求压力(MPa)、比焓(kJ/kg)、比熵(kJ/(kg.℃))、比容(m^3/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "TX", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.TX(out double P, double T, out double H, out double S, out double V, double X, out _);

            // 已知比焓(kJ/kg)和比熵(kJ/(kg.℃))，求压力(MPa)
            //[DllImport("UEwasp.dll", EntryPoint = "HS2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HS2P(double H, double S, out double P, out _);

            // 已知比焓(kJ/kg)和比熵(kJ/(kg.℃))，求温度(℃)
            //[DllImport("UEwasp.dll", EntryPoint = "HS2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HS2T(double H, double S, out double T, out _);

            // 已知比焓(kJ/kg)和比熵(kJ/(kg.℃))，求比容(m^3/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "HS2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HS2V(double H, double S, out double V, out _);

            // 已知比焓(kJ/kg)和比熵(kJ/(kg.℃))，求干度(100%)
            //[DllImport("UEwasp.dll", EntryPoint = "HS2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HS2X(double H, double S, out double X, out _);

            // 已知比焓(kJ/kg)和比熵(kJ/(kg.℃))，求压力(MPa)、温度(℃)、比容(m^3/kg)、干度(100%)
            //[DllImport("UEwasp.dll", EntryPoint = "HS", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HS(out double P, out double T, double H, double S, out double V, out double X, out _);

            // 已知比焓(kJ/kg)和比容(m^3/kg)，求压力(MPa)
            //[DllImport("UEwasp.dll", EntryPoint = "HV2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HV2P(double H, double V, out double P, out _);

            // 已知比焓(kJ/kg)和比容(m^3/kg)，求温度(℃)
            //[DllImport("UEwasp.dll", EntryPoint = "HV2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HV2T(double H, double V, out double T, out _);

            // 已知比焓(kJ/kg)和比容(m^3/kg)，求比熵(kJ/(kg.℃))
            //[DllImport("UEwasp.dll", EntryPoint = "HV2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HV2S(double H, double V, out double S, out _);

            // 已知比焓(kJ/kg)和比容(m^3/kg)，求干度(100%)
            //[DllImport("UEwasp.dll", EntryPoint = "HV2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HV2X(double H, double V, out double X, out _);

            // 已知比焓(kJ/kg)和比容(m^3/kg)，求压力(MPa)、温度(℃)、比熵(kJ/(kg.℃))、干度(100%)
            //[DllImport("UEwasp.dll", EntryPoint = "HV", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HV(out double P, out double T, double H, out double S, double V, out double X, out _);

            // 已知比焓(kJ/kg)和干度(100%)，求压力(MPa)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "HX2PLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HX2PLP(double H, double X, out double P, out _);

            // 已知比焓(kJ/kg)和干度(100%)，求压力(MPa)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "HX2PHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HX2PHP(double H, double X, out double P, out _);

            // 已知比焓(kJ/kg)和干度(100%)，求压力(MPa)(缺省是低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "HX2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HX2P(double H, double X, out double P, out _);

            // 已知比焓(kJ/kg)和干度(100%)，求温度(℃)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "HX2TLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HX2TLP(double H, double X, out double T, out _);

            // 已知比焓(kJ/kg)和干度(100%)，求温度(℃)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "HX2THP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HX2THP(double H, double X, out double T, out _);

            // 已知比焓(kJ/kg)和干度(100%)，求温度(℃)(缺省是低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "HX2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HX2T(double H, double X, out double T, out _);

            // 已知比焓(kJ/kg)和干度(100%)，求比熵(kJ/(kg.℃))(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "HX2SLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HX2SLP(double H, double X, out double S, out _);

            // 已知比焓(kJ/kg)和干度(100%)，求比熵(kJ/(kg.℃))(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "HX2SHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HX2SHP(double H, double X, out double S, out _);

            // 已知比焓(kJ/kg)和干度(100%)，求比熵(kJ/(kg.℃))(缺省是低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "HX2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HX2S(double H, double X, out double S, out _);

            // 已知比焓(kJ/kg)和干度(100%)，求比容(m^3/kg)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "HX2VLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HX2VLP(double H, double X, out double V, out _);

            // 已知比焓(kJ/kg)和干度(100%)，求比容(m^3/kg)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "HX2VHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HX2VHP(double H, double X, out double V, out _);

            // 已知比焓(kJ/kg)和干度(100%)，求比容(m^3/kg)(缺省是低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "HX2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HX2V(double H, double X, out double V, out _);

            // 已知比焓(kJ/kg)和干度(100%)，求压力(MPa)、温度(℃)、比熵(kJ/(kg.℃))、比容(m^3/kg)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "HXLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HXLP(out double P, out double T, double H, out double S, out double V, double X, out _);

            // 已知比焓(kJ/kg)和干度(100%)，求压力(MPa)、温度(℃)、比熵(kJ/(kg.℃))、比容(m^3/kg)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "HXHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HXHP(out double P, out double T, double H, out double S, out double V, double X, out _);


            // 已知比焓(kJ/kg)和干度(100%)，求压力(MPa)、温度(℃)、比熵(kJ/(kg.℃))、比容(m^3/kg)(缺省是低压的一个值)
            // Procedure HX97(Var P,T:Double;Const H:Double;Var S,V:Double;Const X:Double;Var Range:Integer);StdCall;
            //[DllImport("UEwasp.dll", EntryPoint = "HX", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.HX(out double P, out double T, double H, out double S, out double V, double X, out _);


            // 已知比熵(kJ/(kg.℃))和比容(m^3/kg)，求压力(MPa)
            //[DllImport("UEwasp.dll", EntryPoint = "SV2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SV2P(double S, double V, out double P, out _);

            // 已知比熵(kJ/(kg.℃))和比容(m^3/kg)，求温度(℃)
            //[DllImport("UEwasp.dll", EntryPoint = "SV2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SV2T(double S, double V, out double T, out _);

            // 已知比熵(kJ/(kg.℃))和比容(m^3/kg)，求比焓(kJ/kg)
            //[DllImport("UEwasp.dll", EntryPoint = "SV2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SV2H(double S, double V, out double H, out _);

            // 已知比熵(kJ/(kg.℃))和比容(m^3/kg)，求干度(100%)
            //[DllImport("UEwasp.dll", EntryPoint = "SV2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SV2X(double S, double V, out double X, out _);

            // 已知比熵(kJ/(kg.℃))和比容(m^3/kg)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、干度(100%)
            //[DllImport("UEwasp.dll", EntryPoint = "SV", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SV(out double P, out double T, out double H, double S, double V, out double X, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2PLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2PLP(double S, double X, out double P, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)(中压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2PMP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2PMP(double S, double X, out double P, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2PHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2PHP(double S, double X, out double P, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)(缺省是低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2P(double S, double X, out double P, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求温度(℃)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2TLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2TLP(double S, double X, out double T, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求温度(℃)(中压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2TMP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2TMP(double S, double X, out double T, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求温度(℃)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2THP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2THP(double S, double X, out double T, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求温度(℃)(缺省是低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2T(double S, double X, out double T, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求比焓(kJ/kg)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2HLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2HLP(double S, double X, out double H, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求比焓(kJ/kg)(中压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2HMP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2HMP(double S, double X, out double H, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求比焓(kJ/kg)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2HHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2HHP(double S, double X, out double H, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求比焓(kJ/kg)(缺省是低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2H(double S, double X, out double H, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求比容(m^3/kg)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2VLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2VLP(double S, double X, out double V, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求比容(m^3/kg)(中压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2VMP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2VMP(double S, double X, out double V, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求比容(m^3/kg)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2VHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2VHP(double S, double X, out double V, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求比容(m^3/kg)(缺省是低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX2V(double S, double X, out double V, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、比容(m^3/kg)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SXLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SXLP(out double P, out double T, out double H, double S, out double V, double X, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、比容(m^3/kg)(中压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SXMP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SXMP(out double P, out double T, out double H, double S, out double V, double X, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、比容(m^3/kg)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SXHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SXHP(out double P, out double T, out double H, double S, out double V, double X, out _);

            // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、比容(m^3/kg)(缺省是低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "SX", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.SX(out double P, out double T, out double H, double S, out double V, double X, out _);

            // 已知比容(m^3/kg)和干度(100%)，求压力(MPa)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VX2PLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VX2PLP(double V, double X, out double P, out _);

            // 已知比容(m^3/kg)和干度(100%)，求压力(MPa)(低高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VX2PHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VX2PHP(double V, double X, out double P, out _);

            // 已知比容(m^3/kg)和干度(100%)，求压力(MPa)(缺省是低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VX2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VX2P(double V, double X, out double P, out _);

            // 已知比容(m^3/kg)和干度(100%)，求温度(℃)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VX2TLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VX2TLP(double V, double X, out double T, out _);

            // 已知比容(m^3/kg)和干度(100%)，求温度(℃)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VX2THP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VX2THP(double V, double X, out double T, out _);

            // 已知比容(m^3/kg)和干度(100%)，求温度(℃)(缺省是低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VX2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VX2T(double V, double X, out double T, out _);

            // 已知比容(m^3/kg)和干度(100%)，求比焓(kJ/kg)(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VX2HLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VX2HLP(double V, double X, out double H, out _);

            // 已知比容(m^3/kg)和干度(100%)，求比焓(kJ/kg)(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VX2HHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VX2HHP(double V, double X, out double H, out _);

            // 已知比容(m^3/kg)和干度(100%)，求比焓(kJ/kg)(缺省是低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VX2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VX2H(double V, double X, out double H, out _);

            // 已知比容(m^3/kg)和干度(100%)，求比熵(kJ/(kg.℃))(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VX2SLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VX2SLP(double V, double X, out double S, out _);

            // 已知比容(m^3/kg)和干度(100%)，求比熵(kJ/(kg.℃))(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VX2SHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VX2SHP(double V, double X, out double S, out _);

            // 已知比容(m^3/kg)和干度(100%)，求比熵(kJ/(kg.℃))(缺省是低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VX2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VX2S(double V, double X, out double S, out _);

            // 已知比容(m^3/kg)和干度(100%)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、比熵(kJ/(kg.℃))(低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VXLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VXLP(out double P, out double T, out double H, out double S, double V, double X, out _);

            // 已知比容(m^3/kg)和干度(100%)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、比熵(kJ/(kg.℃))(高压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VXHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VXHP(out double P, out double T, out double H, out double S, double V, double X, out _);

            // 已知比容(m^3/kg)和干度(100%)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、比熵(kJ/(kg.℃))(缺省是低压的一个值)
            //[DllImport("UEwasp.dll", EntryPoint = "VX", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            //UEWater.VX(out double P, out double T, out double H, out double S, double V, double X, out _);


            #region fold
            //------------------------------------------------------------------------
            // 已知压力(MPa)，求对应饱和水比容(m^3/kg)

            ////UEWater.P2VL(_P, out double _Vl, out _);

            // 已知压力(MPa)，求对应饱和汽比容(m^3/kg)

            ///UEWater.P2VG(_P, out double Vg, out _);

            // 已知压力(MPa)，求对应饱和温度(℃)、饱和水比焓(kJ/kg)、饱和水比熵(kJ/(kg.℃))、饱和水比容(m^3/kg)

            //UEWater.P2L(_P, out double T, out double H, out double S, out double V, out double X, out _);

            // 已知压力(MPa)，求对应饱和温度(℃)、饱和汽比焓(kJ/kg)、饱和汽比熵(kJ/(kg.℃))、饱和汽比容(m^3/kg)

            //UEWater.P2G(_P, out double T, out double H, out double S, out double V, out double X, out _);

            // 已知压力(MPa)，求对应饱和水定压比热(kJ/(kg.℃))
            ////UEWater.P2CPL(_P, out double _CPl, out _);

            // 已知压力(MPa)，求对应饱和汽定压比热(kJ/(kg.℃))
            ////UEWater.P2CPG(_P, out double _CPg, out _);

            // 已知压力(MPa)，求对应饱和水定容比热(kJ/(kg.℃))
            ////UEWater.P2CVL(_P, out double _CVl, out _);

            // 已知压力(MPa)，求对应饱和汽定容比热(kJ/(kg.℃))
            ////UEWater.P2CVG(_P, out double CVg, out _);

            // 已知压力(MPa)，求对应饱和水内能(kJ/kg)
            ////UEWater.P2EL(_P, out double _El, out _);

            // 已知压力(MPa)，求对应饱和汽内能(kJ/kg)
            ////UEWater.P2EG(_P, out double _Eg, out _);
            // 已知压力(MPa)，求对应饱和水音速(m/s)
            ////UEWater.P2SSPL(_P, out double _SSP_l, out _);
            // 已知压力(MPa)，求对应饱和汽音速(m/s)
            ////UEWater.P2SSPG(_P, out double _SSP_g, out _);
            // 已知压力(MPa)，求对应饱和水定熵指数
            ////UEWater.P2KSL(_P, out double _KSl, out _);

            // 已知压力(MPa)，求对应饱和汽定熵指数
            ////UEWater.P2KSG(_P, out double _KSg, out _);

            // 已知压力(MPa)，求对应饱和水动力粘度(Pa.s)
            ////UEWater.P2ETAL(_P, out double _ETA_l, out _);

            // 已知压力(MPa)，求对应饱和汽动力粘度(Pa.s)
            ////UEWater.P2ETAG(_P, out double _ETA_g, out _);

            // 已知压力(MPa)，求对应饱和水运动粘度(m^2/s)
            ////UEWater.P2UL(_P, out double _Ul, out _);

            // 已知压力(MPa)，求对应饱和汽运动粘度(m^2/s)
            ////UEWater.P2UG(_P, out double Ug, out _);

            // 已知压力(MPa)，求对应饱和水导热系数(W/(m.℃))
            ////UEWater.P2RAMDL(_P, out double _RAMD_l, out _);

            // 已知压力(MPa)，求对应饱和汽导热系数(W/(m.℃))
            ////UEWater.P2RAMDG(_P, out double _RAMD_g, out _);

            // 已知压力(MPa)，求对应饱和水普朗特数
            ////UEWater.P2PRNL(_P, out double _PRN_l, out _);

            // 已知压力(MPa)，求对应饱和汽普朗特数
            ////UEWater.P2PRNG(_P, out double _PRN_g, out _);

            // 已知压力(MPa)，求对应饱和水导电系数
            ////UEWater.P2EPSL(_P, out double _EPS_l, out _);

            // 已知压力(MPa)，求对应饱和汽导电系数
            ////UEWater.P2EPSG(_P, out double _EPS_g, out _);

            // 已知压力(MPa)，求对应饱和水折射率
            ////UEWater.P2NL(_P, double Lanm, out double N, out _);

            // 已知压力(MPa)，求对应饱和汽折射率
            ////UEWater.P2NG(_P, double Lanm, out double N, out _);
            #endregion



        }


        private async void GetP(object sender, RoutedEventArgs e)
        {
            try
            {
                double _T = Convert.ToDouble(T1.Text);
                double _H = Convert.ToDouble(H1.Text);
                UEWater.TH2PHP(_T, _H, out double _P_h, out _);
                UEWater.TH2PLP(_T, _H, out double _P_l, out _);

                P1_h.Text = _P_h.ToString();
                P1_l.Text = _P_l.ToString();
            }
            catch (Exception ex)
            {

                await new MessageDialog(ex.Message).ShowAsync();
            }
        }

        private async void GetT(object sender, RoutedEventArgs e)
        {
            try
            {
                double _P = Convert.ToDouble(P2.Text);
                double _H = Convert.ToDouble(H2.Text);
                UEWater.PH2T(_P, _H, out double _T, out _);


                T2.Text = _T.ToString();
            }
            catch (Exception ex)
            {

                await new MessageDialog(ex.Message).ShowAsync();
            }
        }
    }




    public class DataModel 
    {



        public string desc { get; set; }

        public string name { get; set; }
        public double value { get; set; }

        public DataModel() { }

    }
}
