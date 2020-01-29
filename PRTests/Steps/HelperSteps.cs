using TechTalk.SpecFlow;
using Zonal.App.Shell.PRTests.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Zonal.App.Shell.PRTests.Steps
{
    [Binding]
    public sealed class HelperSteps
    {
        private readonly RestHelper _restHelper = new RestHelper();

        public void EnsureClockedInState()
        {
            var operatorIds = new List<Guid>
            {
                Guid.Parse("a27ec000-0000-0000-0000-300001000023"), // PIN: 7322; Name: Tess Jacobs
            };
            var roleId = Guid.Parse("a27ec000-0000-0000-0000-300001000023");
            var status = "ClockedIn";
            var defaultPaymentLocation = "CashDrawer";

            SetOperatorsStatus(operatorIds, roleId, status, defaultPaymentLocation);
        }

        public void SetOperatorsStatus(List<Guid> operatorIds, Guid roleId, string status, string defaultPaymentLocation)
        {
            var businessId = Guid.Parse("bc0230f9-70ed-4879-b84d-1a2697a1445d");
            var siteId = Guid.Parse("53a6e421-2ce4-410a-993c-ad1a58c05cd8"); // 3430 Third Avenue
            var lastUpdatedTime = "2019-07-10T08:04:58Z";

            foreach (var operatorId in operatorIds)
            {
                _restHelper.CreateRequest(Method.PUT);
                _restHelper.AddBody(new
                {
                    status,
                    defaultPaymentLocation,
                    lastUpdatedTime,
                    roleId
                });

                var operatorBaseUrl = "https://aks1.znl-dev03.com/int/api/operator";
                var endpoint = $"/v2/businesses/{businessId}/sites/{siteId}/operators/{operatorId}/status";
                _restHelper.SetUrl(operatorBaseUrl, endpoint);
                var response = _restHelper.ExecuteRequest();
                if (!response.IsSuccessful)
                {
                    throw new Exception(response.ErrorMessage);
                }
            }
        }
    }
}