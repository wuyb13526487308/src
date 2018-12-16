using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using DevExpress.Web.Demos.Models;
using System.ComponentModel;
using System.Web.Mvc;
using System.Collections;
using DevExpress.XtraReports.UI;

namespace DevExpress.Web.Demos {
    public class ReportsDemoModel {
        public string ReportID { get; set; }
        public XtraReport Report { get; set; }
        public string ParametersView { get; set; }
    }

    public static class DataSources {
        const string NorthwindDataContextKey = "DXReportsNorthwindDataContext";
        
        public static NorthwindDataContext Nwind {
            get {
                if(HttpContext.Current.Items[NorthwindDataContextKey] == null)
                    HttpContext.Current.Items[NorthwindDataContextKey] = new NorthwindDataContext();
                return (NorthwindDataContext)HttpContext.Current.Items[NorthwindDataContextKey];
            }
        }
    }
    static class SelectListItemHelper {
        static readonly string[] FormattingRuleConditions = new[] {
            "Quantity more than 30", "Quantity more than 60", "Unit price more than 40", "Unit price more than 60",
            "Discount more than 5", "Discount more than 15", "Extended price more than 1000", "Extended price more than 1500"
        };
        static readonly string[] FormattingRuleStyles = new[] {
            "Tahoma Bold", "Dark Red", "Light Red", "Dark Blue", "Light Blue", "Dark Green", "Light Green"
        };

        public static IEnumerable<SelectListItem> Generate<T>(T selectedValue) {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach(Enum value in Enum.GetValues(typeof(T)))
                yield return new SelectListItem() {
                    Text = converter.ConvertToInvariantString(value),
                    Selected = Enum.Equals(value, selectedValue)
                };
        }

        public static IEnumerable<SelectListItem> Generate(string[] values, int selectedIndex) {
            for(int i = 0; i < values.Length; i++)
                yield return new SelectListItem() {
                    Value = i.ToString(),
                    Text = values[i],
                    Selected = i == selectedIndex
                };
        }
        public static IEnumerable<SelectListItem> GetSideBySideItems(int defaultValue) {
            var employeesQuery = DataSources.Nwind.Employees.AsEnumerable();
            var employees = from employee in employeesQuery
                            select new SelectListItem
                            {
                                Text = employee.FirstName + ' ' + employee.LastName,
                                Value = employee.EmployeeID.ToString(),
                                Selected = employee.EmployeeID == defaultValue
                            };
            return employees;
        }
        public static IEnumerable<SelectListItem> GetFormattingRuleConditionItems(int defaultValue) {
            return SelectListItemHelper.Generate(FormattingRuleConditions, defaultValue);
        }
        public static IEnumerable<SelectListItem> GetFormattingRuleStyleItems(int defaultValue) {
            return SelectListItemHelper.Generate(FormattingRuleStyles, defaultValue);
        }
    }

    public class ReportsDataProvider : XtraReportsDemos.TableReport.ITableReportDataFiller {
        public void Fill(XtraReportsDemos.TableReport.Report report) {
            var orderDetailsQuery = DataSources.Nwind.OrderDetails.AsEnumerable();
            var orderDetails = from orderDetail in orderDetailsQuery
                               where orderDetail.OrderID == report.OrderID
                               select new {
                                   Discount = orderDetail.Discount,
                                   OrderID = orderDetail.OrderID,
                                   ProductName = orderDetail.ProductName,
                                   Quantity = orderDetail.Quantity,
                                   Supplier = orderDetail.Supplier,
                                   UnitPrice = orderDetail.UnitPrice,
                                   SubTotal = (decimal)orderDetail.Quantity * orderDetail.UnitPrice
                               };
            orderDetails.CopyToDataTable(report.dsOrderDetails1.OrderDetails);
        }
    }

    public static class ReportsDataProviderHelper {
        static string GetValidColumnName(string columnName, DataTable table) {
            if(string.IsNullOrEmpty(columnName))
                return string.Empty;
            if(table.Columns.Contains(columnName))
                return columnName;
            string[] words = columnName.Split('_');
            if(words == null || words.Length == 0)
                return string.Empty;
            string name = DevExpress.XtraPrinting.StringUtils.Join(" ", words);
            if(table.Columns.Contains(name))
                return name;
            return string.Empty;
        }

        public static void CopyToDataTable<T>(this IEnumerable<T> query, DataTable table) {
            if(query == null)
                return;

            PropertyInfo[] properties = null;

            foreach(T item in query) {
                if(properties == null)
                    properties = ((Type)item.GetType()).GetProperties();

                DataRow row = table.NewRow();

                foreach(PropertyInfo property in properties) {
                    string columnName = GetValidColumnName(property.Name, table);
                    if(string.IsNullOrEmpty(columnName))
                        continue;
                    var propertyValue = property.GetValue(item, null);
                    if(propertyValue is System.Data.Linq.Binary)
                        propertyValue = ((System.Data.Linq.Binary)propertyValue).ToArray();
                    row[columnName] = propertyValue ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }
        }
        

        public static XtraReportsDemos.MasterDetailReport.Report Fill(this XtraReportsDemos.MasterDetailReport.Report report) {
            var productsQuery = DataSources.Nwind.Products.AsEnumerable();
            var categoriesQuery = DataSources.Nwind.Categories.AsEnumerable();
            var products = from product in productsQuery
                           join category in categoriesQuery
                           on product.CategoryID equals category.CategoryID
                           select new {
                               CategoryName = category.CategoryName,
                               CategoryID = product.CategoryID,
                               Discontinued = product.Discontinued,
                               ProductID = product.ProductID,
                               ProductName = product.ProductName,
                               QuantityPerUnit = product.QuantityPerUnit,
                               SupplierID = product.SupplierID,
                               UnitPrice = product.UnitPrice,
                           };
            products.CopyToDataTable(report.dsMasterDetail1.Products);
            DataSources.Nwind.Suppliers.CopyToDataTable(report.dsMasterDetail1.Suppliers);

            var orderDetailsQuery = DataSources.Nwind.Order_Details.AsEnumerable();
            var orderDetails = from orderDetail in orderDetailsQuery
                               select new {
                                   Discount = orderDetail.Discount,
                                   OrderID = orderDetail.OrderID,
                                   ProductID = orderDetail.ProductID,
                                   Quantity = orderDetail.Quantity,
                                   UnitPrice = orderDetail.UnitPrice,
                                   SubTotal = (decimal)(orderDetail.Quantity * orderDetail.UnitPrice)
                               };
            orderDetails.CopyToDataTable(report.dsMasterDetail1.Order_Details);
            return report;
        }

        public static XtraReportsDemos.ReportMerging.MergedReport Fill(this XtraReportsDemos.ReportMerging.MergedReport report) {
            report.FillDataFromDatabase = false;

            Fill(report.ChartsReport);

            var productsQuery = DataSources.Nwind.Products.AsEnumerable();
            var categoriesQuery = DataSources.Nwind.Categories.AsEnumerable();
            var products = from product in productsQuery
                           join category in categoriesQuery on product.CategoryID equals category.CategoryID
                           select new {
                               ProductID = product.ProductID,
                               ProductName = product.ProductName,
                               QuantityPerUnit = product.QuantityPerUnit,
                               UnitPrice = product.UnitPrice,
                               Description = category.Description,
                               Picture = category.Picture,
                               CategoryName = category.CategoryName,
                               CategoryID = product.CategoryID,
                           };
            products.CopyToDataTable(report.dsCatalog1.Products);

            var orderDetailsQuery = DataSources.Nwind.Order_Details.AsEnumerable();
            var orderDetails = from orderDetail in orderDetailsQuery
                               select new {
                                   Discount = orderDetail.Discount,
                                   OrderID = orderDetail.OrderID,
                                   ProductID = orderDetail.ProductID,
                                   Quantity = orderDetail.Quantity,
                                   UnitPrice = orderDetail.UnitPrice,
                               };
            orderDetails.CopyToDataTable(report.dsCatalog1.Order_Details);
            return report;
        }

        public static XtraReportsDemos.Charts.Report Fill(this XtraReportsDemos.Charts.Report report) {
            DataSources.Nwind.Products.CopyToDataTable(report.dsCategoriesProducts1.Products);

            var categoriesQuery = DataSources.Nwind.Categories.AsEnumerable();
            var categories = from category in categoriesQuery
                             select new {
                                 CategoryName = category.CategoryName,
                                 CategoryID = category.CategoryID,
                                 Description = category.Description,
                                 Picture = category.Picture
                             };
            categories.CopyToDataTable(report.dsCategoriesProducts1.Categories);
            return report;
        }

        public static XtraReportsDemos.SideBySideReports.EmployeeComparisonReport Fill(this XtraReportsDemos.SideBySideReports.EmployeeComparisonReport report) {
            var employeesQuery = DataSources.Nwind.Employees.AsEnumerable();
            var customersQuery = DataSources.Nwind.Customers.AsEnumerable();
            var productsQuery = DataSources.Nwind.Products.AsEnumerable();
            var ordersQuery = DataSources.Nwind.Orders.AsEnumerable();
            var orderDetailsQuery = DataSources.Nwind.Order_Details.AsEnumerable();

            var employees = from employee in employeesQuery
                            select new {
                                EmployeeID = employee.EmployeeID,
                                FullName = string.Concat(employee.FirstName, ' ', employee.LastName),
                                BirthDate = employee.BirthDate,
                                HireDate = employee.HireDate,
                                Photo = employee.Photo
                            };
            var employeeOrders = from customer in customersQuery
                                 join order in ordersQuery on customer.CustomerID equals order.CustomerID
                                 join employee in employeesQuery on order.EmployeeID equals employee.EmployeeID
                                 join orderDetail in orderDetailsQuery on order.OrderID equals orderDetail.OrderID
                                 join product in productsQuery on orderDetail.ProductID equals product.ProductID
                                 select new {
                                     OrderID = order.OrderID,
                                     EmployeeID = employee.EmployeeID,
                                     ContactName = customer.ContactName,
                                     CompanyName = customer.CompanyName,
                                     ExtendedPrice = (decimal)((double)orderDetail.UnitPrice * orderDetail.Quantity * (1 - orderDetail.Discount / 100.0))
                                 };

            employees.CopyToDataTable(((XtraReportsDemos.SideBySideReports.EmployeeOrdersReport)report.xrSubreport1.ReportSource).dsEmployees1.Employees);
            employees.CopyToDataTable(((XtraReportsDemos.SideBySideReports.EmployeeOrdersReport)report.xrSubreport2.ReportSource).dsEmployees1.Employees);

            employeeOrders.CopyToDataTable(((XtraReportsDemos.SideBySideReports.EmployeeOrdersReport)report.xrSubreport1.ReportSource).dsEmployees1.EmployeeOrders);
            employeeOrders.CopyToDataTable(((XtraReportsDemos.SideBySideReports.EmployeeOrdersReport)report.xrSubreport2.ReportSource).dsEmployees1.EmployeeOrders);
            return report;
        }

        public static XtraReportsDemos.PivotGrid.Report Fill(this XtraReportsDemos.PivotGrid.Report report) {
            DataSources.Nwind.OrderReports.CopyToDataTable(report.dsOrderReports1.OrderReports);
            return report;
        }

        public static XtraReportsDemos.PivotGridAndChart.Report Fill(this XtraReportsDemos.PivotGridAndChart.Report report) {
            DataSources.Nwind.SalesPersons.CopyToDataTable(report.dsSalesPerson.SalesPerson);
            return report;
        }

        public static XtraReportsDemos.FormattingRules.Report Fill(this XtraReportsDemos.FormattingRules.Report report) {
            var orderDetailsQuery = DataSources.Nwind.Order_Details.AsEnumerable();
            var productsQuery = DataSources.Nwind.Products.AsEnumerable();
            var ordersQuery = DataSources.Nwind.Orders.AsEnumerable();

            var orders = from product in productsQuery
                         join orderDetail in orderDetailsQuery on product.ProductID equals orderDetail.ProductID
                         join order in ordersQuery on orderDetail.OrderID equals order.OrderID
                         select new {
                             OrderID = orderDetail.OrderID,
                             ProductID = orderDetail.ProductID,
                             ProductName = product.ProductName,
                             UnitPrice = orderDetail.UnitPrice,
                             Quantity = orderDetail.Quantity,
                             Discount = orderDetail.Discount,
                             Extended_Price = (decimal)((double)orderDetail.UnitPrice * orderDetail.Quantity *
                             (1 - orderDetail.Discount / 100.0)),
                             OrderDate = order.OrderDate
                         };
            orders.CopyToDataTable(report.formattingRulesDataSet1.Orders);
            return report;
        }

        public static XtraReportsDemos.ShrinkGrow.Report Fill(this XtraReportsDemos.ShrinkGrow.Report report) {
            DataSources.Nwind.Employees.CopyToDataTable(report.dsEmployees1.Employees);
            return report;
        }

        public static XtraReportsDemos.NorthwindTraders.CatalogReport Fill(this XtraReportsDemos.NorthwindTraders.CatalogReport report) {
            report.FillDataFromDatabase = false;

            var productsQuery = DataSources.Nwind.Products.AsEnumerable();
            var categoriesQuery = DataSources.Nwind.Categories.AsEnumerable();
            var products = from product in productsQuery
                           join category in categoriesQuery on product.CategoryID equals category.CategoryID
                           select new {
                               ProductID = product.ProductID,
                               ProductName = product.ProductName,
                               QuantityPerUnit = product.QuantityPerUnit,
                               UnitPrice = product.UnitPrice,
                               Description = category.Description,
                               Picture = category.Picture,
                               CategoryName = category.CategoryName,
                               CategoryID = product.CategoryID,
                           };
            products.CopyToDataTable(report.dsCatalog1.Products);

            var orderDetailsQuery = DataSources.Nwind.Order_Details.AsEnumerable();
            var orderDetails = from orderDetail in orderDetailsQuery
                               select new {
                                   Discount = orderDetail.Discount,
                                   OrderID = orderDetail.OrderID,
                                   ProductID = orderDetail.ProductID,
                                   Quantity = orderDetail.Quantity,
                                   UnitPrice = orderDetail.UnitPrice,
                               };
            orderDetails.CopyToDataTable(report.dsCatalog1.Order_Details);
            return report;
        }

        public static XtraReportsDemos.AnchorVertical.Report Fill(this XtraReportsDemos.AnchorVertical.Report report) {
            CarsDataContext dataContext = new CarsDataContext();
            dataContext.Cars.CopyToDataTable(report.dsCars1.Cars);
            return report;
        }
    }

    public class ParameterDictionaryBinder : DefaultModelBinder {
        static IEnumerable<string> GetValueProviderKeys(ControllerContext context) {
            return context.HttpContext.Request.Params.AllKeys;
        }
        static object ConvertType(string stringValue, Type type) {
            return TypeDescriptor.GetConverter(type).ConvertFrom(stringValue);
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            Type modelType = bindingContext.ModelType;
            Type idictType = modelType.GetInterface("System.Collections.Generic.IDictionary`2");

            if(idictType != null) {
                Type[] argumetTypes = idictType.GetGenericArguments();

                object result = null;
                IModelBinder valueBinder = Binders.GetBinder(argumetTypes[1]);

                foreach(string key in GetValueProviderKeys(controllerContext)) {
                    if(!key.StartsWith(bindingContext.ModelName, StringComparison.InvariantCultureIgnoreCase))
                        continue;

                    object dictKey;
                    string parameterName = key.Substring(bindingContext.ModelName.Length);
                    try {
                        dictKey = ConvertType(parameterName, argumetTypes[0]);
                    } catch(NotSupportedException) {
                        continue;
                    }

                    ModelBindingContext innerBindingContext = new ModelBindingContext()
                    {
                        ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => null, argumetTypes[1]),
                        ModelName = key,
                        ModelState = bindingContext.ModelState,
                        PropertyFilter = bindingContext.PropertyFilter,
                        ValueProvider = bindingContext.ValueProvider
                    };
                    object newPropertyValue = valueBinder.BindModel(controllerContext, innerBindingContext);

                    if(result == null)
                        result = CreateModel(controllerContext, bindingContext, modelType);

                    if(!(bool)idictType.GetMethod("ContainsKey").Invoke(result, new object[] { dictKey }))
                        idictType.GetProperty("Item").SetValue(result, newPropertyValue, new object[] { dictKey });
                }
                return result;
            }
            return new DefaultModelBinder().BindModel(controllerContext, bindingContext);
        }
    }
}
