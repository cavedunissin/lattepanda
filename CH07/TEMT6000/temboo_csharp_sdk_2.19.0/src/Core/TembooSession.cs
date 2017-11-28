using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;

/*
Copyright 2014 Temboo, Inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

namespace Temboo.Core
{
	/// <summary>
	/// TembooSession represents a set of valid Temboo credentials, comprised of a Temboo Account Name,
	/// Application Name, and Application Key. 
	/// This object also contains generic utility functions used to make requests to the Temboo platform.
	/// </summary>
	public class TembooSession
	{
		private String accountName, application, applicationKey;

		public TembooSession (String accountName, String application, String applicationKey)
		{
			this.accountName = accountName;
			this.application = application;
			this.applicationKey = applicationKey;
		}

		/// <summary>
		/// Gets the name of the Temboo Account.
		/// </summary>
		/// <value>The name of the account.</value>
		public String AccountName 
		{	
			get { return accountName; } 
		}

		/// <summary>
		/// Gets the encoded credentials, used to construct the HTTP Authentication header.
		/// </summary>
		/// <value>The encoded credentials.</value>
		protected String EncodedCredentials 
		{
			get 
			{
				return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(this.application + ":" + this.applicationKey));
			}
		}

		/// <summary>
		/// Make a well-formed HTTPS request to the Temboo platform, and return the content of the response body
		/// </summary>
		/// <returns>The request body.</returns>
		/// <param name="httpMethod">Http method to use when making the request, one of GET or POST.</param>
		/// <param name="url">The relative URL path to which the request should be made.</param>
		/// <param name="payload">The content of the payload, if any, to be sent with the POST request.</param>
		public String makeRequest(String httpMethod, String url, String payload)
		{
			// Set up the HTTP web request, including authentication headers
			HttpWebRequest client = (HttpWebRequest)WebRequest.Create (url);
			client.Timeout = 900000;
			client.Method = httpMethod;
			client.ContentType = "application/json";
			client.Accept = "application/json";
			client.Headers.Add ("x-temboo-domain", "/" + this.AccountName + "/master");
			client.Headers.Add ("Authorization", "Basic " + this.EncodedCredentials);

			var responseValue = string.Empty;
			HttpWebResponse response = null;

			try {
				// Send POST body, if applicable
				if(payload != null) {
					var bytes = Encoding.GetEncoding ("UTF-8").GetBytes (payload);
					using (var writeStream = client.GetRequestStream ()) {
						writeStream.Write (bytes, 0, bytes.Length);
					}
				}
					
				// Get the response object
				response = (HttpWebResponse) client.GetResponse();

			} catch (WebException e) {
				// If a DNS error occurred, return a friendlier message
				if (e.Status == WebExceptionStatus.NameResolutionFailure) 
				{
					TembooException te = new TembooException (
						"Unable to connect to Temboo. Make sure that your Temboo account name is correct and that a network connection is available.");
					throw te;
				}

				// Get the error response object
				response = (HttpWebResponse)e.Response;

				// Try to provide a more useful error
				if (response.StatusCode == HttpStatusCode.Unauthorized) 
				{
					TembooException te = new TembooException (
						"Authentication failed. Make sure that your Temboo account name, application, and application key are correct.");
					throw te;
				}
			} 

			// Read and return the response body
			using (var responseStream = response.GetResponseStream())
			{
				if (responseStream != null)
					using (var reader = new StreamReader(responseStream))
					{
						responseValue = reader.ReadToEnd();
					}
			}
			return responseValue;
		}
	}
}

