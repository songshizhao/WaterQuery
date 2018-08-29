//---------------------------------------------------------------------------
// IAPWS -IF 97 Backware Equation for Region 1:
// September 2001
// Supplementary Release on Backward Equations for Pressure as a Function of
// Enthalpy and Entropy p(h,s) to the IAPWS Industrial Formulation 1997 for the
// Thermodynamic Properties of Water and Steam 
//  (H,S)->P
//   Last updated: 2009.11.01 By Maohua Cheng
//---------------------------------------------------------------------------

using System;


namespace IAPWS.IF97
{
    internal static class R1HS
    {
        //---------------------------------------------------------------
        // sep 2001,phs.pdf Page 5, Table 2 :
        // Dimensionless form Backward equation P(h,s) for region 1
        //----------------------------------------------------------------
        private static double piHS(double eta, double sigma)
        {
            // Initialize coefficients and exponents (H,S)->P for region 1
            int[] i = new int[19]{ 0, 0, 0, 0, 0,
                            		0, 0, 0, 1, 1,
                            		1, 1, 2, 2, 2,
                            		3, 4, 4, 5};

            int[] j = new int[19]{  0,  1,  2,  4, 5,
                            		6,  8, 14,  0, 1,
                            		4,  6,  0,  1, 10,
                            		4,  1,  4,  0};

            double[] n = new double[19]{ -0.691997014660582,
                                		-0.183612548787560E+02,
                                		-0.928332409297335E+01,
                                		0.659639569909906E+02,
                                		-0.162060388912024E+02,

                                		0.450620017338667E+03,
                                		0.854680678224170E+03,
                                		0.607523214001162E+04,
                                		0.326487682621856E+02,
                                		-0.269408844582931E+02,

                                		-0.319947848334300E+03,
                                		-0.928354307043320E+03,
                                		0.303634537455249E+02,
                                		-0.650540422444146E+02,
                                		-0.430991316516130E+04,

                                		-0.747512324096068E+03,
                                		0.730000345529245E+03,
                                		0.114284032569021E+04,
                                		-0.436407041874559E+03};
            double pi;
            eta = eta + 0.05;
            sigma = sigma + 0.05;
            pi = 0.0;
            for (int k = 0; k < 19; k++)
                pi += n[k] * Math.Pow(eta, i[k]) * Math.Pow(sigma, j[k]);
            return pi;
        }

        internal static double hstopreg1(double h, double s)
        {
            double eta, sigma;
            eta = h / 3400.0;
            sigma = s / 7.6;
            return (100.0 * piHS(eta, sigma));
        }

    }
}
