﻿using SUS.HTTP;
using SUS.mvcFramework.ViewEngine;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace SUS.mvcFramework
{
    public abstract class Controller
    {
        private SusViewEngine viewEngine;
        public Controller()
        {
            this.viewEngine = new SusViewEngine();
        }

        public HttpRequest Request { get; set; }

        public HttpResponse View(object viewModel = null,[CallerMemberName]string path = null)
        {
           

            var viewContent = System.IO.File.ReadAllText(
                "Views/"
                + this.GetType().Name.Replace("Controller", string.Empty)+
                "/" + path +".cshtml");
            viewContent = this.viewEngine.GetHtml(viewContent, viewModel);

            var responseHtml = PutViewInLayout(viewContent, viewModel);

            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            return response;
        }       

        public HttpResponse File(string filePath, string contentType )
        {
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, fileBytes);

            return response;
        }

        public HttpResponse Error(string errorText)
        {
            var viewContent = $"<div class=\"alert alert-danger\" role=\"alert\">{errorText}</div>";
           
            var responseHtml = PutViewInLayout(viewContent);

            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes, HttpStatusCode.ServerError);
            return response;            
        }

        //public HttpResponse Redirect(string url) 
        //{
        //    var response = new HttpResponse(HttpStatusCode.Found);
        //    response.Headers.Add(new Header("Location", url));
        //    return response;
        //}
        private string PutViewInLayout(string viewContent, object viewModel = null)
        {
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");
            layout = layout.Replace("@RenderBody()", "___VIEW__GOES__HERE__");
            layout = this.viewEngine.GetHtml(layout, viewModel);
            var responseHtml = layout.Replace("___VIEW__GOES__HERE__", viewContent);

            return responseHtml;
        }
    }
}
