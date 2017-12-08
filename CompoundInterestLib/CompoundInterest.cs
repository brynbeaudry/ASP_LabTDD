using System;
using System.ComponentModel.DataAnnotations;

namespace CompoundInterestLibrary {
    public class CompoundInterest
    {
        
        public double Amount { get; set; } = 0;
          
        public double Principal { get; set; } = 0;
        
        public double InterestRate { get; set; } = 0;
        
        public double Years { get; set; } = 0;

        public double NumberOfTimesCompoundedPerYear { get; set; } = 1;

        
        public string CalculateAmount() 
        { 
            if (this.Years < 0)
				throw new Exception("Time in Years cannot be negative");
            if(this.NumberOfTimesCompoundedPerYear == 0)
                throw new DivideByZeroException();
            if(this.Principal < 0)
                throw new Exception("Principal Cannot Be Negative");

            this.Amount = Math.Round(this.Principal *  Math.Pow(1 + this.InterestRate / this.NumberOfTimesCompoundedPerYear , this.NumberOfTimesCompoundedPerYear * this.Years ), 2); 
            
            return this.Amount.ToString("#######0.00");
        }
        
    }


}