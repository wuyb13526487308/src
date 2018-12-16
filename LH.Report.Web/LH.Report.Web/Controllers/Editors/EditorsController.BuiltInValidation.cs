using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class EditorsController : DemoController {
        [HttpGet]
        public ActionResult BuiltInValidation() {
            return DemoView("BuiltInValidation", new BuiltInValidationData());
        }
        [HttpPost]
        public ActionResult BuiltInValidation(FormCollection form) {
            BuiltInValidationData validationData;
            if(Request.Params["btnUpdate"] == null) { // Theme changing
                validationData = new BuiltInValidationData {
                    Name = EditorExtension.GetValue<string>("Name"),
                    Age = EditorExtension.GetValue<int?>("Age"),
                    Email = EditorExtension.GetValue<string>("Email"),
                    ArrivalDate = EditorExtension.GetValue<DateTime?>("ArrivalDate")
                };
                return DemoView("BuiltInValidation", validationData);
            }

            bool isValid = true;
            validationData = new BuiltInValidationData {
                Name = EditorExtension.GetValue<string>("Name", EditorsDemosHelper.NameValidationSettings, EditorsDemosHelper.OnNameValidation, ref isValid),
                Age = EditorExtension.GetValue<int?>("Age", EditorsDemosHelper.AgeValidationSettings, EditorsDemosHelper.OnAgeValidation, ref isValid),
                Email = EditorExtension.GetValue<string>("Email", EditorsDemosHelper.EmailValidationSettings, null, ref isValid),
                ArrivalDate = EditorExtension.GetValue<DateTime?>("ArrivalDate", EditorsDemosHelper.ArrivalDateValidationSettings, null, ref isValid)
            };
            if(isValid)
                return DemoView("BuiltInValidation", "BuiltInValidationSuccess", validationData);
            else
                return DemoView("BuiltInValidation", validationData);
        }
    }
}
