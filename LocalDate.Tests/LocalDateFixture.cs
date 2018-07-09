using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using AutoFixture;
using LocalDate.Utilities;

namespace LocalDate.Tests
{
    public class LocalDateFixture
    {
        private readonly Random _random;
        protected readonly Fixture Fixture;

        protected LocalDateFixture()
        {
            _random = new Random(DateTime.Now.Millisecond);
            Fixture = GetFixture();
        }

        /// <summary>
        /// Creates a fixture from a random predefined list
        /// </summary>
        /// <returns></returns>
        private Fixture GetFixture()
        {
            var fixture = new Fixture();

            var proerties = typeof(LocalDate).GetProperties()
                .ToDictionary(x => x.Name, y => y.GetCustomAttribute<RangeAttribute>())
                .ToDictionary(x => x.Key, y => (minimum: y.Value.Minimum, maximum: y.Value.Maximum));

            var list = new List<LocalDate>();

            for (var i = 0; i < 100; i++)
            {
                var day = _random.Next((int) proerties["Day"].minimum, (int) proerties["Day"].maximum);
                var month = _random.Next((int) proerties["Month"].minimum, (int) proerties["Month"].maximum);
                var year = _random.Next((int) proerties["Year"].minimum, (int) proerties["Year"].maximum);

                // Fix the day value
                while (day > YearUtility.NumberOfDaysInMonth(year, month)) day--; 
                
                list.Add(new LocalDate(year, month, day));
            }
            
            fixture.Customizations.Add(new ElementsBuilder<LocalDate>(list));
            
            return fixture;
        }
    }
}