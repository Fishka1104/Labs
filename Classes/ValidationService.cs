using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookApp1.Classes
{
    public static class ValidationService
    {
        public static List<ValidationResult> Validate<T>(T entity)
        {
            var results = new List<ValidationResult>();

            if (entity == null)
                return results;

            var context = new ValidationContext(entity);
            Validator.TryValidateObject(entity, context, results, validateAllProperties: true);

           
            foreach (var property in entity.GetType().GetProperties())
            {
               
                var getter = property.GetGetMethod();
                if (getter == null || getter.GetParameters().Length > 0)
                    continue;

                var value = property.GetValue(entity);

                if (value != null &&
                    !(value is string) &&
                    !property.PropertyType.IsPrimitive &&
                    !property.PropertyType.IsEnum)
                {
                    results.AddRange(Validate(value));
                }
            }

            return results;
        }
       
    }

}
