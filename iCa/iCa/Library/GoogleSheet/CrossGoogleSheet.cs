using Common;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Plugin.GoogleSheet
{
    public class CrossGoogleSheet
    {
        //private void InitializeService()
        //{
        //    var credential = GetCredentialsFromFile();
        //    Service = new SheetsService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = APPLICATION_NAME
        //    });
        //}
        //private GoogleCredential GetCredentialsFromFile()
        //{
        //    string _resource = GetType().Assembly.GetName().Name + "." + UserConstant.ResourcePath + ".Keys" + "." + UserConstant.GoogleSheetService;
        //    GoogleCredential credential;
        //    using (var stream = new FileStream(_resource, FileMode.Open, FileAccess.Read))
        //    {
        //        credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
        //    }
        //    return credential;
        //}


        static Lazy<IGoogleSheet> Implementation = new Lazy<IGoogleSheet>(() => InitializeService(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Current settings to use
        /// </summary>
        public static IGoogleSheet Current
        {
            get
            {
                var ret = Implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        static IGoogleSheet InitializeService()
        {
            return Xamarin.Forms.DependencyService.Get<IGoogleSheet>();
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}
