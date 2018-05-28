using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using AutoFixture;
using AutoFixture.Kernel;

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

        private Fixture GetFixture()
        {
            var fixture = new Fixture();

            var proerties = typeof(LocalDate).GetProperties()
                .ToDictionary(x => x.Name, y => y.GetCustomAttribute<RangeAttribute>())
                .ToDictionary(x => x.Key, y => (minimum: y.Value.Minimum, maximum: y.Value.Maximum));


            var list = new List<LocalDate>();

            for (var i = 0; i < 100; i++)
            {
                var day = _random.Next((int) proerties["Day"].maximum, (int) proerties["Day"].maximum);
                var month = _random.Next((int) proerties["Month"].maximum, (int) proerties["Month"].maximum);
                var year = _random.Next((int) proerties["Year"].maximum, (int) proerties["Year"].maximum);

                list.Add(new LocalDate(year, month, day));
            }
            
            fixture.Customizations.Add(new ElementsBuilder<LocalDate>(list));
            
            return fixture;
        }
    }
}