using LocalDate.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LocalDate.Enums;
using LocalDate.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace LocalDate.Models
{
    [Serializable]
    [BsonSerializer(typeof(LocalDateBsonConverter))]
    [JsonConverter(typeof(LocalDateJsonConverter))]
    public class LocalDateStruct: ILocalDateStruct
    {
        [Range(1, 9999)]
        public int Year { get; }

        [Range(1, 12)]
        public int Month { get; }

        [Range(1, 31)]
        public int Day { get; }

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
            if (!(obj is ILocalDateStruct localDateStruct))
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
