﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using LocalDate.Exceptions;
using LocalDate.Interfaces;
using LocalDate.Extensions;
using LocalDate.Extensions.LocalDateExtensions;
using LocalDate.Models;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;
using LocalDate.Serializers;
using LocalDate.Utilities;

namespace LocalDate
{
    [Serializable]
    [BsonSerializer(typeof(LocalDateBsonConverter))]
    [JsonConverter(typeof(LocalDateJsonConverter))]
    public class LocalDate : LocalDateStruct, ILocalDate
    {        
        /// <summary>
        /// Constructor that takes: year, month and day
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public LocalDate(int year, int month, int day) : base(year, month, day)
        {
            ValidateLocalDate(year, month, day);
        }

        /// <inheritdoc />
        /// <summary>
        /// Constructor that takes a DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        public LocalDate(DateTime dateTime) : this(dateTime.Year, dateTime.Month, dateTime.Day)
        {

        }

        /// <summary>
        /// Adds two LocalDate together
        /// </summary>
        /// <param name="localDate1"></param>
        /// <param name="localDate2"></param>
        /// <returns></returns>
        public static ILocalDate operator +(LocalDate localDate1, LocalDate localDate2)
        {
            return localDate1.AddDays(localDate2.Day)
                .AddMonths(localDate2.Month)
                .AddYears(localDate2.Year);
        }

        /// <summary>
        /// Subtracts two LocalDate together
        /// </summary>
        /// <param name="localDate1"></param>
        /// <param name="localDate2"></param>
        /// <returns></returns>
        public static ILocalDate operator -(LocalDate localDate1, LocalDate localDate2)
        {
            return localDate1.SubtractDays(localDate2.Day)
                .SubtractMonths(localDate2.Month)
                .SubtractYears(localDate2.Year);
        }

        /// <summary>
        /// Subtract given days from LocalDate
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public ILocalDate SubtractDays(int days) => (this.ToJulianNumber() - days).ToGregorian();

        /// <summary>
        /// Subtract given months from LocalDate
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public ILocalDate SubtractMonths(int months)
        {
            var temp = Month - months;
            return temp < 0 ? new LocalDate(Year, temp.ModPositive(12), Day).SubtractYears((int)Math.Floor(temp / 12.0) * -1) : new LocalDate(Year, temp, Day);
        }

        /// <summary>
        /// Subtract given years from LocalDate
        /// </summary>
        /// <param name="years"></param>
        /// <returns></returns>
        public ILocalDate SubtractYears(int years) => new LocalDate(Year - years, Month, Day);

        /// <summary>
        /// Adds a given days to LocalDate
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public ILocalDate AddDays(int days) => (this.ToJulianNumber() + days).ToGregorian();
        /// <summary>
        /// Adds given months to LocalDate
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public ILocalDate AddMonths(int months)
        {
            var temp = Month + months;
            return temp > 12 ? new LocalDate(Year, temp % 12, Day).AddYears(temp / 12) : new LocalDate(Year, temp, Day);
        }

        /// <summary>
        /// Adds given years to LocalYear
        /// </summary>
        /// <param name="years"></param>
        /// <returns></returns>
        public ILocalDate AddYears(int years) => new LocalDate(Year + years, Month, Day);

        /// <summary>
        /// Explicit cast from DateTime to LocalDate
        /// </summary>
        /// <param name="dateTime"></param>
        public static explicit operator LocalDate(DateTime dateTime) => new LocalDate(dateTime);

        /// <summary>
        /// Validate date properties are in correct range, roughly
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <exception cref="ArgumentException"></exception>
        private static void ValidateLocalDate(int year, int month, int day)
        {
            typeof(LocalDateStruct).GetProperties().ToDictionary(x => x.Name, x => x.GetCustomAttribute<RangeAttribute>())
                .ForEach(x =>
                {
                    // ReSharper disable once SwitchStatementMissingSomeCases
                    switch (x.Key)
                    {
                        case "Year":
                            ValidateAction(x.Value, year);
                            break;
                        case "Month":
                            ValidateAction(x.Value, month);
                            break;
                        case "Day":
                            ValidateAction(x.Value, day);
                            break;
                    }
                });

            // More specific range validation
            if (day > YearUtility.NumberOfDaysInMonth(year, month))
            {
                throw new LocalDateRangeException();
            }
        }
        
        /// <summary>
        /// Validates an attribute
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="i"></param>
        /// <exception cref="ArgumentException"></exception>
        private static void ValidateAction(ValidationAttribute attribute, int i)
        {
            if (!attribute.IsValid(i))
            {
                throw new LocalDateRangeException();
            }
        }
    }
}