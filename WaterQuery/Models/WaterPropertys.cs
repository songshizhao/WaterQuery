using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WaterPropertyQuery.Models
{
    public class WaterPropertys : INotifyPropertyChanged
    {

        //单位文本
        private double _Pressure=0;
        public double Pressure
        {
            get { return _Pressure; }
            set { SetProperty(ref _Pressure, value); }
        }



        //单位文本
        private double _Temperature = 0;
        public double Temperature
        {
            get { return _Temperature; }
            set { SetProperty(ref _Temperature, value); }
        }
        //单位文本
        private double _Xe = 0;
        public double Xe
        {
            get { return _Xe; }
            set { SetProperty(ref _Xe, value); }
        }
        //单位文本
        private double _Enthalpy = 0;
        public double Enthalpy
        {
            get { return _Enthalpy; }
            set { SetProperty(ref _Enthalpy, value); }
        }
        private double _Hg = 0;
        public double Hg
        {
            get { return _Hg; }
            set { SetProperty(ref _Hg, value); }
        }

        private double _HL = 0;
        public double HL
        {
            get { return _HL; }
            set { SetProperty(ref _HL, value); }
        }


        //单位文本
        private double _Entropy = 0;
        public double Entropy
        {
            get { return _Entropy; }
            set { SetProperty(ref _Entropy, value); }
        }
        //比熵
        //单位文本
        private double _SpecificVolume = 0;
        public double SpecificVolume
        {
            get { return _SpecificVolume; }
            set { SetProperty(ref _SpecificVolume, value); }
        }        //比容
        //单位文本
        private double _Cp = 0;
        public double Cp
        {
            get { return _Cp; }
            set { SetProperty(ref _Cp, value); }
        }
        //定压比热
       
        private double _Cv = 0;
        public double Cv
        {
            get { return _Cv; }
            set { SetProperty(ref _Cv, value); }
        }
        //定容比热 
        //单位文本
        private double _E = 0;
        public double E
        {
            get { return _E; }
            set { SetProperty(ref _E, value); }
        }
        //内能 
        //单位文本
        private double _SSP = 0;
        public double SSP
        {
            get { return _SSP; }
            set { SetProperty(ref _SSP, value); }
        }
        //声速 
        //单位文本
        private double _KS = 0;
        public double KS
        {
            get { return _KS; }
            set { SetProperty(ref _KS, value); }
        }
        //定熵指数 
        //单位文本
        private double _Eta = 0;
        public double Eta
        {
            get { return _Eta; }
            set { SetProperty(ref _Eta, value); }
        }
        //动力粘度 
        //单位文本
        private double _U = 0;
        public double U
        {
            get { return _U; }
            set { SetProperty(ref _U, value); }
        }
        //运动粘度 U 
        //单位文本
        private double _RAMD = 0;
        public double RAMD
        {
            get { return _RAMD; }
            set { SetProperty(ref _RAMD, value); }
        }
        //导热系数
        //单位文本
        private double _PRN = 0;
        public double PRN
        {
            get { return _PRN; }
            set { SetProperty(ref _PRN, value); }
        }
        //普朗特数 
        //单位文本
        private double _EPS = 0;
        public double EPS
        {
            get { return _EPS; }
            set { SetProperty(ref _EPS, value); }
        }
        //介电常数 EPS = 14.281653534434
        //单位文本
        private double _N = 0;
        public double N
        {
            get { return _N; }
            set { SetProperty(ref _N, value); }
        }
        //折射率   N    =   1.229697688549 
        //单位文本

        //比焓 H = 2610.864760990423 kJ/kg

        //单位文本
        private double _Density = 0;
        public double Density
        {
            get { return _Density; }
            set { SetProperty(ref _Density, value); }
        }

        // 实现INotify接口-------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName="")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }










}
