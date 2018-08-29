// --------------------------------------
// 完全以IAPWS提供的公式（基本和补充）完成
// 四种自变量组合下的7种性质计算
// 1   (p.t)->v,u,s,h,cp.cv,w
//
// 2   (p,h)->T->(p.t)->(p.t)->v,u,s,h,cp.cv,w
// 3   (p,s)->T->(p.t)->(p.t)->v,u,s,h,cp.cv,w
//
// 4   (h,s)->p-(P,H)->T->(p.t)->v,u,s,h,cp.cv,w
//       ? 需要比较下 (h,s)->p-(P,S)->T->(p.t)->v,u,s,h,cp.cv,w 那个更好
//  2009.11.1 By Cheng Maohua 
//---------------------------------------
using System;

namespace IAPWS.IF97
{
    public static class R1
    {
        public static double pt(double p, double t, string pws)
        {
            double r = -1000;
            double T = t + 273.15;
            if (pws.Trim() == "v") r = R1PT.vreg1(T, p);
            if (pws.Trim() == "u") r = R1PT.ureg1(T, p);
            if (pws.Trim() == "h") r = R1PT.hreg1(T, p);
            if (pws.Trim() == "s") r = R1PT.sreg1(T, p);
            if (pws.Trim() == "cv") r = R1PT.cvreg1(T, p);
            if (pws.Trim() == "cp") r = R1PT.cpreg1(T, p);
            if (pws.Trim() == "w") r = R1PT.wreg1(T, p);
            return (r);
        }

        public static double ph(double p, double h, string pws)
        {
            double r = -1000;
            double t = R1PHPS.phtoTreg1(p, h) - 273.15;
            r = pt(p, t, pws);
            return (r);
        }

        public static double ps(double p, double s, string pws)
        {
            double r = -1000;
            double t = R1PHPS.pstoTreg1(p, s) - 273.15;
            r = pt(p, t, pws);
            return (r);
        }

        public static double hs(double h, double s, string pws)
        {
            double r = -1000;
            double p = R1HS.hstopreg1(h, s);
            //  Liquid Region 1
            //For calculating the temperature T from given specific enthalpy h and entropy s for region 1,
            //the following steps should be made:
            //First, the pressure p is calculated using the equation p1(h,s), Eq. (1).
            //Second, the temperature T can be calculated using the IAPWS-IF97 equation 97 ( , )
            //T1 p h
            //(see Fig. 1), where p is the pressure previously calculated.
            //Vapor Region
            r = ph(p, h, pws);
            return (r);
        }
    }
}
