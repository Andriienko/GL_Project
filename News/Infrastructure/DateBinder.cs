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
            UserModel model = (UserModel) base.BindModel(modelBindingExecutionContext, bindingContext);
            model.BirthDate = GetDate(bindingContext, "BirthDate");
            bindingContext.ModelState.SetModelValue("BirthDate", new ValueProviderResult("new value", "", CultureInfo.InvariantCulture));
            return model;
        }
        private DateTime GetDate(ModelBindingContext context, string name)
        {
            ValueProviderResult day = context.ValueProvider.GetValue(name+".Day");
            ValueProviderResult month = context.ValueProvider.GetValue(name + ".Month");
            ValueProviderResult year = context.ValueProvider.GetValue(name + ".Year");
            if ((day == null || day.AttemptedValue == "")||(month == null || month.AttemptedValue == "") ||(year == null || year.AttemptedValue == ""))
            {
                return new DateTime();
            }
            else
            {
                context.ModelState["BirthDate"].Errors.RemoveAt(0);
                return new DateTime(Int32.Parse(year.AttemptedValue),Int32.Parse(month.AttemptedValue),Int32.Parse(day.AttemptedValue));
            }
        }
    }
}
