using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public class BuiltInValidationData {
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public DateTime? ArrivalDate { get; set; }
    }

    public class ModelValidationData {
        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Age:")]
        [Range(18, 100, ErrorMessage = "Must be between 18 and 100")]
        public int? Age { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Display(Name = "Arrival Date:")]
        [Required(ErrorMessage = "Arrival date is required")]
        public DateTime? ArrivalDate { get; set; }
    }

    public class UnobtrusiveValidationData {
        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Weight, kg:")]
        [RegularExpression("(\\d)*", ErrorMessage = "Weight must be a number")]
        [Range(20, 200, ErrorMessage = "Weight should be between 20 and 200 kg")]
        public int? Weight { get; set; }

        [Display(Name = "Systolic Blood Pressure, mmHg:")]
        [Required(ErrorMessage = "Systolic is required")]
        [Range(10, 240, ErrorMessage = "Systolic should be between 10 and 240 mmHg")]
        public float? SystolicBloodPressure { get; set; }

        [Display(Name = "Diastolic Blood Pressure, mmHg:")]
        [Required(ErrorMessage = "Diastolic is required")]
        [Range(10, 200, ErrorMessage = "Diastolic should be between 10 and 200 mmHg")]
        public float? DiastolicBloodPressure { get; set; }

        [Display(Name = "Notes:")]
        [Required(ErrorMessage = "Notes is required")]
        public string Notes { get; set; }
    }

    public class JQueryValidationData {
        [Display(Name = "Author:")]
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Display(Name = "Publisher:")]
        [StringLength(10, ErrorMessage = "Must be under 10 characters")]
        public string Publisher { get; set; }

        [Display(Name = "Release Date:")]
        [Required(ErrorMessage = "Release date is required")]
        [Remote("CheckReleaseDate", "Common", ErrorMessage = "Release date can not be earlier than today")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Annotation:")]
        [Required(ErrorMessage = "Annotation is required")]
        public string Annotation { get; set; }
    }

    public enum FuelType { Petroleum, NaturalGas, Ethanol, Diesel }
    public class EditorTemplatesData {
        [Display(Name = "Car Model:")]
        [Required(ErrorMessage = "Car Model is required")]
        public string CarModel { get; set; }

        [Display(Name = "Price:")]
        [DisplayFormat(DataFormatString="c")]
        [RegularExpression("(\\d)*", ErrorMessage = "Price must be a number")]
        [Range(500, 50000, ErrorMessage = "Must be between {1} and {2}")]
        public float? Price { get; set; }

        [Display(Name = "Fuel Type:")]
        [Required(ErrorMessage = "Type of fuel is required")]
        public FuelType? FuelType { get; set; }

        [UIHint("Mileage")]
        [Display(Name = "Mileage:")]
        [Range(10, 999, ErrorMessage = "Must be between {1} and {2}")]
        public float Mileage { get; set; }
    }

    public enum Gender { Male, Female };
    public class AjaxFormValidationData {
        [Display(Name = "Full Name")]
        [Required]
        public string FullName { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [StringLength(10)]
        public string Login { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }
    }
}
