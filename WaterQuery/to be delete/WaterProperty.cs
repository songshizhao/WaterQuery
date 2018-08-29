using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IAPWS.IF97
{
    class UEWater
    {

        //设置使用的公式 STDID=97,使用IAPWS-IF97公式；STDID=67,使用IFC67公式
        [DllImport("UEwasp.dll", EntryPoint = "SETSTD_WASP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SETSTD_WASP(long STDID);
        //已知压力求对应水的饱和温度
        [DllImport("UEwasp.dll", EntryPoint = "P2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2T(double P, out double T, out long Range);
        // 
        [DllImport("UEwasp.dll", EntryPoint = "P2HL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2HL(double P, out double H, out long Range);

        // 已知压力(MPa)，求对应饱和汽比焓(kJ/kg)
        [DllImport("UEwasp.dll", EntryPoint = "P2HG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2HG(double P, out double H, out long Range);

        // 已知压力(MPa)，求对应饱和水比熵(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "P2SL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2SL(double P, out double S, out long Range);

        // 已知压力(MPa)，求对应饱和汽比熵(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "P2SG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2SG(double P, out double S, out long Range);

        // 已知压力(MPa)，求对应饱和水比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "P2VL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2VL(double P, out double V, out long Range);

        // 已知压力(MPa)，求对应饱和汽比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "P2VG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2VG(double P, out double V, out long Range);

        // 已知压力(MPa)，求对应饱和温度(℃)、饱和水比焓(kJ/kg)、饱和水比熵(kJ/(kg.℃))、饱和水比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "P2L", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2L(double P, out double T, out double H, out double S, out double V, out double X, out long Range);

        // 已知压力(MPa)，求对应饱和温度(℃)、饱和汽比焓(kJ/kg)、饱和汽比熵(kJ/(kg.℃))、饱和汽比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "P2G", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2G(double P, out double T, out double H, out double S, out double V, out double X, out long Range);

        // 已知压力(MPa)，求对应饱和水定压比热(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "P2CPL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2CPL(double P, out double CP, out long Range);

        // 已知压力(MPa)，求对应饱和汽定压比热(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "P2CPG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2CPG(double P, out double CP, out long Range);

        // 已知压力(MPa)，求对应饱和水定容比热(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "P2CVL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2CVL(double P, out double CV, out long Range);

        // 已知压力(MPa)，求对应饱和汽定容比热(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "P2CVG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2CVG(double P, out double CV, out long Range);

        // 已知压力(MPa)，求对应饱和水内能(kJ/kg)
        [DllImport("UEwasp.dll", EntryPoint = "P2EL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2EL(double P, out double E, out long Range);

        // 已知压力(MPa)，求对应饱和汽内能(kJ/kg)
        [DllImport("UEwasp.dll", EntryPoint = "P2EG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2EG(double P, out double E, out long Range);
        // 已知压力(MPa)，求对应饱和水音速(m/s)
        [DllImport("UEwasp.dll", EntryPoint = "P2SSPL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2SSPL(double P, out double SSP, out long Range);
        // 已知压力(MPa)，求对应饱和汽音速(m/s)
        [DllImport("UEwasp.dll", EntryPoint = "P2SSPG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2SSPG(double P, out double SSP, out long Range);
        // 已知压力(MPa)，求对应饱和水定熵指数
        [DllImport("UEwasp.dll", EntryPoint = "P2KSL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2KSL(double P, out double KS, out long Range);
        
        // 已知压力(MPa)，求对应饱和汽定熵指数
        [DllImport("UEwasp.dll", EntryPoint = "P2KSG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void P2KSG(double P, out double KS, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "P2ETAL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)，求对应饱和水动力粘度(Pa.s)
        public static extern void P2ETAL(double P, out double ETA, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "P2ETAG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)，求对应饱和汽动力粘度(Pa.s)
        public static extern void P2ETAG(double P, out double ETA, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "P2UL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)，求对应饱和水运动粘度(m^2/s)
        public static extern void P2UL(double P, out double U, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "P2UG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)，求对应饱和汽运动粘度(m^2/s)
        public static extern void P2UG(double P, out double U, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "P2RAMDL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)，求对应饱和水导热系数(W/(m.℃))
        public static extern void P2RAMDL(double P, out double RAMD, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "P2RAMDG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)，求对应饱和汽导热系数(W/(m.℃))
        public static extern void P2RAMDG(double P, out double RAMD, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "P2PRNL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)，求对应饱和水普朗特数
        public static extern void P2PRNL(double P, out double PRN, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "P2PRNG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)，求对应饱和汽普朗特数
        public static extern void P2PRNG(double P, out double PRN, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "P2EPSL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)，求对应饱和水导电系数
        public static extern void P2EPSL(double P, out double EPS, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "P2EPSG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)，求对应饱和汽导电系数
        public static extern void P2EPSG(double P, out double EPS, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "P2NL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)，求对应饱和水折射率
        public static extern void P2NL(double P, double Lanm, out double N, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "P2NG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)，求对应饱和汽折射率
        public static extern void P2NG(double P, double Lanm, out double N, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求比焓(kJ/kg)
        public static extern void PT2H(double P, double T, out double H, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求比熵(kJ/(kg.℃))
        public static extern void PT2S(double P, double T, out double S, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求比容(m^3/kg)
        public static extern void PT2V(double P, double T, out double V, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求干度(100%)
        public static extern void PT2X(double P, double T, out double X, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求比焓(kJ/kg)、比熵(kJ/(kg.℃))、比容(m^3/kg)
        public static extern void PT(double P, double T, out double H, out double S, out double V, out double X, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2CP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求定压比热(kJ/(kg.℃))
        public static extern void PT2CP(double P, double T, out double CP, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2CV", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求定容比热(kJ/(kg.℃))
        public static extern void PT2CV(double P, double T, out double CV, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2E", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求内能(kJ/kg)
        public static extern void PT2E(double P, double T, out double E, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2SSP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求音速(m/s)
        public static extern void PT2SSP(double P, double T, out double a, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2KS", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求定熵指数
        public static extern void PT2KS(double P, double T, out double k, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2ETA", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求动力粘度(Pa.s)
        public static extern void PT2ETA(double P, double T, out double ETA, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2U", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求运动粘度(m^2/s)
        public static extern void PT2U(double P, double T, out double U, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2RAMD", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求热传导系数(W/(m.℃))
        public static extern void PT2RAMD(double P, double T, out double RAMD, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2PRN", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求普朗特数
        public static extern void PT2PRN(double P, double T, out double PRN, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2EPS", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求介电常数
        public static extern void PT2EPS(double P, double T, out double EPS, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PT2N", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和温度(℃)，求折射率
        public static extern void PT2N(double P, double T, double Lamd, out double N, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PH2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和比焓(kJ/kg)，求温度(℃)
        public static extern void PH2T(double P, double H, out double T, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PH2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和比焓(kJ/kg)，求比熵(kJ/(kg.℃))
        public static extern void PH2S(double P, double H, out double S, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PH2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和比焓(kJ/kg)，求比容(m^3/kg)
        public static extern void PH2V(double P, double H, out double V, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PH2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和比焓(kJ/kg)，求干度(100%)
        public static extern void PH2X(double P, double H, out double X, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PH", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和比焓(kJ/kg)，求温度(℃)、比熵(kJ/(kg.℃))、比容(m^3/kg)、干度(100%)
        public static extern void PH(double P, out double T, double H, out double S, out double V, out double X, out long Range);

        [DllImport("UEwasp.dll", EntryPoint = "PS2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        // 已知压力(MPa)和比熵(kJ/(kg.℃))，求温度(℃)
        public static extern void PS2T(double P, double S, out double T, out long Range);

        
        // 已知压力(MPa)和比熵(kJ/(kg.℃))，求比焓(kJ/kg)
        [DllImport("UEwasp.dll", EntryPoint = "PS2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void PS2H(double P, double S, out double H, out long Range);
        
        // 已知压力(MPa)和比熵(kJ/(kg.℃))，求比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "PS2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void PS2V(double P, double S, out double V, out long Range);
        
        // 已知压力(MPa)和比熵(kJ/(kg.℃))，求干度(100%)
        [DllImport("UEwasp.dll", EntryPoint = "PS2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void PS2X(double P, double S, out double X, out long Range);
        
        //!!!!已知压力(MPa)和比熵(kJ/(kg.℃))，求温度(℃)、比焓(kJ/kg)、比容(m^3/kg)、干度(100%)
        //!!!! public static extern void PsAlias "PS" (double P,out double T,out double H,double S,out double V,out double X,out long Range);

        // 已知压力(MPa)和比容(m^3/kg)，求温度(℃)
        [DllImport("UEwasp.dll", EntryPoint = "PV2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void PV2T(double P, double V, out double T, out long Range);
        
        // 已知压力(MPa)和比容(m^3/kg)，求比焓(kJ/kg)
        [DllImport("UEwasp.dll", EntryPoint = "PV2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void PV2H(double P, double V, out double H, out long Range);
        
        // 已知压力(MPa)和比容(m^3/kg)，求比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "PV2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void PV2S(double P, double V, out double S, out long Range);
        
        // 已知压力(MPa)和比容(m^3/kg)，求干度(100%)
        [DllImport("UEwasp.dll", EntryPoint = "PV2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void PV2X(double P, double V, out double X, out long Range);
        
        // 已知压力(MPa)和比容(m^3/kg)，求温度(℃)、比焓(kJ/kg)、比容(m^3/kg)、干度(100%)
        [DllImport("UEwasp.dll", EntryPoint = "PV", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void PV(double P, out double T, out double H, out double S, double V, out double X, out long Range);

        // 已知压力(MPa)和干度(100%)，求温度(℃)
        [DllImport("UEwasp.dll", EntryPoint = "PX2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void PX2T(double P, double X, out double T, out long Range);
        
        // 已知压力(MPa)和干度(100%)，求比焓(kJ/kg)
        [DllImport("UEwasp.dll", EntryPoint = "PX2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void PX2H(double P, double X, out double H, out long Range);
        
        // 已知压力(MPa)和干度(100%)，求比熵(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "PX2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void PX2S(double P, double X, out double S, out long Range);
        
        // 已知压力(MPa)和干度(100%)，求比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "PX2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void PX2V(double P, double X, out double V, out long Range);
        
        // 已知压力(MPa)和干度(100%)，求温度(℃)、比焓(kJ/kg)、比熵(kJ/(kg.℃))、比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "PX", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void PX(double P, out double T, out double H, out double S, out double V, double X, out long Range);

        // 已知温度(℃)，求饱和压力(MPa)
        [DllImport("UEwasp.dll", EntryPoint = "T2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2P(double T, out double P, out long Range);
        
        // 已知温度(℃)，求饱和水比焓(kJ/kg)
        [DllImport("UEwasp.dll", EntryPoint = "T2HL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2HL(double T, out double H, out long Range);
        
        // 已知温度(℃)，求饱和汽比焓(kJ/kg)
        [DllImport("UEwasp.dll", EntryPoint = "T2HG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2HG(double T, out double H, out long Range);
        
        // 已知温度(℃)，求饱和水比熵(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "T2SL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2SL(double T, out double S, out long Range);
        
        // 已知温度(℃)，求饱和汽比熵(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "T2SG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2SG(double T, out double S, out long Range);
        
        // 已知温度(℃)，求饱和水比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "T2VL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2VL(double T, out double V, out long Range);
        
        // 已知温度(℃)，求饱和汽比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "T2VG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2VG(double T, out double V, out long Range);
        
        // 已知温度(℃)，求饱和水比焓(kJ/kg)、饱和水比熵(kJ/(kg.℃))、饱和水比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "T2L", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2L(out double P, double T, out double H, out double S, out double V, out double X, out long Range);
        
        // 已知温度(℃)，求饱和汽比焓(kJ/kg)、饱和汽比熵(kJ/(kg.℃))、饱和汽比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "T2G", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2G(out double P, double T, out double H, out double S, out double V, out double X, out long Range);
        
        // 已知温度(℃)，求饱和水定压比热(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "T2CPL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2CPL(double T, out double CP, out long Range);
        
        // 已知温度(℃)，求饱和汽定压比热(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "T2CPG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2CPG(double T, out double CP, out long Range);
        
        // 已知温度(℃)，求饱和水定容比热(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "T2CVL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2CVL(double T, out double CV, out long Range);
        
        // 已知温度(℃)，求饱和汽定容比热(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "T2CVG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2CVG(double T, out double CV, out long Range);
        
        // 已知温度(℃)，求饱和水内能(kJ/kg)
        [DllImport("UEwasp.dll", EntryPoint = "T2EL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2EL(double T, out double E, out long Range);
       
        // 已知温度(℃)，求饱和汽内能(kJ/kg)
        [DllImport("UEwasp.dll", EntryPoint = "T2EG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2EG(double T, out double E, out long Range);
        
        // 已知温度(℃)，求饱和水音速(m/s)
        [DllImport("UEwasp.dll", EntryPoint = "T2SSPL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2SSPL(double T, out double SSP, out long Range);
        
        // 已知温度(℃)，求饱和汽音速(m/s)
        [DllImport("UEwasp.dll", EntryPoint = "T2SSPG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2SSPG(double T, out double SSP, out long Range);
        
        // 已知温度(℃)，求饱和水定熵指数
        [DllImport("UEwasp.dll", EntryPoint = "T2KSL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2KSL(double T, out double KS, out long Range);
        
        // 已知温度(℃)，求饱和汽定熵指数
        [DllImport("UEwasp.dll", EntryPoint = "T2KSG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2KSG(double T, out double KS, out long Range);
        
        // 已知温度(℃)，求饱和水动力粘度(Pa.s)
        [DllImport("UEwasp.dll", EntryPoint = "T2ETAL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2ETAL(double T, out double ETA, out long Range);
        
        // 已知温度(℃)，求饱和汽动力粘度(Pa.s)
        [DllImport("UEwasp.dll", EntryPoint = "T2ETAG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2ETAG(double T, out double ETA, out long Range);
        
        // 已知温度(℃)，求饱和水运动粘度(m^2/s)
        [DllImport("UEwasp.dll", EntryPoint = "T2UL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2UL(double T, out double U, out long Range);
        
        // 已知温度(℃)，求饱和汽运动粘度(m^2/s)
        [DllImport("UEwasp.dll", EntryPoint = "T2UG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2UG(double T, out double U, out long Range);
        
        // 已知温度(℃)，求饱和水导热系数(W/(m.℃))
        [DllImport("UEwasp.dll", EntryPoint = "T2RAMDL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2RAMDL(double T, out double RAMD, out long Range);
        
        // 已知温度(℃)，求饱和汽导热系数(W/(m.℃))
        [DllImport("UEwasp.dll", EntryPoint = "T2RAMDG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2RAMDG(double T, out double RAMD, out long Range);
        
        // 已知温度(℃)，求饱和水普朗特数
        [DllImport("UEwasp.dll", EntryPoint = "T2PRNL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2PRNL(double T, out double PRN, out long Range);
        
        // 已知温度(℃)，求饱和汽普朗特数
        [DllImport("UEwasp.dll", EntryPoint = "T2PRNG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2PRNG(double T, out double PRN, out long Range);
        
        // 已知温度(℃)，求饱和水介电常数
        [DllImport("UEwasp.dll", EntryPoint = "T2EPSL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2EPSL(double T, out double EPS, out long Range);
        
        // 已知温度(℃)，求饱和汽介电常数
        [DllImport("UEwasp.dll", EntryPoint = "T2EPSG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2EPSG(double T, out double EPS, out long Range);
        
        // 已知温度(℃)，求饱和水折射率
        [DllImport("UEwasp.dll", EntryPoint = "T2NL", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2NL(double T, double Lanm, out double N, out long Range);
        
        // 已知温度(℃)，求饱和汽折射率
        [DllImport("UEwasp.dll", EntryPoint = "T2NG", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2NG(double T, double Lanm, out double N, out long Range);
        
        // 已知温度(℃)，求饱和水表面张力(N/m)
        [DllImport("UEwasp.dll", EntryPoint = "T2SURFT", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void T2SURFT(double T, out double SurfT, out long Range);

        // 已知温度(℃)和比焓(kJ/kg)，求压力(MPa)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TH2PLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TH2PLP(double T, double H, out double P, out long Range);
        
        // 已知温度(℃)和比焓(kJ/kg)，求压力(MPa)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TH2PHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TH2PHP(double T, double H, out double P, out long Range);
        
        // 已知温度(℃)和比焓(kJ/kg)，求压力(MPa)(缺省为低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TH2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TH2P(double T, double H, out double P, out long Range);
        
        // 已知温度(℃)和比焓(kJ/kg)，求比熵(kJ/(kg.℃))(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TH2SLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TH2SLP(double T, double H, out double S, out long Range);
        
        // 已知温度(℃)和比焓(kJ/kg)，求比熵(kJ/(kg.℃))(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TH2SHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TH2SHP(double T, double H, out double S, out long Range);
        
        // 已知温度(℃)和比焓(kJ/kg)，求比熵(kJ/(kg.℃))(缺省为低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TH2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TH2S(double T, double H, out double S, out long Range);
        
        // 已知温度(℃)和比焓(kJ/kg)，求比容(m^3/kg)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TH2VLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TH2VLP(double T, double H, out double V, out long Range);
        
        // 已知温度(℃)和比焓(kJ/kg)，求比容(m^3/kg)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TH2VHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TH2VHP(double T, double H, out double V, out long Range);
        
        // 已知温度(℃)和比焓(kJ/kg)，求比容(m^3/kg)(缺省为低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TH2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TH2V(double T, double H, out double V, out long Range);
        
        // 已知温度(℃)和比焓(kJ/kg)，求干度(100%)
        [DllImport("UEwasp.dll", EntryPoint = "TH2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TH2X(double T, double H, out double X, out long Range);
        
        // 已知温度(℃)和比焓(kJ/kg)，求压力(MPa)、比熵(kJ/(kg.℃))、比容(m^3/kg)、干度(100%)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "THLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void THLP(out double P, double T, double H, out double S, out double V, out double X, out long Range);
        
        // 已知温度(℃)和比焓(kJ/kg)，求压力(MPa)、比熵(kJ/(kg.℃))、比容(m^3/kg)、干度(100%)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "THHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void THHP(out double P, double T, double H, out double S, out double V, out double X, out long Range);
        
        // 已知温度(℃)和比焓(kJ/kg)，求压力(MPa)、比熵(kJ/(kg.℃))、比容(m^3/kg)、干度(100%)(缺省为低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TH", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TH(out double P, double T, double H, out double S, out double V, out double X, out long Range);

        // 已知温度(℃)和比熵(kJ/(kg.℃))，求压力(MPa)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TS2PLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TS2PLP(double T, double S, out double P, out long Range);
        
        // 已知温度(℃)和比熵(kJ/(kg.℃))，求压力(MPa)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TS2PHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TS2PHP(double T, double S, out double P, out long Range);
        
        // 已知温度(℃)和比熵(kJ/(kg.℃))，求压力(MPa)(缺省为低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TS2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TS2P(double T, double S, out double P, out long Range);
        
        // 已知温度(℃)和比熵(kJ/(kg.℃))，求比焓(kJ/kg)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TS2HLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TS2HLP(double T, double S, out double H, out long Range);
        
        // 已知温度(℃)和比熵(kJ/(kg.℃))，求比焓(kJ/kg)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TS2HHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TS2HHP(double T, double S, out double H, out long Range);
        
        // 已知温度(℃)和比熵(kJ/(kg.℃))，求比焓(kJ/kg)(缺省为低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TS2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TS2H(double T, double S, out double H, out long Range);
        
        // 已知温度(℃)和比熵(kJ/(kg.℃))，求比容(m^3/kg)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TS2VLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TS2VLP(double T, double S, out double V, out long Range);
        
        // 已知温度(℃)和比熵(kJ/(kg.℃))，求比容(m^3/kg)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TS2VHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TS2VHP(double T, double S, out double V, out long Range);
        
        // 已知温度(℃)和比熵(kJ/(kg.℃))，求比容(m^3/kg)(缺省为低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TS2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TS2V(double T, double S, out double V, out long Range);
        
        // 已知温度(℃)和比熵(kJ/(kg.℃))，求干度(100%)
        [DllImport("UEwasp.dll", EntryPoint = "TS2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TS2X(double T, double S, out double X, out long Range);
        
        // 已知温度(℃)和比熵(kJ/(kg.℃))，求压力(MPa)、比焓(kJ/kg)、比容(m^3/kg)、干度(100%)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TSLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TSLP(out double P, double T, out double H, double S, out double V, out double X, out long Range);
        
        // 已知温度(℃)和比熵(kJ/(kg.℃))，求压力(MPa)、比焓(kJ/kg)、比容(m^3/kg)、干度(100%)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TSHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TSHP(out double P, double T, out double H, double S, out double V, out double X, out long Range);
        
        // 已知温度(℃)和比熵(kJ/(kg.℃))，求压力(MPa)、比焓(kJ/kg)、比容(m^3/kg)、干度(100%)(缺省为低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "TS", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TS(out double P, double T, out double H, double S, out double V, out double X, out long Range);

        // 已知温度(℃)和比容(m^3/kg)，求压力(MPa)
        [DllImport("UEwasp.dll", EntryPoint = "TV2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TV2P(double T, double V, out double P, out long Range);
        
        // 已知温度(℃)和比容(m^3/kg)，求比焓(kJ/kg)
        [DllImport("UEwasp.dll", EntryPoint = "TV2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TV2H(double T, double V, out double H, out long Range);
        
        // 已知温度(℃)和比容(m^3/kg)，求比熵(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "TV2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TV2S(double T, double V, out double S, out long Range);
        
        // 已知温度(℃)和比容(m^3/kg)，求干度(100%)
        [DllImport("UEwasp.dll", EntryPoint = "TV2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TV2X(double T, double V, out double X, out long Range);
        
        // 已知温度(℃)和比容(m^3/kg)，求压力(MPa)、比焓(kJ/kg)、比熵(kJ/(kg.℃))、干度(100%)
        [DllImport("UEwasp.dll", EntryPoint = "TV", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TV(out double P, double T, out double H, out double S, double V, out double X, out long Range);

        
        // 已知温度(℃)和干度(100%)，求压力(MPa)
        [DllImport("UEwasp.dll", EntryPoint = "TX2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TX2P(double T, double X, out double P, out long Range);
        
        // 已知温度(℃)和干度(100%)，求比焓(kJ/kg)
        [DllImport("UEwasp.dll", EntryPoint = "TX2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TX2H(double T, double X, out double H, out long Range);
        
        // 已知温度(℃)和干度(100%)，求比熵(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "TX2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TX2S(double T, double X, out double S, out long Range);
        
        // 已知温度(℃)和干度(100%)，求比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "TX2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TX2V(double T, double X, out double V, out long Range);
        
        // 已知温度(℃)和干度(100%)，求压力(MPa)、比焓(kJ/kg)、比熵(kJ/(kg.℃))、比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "TX", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void TX(out double P, double T, out double H, out double S, out double V, double X, out long Range);

        // 已知比焓(kJ/kg)和比熵(kJ/(kg.℃))，求压力(MPa)
        [DllImport("UEwasp.dll", EntryPoint = "HS2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HS2P(double H, double S, out double P, out long Range);
        
        // 已知比焓(kJ/kg)和比熵(kJ/(kg.℃))，求温度(℃)
        [DllImport("UEwasp.dll", EntryPoint = "HS2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HS2T(double H, double S, out double T, out long Range);
        
        // 已知比焓(kJ/kg)和比熵(kJ/(kg.℃))，求比容(m^3/kg)
        [DllImport("UEwasp.dll", EntryPoint = "HS2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HS2V(double H, double S, out double V, out long Range);
        
        // 已知比焓(kJ/kg)和比熵(kJ/(kg.℃))，求干度(100%)
        [DllImport("UEwasp.dll", EntryPoint = "HS2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HS2X(double H, double S, out double X, out long Range);
        
        // 已知比焓(kJ/kg)和比熵(kJ/(kg.℃))，求压力(MPa)、温度(℃)、比容(m^3/kg)、干度(100%)
        [DllImport("UEwasp.dll", EntryPoint = "HS", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HS(out double P, out double T, double H, double S, out double V, out double X, out long Range);

        // 已知比焓(kJ/kg)和比容(m^3/kg)，求压力(MPa)
        [DllImport("UEwasp.dll", EntryPoint = "HV2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HV2P(double H, double V, out double P, out long Range);
        
        // 已知比焓(kJ/kg)和比容(m^3/kg)，求温度(℃)
        [DllImport("UEwasp.dll", EntryPoint = "HV2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HV2T(double H, double V, out double T, out long Range);
        
        // 已知比焓(kJ/kg)和比容(m^3/kg)，求比熵(kJ/(kg.℃))
        [DllImport("UEwasp.dll", EntryPoint = "HV2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HV2S(double H, double V, out double S, out long Range);
        
        // 已知比焓(kJ/kg)和比容(m^3/kg)，求干度(100%)
        [DllImport("UEwasp.dll", EntryPoint = "HV2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HV2X(double H, double V, out double X, out long Range);
        
        // 已知比焓(kJ/kg)和比容(m^3/kg)，求压力(MPa)、温度(℃)、比熵(kJ/(kg.℃))、干度(100%)
        [DllImport("UEwasp.dll", EntryPoint = "HV", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HV(out double P, out double T, double H, out double S, double V, out double X, out long Range);

        // 已知比焓(kJ/kg)和干度(100%)，求压力(MPa)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "HX2PLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HX2PLP(double H, double X, out double P, out long Range);
        
        // 已知比焓(kJ/kg)和干度(100%)，求压力(MPa)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "HX2PHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HX2PHP(double H, double X, out double P, out long Range);
        
        // 已知比焓(kJ/kg)和干度(100%)，求压力(MPa)(缺省是低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "HX2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HX2P(double H, double X, out double P, out long Range);
        
        // 已知比焓(kJ/kg)和干度(100%)，求温度(℃)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "HX2TLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HX2TLP(double H, double X, out double T, out long Range);
        
        // 已知比焓(kJ/kg)和干度(100%)，求温度(℃)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "HX2THP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HX2THP(double H, double X, out double T, out long Range);
        
        // 已知比焓(kJ/kg)和干度(100%)，求温度(℃)(缺省是低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "HX2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HX2T(double H, double X, out double T, out long Range);
        
        // 已知比焓(kJ/kg)和干度(100%)，求比熵(kJ/(kg.℃))(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "HX2SLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HX2SLP(double H, double X, out double S, out long Range);
        
        // 已知比焓(kJ/kg)和干度(100%)，求比熵(kJ/(kg.℃))(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "HX2SHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HX2SHP(double H, double X, out double S, out long Range);
        
        // 已知比焓(kJ/kg)和干度(100%)，求比熵(kJ/(kg.℃))(缺省是低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "HX2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HX2S(double H, double X, out double S, out long Range);
        
        // 已知比焓(kJ/kg)和干度(100%)，求比容(m^3/kg)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "HX2VLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HX2VLP(double H, double X, out double V, out long Range);
        
        // 已知比焓(kJ/kg)和干度(100%)，求比容(m^3/kg)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "HX2VHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HX2VHP(double H, double X, out double V, out long Range);
        
        // 已知比焓(kJ/kg)和干度(100%)，求比容(m^3/kg)(缺省是低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "HX2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HX2V(double H, double X, out double V, out long Range);
        
        // 已知比焓(kJ/kg)和干度(100%)，求压力(MPa)、温度(℃)、比熵(kJ/(kg.℃))、比容(m^3/kg)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "HXLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HXLP(out double P, out double T, double H, out double S, out double V, double X, out long Range);

        // 已知比焓(kJ/kg)和干度(100%)，求压力(MPa)、温度(℃)、比熵(kJ/(kg.℃))、比容(m^3/kg)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "HXHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HXHP(out double P, out double T, double H, out double S, out double V, double X, out long Range);
       
        
        // 已知比焓(kJ/kg)和干度(100%)，求压力(MPa)、温度(℃)、比熵(kJ/(kg.℃))、比容(m^3/kg)(缺省是低压的一个值)
        // Procedure HX97(Var P,T:Double;Const H:Double;Var S,V:Double;Const X:Double;Var Range:Integer);StdCall;
        [DllImport("UEwasp.dll", EntryPoint = "HX", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void HX(out double P, out double T, double H, out double S, out double V, double X, out long Range);


        // 已知比熵(kJ/(kg.℃))和比容(m^3/kg)，求压力(MPa)
        [DllImport("UEwasp.dll", EntryPoint = "SV2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SV2P(double S, double V, out double P, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和比容(m^3/kg)，求温度(℃)
        [DllImport("UEwasp.dll", EntryPoint = "SV2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SV2T(double S, double V, out double T, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和比容(m^3/kg)，求比焓(kJ/kg)
        [DllImport("UEwasp.dll", EntryPoint = "SV2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SV2H(double S, double V, out double H, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和比容(m^3/kg)，求干度(100%)
        [DllImport("UEwasp.dll", EntryPoint = "SV2X", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SV2X(double S, double V, out double X, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和比容(m^3/kg)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、干度(100%)
        [DllImport("UEwasp.dll", EntryPoint = "SV", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SV(out double P, out double T, out double H, double S, double V, out double X, out long Range);

        // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2PLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2PLP(double S, double X, out double P, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)(中压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2PMP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2PMP(double S, double X, out double P, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2PHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2PHP(double S, double X, out double P, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)(缺省是低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2P(double S, double X, out double P, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求温度(℃)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2TLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2TLP(double S, double X, out double T, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求温度(℃)(中压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2TMP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2TMP(double S, double X, out double T, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求温度(℃)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2THP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2THP(double S, double X, out double T, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求温度(℃)(缺省是低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2T(double S, double X, out double T, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求比焓(kJ/kg)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2HLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2HLP(double S, double X, out double H, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求比焓(kJ/kg)(中压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2HMP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2HMP(double S, double X, out double H, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求比焓(kJ/kg)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2HHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2HHP(double S, double X, out double H, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求比焓(kJ/kg)(缺省是低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2H(double S, double X, out double H, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求比容(m^3/kg)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2VLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2VLP(double S, double X, out double V, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求比容(m^3/kg)(中压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2VMP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2VMP(double S, double X, out double V, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求比容(m^3/kg)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2VHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2VHP(double S, double X, out double V, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求比容(m^3/kg)(缺省是低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX2V", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX2V(double S, double X, out double V, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、比容(m^3/kg)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SXLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SXLP(out double P, out double T, out double H, double S, out double V, double X, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、比容(m^3/kg)(中压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SXMP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SXMP(out double P, out double T, out double H, double S, out double V, double X, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、比容(m^3/kg)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SXHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SXHP(out double P, out double T, out double H, double S, out double V, double X, out long Range);
        
        // 已知比熵(kJ/(kg.℃))和干度(100%)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、比容(m^3/kg)(缺省是低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "SX", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void SX(out double P, out double T, out double H, double S, out double V, double X, out long Range);

        // 已知比容(m^3/kg)和干度(100%)，求压力(MPa)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VX2PLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VX2PLP(double V, double X, out double P, out long Range);
        
        // 已知比容(m^3/kg)和干度(100%)，求压力(MPa)(低高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VX2PHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VX2PHP(double V, double X, out double P, out long Range);
        
        // 已知比容(m^3/kg)和干度(100%)，求压力(MPa)(缺省是低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VX2P", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VX2P(double V, double X, out double P, out long Range);
        
        // 已知比容(m^3/kg)和干度(100%)，求温度(℃)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VX2TLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VX2TLP(double V, double X, out double T, out long Range);
        
        // 已知比容(m^3/kg)和干度(100%)，求温度(℃)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VX2THP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VX2THP(double V, double X, out double T, out long Range);
        
        // 已知比容(m^3/kg)和干度(100%)，求温度(℃)(缺省是低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VX2T", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VX2T(double V, double X, out double T, out long Range);
        
        // 已知比容(m^3/kg)和干度(100%)，求比焓(kJ/kg)(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VX2HLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VX2HLP(double V, double X, out double H, out long Range);
        
        // 已知比容(m^3/kg)和干度(100%)，求比焓(kJ/kg)(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VX2HHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VX2HHP(double V, double X, out double H, out long Range);
        
        // 已知比容(m^3/kg)和干度(100%)，求比焓(kJ/kg)(缺省是低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VX2H", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VX2H(double V, double X, out double H, out long Range);
        
        // 已知比容(m^3/kg)和干度(100%)，求比熵(kJ/(kg.℃))(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VX2SLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VX2SLP(double V, double X, out double S, out long Range);
        
        // 已知比容(m^3/kg)和干度(100%)，求比熵(kJ/(kg.℃))(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VX2SHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VX2SHP(double V, double X, out double S, out long Range);
        
        // 已知比容(m^3/kg)和干度(100%)，求比熵(kJ/(kg.℃))(缺省是低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VX2S", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VX2S(double V, double X, out double S, out long Range);
        
        // 已知比容(m^3/kg)和干度(100%)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、比熵(kJ/(kg.℃))(低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VXLP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VXLP(out double P, out double T, out double H, out double S, double V, double X, out long Range);
        
        // 已知比容(m^3/kg)和干度(100%)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、比熵(kJ/(kg.℃))(高压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VXHP", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VXHP(out double P, out double T, out double H, out double S, double V, double X, out long Range);
        
        // 已知比容(m^3/kg)和干度(100%)，求压力(MPa)、温度(℃)、比焓(kJ/kg)、比熵(kJ/(kg.℃))(缺省是低压的一个值)
        [DllImport("UEwasp.dll", EntryPoint = "VX", CharSet = CharSet.Ansi, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void VX(out double P, out double T, out double H, out double S, double V, double X, out long Range);

    }
}
