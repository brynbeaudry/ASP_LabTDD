using System;
using CompoundInterestLibrary;
using Xunit;

namespace CompoundInterestTests
{

    /* 
        2) negative time throw exception
        3) divide by zero exception when n=0
        4) negative n throw exception
        5) P = 5000. r = 5/100 = 0.05 (decimal). n = 12. t = 10
        6) negative principal throw exception
    */


    public class CompoundInterestTests
    {
        [Fact]
        public void Principal0Amount0()
        {
            CompoundInterest c = new CompoundInterest{
                Principal = 0,
                Amount = 0,

            };  
            string actual = c.CalculateAmount();
            string expected = "0.00";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void NegativeTimeThrowException()
        {
            CompoundInterest c = new CompoundInterest{
                Years = -1
            };
            Exception ex = Assert.Throws<Exception>(
				() => c.CalculateAmount()
			);
            string actual = ex.Message;
            string expected = "Time in Years cannot be negative";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void NumberOfTimesCompoundedZeroThrowsDivideByZeroException()
        {
            CompoundInterest c = new CompoundInterest{
                NumberOfTimesCompoundedPerYear = 0
            };
            Exception ex = Assert.Throws<DivideByZeroException>(
				() => c.CalculateAmount()
			);
            string actual = ex.Message;
            string expected = new DivideByZeroException().Message;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void P_5000_R_5div100_N_12_T_10_Equals_8235_05()
        {
            CompoundInterest c = new CompoundInterest{
                Principal = 5000,
                InterestRate = 0.05,
                NumberOfTimesCompoundedPerYear = 12,
                Years = 10
            };
            string actual = c.CalculateAmount();
            string expected = "8235.05";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NegativePrincipalThrowException()
        {
            CompoundInterest c = new CompoundInterest{
                Principal = -1
            };
            Exception ex = Assert.Throws<Exception>(
				() => c.CalculateAmount()
			);
            string actual = ex.Message;
            string expected = "Principal Cannot Be Negative";
            Assert.Equal(expected, actual);
        }
    }
}
