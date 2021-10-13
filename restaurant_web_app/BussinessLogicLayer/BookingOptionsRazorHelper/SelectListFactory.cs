using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.BookingOptions.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace restaurant_web_app.BussinessLogicLayer.BookingOptionsRazorHelper
{
    internal static class SelectListFactory
    {
        internal static SelectList GetSelectList(DropDownItemInfo dropDownItemInfo)
        {
            SelectList selectListHelper = new SelectList(
                dropDownItemInfo.DropDownDictionary.Select(x =>
                    new { Value = x.Key, Text = x.Value })
                , "Value", "Text", dropDownItemInfo.Label);

            return selectListHelper;
        }
    }
}
