using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace BookApp1.Classes {
    public static class ValidationService {
        public static List<ValidationResult> Validate<T>(T entity) {
            var results = new List<ValidationResult>();

            if (entity == null) {
                return results;
            }

            try {
                var context = new ValidationContext(entity) {
                    MemberName = null
                };

                bool isValid = Validator.TryValidateObject(entity, context, results, validateAllProperties: true);
                if (!isValid) {
                    Console.WriteLine("Validation failed with errors: " + string.Join(", ", results.Select(r => r.ErrorMessage)));
                } else {
                    Console.WriteLine("Validation successful");
                }
            } catch (Exception ex) {
                Console.WriteLine($"Validation error: {ex.Message}");
                results.Add(new ValidationResult($"Validation failed due to: {ex.Message}", new[] { "*" }));
            }

            foreach (var property in typeof(T).GetProperties()) {
                var getter = property.GetGetMethod();
                if (getter == null)
                    continue;

                var value = property.GetValue(entity);
                if (value != null && value.GetType().IsClass && value.GetType() != typeof(string)) {
                    Console.WriteLine($"Skipping validation for complex property: {property.Name}");
                    continue;
                }
            }

            return results;
        }
    }
}