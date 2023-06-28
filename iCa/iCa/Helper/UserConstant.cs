using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Common
{
    public class UserConstant
    {
        public const string LoginUri = "https://api0.acis.com.vn";
        //public const string LoginUri = "https://bkapi0.acis.com.vn";
        public const string LoginHardKey = "A-/kF78)qf{L3D&g";
        public const string HardAPI0 = "7fcs2ySY[M5z4YHJ";
        public const string SQLFileName = "ESCollection.sqlite";
        public const string True = "true";
        public const string False = "false";
        public const string NoExist = "NoExist";
        public const string Exist = "Exist";
        public const string WeightUnit = "KG";
        public const string Spreadsheet_id = "1akX44a9ztYJ96AzILUuFyCvB1cGr2gC3EQYwl4fw0dE";

        public const int SmallUIDelayMs = 10;
        public const int DelayCanView = 1500;
        public const int LearnDeviceTimeout = 60;

        public const int WaitStepTime = 10; // 10 ms
        public const int WaitStepCnt = 300; // waiting 300 time of 10 ms
        public const int WaitStepDeviceCnt = 20; // waiting 20 time of 10 ms

        public const int WaitStepLowPowerCnt = 800; // waiting 800 time of 10 ms

        public const string STORE = "STORE";

        public const int LoginAPIVersion = 1;
        public const int APIVersion = 1;

        public const string Connect = "CONNECT";
        public const string Disconnect = "DISCONNECT";

        public const string NoConnectString = "NoConnect";

        public const int KeepAliveCloudTO = 10000;
        public const int CheckNetworkInterval = 5000;

        #region Delay value
        public const int DelayUI = 200;
        public const int SmallDelayUI = 10;
        public const int RoomDlyMul = 10;
        public const int DeviceDlyMul = 2;
        public const int SceneDlyMul = 2;
        public const int TimeoutFail = 5;

        public const int MaxTimeoutService = 10000;
        public const int MinTimeoutService = 4000;
        public const int TCPKeepAliveTime = 120;

        // Version info
        //public const string Version = "2";
        //public const string Reversion = "8";
        //public const string Build = "47";
        public const string VersionId = "1";
        #endregion

        #region FTP info
        // ftp info
        public const string FtpServerAddDF = "ftp://sto.acis.com.vn";
        public const string FtpUserNameDF = "UpDqzL23Ra";
        public const string FtpPassDF = "Fs3[Szr93Zaq2G3U";
        #endregion
        // Background default
        public const string RoomBackground = "room.jpg";
        public const string NoRoomLightBackground = "no_room_light.jpg";
        public const string NoRoomDarkBackground = "no_room_dark.png";
        public const string SceneDefaultIcon = "ic_scene.svg";
        public const string RoomBackgroundTail = "jpg";
        public const string ResourcePath = "Resources";
        public const string SoundPath = "Sounds";
        public const string ClickFileName = "Click.wav";

        public const int Symetry = 0;
        public const int FreeTransfrom = 1;
        public const int Line = 2;

        #region Max info
        public const int MaxSceneInRoom = 5;
        #endregion

        #region Info
        public const string AppName = "ihome";
        public const string MessageWelcomeCode = "welc";
        public const string MessageDeviceCode = "devi";
        public const string MessageSceneCode = "scen";
        public const string MessageNotiCode = "noti";
        public const string MessageSettingCode = "sett";
        public const string MessageAboutCode = "abou";
        public const string LangEn = "en";
        public const string langVn = "vi";
        public const string ServiceName = "sma";
        public const string GoogleSheetService = "googlesheet.json";

        public const string MCERecManualCode = "ugmcerec";
        public const string MCECirManualCode = "ugmcecir";
        public const string RERecOledManualCode = "ugrerecoled";
        public const string RERecManualCode = "ugrerec";
        public const string SSWRecManualCode = "ugsswrec";
        public const string SSWSqManualCode = "ugsswsq";
        public const string IRCirManualCode = "ugircir";
        public const string IRRecManualCode = "ugirrec";
        public const string DCManualCode = "ugdc";
        public const string ALEManualCode = "ugale";
        public const string REMManualCode = "ugrem";
        public const string AppManualCode = "ugapp";
        public const string CompanyAddressCode = "cpnaddr";
        public const string CompanyHotlineCode = "cpnhotline";
        public const string CompanyWebsiteCode = "cpnwebsite";
        #endregion

        public const string ON = "ON";
        public const string OFF = "OFF";
        public const string LAST = "LST";
        public const string XX = "XX";
        public const string OPEN = "OPEN";
        public const string CLOSE = "CLOSE";
        public const string LOCK = "LOCK";
        public const string UNLOCK = "UNLOCK";

        public const int PictureMaxSize = 1024 * 1536;

        public const string NA = "NA";
        public const int NAVALUE = int.MinValue;

        public const int MaxTimerPoint = 4;

        public const int API0Version = 1;
        public const int API1Version = 1;
        public const int API1ZipVersion = 2;

        public const int MinHistoryMonthPre = -1;
    }


    public enum DeviceType
    {
        OnOff,
        Door,
        Curtain,
        Dimer,
        AirCon,
        TV,
        CAM
    }
    public class DeviceCode
    {
        public const string RE4 = "RE4";
        public const string RE3 = "RE3";
        public const string RE2 = "RE2";
        public const string IR = "IR";
        public const string DC = "DC";
        public const string DC2 = "DC2";
        public const string DI1 = "DI1";
        public const string SB6 = "SB6";
        public const string ALE = "ALE";
        public const string REM = "REM";
        public const string SCENE = "SCRIPT";
        public const string APP = "APP";
        public const string SERVER = "SER";
        public const string GW = "MCE";
        public const string CAM = "CAM";
        public const string DL = "DL";

        public const string DI2 = "DI2";
        public const string SE = "SE";
        public const string RGB = "RGB";
        public const string DSE = "DSE";
        public const string PIR = "PIR";

        public const string BSP = "BSP";

        public const string SO = "SO";
        public const string SO2 = "SO2";
        public const string DR2 = "DR2";

        public const string AICAM = "AICAM";


        public const int Symetry = 0;
        public const int FreeTransfrom = 1;
        public const int Line = 2;
    }

    public class DeviceMaxChannel
    {
        public const int RE4 = 4;
        public const int RE3 = 3;
        public const int RE2 = 2;
        public const int SO = 2;
        public const int SO2 = 2;

        public const int IR = 4;
        public const int DC = 1;
        public const int DC2 = 2;
        public const int CAM = 1;

        public const int SE = 1;
        public const int RGB = 1;
        public const int DSE = 1;
        public const int PIR = 1;

        public const int DI2 = 2;
        public const int DI1 = 1;

        public const int BSP = 10;
        public const int REM = 12;

        public const int DR2 = 3;
    }

    public class BSPMaxChannel
    {
        public const int ONOFF = 4;
        public const int DIM = 2;
        public const int DC = 2;
        public const int IR = 1;
    }
    public enum ChannelType
    {
        OnOff,
        AirCon,
        TV,
        Fan,
        Projector,
        IRDefault,
        Door,
        Curtain,
        Camera,
        Dimmer,
        RGB,
        TempHumi,
        DSE,
        PIR,
        REM,
        ALE,
        DL,
        Door1Wing,
        Door2Wing,
        Speaker,
        AICamera,
        GW
    }
    public class SpecialDeviceType
    {
        public const string TV = "TV";
        public const string AirCon = "AC";
        public const string Curtain = "CT";
        public const string Door = "DO";
        public const string Camera = "CA";
        public const string Fan = "FA";
        public const string Projector = "PR";
        public const string IRDefault = "ID";
        public const string OnOff = "OF";
        public const string Dimmer = "DI";
        public const string TempHumi = "TH";
        public const string DoorSensor = "DSE";
        public const string DoorLock = "DL";
        public const string Door1Wing = "D1W";
        public const string Door2Wing = "D2W";
        public const string Speaker = "SPK";
    }

    public class TPUserCode
    {
        public const string GoogleHome = "GGHOME";
        public const string GoogleAssistant = "GGASSIST";
    }
    public enum LightIconSharpType
    {
        Symetry,
        FreeTransform,
        Line
    }

    public enum CheckResponseStatus
    {
        OK,
        Fail
    }

    public enum TypeRE
    {
        OLED,
        RE,
        SSW,
    }
    public enum SettingType
    {
        ChangeInfo,
        DeleteUserPermanent,
        CloneMCE,
        ControlDC
    }

    public enum SetTimeTypeEnum
    {
        AutoOff,
        BuzzerBip,
        GMT,
        Remind,
        Dimmer,
        LedNums,
        ChangeStepNum,
    }
    public enum CameraFormatLinkEnum
    {
        /// <summary>
        /// For regular cam
        /// </summary>
        Regular,
        /// <summary>
        /// Cam of TP
        /// </summary>
        TP,
        /// <summary>
        /// Else
        /// </summary>
        Else
    }

    public class KeyboardType
    {
        public const string Numberic = "Numberic";
        public const string Default = "Default";
        public const string Chat = "Chat";
        public const string Email = "Email";
        public const string Plain = "Plain";
        public const string Telephone = "Telephone";
        public const string Text = "Text";
        public const string Url = "Url";
    }

    public enum VerifyCodeType
    {
        Signup,
        ForgotPassword
    }

    public enum AlertType
    {
        Error,
        Notification,
        Warning,
        Success
    }
    public enum PopupType
    {
        NoConnection,
        DownloadFileSetup,
        RetryRefresh,
        None
    }

    public class ProductCode
    {
        public const string Cobia = "Cobia";
        public const string StingRay = "StingRay";
        public const string Basa = "Basa";
        public const string Salmon = "Salmon";
    }
}
