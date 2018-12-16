using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class EditorsController: DemoController {
        public override string Name { get { return "Editors"; } }

        static EditorsController() {
            PersonDataGenerator.Register();
        }

        public ActionResult Index() {
            return ComboBox();
        }

        public ActionResult ModelValidation() {
            return RedirectToAction("ModelValidation", "Common");
        }
    }

    public class EditorsDemosHelper {
        static ValidationSettings nameValidationSettings;
        public static ValidationSettings NameValidationSettings {
            get {
                if(nameValidationSettings == null) {
                    nameValidationSettings = ValidationSettings.CreateValidationSettings();
                    nameValidationSettings.Display = Display.Dynamic;
                    nameValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
                    nameValidationSettings.ErrorText = "Name is required";
                }
                return nameValidationSettings;
            }
        }
        static ValidationSettings ageValidationSettings;
        public static ValidationSettings AgeValidationSettings {
            get {
                if(ageValidationSettings == null) {
                    ageValidationSettings = ValidationSettings.CreateValidationSettings();
                    ageValidationSettings.Display = Display.Dynamic;
                    ageValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
                    ageValidationSettings.ErrorText = "Must be between 18 and 100";
                }
                return ageValidationSettings;
            }
        }
        static ValidationSettings emailValidationSettings;
        public static ValidationSettings EmailValidationSettings {
            get {
                if(emailValidationSettings == null) {
                    emailValidationSettings = ValidationSettings.CreateValidationSettings();
                    emailValidationSettings.Display = Display.Dynamic;
                    emailValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
                    emailValidationSettings.RequiredField.IsRequired = true;
                    emailValidationSettings.RequiredField.ErrorText = "Email is required";
                    emailValidationSettings.RegularExpression.ValidationExpression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                    emailValidationSettings.RegularExpression.ErrorText = "Email is invalid";
                }
                return emailValidationSettings;
            }
        }
        static ValidationSettings arrivalDateValidationSettings;
        public static ValidationSettings ArrivalDateValidationSettings {
            get {
                if(arrivalDateValidationSettings == null) {
                    arrivalDateValidationSettings = ValidationSettings.CreateValidationSettings();
                    arrivalDateValidationSettings.Display = Display.Dynamic;
                    arrivalDateValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
                    arrivalDateValidationSettings.ErrorText = "Arrival date is required";
                    arrivalDateValidationSettings.RequiredField.IsRequired = true;
                    arrivalDateValidationSettings.RequiredField.ErrorText = "";
                }
                return arrivalDateValidationSettings;
            }
        }

        public static void OnNameValidation(object sender, ValidationEventArgs e) {
            if(e.Value == null) {
                e.IsValid = false;
                return;
            }
            var name = e.Value.ToString();
            if(name == string.Empty)
                e.IsValid = false;
            if(name.Length > 50) {
                e.IsValid = false;
                e.ErrorText = "Must be under 50 characters";
            }
        }
        public static void OnAgeValidation(object sender, ValidationEventArgs e) {
            if(e.Value == null)
                return;
            var age = int.Parse(e.Value.ToString());
            if(age < 18 || age > 100)
                e.IsValid = false;
        }
    }
}
