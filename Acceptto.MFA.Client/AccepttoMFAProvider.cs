using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Acceptto.MFA.Client
{
    public interface IMFAProvider
    {
        string Authenticate(string message, string mfaEmail, int timeout, string type);
        string Check(string channel, string mfaEmail);
        bool IsUserValid(string mfaEmail);
    }

    public class AccepttoMFAProvider : IMFAProvider
    {
        class AccepttoAuthResponse
        {
            public string channel { get; set; }
        }

        class AccepttoValidResponse
        {
            public bool valid { get; set; }
        }

        class AccepttoCheckResponse
        {
            public string status { get; set; }
        }

        public string MFAUID { get; set; }
        public string MFASecret { get; set; }
        private string MFAServer { get; set; }

        public AccepttoMFAProvider(string _mfaUID, string _mfaSecret)
        {
            this.MFAUID = _mfaUID;
            this.MFASecret = _mfaSecret;
            this.MFAServer = "https://mfa.acceptto.com/";
        }

        public string Authenticate(string message, string mfaEmail, int timeout, string type)
        {
            var client = new RestClient(MFAServer);
            var request = new RestRequest("api/v9/authenticate_with_options", Method.POST);
            request.AddParameter("message", message);
            request.AddParameter("email", mfaEmail);
            request.AddParameter("uid", MFAUID);
            request.AddParameter("secret", MFASecret);
            request.AddParameter("timeout", timeout);
            request.AddParameter("type", type);
            IRestResponse<AccepttoAuthResponse> response = client.Execute<AccepttoAuthResponse>(request);
            return response.Data.channel;
        }

        public string Check(string channel, string mfaEmail)
        {
            var client = new RestClient(MFAServer);
            var request = new RestRequest("api/v9/check", Method.POST);
            request.AddParameter("channel", channel);
            request.AddParameter("email", mfaEmail);
            IRestResponse<AccepttoCheckResponse> response = client.Execute<AccepttoCheckResponse>(request);
            return response.Data.status;
        }

        public bool IsUserValid(string mfaEmail)
        {
            var client = new RestClient(MFAServer);
            var request = new RestRequest("api/v9/is_user_valid", Method.POST);
            request.AddParameter("email", mfaEmail);
            request.AddParameter("uid", MFAUID);
            request.AddParameter("secret", MFASecret);
            IRestResponse<AccepttoValidResponse> response = client.Execute<AccepttoValidResponse>(request);
            return response.Data.valid;
        }
    }
}
