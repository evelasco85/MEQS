﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public interface IRequestProcessor
    {
        StringBuilder SendRequest(IDictionary<string, string> headers, string acceptContent, string requestUrl, string contentType, string method, StringBuilder bodyData, int timeoutMS);
    }

    public class RequestProcessor : IRequestProcessor
    {
        static IRequestProcessor _processor;

        private RequestProcessor(){}

        public static IRequestProcessor GetInstance()
        {
            if (_processor == null)
                _processor = new RequestProcessor();

            return _processor;
        }
        //public void Process(IRequestBuilder request, int timeoutMS)
        //{
        //    StringBuilder responseData = new StringBuilder();
        //    StringBuilder bodyData = request.GetBodyData();

        //    try
        //    {
        //        string url =  this.GetServiceURL(request);
        //        string acceptType = this._context.Accept;
        //        string contentType = request.GetContentType();
        //        string methodType = Enum.GetName(typeof(BuilderMethod), request.GetMethod());

        //        IDictionary<string, string> headers = ((request.GetHeaderOverrides() == null) || (request.GetHeaderOverrides().Count == 0)) ? this._context.HeadersDictionary : request.GetHeaderOverrides();

        //        request.SetCompleteRequestUrl(url);

        //        responseData = this.ProcessRequest(headers, acceptType, url, contentType, methodType, bodyData, timeoutMS);

        //        request.SetResponseData(responseData);
        //    }
        //    catch(Exception ex)
        //    {
        //        ex.Data.Add("Body Data", bodyData.ToString());
        //        throw ex;
        //    }
        //}

        public StringBuilder SendRequest(IDictionary<string, string> headers, string acceptContent, string requestUrl, string contentType, string method, StringBuilder bodyData, int timeoutMS)
        {
            return this.ProcessRequest(headers, acceptContent, requestUrl, contentType, method, bodyData, timeoutMS);
        }

        StringBuilder ProcessRequest(IDictionary<string, string> headers, string acceptContent, string requestUrl, string contentType, string method, StringBuilder bodyData, int timeoutMS)  
        {
            StringBuilder responseData = new StringBuilder();
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            byte[] contentBytes = null;

            if (!string.IsNullOrEmpty(contentType))
                request.ContentType = contentType;

            request.Method = method;
            request.Accept = acceptContent;

            if (contentBytes != null)
                request.ContentLength = contentBytes.Length;

            request.ServicePoint.Expect100Continue = false;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.90 Safari/537.36";
            request.UnsafeAuthenticatedConnectionSharing = true;
            request.KeepAlive = true;
            request.AllowAutoRedirect = true;

            Debug.WriteLine(request);

            if (timeoutMS > 0)
                request.Timeout = timeoutMS;

            if ((headers != null) && (headers.Count > 0))
            {
                IList<KeyValuePair<string, string>> iteratedHeaders = headers.ToList();

                for (int index = 0; index < iteratedHeaders.Count; index++)
                {
                    string headerName = iteratedHeaders[index].Key;
                    string headerValue = iteratedHeaders[index].Value;

                    request.Headers.Add(headerName, headerValue);
                    
                }
            }

            if((bodyData != null) && (bodyData.Length > 0))
            {
                contentBytes = System.Text.Encoding.ASCII.GetBytes(bodyData.ToString());

                using(Stream requestWriter = request.GetRequestStream())
                {
                    requestWriter.Write(contentBytes, 0, contentBytes.Length);
                }
            }

            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                using (StreamReader responseReader = new StreamReader(response.GetResponseStream()))
                {
                    responseData.Append(responseReader.ReadToEnd());
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse response = ex.Response as HttpWebResponse;
                StringBuilder responseExceptionData = new StringBuilder();

                using (StreamReader responseReader = new StreamReader(response.GetResponseStream()))
                {
                    responseExceptionData.Append(responseReader.ReadToEnd());
                }

                ex.Data.Add("ResponseException", responseExceptionData.ToString());

                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return responseData;
        }
    }
}
