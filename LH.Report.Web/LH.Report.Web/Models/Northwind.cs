﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace DevExpress.Web.Demos {
    using DevExpress.Web.Demos.Models;

    public static class NorthwindDataProvider {
        const string NorthwindDataContextKey = "DXNorthwindDataContext";

        public static NorthwindDataContext DB {
            get {
                if(HttpContext.Current.Items[NorthwindDataContextKey] == null)
                    HttpContext.Current.Items[NorthwindDataContextKey] = new NorthwindDataContext();
                return (NorthwindDataContext)HttpContext.Current.Items[NorthwindDataContextKey];
            }
        }

        static double CalculateAveragePrice(int categoryID) {
            return (double)(from product in DB.Products where product.CategoryID == categoryID select product).Average(s => s.UnitPrice);
        }
        public static IEnumerable GetCategories() {
            return from category in DB.Categories select category;
        }
        public static Category GetCategoryByID(int categoryID) {
            return (from category in DB.Categories where category.CategoryID == categoryID select category).SingleOrDefault<Category>();
        }
        public static string GetCategoryNameById(int id) {
            Category category = GetCategoryByID(id);
            return category != null ? category.CategoryName : null;
        }
        public static IEnumerable GetCategoriesNames() {
            return from category in DB.Categories select category.CategoryName;
        }
        public static IEnumerable GetCategoriesAverage() {
            return from category in DB.Categories select new {
                category.CategoryName,
                AvgPrice = CalculateAveragePrice(category.CategoryID)
            };
        }
        public static IEnumerable GetCustomers() {
            return from customer in DB.Customers select customer;
        }
        public static IEnumerable GetProducts() {
            return from product in DB.Products select product;
        }
        public static IEnumerable GetProducts(string categoryName) {
            return from product in DB.Products
                   join category in DB.Categories on product.CategoryID equals category.CategoryID
                   where category.CategoryName == categoryName
                   select product;
        }
        public static IEnumerable GetEmployees() {
            return from employee in DB.Employees select employee;
        }
        public static Binary GetEmployeePhoto(int employeeId) {
            return (from employee in DB.Employees
                    where employee.EmployeeID == employeeId
                    select employee.Photo).SingleOrDefault();
        }
        public static string GetEmployeeNotes(int employeeId) {
            return (from employee in DB.Employees
                    where employee.EmployeeID == employeeId
                    select employee.Notes).Single();
        }
        public static IEnumerable GetOrders() {
            return from order in DB.Orders select order;
        }
        public static IQueryable<Invoice> GetInvoices() {
            return from invoice in DB.Invoices
                   join customer in DB.Customers on invoice.CustomerID equals customer.CustomerID
                   select new Invoice() {
                       CompanyName = customer.CompanyName,
                       City = invoice.City,
                       Region = invoice.Region,
                       Country = invoice.Country,
                       UnitPrice = invoice.UnitPrice,
                       Quantity = invoice.Quantity,
                       Discount = invoice.Discount
                   };
        }
        public static IEnumerable GetFullInvoices() {
            return from invoice in DB.Invoices
                   join customer in DB.Customers on invoice.CustomerID equals customer.CustomerID
                   join order in DB.Orders on invoice.OrderID equals order.OrderID
                   select new {
                       SalesPerson = order.Employee.FirstName + " " + order.Employee.LastName,
                       customer.CompanyName,
                       invoice.Country,
                       invoice.Region,
                       invoice.OrderDate,
                       invoice.ProductName,
                       invoice.UnitPrice,
                       invoice.Quantity,
                       invoice.Discount,
                       invoice.ExtendedPrice,
                   };
        }
        public static IEnumerable GetInvoices(string customerID) {
            return from invoice in DB.Invoices where invoice.CustomerID == customerID select invoice;
        }
        
        public static IList<EditableProduct> GetEditableProducts() {
            IList<EditableProduct> products = (IList<EditableProduct>)HttpContext.Current.Session["Products"];

            if(products == null) {
                products = (from product in DB.Products
                            select new EditableProduct {
                                ProductID = product.ProductID,
                                ProductName = product.ProductName,
                                CategoryID = product.CategoryID,
                                QuantityPerUnit = product.QuantityPerUnit,
                                UnitPrice = product.UnitPrice,
                                UnitsInStock = product.UnitsInStock,
                                Discontinued = product.Discontinued
                            }).ToList();
                HttpContext.Current.Session["Products"] = products;
            }
            return products;
        }
        public static EditableProduct GetEditableProduct(int productID) {
            return (from product in GetEditableProducts() where product.ProductID == productID select product).FirstOrDefault();
        }
        public static int GetNewEditableProductID() {
            IEnumerable<EditableProduct> editableProducts = GetEditableProducts();
            return (editableProducts.Count() > 0) ? editableProducts.Last().ProductID + 1 : 0;
        }
        public static void DeleteProduct(int productID) {
            EditableProduct product = GetEditableProduct(productID);
            if(product != null)
                GetEditableProducts().Remove(product);
        }
        public static void InsertProduct(EditableProduct product) {
            EditableProduct editProduct = new EditableProduct();
            editProduct.ProductID = GetNewEditableProductID();
            editProduct.ProductName = product.ProductName;
            editProduct.CategoryID = product.CategoryID;
            editProduct.QuantityPerUnit = product.QuantityPerUnit;
            editProduct.UnitPrice = product.UnitPrice;
            editProduct.UnitsInStock = product.UnitsInStock;
            editProduct.Discontinued = product.Discontinued;
            GetEditableProducts().Add(editProduct);
        }
        public static void UpdateProduct(EditableProduct product) {
            EditableProduct editProduct = GetEditableProduct(product.ProductID);
            if(editProduct != null) {
                editProduct.ProductName = product.ProductName;
                editProduct.CategoryID = product.CategoryID;
                editProduct.QuantityPerUnit = product.QuantityPerUnit;
                editProduct.UnitPrice = product.UnitPrice;
                editProduct.UnitsInStock = product.UnitsInStock;
                editProduct.Discontinued = product.Discontinued;
            }
        }
        
        public static IEnumerable GetEmployeesList() {
            return from employee in DB.Employees
                   select new {
                       ID = employee.EmployeeID,
                       Name = employee.LastName + " " + employee.FirstName
                   };
        }
        public static int GetFirstEmployeeID() {
            return (from employee in DB.Employees
                    select employee.EmployeeID).First<int>();
        }
        public static Employee GetEmployee(int employeeId) {
            return (from employee in DB.Employees
                    where employeeId == employee.EmployeeID
                    select employee).Single<Employee>();
        }
        public static IEnumerable GetOrders(int employeeID) {
            return from order in DB.Orders
                   where order.EmployeeID == employeeID
                   join order_detail in DB.Order_Details on order.OrderID equals order_detail.OrderID
                   join customer in DB.Customers on order.CustomerID equals customer.CustomerID
                   select new {
                       order.OrderID,
                       order.ShipName,
                       order_detail.Quantity,
                       order_detail.UnitPrice,
                       customer.ContactName,
                       customer.CompanyName,
                       customer.City,
                       customer.Address,
                       customer.Phone,
                       customer.Fax
                   };
        }
        public static IEnumerable GetProductReports() {
            return from sale in DB.Sales_by_Categories
                   join invoice in DB.Invoices on sale.ProductName equals invoice.ProductName
                   where invoice.ShippedDate != null
                   select new {
                       sale.CategoryName,
                       sale.ProductName,
                       sale.ProductSales,
                       invoice.ShippedDate,
                   };
        }
        public static IEnumerable GetCustomerReports() {
            return from customer in DB.Customers 
                   join order in DB.Orders on customer.CustomerID equals order.CustomerID
                   join order_detail in DB.Order_Details on order.OrderID equals order_detail.OrderID
                   join product in DB.Products on order_detail.ProductID equals product.ProductID
                   select new {
                       product.ProductName,
                       customer.CompanyName,
                       order.OrderDate,
                       ProductAmount = (float)(order_detail.UnitPrice * order_detail.Quantity) * (1 - order_detail.Discount / 100) * 100
                   };

        }
        public static IEnumerable GetSalesPerson() {
            return from salePerson in DB.SalesPersons select salePerson;
        }
    }

    public class EditableProduct {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int? CategoryID { get; set; }

        [StringLength(100, ErrorMessage = "Must be under 100 characters")]
        public string QuantityPerUnit { get; set; }

        [Range(0, 10000, ErrorMessage = "Must be between 0 and 10000$")]
        public decimal? UnitPrice { get; set; }

        [Range(0, 1000, ErrorMessage = "Must be between 0 and 1000")]
        public short? UnitsInStock { get; set; }

        bool? discontinued;
        public bool? Discontinued {
            get {
                return discontinued;
            }
            set {
                discontinued = value == null ? false : value;
            }
        }
    }

    public class Invoice {
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }
}
