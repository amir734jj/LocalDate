using LocalDate.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using LocalDate.Enums;

namespace LocalDate.Models
{
    public class LocalDateStruct: ILocalDateStruct
    {
        [Range(1, 9999)]
        public int Year { get; }

        [Range(1, 12)]
        public int Month { get; }

        [Range(1, 31)]
        public int Day { get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected LocalDateStruct(): this(1, 1, 1) { } 
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        protected LocalDateStruct(int year, int month, int day)
        {
            // Validate Date properties
            Year = year;
            Month = month;
            Day = day;
        }
         
        /// <summary>
        /// ToString override
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Enum.GetName(typeof(MonthEnum), Month)} {Day}, {Year}";
        }

        /// <summary>
        /// Equality check implementation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            
            if (!(obj is LocalDateStruct localDateStruct))
            {
                return false;
            }

            return Day == localDateStruct.Day && Month == localDateStruct.Month && Year == localDateStruct.Year;
        }

        /// <summary>
        /// HashCode implementation
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            const int prime = 31;
            var result = 1;
            result = prime * result + Year * 1000;
            result = prime * result + Month * 100;
            result = prime * result + Day * 1;
            return result;
        }
    }
}
