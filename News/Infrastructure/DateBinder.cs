using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Models;

namespace News.Infrastructure
{
    public class DateBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext modelBindingExecutionContext, ModelBindingContext bindingContext)
        {
            //UserModel model = (UserModel)bindingContext.Model
            //?? new UserModel();
            //model.FirstName = GetValue(bindingContext, "FirstName");
            //model.LastName = GetValue(bindingContext, "LastName");
            //model.Email = GetValue(bindingContext, "Email");
            //model.Password = GetValue(bindingContext, "Password");
            //model.ConfirmPassword = GetValue(bindingContext, "ConfirmPassword");
            //model.BirthDate = GetDate(bindingContext, "BirthDate");
            //return model;
            UserModel model = (UserModel) base.BindModel(modelBindingExecutionContext, bindingContext);
            model.BirthDate = GetDate(bindingContext, "BirthDate");
            bindingContext.ModelState["BirthDate"].Errors.RemoveAt(0);
            bindingContext.ModelState.SetModelValue("BirthDate", new ValueProviderResult("new value", "", CultureInfo.InvariantCulture));
            return model;
        }
        //private string GetValue(ModelBindingContext context, string name)
        //{
        //    //name = (context.ModelName == "" ? "" : context.ModelName + ".") + name;
        //    ValueProviderResult result = context.ValueProvider.GetValue(name);
        //    if (result == null || result.AttemptedValue == "")
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return (string)result.AttemptedValue;
        //    }
        //}
        private DateTime GetDate(ModelBindingContext context, string name)
        {
            //name = (context.ModelName == "" ? "" : context.ModelName + ".") + name;
            ValueProviderResult day = context.ValueProvider.GetValue(name+".Day");
            ValueProviderResult month = context.ValueProvider.GetValue(name + ".Month");
            ValueProviderResult year = context.ValueProvider.GetValue(name + ".Year");
            if ((day == null || day.AttemptedValue == "")||(month == null || month.AttemptedValue == "") ||(year == null || year.AttemptedValue == ""))
            {
                return new DateTime();
            }
            else
            {
                return new DateTime(Int32.Parse(year.AttemptedValue),Int32.Parse(month.AttemptedValue),Int32.Parse(day.AttemptedValue));
            }
        }
    }
}
