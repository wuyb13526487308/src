using System;
using System.Web.Mvc;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data.Linq;
using System.Collections.Generic;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class SchedulerController: DemoController {
        public override string Name { get { return "Scheduler"; } }

        public ActionResult Index() {
            return RedirectToAction("Grouping");
        }
        public ActionResult CarImage() {
            if (Request.QueryString[SchedulerDemoHelper.ImageQueryKey] != null) {
                int carId = int.Parse(Request.QueryString[GridViewDemosHelper.ImageQueryKey]);
                Response.ContentType = "image";
                Binary photo = CarsDataProvider.GetCarPictureById(carId);
                if (photo != null)
                    Response.BinaryWrite(photo.ToArray());
                Response.End();
            }
            return null;
        }

        protected override int IECompatibilityVersion { get { return 7; } }
        protected override bool IsDemoRequiredCompatibilityMode() {
            return Utils.IsIE9() && Utils.CurrentDemo != null && IsDemoWithEditableActions();
        }
        bool IsDemoWithEditableActions() {
            ArrayList editingDemos = new ArrayList { "Editing", "Reminders", "CustomForms" };
            return editingDemos.Contains(Utils.CurrentDemo.Key);
        }
    }

    public class SchedulerDemoHelper {
        public const string ImageQueryKey = "DXImage";

        public static string GetCarImageRouteUrl() {
            return DevExpressHelper.GetUrl(new { Controller = "Scheduler", Action = "CarImage" });
        }

        static MVCxAppointmentStorage defaultAppointmentStorage;
        public static MVCxAppointmentStorage DefaultAppointmentStorage {
            get {
                if (defaultAppointmentStorage == null)
                    defaultAppointmentStorage = CreateDefaultAppointmentStorage();
                return defaultAppointmentStorage;
            }
        }

        static MVCxAppointmentStorage CreateDefaultAppointmentStorage() {
            MVCxAppointmentStorage appointmentStorage = new MVCxAppointmentStorage();
            appointmentStorage.Mappings.AppointmentId = "ID";
            appointmentStorage.Mappings.Start = "StartTime";
            appointmentStorage.Mappings.End = "EndTime";
            appointmentStorage.Mappings.Subject = "Subject";
            appointmentStorage.Mappings.Description = "Description";
            appointmentStorage.Mappings.Location = "Location";
            appointmentStorage.Mappings.AllDay = "AllDay";
            appointmentStorage.Mappings.Type = "EventType";
            appointmentStorage.Mappings.RecurrenceInfo = "RecurrenceInfo";
            appointmentStorage.Mappings.ReminderInfo = "ReminderInfo";
            appointmentStorage.Mappings.Label = "Label";
            appointmentStorage.Mappings.Status = "Status";
            appointmentStorage.Mappings.ResourceId = "CarId";
            return appointmentStorage;
        }

        static MVCxResourceStorage defaultResourceStorage;
        public static MVCxResourceStorage DefaultResourceStorage {
            get {
                if (defaultResourceStorage == null)
                    defaultResourceStorage = CreateDefaultResourceStorage();
                return defaultResourceStorage;
            }
        }
        static MVCxResourceStorage CreateDefaultResourceStorage() {
            MVCxResourceStorage resourceStorage = new MVCxResourceStorage();
            resourceStorage.Mappings.ResourceId = "ID";
            resourceStorage.Mappings.Caption = "Model";
            return resourceStorage;
        }

        static MVCxAppointmentStorage customAppointmentStorage;
        public static MVCxAppointmentStorage CustomAppointmentStorage {
            get {
                if (customAppointmentStorage == null)
                    customAppointmentStorage = CreateCustomAppointmentStorage();
                return customAppointmentStorage;
            }
        }
        static MVCxAppointmentStorage CreateCustomAppointmentStorage() {
            MVCxAppointmentStorage appointmentStorage = CreateDefaultAppointmentStorage();
            appointmentStorage.CustomFieldMappings.Add("Price", "Price");
            appointmentStorage.CustomFieldMappings.Add("ContactInfo", "ContactInfo");
            return appointmentStorage;
        }

        static SchedulerSettings exportSchedulerSettings;
        public static SchedulerSettings ExportSchedulerSettings {
            get {
                if (exportSchedulerSettings == null)
                    exportSchedulerSettings = CreateExportSchedulerSettings();
                return exportSchedulerSettings;
            }
        }
        static SchedulerSettings CreateExportSchedulerSettings() {
            SchedulerSettings settings = new SchedulerSettings();
            settings.Name = "schedulerExport";
            settings.CallbackRouteValues = new { Controller = "Scheduler", Action = "ICalendarPartial" };
            settings.ActiveViewType = SchedulerViewType.WorkWeek;
            settings.Start = new DateTime(2010, 7, 14);
            settings.Views.DayView.Styles.ScrollAreaHeight = Unit.Pixel(200);
            settings.Views.WorkWeekView.Styles.ScrollAreaHeight = Unit.Pixel(200);
            settings.Storage.EnableReminders = false;

            settings.Storage.Appointments.Assign(DefaultAppointmentStorage);
            settings.Storage.Resources.Assign(DefaultResourceStorage);
            settings.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.None;
            settings.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None;
            settings.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.None;
            return settings;
        }

        static IEnumerable reportTemplateFileNames;
        public static IEnumerable ReportTemplateFileNames {
            get {
                if (reportTemplateFileNames == null)
                    reportTemplateFileNames = CreateReportTemplateFileNames();
                return reportTemplateFileNames;
            }
        }
        static IEnumerable CreateReportTemplateFileNames() {
            return new List<string>() { "TrifoldStandard.schrepx", "TrifoldResource.schrepx", "TimetableStyle.schrepx",
                "DailyStyleFitToPage.schrepx", "DailyStyleFixedCellHeight.schrepx", "MonthlyStyle.schrepx"};
        }

        static SchedulerSettings reportTemplatesSchedulerSettings;
        public static SchedulerSettings ReportTemplatesSchedulerSettings {
            get {
                if (reportTemplatesSchedulerSettings == null)
                    reportTemplatesSchedulerSettings = CreateReportTemplatesSchedulerSettings();
                return reportTemplatesSchedulerSettings;
            }
        }
        static SchedulerSettings CreateReportTemplatesSchedulerSettings() {
            SchedulerSettings settings = new SchedulerSettings();
            settings.Name = "scheduler";
            settings.CallbackRouteValues = new { Controller = "Scheduler", Action = "ReportTemplatesPartial" };
            settings.ActiveViewType = SchedulerViewType.Week;
            settings.GroupType = SchedulerGroupType.Resource;
            settings.Start = new DateTime(2010, 7, 14);
            settings.Width = Unit.Percentage(100);

            settings.Views.DayView.ResourcesPerPage = 3;
            settings.Views.DayView.Styles.ScrollAreaHeight = Unit.Pixel(300);
            settings.Views.WorkWeekView.ResourcesPerPage = 3;
            settings.Views.WorkWeekView.Styles.ScrollAreaHeight = Unit.Pixel(300);
            settings.Views.WeekView.ResourcesPerPage = 3;
            settings.Views.MonthView.ResourcesPerPage = 3;
            settings.Views.TimelineView.ResourcesPerPage = 3;

            settings.Storage.EnableReminders = false;
            settings.Storage.Appointments.Assign(SchedulerDemoHelper.DefaultAppointmentStorage);
            settings.Storage.Resources.Assign(SchedulerDemoHelper.DefaultResourceStorage);
            settings.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.None;
            settings.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None;
            settings.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.None;
            return settings;
        }

        static SchedulerSettings dateNavigatorSchedulerSettings;
        public static SchedulerSettings DateNavigatorSchedulerSettings {
            get {
                if (dateNavigatorSchedulerSettings == null)
                    dateNavigatorSchedulerSettings = CreateDateNavigatorSchedulerSettings();
                return dateNavigatorSchedulerSettings;
            }
        }
        static SchedulerSettings CreateDateNavigatorSchedulerSettings() {
            SchedulerSettings settings = new SchedulerSettings();
            settings.Name = "scheduler";
            settings.CallbackRouteValues = new { Controller = "Scheduler", Action = "DateNavigatorPartial" };
            settings.Start = new DateTime(2010, 7, 13);
            settings.Width = Unit.Pixel(580);
            settings.Views.DayView.ResourcesPerPage = 2;
            settings.Views.DayView.Styles.ScrollAreaHeight = Unit.Pixel(400);
            settings.OptionsBehavior.ShowViewNavigator = false;
            settings.OptionsBehavior.ShowViewSelector = false;

            settings.Storage.EnableReminders = false;
            settings.Storage.Resources.Assign(SchedulerDemoHelper.DefaultResourceStorage);
            settings.Storage.Appointments.Assign(SchedulerDemoHelper.DefaultAppointmentStorage);
            settings.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.None;
            settings.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None;
            settings.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.None;

            settings.DateNavigatorExtensionSettings.Name = "dateNavigator";
            settings.DateNavigatorExtensionSettings.Width = 220;
            settings.DateNavigatorExtensionSettings.Properties.Rows = 2;
            settings.DateNavigatorExtensionSettings.Properties.DayNameFormat = DayNameFormat.FirstLetter;
            settings.DateNavigatorExtensionSettings.Properties.BoldAppointmentDates = true;
            return settings;
        }
    }

    public class CustomAppointmentTemplateContainer: AppointmentFormTemplateContainer {
        public CustomAppointmentTemplateContainer(MVCxScheduler scheduler)
            : base(scheduler) {
        }
        public string ContactInfo { 
            get { return Convert.ToString(Appointment.CustomFields["ContactInfo"]); } 
        }
        public decimal? Price {
            get {
                object priceRawValue = Appointment.CustomFields["Price"];
                return priceRawValue == DBNull.Value ? 0 : (decimal?)priceRawValue;
            }
        }
    }
}
