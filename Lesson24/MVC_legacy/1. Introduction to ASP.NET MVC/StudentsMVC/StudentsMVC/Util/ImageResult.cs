﻿using System.Web.Mvc;

namespace StudentsMVC.Util
{
    public class ImageResult : ActionResult
    {
        private string path;
        public ImageResult(string path)
        {
            this.path = path;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write("<div style='width:100%;text-align:center;'>" +
                "<img style='max-width:1024px;' src='" + path + "' /></div>");
        }
    }
}