using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LocalDate.Exceptions;
using LocalDate.Extensions;

namespace LocalDate.Utilities
{
    public static class LocalDateValidation
    {
        /// <summary>
        /// Validates an attribute
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="i"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ValidateRangeAction(ValidationAttribute attribute, int i)
        {
            if (!attribute.IsValid(i))
            {
                throw new LocalDateRangeException();
            }
        }

        /// <summary>
        /// Validate againt null
        /// </summary>
        /// <returns></returns>
        private static void ValidateNullLocalDate(LocalDate localDate)
        {
            if (localDate == null)
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Validates many LocalDates againt null
        /// </summary>
        /// <param name="localDates"></param>
        /// <returns></returns>
        public static void ValidateNullLocalDates(params LocalDate[] localDates)
        {
            localDates.ForEach(ValidateNullLocalDate);
        }
    }
}