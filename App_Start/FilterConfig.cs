﻿using System.Web;
using System.Web.Mvc;

namespace TP_Samouraï
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
