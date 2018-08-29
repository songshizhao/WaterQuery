//---------------------------------------------------------------------------
//  IAPWS IF97 Basic Equation for Region 1:
//  IAPWS IF97-revised version August 2007, P6-9
//      The basic equation for this region is a fundamental equation for the specific
//  Gibbs free energy g.Eq(7). This equation is expressed in dimensionless form: g/(RT)
//    
//      Equation (7) covers region 1 of IAPWS-IF97 defined by the following range of
//  temperature and pressure
//         273.15 K ¡Ü T ¡Ü 623.15 K ps ( T ) ¡Ü p ¡Ü 100 MPa
 
//    In addition to the properties in the stable single-phase liquid region, Eq.(7) also yields
// reasonable values in the metastable superheated-liquid region close to the saturated liquid line.
// Note: For temperatures between 273.15 K and 273.16 K at pressures below the melting pressure [10]
// (metastablestates) all values are calculated by extrapolation from Eqs.(7) and (30). 
      
//      (p.t)->v,u,s,h,cp.cv,w
//       p in MPa,t in K, 
   
//  Last updated: 2009.11. By Maohua Cheng
//  If you have any comments and suggestion .please email: cmhnj@hotmail.com
//--------------------------------------------------------------------------
using System;

namespace IAPWS.IF97
{
    internal static class R1PT
    {
        // Reference Constants P5
        private const double rgas_water = 0.461526;   // (1) gas constant in KJ/(kg K)
        private const double tc_water = 647.096;     //  (2) critical temperature in K
        private const double pc_water = 22.064;      //  (3) critical p in Mpa
        private const double dc_water = 322.0;       //  (4) critical density in kg/m**3
        
        //p6
        const double r1Ps = 16.53;	//[MPa]	Release
        const double r1Ts = 1386.0;	//[K]	Release
        
        //  P7 Table 2: Numerical values of the coefficients and exponents of 
        //              the dimensionless Gibbs free energy for region 1, Eq.(7)
        private static int[] i = new int[34]{ 0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
                                           1, 1, 1, 1, 2, 2, 2, 2, 2, 3,
                                           3, 3, 4, 4, 4, 5, 8, 8,21,23,
                                          29,30,31,32};

        private static int[] j = new int[34]{ -2, -1,  0,  1,  2,
                                            3,  4,  5, -9, -7,
                                           -1,  0,  1,  3, -3,
                                            0,  1,  3, 17, -4,
                                            0,  6, -5, -2, 10,
                                           -8,-11, -6,-29,-31,
                                          -38,-39,-40,-41};

        private static double[] n = new double[34]{  0.14632971213167,
                            -0.84548187169114,
                            -3.756360367204,
                             3.3855169168385,
                            -0.95791963387872,

                             0.15772038513228,
                            -0.016616417199501,
                             8.1214629983568E-04,
                             2.8319080123804E-04,
                            -6.0706301565874E-04,

                            -0.018990068218419,
                            -0.032529748770505,
                            -0.021841717175414,
                            -5.283835796993E-05,
                            -4.7184321073267E-04,

                            -3.0001780793026E-04,
                             4.7661393906987E-05,
                            -4.4141845330846E-06,
                            -7.2694996297594E-16,
                            -3.1679644845054E-05,

                            -2.8270797985312E-06,
                            -8.5205128120103E-10,
                            -2.2425281908E-06,
                            -6.5171222895601E-07,
                            -1.4341729937924E-13,

                            -4.0516996860117E-07,
                            -1.2734301741641E-09,
                            -1.7424871230634E-10,
                            -6.8762131295531E-19,
                             1.4478307828521E-20,

                             2.6335781662795E-23,
                            -1.1947622640071E-23,
                             1.8228094581404E-24,
                            -9.3537087292458E-26};

        // P8, Table 4 The dimensionless Gibbs free energy gamma and its derivatives according to Eq.(7)
        #region  Table4
        private static double gammareg1(double tau, double pi)
        // The dimensionless Gibbs free energy gamma  for region 1
        {
            double r = 0.0;
            tau = tau - 1.222;
            pi = 7.1 - pi;
            for (int k = 0; k <= 33; k++)
                r += n[k] * Math.Pow(pi, i[k]) * Math.Pow(tau, j[k]);
            return r;
        }

        private static double gammapireg1(double tau, double pi)
        // First derivative of fundamental equation in pi for region 1
        {
            double r = 0.0;
            tau = tau - 1.222;
            pi = 7.1 - pi;
            for (int k = 0; k <= 33; k++)
                r -= n[k] * i[k] * Math.Pow(pi, i[k] - 1) * Math.Pow(tau, j[k]);
            return r;
        }

        private static double gammapipireg1(double tau, double pi)
        // Second derivative of fundamental equation in pi for region 1
        {
            double r = 0.0;
            tau = tau - 1.222;
            pi = 7.1 - pi;
            for (int k = 0; k <= 33; k++)
                r += n[k] * i[k] * (i[k] - 1) * Math.Pow(pi, i[k] - 2) * Math.Pow(tau, j[k]);
            return r;
        }

        private static double gammataureg1(double tau, double pi)
        // First derivative of fundamental equation in tau for region 1
        {
            double r = 0.0;
            tau = tau - 1.222;
            pi = 7.1 - pi;
            for (int k = 0; k <= 33; k++)
                r += n[k] * Math.Pow(pi, i[k]) * j[k] * Math.Pow(tau, j[k] - 1);
            return r;
        }

        private static double gammatautaureg1(double tau, double pi)
        // Second derivative of fundamental equation in tau for region 1
        {
            double r = 0.0;
            tau = tau - 1.222;
            pi = 7.1 - pi;
            for (int k = 0; k <= 33; k++)
                r += n[k] * Math.Pow(pi, i[k]) * j[k] * (j[k] - 1) * Math.Pow(tau, j[k] - 2);
            return r;
        }

        private static double gammapitaureg1(double tau, double pi)
        // Second derivative of fundamental equation in pi and tau for region 1
        {
            double r = 0.0;
            tau = tau - 1.222;
            pi = 7.1 - pi;
            for (int k = 0; k <= 33; k++)
                r -= n[k] * i[k] * Math.Pow(pi, i[k] - 1) * j[k] * Math.Pow(tau, j[k] - 1);
            return r;
        }

        #endregion Table4

        #region  Table3


        // P8, Table 3: Relations of thermodynamic properties to the dimensionless Gibbs
        //              free energy  and its derivatives when using Eq.(7)
        internal static double vreg1(double t, double p)
        // specific volume in region 1
        {
            double tau = r1Ts / t;
            double pi = p / r1Ps;
            return 0.001 * rgas_water * t * pi * gammapireg1(tau, pi) / p;
        }

        internal static double ureg1(double t, double p)
        // specific internal energy in region 1
        {
            double tau = r1Ts / t;
            double pi = p / r1Ps;
            return rgas_water * t * (tau * gammataureg1(tau, pi) - pi * gammapireg1(tau, pi));
        }

        internal static double sreg1(double t, double p)
        // specific entropy in region 1
        {
            double tau = r1Ts / t;
            double pi = p / r1Ps;
            return rgas_water * (tau * gammataureg1(tau, pi) - gammareg1(tau, pi));
        }

        internal static double hreg1(double t, double p)
        // specific enthalpy in region 1
        {
            double tau = r1Ts / t;
            double pi = p / r1Ps;
            return rgas_water * t * tau * gammataureg1(tau, pi);
        }

        internal static double cpreg1(double t, double p)
        // specific isobaric heat capacity in region 1
        {
            double tau = r1Ts / t;
            double pi = p / r1Ps;
            return -rgas_water * tau * tau * gammatautaureg1(tau, pi);
        }

        internal static double cvreg1(double t, double p)
        // specific isochoric heat capacity in region 1
        // cvreg1 in kJ/(kg K),t in K, p in MPa
        {
            double a, b;
            double tau = r1Ts / t;
            double pi = p / r1Ps;
            a = -tau * tau * gammatautaureg1(tau, pi);
            b = gammapireg1(tau, pi) - tau * gammapitaureg1(tau, pi);
            b *= b;
            return rgas_water * (a + b / gammapipireg1(tau, pi));
        }

        internal static double wreg1(double t, double p)
        // speed of sound in region 1
        // spsoundreg1 in m/s, t in K, p in Mpa
        {
            double gammapi, a, b;
            double tau = r1Ts / t;
            double pi = p / r1Ps;
            gammapi = gammapireg1(tau, pi);
            a = gammapi - tau * gammapitaureg1(tau, pi);
            a *= a;
            b = a / (tau * tau * gammatautaureg1(tau, pi));
            b = b - gammapipireg1(tau, pi);
            return gammapi * Math.Sqrt(1000.0 * rgas_water * t / b);
        }
        #endregion Table3

    }
}
