using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace AppFom.Helpers
{
    public class SNSUtils
    {
        public enum Platform
        {
            Android,
            IOS,
            WindowsPhone
        }

        private static AWSCredentials _credentials;

        private static AWSCredentials Credentials
        {
            get
            {
                if (_credentials == null)
                    _credentials = new BasicAWSCredentials("AKIAJIBCHW7VSMOEEHCA", "CAitFBKfV2DKJ9KMe2kvt3wVQrrnD5iDJGyNUx7N");// CognitoAWSCredentials(RTD_Config.IdentityPoolId, RTD_Config.CognitoRegion);
                return _credentials;
            }
        }

        private static IAmazonSimpleNotificationService _snsClient;

        private static IAmazonSimpleNotificationService SnsClient
        {
            get
            {
                if (_snsClient == null)
                    _snsClient = new AmazonSimpleNotificationServiceClient(Credentials, Amazon.RegionEndpoint.USEast1);
                return _snsClient;
            }
        }


        public static async Task<String> createPlatformEndpoint(Platform platform, string registrationId)
        {

            // The app arn 
            var arn = string.Empty;

            string _endpointArn = string.Empty;

            switch (platform)
            {
                case Platform.Android:
                    arn = "arn:aws:sns:us-east-1:806044046086:app/GCM/GDLKProdDroid";//DEV
                    break;
                case Platform.IOS:
                    //arn = "arn:aws:sns:us-east-1:806044046086:app/APNS_SANDBOX/GDLKDevPush";//DEV
                    //arn = "arn:aws:sns:us-east-1:806044046086:app/APNS/GDLKProdPush"; //PRO
                    //arn = "arn:aws:sns:us-east-1:806044046086:app/APNS_SANDBOX/GDLKDevPushN";//devnew
                    arn = "arn:aws:sns:us-east-1:806044046086:app/APNS/GDLKRProdPushN";//pronew
                    break;
            }
            //  call create platform endpoint
            var response = await SnsClient.CreatePlatformEndpointAsync(new CreatePlatformEndpointRequest
            {
                Token = registrationId,
                PlatformApplicationArn = arn
            }
            );

            _endpointArn = response.EndpointArn;

            //  store the returned platform endpoint ARN

            // Save to Oracle via service
            //Service in progress

            // Save to local Sqlite DB
            return _endpointArn;

        }


        public static async Task registerWithSNS(Platform platform, string registrationId)
        {

            String endpointArn = await retrieveEndpointArn();

            Boolean updateNeeded = false;
            Boolean createNeeded = (string.Empty == endpointArn);

            if (createNeeded)
            {
                // No platform endpoint ARN is stored; need to call createEndpoint.
                endpointArn = await createPlatformEndpoint(platform, registrationId);
                createNeeded = false;
                await storeEndpointArn(endpointArn);
            }

            //Console.WriteLine("Retrieving platform endpoint data...");
            // Look up the platform endpoint and make sure the data in it is current, even if
            // it was just created.
            try
            {
                GetEndpointAttributesRequest geaReq =
                    new GetEndpointAttributesRequest();
                geaReq.EndpointArn = endpointArn;

                GetEndpointAttributesResponse geaRes = await
                  SnsClient.GetEndpointAttributesAsync(geaReq);

                string token = string.Empty;
                string enabled = string.Empty;

                geaRes.Attributes.TryGetValue("Token", out token);
                geaRes.Attributes.TryGetValue("Enabled", out enabled);

                updateNeeded = !(token == registrationId) || !(enabled == "enabled");

            }
            catch (NotFoundException nfe)
            {
                // We had a stored ARN, but the platform endpoint associated with it
                // disappea2red. Recreate it.
                Debug.WriteLine("Error: " + nfe.Message);
                createNeeded = true;
            }

            if (createNeeded)
            {
                endpointArn = await createPlatformEndpoint(platform, registrationId);
                await storeEndpointArn(endpointArn);
            }

            Debug.WriteLine("updateNeeded = " + updateNeeded);


            if (updateNeeded)
            {
                // The platform endpoint is out of sync with the current data;
                // update the token and enable it.
                Debug.WriteLine("Updating platform endpoint " + endpointArn);

                Dictionary<string, string> attribs = new Dictionary<string, string>();

                attribs.Add("Token", registrationId);
                attribs.Add("Enabled", "true");

                SetEndpointAttributesRequest saeReq =
                    new SetEndpointAttributesRequest();
                saeReq.EndpointArn = endpointArn;
                saeReq.Attributes = attribs;

                await SnsClient.SetEndpointAttributesAsync(saeReq);
                await storeEndpointArn(endpointArn);
            }
        }


        /**
        * @return the ARN the app was registered under previously, or null if no
        *         platform endpoint ARN is stored.
        */
        static async Task<String> retrieveEndpointArn()
        {
            string arnStorage = "123";//Look.Globals.AWSARN;//RTDPersistents.values.Arn;

            if (arnStorage == null)
            {
                arnStorage = string.Empty;
            }

            // Retrieve the platform endpoint ARN from permanent storage,
            // or return null if null is stored.
            return arnStorage;
        }

        /**
        * Stores the platform endpoint ARN in permanent storage for lookup next time.
        * */
        static async Task storeEndpointArn(String endpointArn)
        {
            // Write the platform endpoint ARN to permanent storage.
            //Look.Globals.AWSARN = ""; endpointArn;
            //RTDPersistents.values.Arn = endpointArn;
            //RTDPersistents.Save();
        }

    }
}