//---------------------------------------------------------------------------
// IAPWS -IF 97 Backware Equation for Region 1:
// Ref: IAPWS IF97-revised version August 2007, P9-P
//  P10,Eq(11)  (P,H)->T
//  (P,S)->T   
// 
// Equation (11) covers the same range of validity as the basic equation, Eq. (7), except for
// the metastable region (superheated liquid), where Eq. (11) is not valid.
//
//   Last updated: 2009.11.01 By Maohua Cheng
//---------------------------------------------------------------------------

using System;

namespace IAPWS.IF97
{
    internal static class R1PHPS
    {
        //-------------------------------------------------------------
        // Page 10, Table6 :
        // Dimensionless form Backward equation T(p,h) for region 1
        //--------------------------------------------------------------
        //p10
        private const double Ps = 1.0;	//[MPa]	Release
        private const double Ts = 1.0;	//[K]	Release
        private const double hs = 2500.0;	//[kJ/kg]	Release
        //p11
        private const double ss = 1.0;	//[kJ/(kg.K)]	Release


        private static double thetaPHtoT(double pi, double eta)
        {
            // Initialize coefficients and exponents (P,H)->T for region 1
            int[] i = new int[20]{ 0, 0, 0, 0, 0,
                     0, 1, 1, 1, 1,
                     1, 1, 1, 2, 2,
                     3, 3, 4, 5, 6};

            int[] j = new int[20]{  0,  1,  2,  6, 22,
                     32,  0,  1,  2,  3,
                      4, 10, 32, 10, 32,
                     10, 32, 32, 32, 32};

            double[] n = new double[20]{ -0.23872489924521E+03,
                         0.40421188637945E+03,
                         0.11349746881718E+03,
                        -0.58457616048039E+01,
                        -0.15285482413140E-03,

                        -0.10866707695377E-05,
                        -0.13391744872602E+02,
                         0.43211039183559E+02,
                        -0.54010067170506E+02,
                         0.30535892203916E+02,

                        -0.65964749423638E+01,
                         0.93965400878363E-02,
                         0.11573647505340E-06,
                        -0.25858641282073E-04,
                        -0.40644363084799E-08,

                         0.66456186191635E-07,
                         0.80670734103027E-10,
                        -0.93477771213947E-12,
                         0.58265442020601E-14,
                        -0.15020185953503E-16};

            double theta;
            eta = eta + 1.0;
            theta = 0;
            for (int k = 0; k < 20; k++)
                theta += n[k] * Math.Pow(pi, i[k]) * Math.Pow(eta, j[k]);
            return theta;
        }

        internal static double phtoTreg1(double p, double h)
        {
            double pi, eta;
            pi = p / Ps;
            eta = h / hs;
            return (1.0 * thetaPHtoT(pi, eta));
        }

        //----------------------------------------------------------------
        // Page 12, Table 8 :
        // Dimensionless form Backward equation T(p,s) for region 1
        //----------------------------------------------------------------
        private static double thetaPStoT(double pi, double sigma)
        // Initialize coefficients and exponents (P,S)->T for region 1
        {
            int[] i = new int[20]{ 0, 0, 0, 0, 0,
                     0, 1, 1, 1, 1,
                     1, 1, 2, 2, 2,
                     2, 2, 3, 3, 4};

            int[] j = new int[20]{  0,  1,  2,  3, 11,
                            	  31,  0,  1,  2,  3,
                            	  12, 31,  0,  1,  2,
                            	  9, 31, 10, 32, 32};

            double[] n = new double[20]{ 0.17478268058307E+03,
                    	  0.34806930892873E+02,
                    	  0.65292584978455E+01,
                    	  0.33039981775489,
                    	  -0.19281382923196E-06,

                    	  -0.24909197244573E-22,
                    	  -0.26107636489332,
                    	  0.22592965981526,
                    	  -0.64256463395226E-01,
                    	  0.78876289270526E-02,

                    	  0.35672110607366E-9,
                    	  0.17332496994895E-23,
                    	  0.56608900654837E-03,
                    	  -0.32635483139717E-03,
                    	  0.44778286690632E-04,

                    	  -0.51322156908507E-9,
                    	  -0.42522657042207E-25,
                    	  0.26400441360689E-12,
                    	  0.78124600459723E-28,
                    	  -0.30732199903668E-30};

            double theta;
            sigma = sigma + 2.0;
            theta = 0.0;
            for (int k = 0; k < 20; k++)
                theta += n[k] * Math.Pow(pi, i[k]) * Math.Pow(sigma, j[k]);
            return theta;
        }

        internal static double pstoTreg1(double p, double s)
        {
            double pi, sigma;
            pi = p / Ps;
            sigma = s / ss;
            return (1.0 * thetaPStoT(pi, sigma));
        }
    }
}
