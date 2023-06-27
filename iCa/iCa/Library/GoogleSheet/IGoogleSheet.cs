using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.GoogleSheet
{
    public interface IGoogleSheet
    {
        void InitializeService();
        GoogleCredential GetCredentialsFromFile();
    }
}
