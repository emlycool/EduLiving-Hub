﻿using System.Web;
using System.Web.Mvc;

namespace EduLiving_Hub
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
