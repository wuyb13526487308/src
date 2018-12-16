using System;
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
    using DevExpress.Web.ASPxEditors;
    using DevExpress.Web.Mvc;

    public static class LargeDatabaseDataProvider {
        const string LargeDatabaseDataContextKey = "DXLargeDatabaseDataContext";

        public static LargeDatabaseDataContext DB {
            get {
                if(HttpContext.Current.Items[LargeDatabaseDataContextKey] == null)
                    HttpContext.Current.Items[LargeDatabaseDataContextKey] = new LargeDatabaseDataContext();
                return (LargeDatabaseDataContext)HttpContext.Current.Items[LargeDatabaseDataContextKey];
            }
        }

        public static IQueryable<Email> Emails { get { return DB.Emails; } }
    
        public static object GetPersonsRange(ListEditItemsRequestedByFilterConditionEventArgs args){
            var skip = args.BeginIndex;
            var take = args.EndIndex - args.BeginIndex + 1;
            return (from person in DB.Persons
                    where (person.FirstName + " " + person.LastName + " " + person.Phone).StartsWith(args.Filter)
                         orderby person.LastName
                         select person
                    ).Skip(skip).Take(take);
        }
        public static object GetPersonByID(ListEditItemRequestedByValueEventArgs args) {
            if(args.Value != null) {
                int id = (int)args.Value;
                return (from person in DB.Persons
                         where person.ID == id
                         select person).Take(1);
            }
            return null;
        }
    }
}
