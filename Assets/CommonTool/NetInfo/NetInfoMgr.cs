/***
 * 
 * 
 * 网络信息控制
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Runtime.InteropServices;
using Unity.VisualScripting.FullSerializer;
//using MoreMountains.NiceVibrations;

public class NetInfoMgr : MonoBehaviour
{
    public static NetInfoMgr instance;
    //base
    public string BaseUrl;
    //登录url
    public string BaseLoginUrl;
    //配置url
    public string BaseConfigUrl;
    //时间戳url
    public string BaseTimeUrl;

    public string GameCode = "21159";

    //channel
#if UNITY_IOS
    private string Channel = "AppStore";
#elif UNITY_ANDROID
    private string Channel = "GooglePlay";
#else
    private string Channel = "GooglePlay";
#endif
    //private string PackageName = "com.enjoymerge.match3aqua";
    private string PackageName { get { return Application.identifier; } }

    //登录url
    private string LoginUrl = "";
    //配置url
    private string ConfigUrl = "";
    public string country = "";
    public ServerData NetServerData;
    public Init InitData;
    public GameData gameData;
    public FlyBubble gameFlyData;
    public KeyValuesUpdate flyreward;
    public GameObject adManager;
    [HideInInspector]
    public string gaid;
    [HideInInspector]
    public string aid;
    [HideInInspector]
    public string idfa;
    int ready_count = 0;
    public bool ready = false;
    public List<string> paypal_country = new List<string>(new string[] {"US", "BR", "PH", "TH", "MY", "IN", "VN", "AR", "CO", "VE", "PE", "ZA", "CL", "BO", "MX", "EG", "MA" });
//#if UNITY_IOS
//    [DllImport("__Internal")]
//    internal extern static void getIDFA();
//#endif

    //更新AdjustId url
    private string AdjustUrl = "";
    //更新AdjustId url
    public string BaseAdjustUrl;

    //服务器Config数据
    public ServerData ConfigData;

    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        instance = this;
        LoginUrl = BaseLoginUrl + GameCode + "&channel=" + Channel + "&version=" + Application.version;
        ConfigUrl = BaseConfigUrl + GameCode + "&channel=" + Channel + "&version=" + Application.version;
        AdjustUrl = BaseAdjustUrl + GameCode;
    }
    private void Start()
    {

        //Login();
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
            p.Call("getGaid");
            p.Call("getAid");
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
#if UNITY_IOS
            Login("");
#endif
        }
        else
        {
            Login("aaa");
            GetServerData();
        }
    }

    ///// <summary>
    ///// 登录
    ///// </summary>
    public void gaidAction(string gaid_str)
    {
        Debug.Log("unity收到gaid：" + gaid_str);
        gaid = gaid_str;
        ready_count++;
        if (ready_count == 2)
        {
            Debug.Log("Start Login");
            Login(gaid, aid);
            GetServerData();
        }
    }
    public void aidAction(string aid_str)
    {
        Debug.Log("unity收到aid：" + aid_str);
        aid = aid_str;
        ready_count++;
        if (ready_count == 2)
        {
            Debug.Log("Start Login");
            Login(gaid, aid);
            GetServerData();
        }
    }
    public void idfaSuccess(string message)
    {
        Debug.Log("idfa success:" + message);
        idfa = message;
        Login(message);
        GetServerData();
    }
    public void idfaFail(string message)
    {
        Debug.Log("idfa fail");
        Login("");
        GetServerData();
    }
    /// <summary>
    /// 登录
    /// </summary>
    public void Login(string value1 = "", string value2 = "")
    {
        if (value1 != "")
        {
            SaveDataManager.SetString("LoginValue1", value1);
        }
        else
        {
            value1 = SaveDataManager.GetString("LoginValue1");
            if (value1 == "")
            {
                value1 = "aaa";
            }
        }
        if (value2 != "")
        {
            SaveDataManager.SetString("LoginValue2", value2);
        }
        else
        {
            value2 = SaveDataManager.GetString("LoginValue2");
        }
        Debug.Log("Login");
        //本地存储的服务器id
        string serverId = SaveDataManager.GetString(CConfig.sv_LocalServerId);
        if (serverId == "" || serverId.Length == 0)
        {
            string localId = SaveDataManager.GetString(CConfig.sv_LocalUserId);
            //空用户id
            if (localId == "" || localId.Length == 0)
            {
                SaveDataManager.SetString("sign_version", Application.version);
                //生成用户id
                TimeSpan st = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
                string timeStr = Convert.ToInt64(st.TotalSeconds).ToString() + UnityEngine.Random.Range(0, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString();
                localId = timeStr;
                SaveDataManager.SetString(CConfig.sv_LocalUserId, localId);
            }
            string url = "";
            if (value2 == "")
            {
                url = LoginUrl + "&" + "randomKey" + "=" + localId + "&idfa=" + value1 + "&packageName=" + PackageName;
            }
            else
            {
                url = LoginUrl + "&" + "randomKey" + "=" + localId + "&gaid=" + value1 + "&androidId=" + value2 + "&packageName=" + PackageName;
            }

            getCountry(() => {
                url += "&country=" + country;
                StartCoroutine(NetWorkTimeOut(() =>
                {
                    GetLoactionData();
                }));
                NetWorkManager.GetInstance().HttpGet(url,
                    (data) => {
                        Debug.Log("Login 成功" + data.downloadHandler.text);
                        SaveDataManager.SetString("init_time", DateTime.Now.ToString());
                        ServerUserData serverUserData = JsonMapper.ToObject<ServerUserData>(data.downloadHandler.text);
                        SaveDataManager.SetString(CConfig.sv_LocalServerId, serverUserData.data.ToString());
                        GetServerData();
                    },
                    () => {
                        Debug.Log("Login 失败");
                    });
            });
        }
        else
        {
            GetServerData();
        }
    }

    private void getCountry(Action cb)
    {
        if (string.IsNullOrEmpty(country))
        {
            NetWorkManager.GetInstance().HttpGet("https://a.mafiagameglobal.com/event/country/", (data) =>
            {

                country = JsonMapper.ToObject<Dictionary<string, string>>(data.downloadHandler.text)["country"];
                //country = "TH";
                Debug.Log("获取国家 成功:" + country);
                cb?.Invoke();
            },
            () => {
                Debug.Log("获取国家 失败");
                cb?.Invoke();
            });
        }
        else
        {
            cb?.Invoke();
        }
    }

    /// <summary>
    /// 获取服务器数据
    /// </summary>
    private void GetServerData()
    {
        getCountry(null);
        StartCoroutine(NetWorkTimeOut(() =>
        {
            GetLoactionData();
        }));
        NetWorkManager.GetInstance().HttpGet(ConfigUrl,
        (data) => {
            Debug.Log("ServerData 成功" + data.downloadHandler.text);
            SaveDataManager.SetString("OnlineData", data.downloadHandler.text);
            RootData rootData = JsonMapper.ToObject<RootData>(data.downloadHandler.text);

            if (NetServerData == null)
            {
                NetServerData = rootData.data;
                InitData = JsonMapper.ToObject<Init>(NetServerData.init);
                GetGameData();
                //PostEventScript.GetInstance().SendEvent("1002", "0");
                adManager.SetActive(true);
                ready = true;
            }
        },
        () => {
            Debug.Log("ServerData 失败");
        });
    }
    private void GetLoactionData()
    {
        RootData rootData;
        if (SaveDataManager.GetString("OnlineData") == "" || SaveDataManager.GetString("OnlineData").Length == 0)
        {
            Debug.Log("本地网络数据");
            TextAsset json = Resources.Load<TextAsset>("LocationJson/LocationData");
            rootData = JsonMapper.ToObject<RootData>(json.text);
        }
        else
        {
            Debug.Log("本地数据");
            rootData = JsonMapper.ToObject<RootData>(SaveDataManager.GetString("OnlineData"));
        }
        if (NetServerData == null)
        {
            Debug.Log("使用本地数据");
            NetServerData = rootData.data;
            InitData = JsonMapper.ToObject<Init>(NetServerData.init);
            GetGameData();
            adManager.SetActive(true);
            ready = true;
            //PostEventScript.GetInstance().SendEvent("1002","1");
        }

    }
    void GetGameData()
    {
        string url = "LocationJson/GameData";//这里必须加后缀，不加报错
        TextAsset json  = Resources.Load<TextAsset>(url);
        gameData = JsonMapper.ToObject<GameData>(json.text);
        FlyBubbleCfg flyBubbleCfg = JsonMapper.ToObject<FlyBubbleCfg>(NetServerData.game_data);
        gameFlyData = flyBubbleCfg.fly_bubble_config;
    }
    IEnumerator NetWorkTimeOut(Action finish)
    {
        yield return new WaitForSeconds(3f);
        finish();
    }

    public static bool IsEditor()
    {
#if UNITY_EDITOR
        return true;
#else
            return false;
#endif
    }

    /// <summary>
    /// 向后台发送adjustId
    /// </summary>
    public void SendAdjustAdid()
    {
        string serverId = SaveDataManager.GetString(CConfig.sv_LocalServerId);
        string adjustId = AdjustInitManager.Instance.GetAdjustAdid();
        if (string.IsNullOrEmpty(serverId) || string.IsNullOrEmpty(adjustId))
        {
            return;
        }

        string url = AdjustUrl + "&serverId=" + serverId + "&adid=" + adjustId;
        NetWorkManager.GetInstance().HttpGet(url,
            (data) => {
                Debug.Log("服务器更新adjust adid 成功" + data.downloadHandler.text);
            },
            () => {
                Debug.Log("服务器更新adjust adid 失败");
            });
    }
}
