﻿using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LMConnect.WebApi.API;

namespace LMConnect.Web.API
{
	public class XmlResult : ActionResult
	{
		public Encoding ContentEncoding { get; set; }

		public string ContentType { get; set; }

		public Response Data { get; set; }

		public override void ExecuteResult(ControllerContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}

			HttpResponseBase response = context.HttpContext.Response;

			if (!String.IsNullOrEmpty(ContentType))
			{
				response.ContentType = ContentType;
			}
			else
			{
				response.ContentType = "text/xml";
			}

			if (ContentEncoding != null)
			{
				response.ContentEncoding = ContentEncoding;
			}

			if (this.Data != null)
			{
				this.Data.WriteToStream(response.OutputStream);
			}
		}
	}
}
