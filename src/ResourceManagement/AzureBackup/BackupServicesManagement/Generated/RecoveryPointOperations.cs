// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.BackupServices
{
    /// <summary>
    /// Definition of Recovery Point operations for the Azure Backup extension.
    /// </summary>
    internal partial class RecoveryPointOperations : IServiceOperations<BackupServicesManagementClient>, IRecoveryPointOperations
    {
        /// <summary>
        /// Initializes a new instance of the RecoveryPointOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal RecoveryPointOperations(BackupServicesManagementClient client)
        {
            this._client = client;
        }
        
        private BackupServicesManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.BackupServices.BackupServicesManagementClient.
        /// </summary>
        public BackupServicesManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Get the recovery point.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='resourceName'>
        /// Required.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <param name='containerName'>
        /// Optional.
        /// </param>
        /// <param name='itemName'>
        /// Optional.
        /// </param>
        /// <param name='recoveryPointName'>
        /// Optional.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The definition of a CSMRecoveryPointGetOperationResponse.
        /// </returns>
        public async Task<CSMRecoveryPointGetOperationResponse> GetAsync(string resourceGroupName, string resourceName, CustomRequestHeaders customRequestHeaders, string containerName, string itemName, string recoveryPointName, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (resourceName == null)
            {
                throw new ArgumentNullException("resourceName");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("resourceName", resourceName);
                tracingParameters.Add("customRequestHeaders", customRequestHeaders);
                tracingParameters.Add("containerName", containerName);
                tracingParameters.Add("itemName", itemName);
                tracingParameters.Add("recoveryPointName", recoveryPointName);
                TracingAdapter.Enter(invocationId, this, "GetAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/";
            url = url + "Microsoft.Backup";
            url = url + "/";
            url = url + "BackupVault";
            url = url + "/";
            url = url + Uri.EscapeDataString(resourceName);
            url = url + "/registeredContainers/";
            if (containerName != null)
            {
                url = url + Uri.EscapeDataString(containerName);
            }
            url = url + "/protectedItems/";
            if (itemName != null)
            {
                url = url + Uri.EscapeDataString(itemName);
            }
            url = url + "/recoveryPoints/";
            if (recoveryPointName != null)
            {
                url = url + Uri.EscapeDataString(recoveryPointName);
            }
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2014-09-01");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("Accept-Language", "en-us");
                httpRequest.Headers.Add("x-ms-client-request-id", customRequestHeaders.ClientRequestId);
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    CSMRecoveryPointGetOperationResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new CSMRecoveryPointGetOperationResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            CSMRecoveryPointResponse cSMRecoveryPointResponseInstance = new CSMRecoveryPointResponse();
                            result.CSMRecoveryPointResponse = cSMRecoveryPointResponseInstance;
                            
                            JToken propertiesValue = responseDoc["properties"];
                            if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                            {
                                CSMRecoveryPointProperties propertiesInstance = new CSMRecoveryPointProperties();
                                cSMRecoveryPointResponseInstance.Properties = propertiesInstance;
                                
                                JToken recoveryPointTypeValue = propertiesValue["recoveryPointType"];
                                if (recoveryPointTypeValue != null && recoveryPointTypeValue.Type != JTokenType.Null)
                                {
                                    string recoveryPointTypeInstance = ((string)recoveryPointTypeValue);
                                    propertiesInstance.RecoveryPointType = recoveryPointTypeInstance;
                                }
                                
                                JToken recoveryPointTimeValue = propertiesValue["recoveryPointTime"];
                                if (recoveryPointTimeValue != null && recoveryPointTimeValue.Type != JTokenType.Null)
                                {
                                    DateTime recoveryPointTimeInstance = ((DateTime)recoveryPointTimeValue);
                                    propertiesInstance.RecoveryPointTime = recoveryPointTimeInstance;
                                }
                                
                                JToken recoveryPointAdditionalInfoValue = propertiesValue["recoveryPointAdditionalInfo"];
                                if (recoveryPointAdditionalInfoValue != null && recoveryPointAdditionalInfoValue.Type != JTokenType.Null)
                                {
                                    string recoveryPointAdditionalInfoInstance = ((string)recoveryPointAdditionalInfoValue);
                                    propertiesInstance.RecoveryPointAdditionalInfo = recoveryPointAdditionalInfoInstance;
                                }
                            }
                            
                            JToken idValue = responseDoc["id"];
                            if (idValue != null && idValue.Type != JTokenType.Null)
                            {
                                string idInstance = ((string)idValue);
                                cSMRecoveryPointResponseInstance.Id = idInstance;
                            }
                            
                            JToken nameValue = responseDoc["name"];
                            if (nameValue != null && nameValue.Type != JTokenType.Null)
                            {
                                string nameInstance = ((string)nameValue);
                                cSMRecoveryPointResponseInstance.Name = nameInstance;
                            }
                            
                            JToken typeValue = responseDoc["type"];
                            if (typeValue != null && typeValue.Type != JTokenType.Null)
                            {
                                string typeInstance = ((string)typeValue);
                                cSMRecoveryPointResponseInstance.Type = typeInstance;
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Get the list of all recovery points.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='resourceName'>
        /// Required.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <param name='containerName'>
        /// Optional.
        /// </param>
        /// <param name='itemName'>
        /// Optional.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The definition of a CSMRecoveryPointListOperationResponse.
        /// </returns>
        public async Task<CSMRecoveryPointListOperationResponse> ListAsync(string resourceGroupName, string resourceName, CustomRequestHeaders customRequestHeaders, string containerName, string itemName, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (resourceName == null)
            {
                throw new ArgumentNullException("resourceName");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("resourceName", resourceName);
                tracingParameters.Add("customRequestHeaders", customRequestHeaders);
                tracingParameters.Add("containerName", containerName);
                tracingParameters.Add("itemName", itemName);
                TracingAdapter.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/";
            url = url + "Microsoft.Backup";
            url = url + "/";
            url = url + "BackupVault";
            url = url + "/";
            url = url + Uri.EscapeDataString(resourceName);
            url = url + "/registeredContainers/";
            if (containerName != null)
            {
                url = url + Uri.EscapeDataString(containerName);
            }
            url = url + "/protectedItems/";
            if (itemName != null)
            {
                url = url + Uri.EscapeDataString(itemName);
            }
            url = url + "/recoveryPoints";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2014-09-01");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("Accept-Language", "en-us");
                httpRequest.Headers.Add("x-ms-client-request-id", customRequestHeaders.ClientRequestId);
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    CSMRecoveryPointListOperationResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new CSMRecoveryPointListOperationResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            CSMRecoveryPointListResponse cSMRecoveryPointListResponseInstance = new CSMRecoveryPointListResponse();
                            result.CSMRecoveryPointListResponse = cSMRecoveryPointListResponseInstance;
                            
                            JToken valueArray = responseDoc["value"];
                            if (valueArray != null && valueArray.Type != JTokenType.Null)
                            {
                                foreach (JToken valueValue in ((JArray)valueArray))
                                {
                                    CSMRecoveryPointResponse cSMRecoveryPointResponseInstance = new CSMRecoveryPointResponse();
                                    cSMRecoveryPointListResponseInstance.Value.Add(cSMRecoveryPointResponseInstance);
                                    
                                    JToken propertiesValue = valueValue["properties"];
                                    if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                                    {
                                        CSMRecoveryPointProperties propertiesInstance = new CSMRecoveryPointProperties();
                                        cSMRecoveryPointResponseInstance.Properties = propertiesInstance;
                                        
                                        JToken recoveryPointTypeValue = propertiesValue["recoveryPointType"];
                                        if (recoveryPointTypeValue != null && recoveryPointTypeValue.Type != JTokenType.Null)
                                        {
                                            string recoveryPointTypeInstance = ((string)recoveryPointTypeValue);
                                            propertiesInstance.RecoveryPointType = recoveryPointTypeInstance;
                                        }
                                        
                                        JToken recoveryPointTimeValue = propertiesValue["recoveryPointTime"];
                                        if (recoveryPointTimeValue != null && recoveryPointTimeValue.Type != JTokenType.Null)
                                        {
                                            DateTime recoveryPointTimeInstance = ((DateTime)recoveryPointTimeValue);
                                            propertiesInstance.RecoveryPointTime = recoveryPointTimeInstance;
                                        }
                                        
                                        JToken recoveryPointAdditionalInfoValue = propertiesValue["recoveryPointAdditionalInfo"];
                                        if (recoveryPointAdditionalInfoValue != null && recoveryPointAdditionalInfoValue.Type != JTokenType.Null)
                                        {
                                            string recoveryPointAdditionalInfoInstance = ((string)recoveryPointAdditionalInfoValue);
                                            propertiesInstance.RecoveryPointAdditionalInfo = recoveryPointAdditionalInfoInstance;
                                        }
                                    }
                                    
                                    JToken idValue = valueValue["id"];
                                    if (idValue != null && idValue.Type != JTokenType.Null)
                                    {
                                        string idInstance = ((string)idValue);
                                        cSMRecoveryPointResponseInstance.Id = idInstance;
                                    }
                                    
                                    JToken nameValue = valueValue["name"];
                                    if (nameValue != null && nameValue.Type != JTokenType.Null)
                                    {
                                        string nameInstance = ((string)nameValue);
                                        cSMRecoveryPointResponseInstance.Name = nameInstance;
                                    }
                                    
                                    JToken typeValue = valueValue["type"];
                                    if (typeValue != null && typeValue.Type != JTokenType.Null)
                                    {
                                        string typeInstance = ((string)typeValue);
                                        cSMRecoveryPointResponseInstance.Type = typeInstance;
                                    }
                                }
                            }
                            
                            JToken nextLinkValue = responseDoc["nextLink"];
                            if (nextLinkValue != null && nextLinkValue.Type != JTokenType.Null)
                            {
                                string nextLinkInstance = ((string)nextLinkValue);
                                cSMRecoveryPointListResponseInstance.NextLink = nextLinkInstance;
                            }
                            
                            JToken idValue2 = responseDoc["id"];
                            if (idValue2 != null && idValue2.Type != JTokenType.Null)
                            {
                                string idInstance2 = ((string)idValue2);
                                cSMRecoveryPointListResponseInstance.Id = idInstance2;
                            }
                            
                            JToken nameValue2 = responseDoc["name"];
                            if (nameValue2 != null && nameValue2.Type != JTokenType.Null)
                            {
                                string nameInstance2 = ((string)nameValue2);
                                cSMRecoveryPointListResponseInstance.Name = nameInstance2;
                            }
                            
                            JToken typeValue2 = responseDoc["type"];
                            if (typeValue2 != null && typeValue2.Type != JTokenType.Null)
                            {
                                string typeInstance2 = ((string)typeValue2);
                                cSMRecoveryPointListResponseInstance.Type = typeInstance2;
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
