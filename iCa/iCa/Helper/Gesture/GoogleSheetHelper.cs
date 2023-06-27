using Common;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Google.Apis.Sheets.v4.SheetsService;

namespace iCa.Helper.Gesture
{
    public class GoogleSheetHelper
    {
        GoogleCredential credential;
        public SheetsService Service { get; set; }
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        void InitializeService()
        {
            try
            {
                string _resource = GetType().Assembly.GetName().Name + "." + UserConstant.ResourcePath + ".Keys" + "." + UserConstant.GoogleSheetService;
                using (Stream stream = GetType().Assembly.GetManifestResourceStream(_resource))
                {
                    credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
                }
                Service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google sheet working in iCa"
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public GoogleSheetHelper()
        {
            InitializeService();
        }
    }
}
