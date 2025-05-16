using System;
using System.Collections.Generic;
using System.Text;
using LitJson;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ForestPoemOustMedical : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("test")]    [UnityEngine.Serialization.FormerlySerializedAs("test")]public GameObject Pair;
    public static ForestPoemOustMedical instance;
[UnityEngine.Serialization.FormerlySerializedAs("RobloxShopData")]
[UnityEngine.Serialization.FormerlySerializedAs("RobloxShopData")]    public RobloxShopDataConfig ForestPoemOust;
[UnityEngine.Serialization.FormerlySerializedAs("CountryData")]    [UnityEngine.Serialization.FormerlySerializedAs("CountryData")]public CountryInfo MigrantOust;
[UnityEngine.Serialization.FormerlySerializedAs("RobuxData")]    
[UnityEngine.Serialization.FormerlySerializedAs("RobuxData")]    public Dictionary<int, RobuxData> EarlyOust= new Dictionary<int, RobuxData>();
[UnityEngine.Serialization.FormerlySerializedAs("RobloxItemDatas")]    [UnityEngine.Serialization.FormerlySerializedAs("RobloxItemDatas")]public Dictionary<int, RobloxItemData> ForestClanReply= new Dictionary<int, RobloxItemData>();
[UnityEngine.Serialization.FormerlySerializedAs("RobloxItemTwoDatas")]    [UnityEngine.Serialization.FormerlySerializedAs("RobloxItemTwoDatas")]public Dictionary<int, RobloxItemTwoData> ForestClanBatReply= new Dictionary<int, RobloxItemTwoData>();
[UnityEngine.Serialization.FormerlySerializedAs("CurrentId")]    [UnityEngine.Serialization.FormerlySerializedAs("CurrentId")]public int AddressOn;
[UnityEngine.Serialization.FormerlySerializedAs("AddValue")]    [UnityEngine.Serialization.FormerlySerializedAs("AddValue")]public int WhoQuill;
[UnityEngine.Serialization.FormerlySerializedAs("MinID")]    [UnityEngine.Serialization.FormerlySerializedAs("MinID")]public int FirID;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshValue")]    [UnityEngine.Serialization.FormerlySerializedAs("RefreshValue")]public Action<int, int> MeetingQuill;
[UnityEngine.Serialization.FormerlySerializedAs("nowWithdraw")]    [UnityEngine.Serialization.FormerlySerializedAs("nowWithdraw")]public int FunPortrait;
[UnityEngine.Serialization.FormerlySerializedAs("currentGame")]    [UnityEngine.Serialization.FormerlySerializedAs("currentGame")]public int GermanyDire;
[UnityEngine.Serialization.FormerlySerializedAs("CountryInfo")]    [UnityEngine.Serialization.FormerlySerializedAs("CountryInfo")]public string MigrantGate= "";
    private CountryData _GermanyMigrant;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        TourForestPoemOust();
        TourOustInnocence();
        //SetCountryInfo("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    /// <summary>
    /// 初始化商店数据
    /// </summary>
    private void TourForestPoemOust()
    {
        TextAsset json = Resources.Load<TextAsset>(CConfig.RRobloxJsonRobloxData);
        //Debug.LogError("json == " + json);
        ForestPoemOust = JsonMapper.ToObject<RobloxShopDataConfig>(json.text);
        MeetingForeshadow();

        
        TextAsset Countryjson = Resources.Load<TextAsset>(CConfig.RRobloxJsonCountryData);
        //Debug.LogError("json == " + Countryjson);
        MigrantOust = JsonMapper.ToObject<CountryInfo>(Countryjson.text);
        if(Application.platform == RuntimePlatform.Android)
            ForestPoemOust.isStartCashShop = 1;
        else if(Application.platform == RuntimePlatform.IPhonePlayer)
            ForestPoemOust.isStartCashShop = 0;
    }


    public void MeetingForeshadow()
    {
        List<int> idList = new List<int>(SaveDataManager.GetIntArray("RookieList"));
        if (idList.Count == 3)
        {
            List<RobloxItemData> list = new List<RobloxItemData>(ForestPoemOust.Characters_list);
            foreach (RobloxItemData data in list)
            {
                if (idList.Contains(data.ID))
                {
                    RobloxItemData moveItem = data;
                    ForestPoemOust.Characters_list.Remove(data);
                    ForestPoemOust.Characters_list.Insert(0, moveItem);
                }
            }
        }
    }
    /// <summary>
    /// 字典存储数据
    /// </summary>
    private void TourOustInnocence()
    {
        /*for (int i = 0; i < RobloxShopData.Shop_list.Count; i++)
        {
            if (!RobuxData.ContainsKey(RobloxShopData.Shop_list[i].ID))
            {
                RobuxData.Add(RobloxShopData.Shop_list[i].ID,RobloxShopData.Shop_list[i]);
            }
        }*/

        for (int i = 0; i < ForestPoemOust.Shop_class.Count; i++)
        {
            for (int j = 0; j < ForestPoemOust.Shop_class[i].Shop_list.Count; j++)
            {
                if (!EarlyOust.ContainsKey(ForestPoemOust.Shop_class[i].Shop_list[j].ID))
                {
                    EarlyOust.Add(ForestPoemOust.Shop_class[i].Shop_list[j].ID,ForestPoemOust.Shop_class[i].Shop_list[j]);
                }
            }
        }
        
        for (int i = 0; i < ForestPoemOust.Characters_list.Count; i++)
        {
            if (!ForestClanReply.ContainsKey(ForestPoemOust.Characters_list[i].ID))
            {
                ForestClanReply.Add(ForestPoemOust.Characters_list[i].ID,ForestPoemOust.Characters_list[i]);
            }
        }
        
        for (int i = 0; i < ForestPoemOust.Props_list.Count; i++)
        {
            if (!ForestClanBatReply.ContainsKey(ForestPoemOust.Props_list[i].ID))
            {
                ForestClanBatReply.Add(ForestPoemOust.Props_list[i].ID,ForestPoemOust.Props_list[i]);
            }
        }

        
    }

    /// <summary>
    /// 获取地区信息
    /// </summary>
    /// <param name="str"></param>
    public void DogMigrantGate(string str)
    {
        MigrantGate = str;

        for (int i = 0; i < MigrantOust.Country_Info.Count; i++)
        {
            if(MigrantGate == MigrantOust.Country_Info[i].countryName)
                _GermanyMigrant = MigrantOust.Country_Info[i];
        }
    }
    
    public string OakOffshore()
    {
        if (Application.isEditor)
        {
            //Debug.LogError("systemLanguage:" + Application.systemLanguage.ToString());
            return Application.systemLanguage.ToString();
        }
        //获得系统语言
        AndroidJavaClass unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject _unityContext = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject locale = _unityContext.Call<AndroidJavaObject>("getResources").Call<AndroidJavaObject>("getConfiguration").Get<AndroidJavaObject>("locale");
        string systemLanguage = locale.Call<string>("getLanguage");

        Debug.LogError("systemLanguage:" + systemLanguage);
        return systemLanguage;
    }

    ///根据国家刷新不同信息
    public void MeetingMigrantGate()
    {
        //打开商店才有用
        if (ForestPoemOust.isStartCashShop == 1 && _GermanyMigrant != null)
        {
            for (int i = 0; i < ForestPoemOust.Shop_class[2].Shop_list.Count; i++)
            {
                ForestPoemOust.Shop_class[2].Shop_list[i].currencyValue = _GermanyMigrant.GetValue[i];
            }
            ForestPoemOust.Shop_class[2].unitName = _GermanyMigrant.currencyName;
            ForestPoemOust.Shop_class[2].iconPath = _GermanyMigrant.iconPath;
        }
    }

    /// <summary>
    /// 根据ID获取对应图片位置
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string OakRailKeenByID(int id)
    {
        if (id.ToString().StartsWith("1"))
        {
            return EarlyOust[id].iconPath;
        }
        else if(id.ToString().StartsWith("2"))
        {
            return ForestClanReply[id].Img;
        }
        else
        {
            return ForestClanBatReply[id].Img;
        }
        
    }

    /// <summary>
    /// 根据ID获取对应图片资源
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Sprite OakRuggedMeID(int id)
    {
        string path = OakRailKeenByID(id);

        Sprite sprite = Resources.Load<Sprite>(path);

        return sprite;
    }

    /// <summary>
    /// 根据路径获取对应图片资源
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Sprite OakRuggedMeID(string str)
    {
        Sprite sprite = Resources.Load<Sprite>(str);
        return sprite;
    }

    /// <summary>
    /// 根据ID获取对应图片资源
    /// </summary>
    /// <param name="id"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public Sprite OakRuggedMeID(int id, int type)
    {
        foreach (var VARIABLE in EarlyOust)
        {
            if (VARIABLE.Value.CostType == type)
            {
                string path = VARIABLE.Value.iconPath;
                Sprite sprite = Resources.Load<Sprite>(path);
                return sprite;
            }
        }

        return null;
    }

    /// <summary>
    /// 根据ID获取对应兑换资源的消耗值
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int OakHumorousAttractQuillMeID(int id)
    {
        if (id.ToString().StartsWith("1"))
        {
            return EarlyOust[id].CostValue;
        }
        else if(id.ToString().StartsWith("2"))
        {
            return ForestClanReply[id].CostValue;
        }
        else
        {
            return ForestClanBatReply[id].CostValue;
        }
    }
[UnityEngine.Serialization.FormerlySerializedAs("CurrenctOne")]
[UnityEngine.Serialization.FormerlySerializedAs("CurrenctOne")]    /// <summary>
    /// 根据ID获取对应兑换的资源类型
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /*public int GetExchangeTypeByID(int id)
    {
        if (id.ToString().StartsWith("1"))
        {
            return RobuxData[id].CostType;
        }
        else if(id.ToString().StartsWith("2"))
        {
            return RobloxItemDatas[id].CostType;
        }
        else
        {
            return RobloxItemTwoDatas[id].CostType;
        }
    }*/

    public int BehaviorFur;
[UnityEngine.Serialization.FormerlySerializedAs("CurrenctTwo")]    [UnityEngine.Serialization.FormerlySerializedAs("CurrenctTwo")]public int BehaviorBat;
[UnityEngine.Serialization.FormerlySerializedAs("CurrenctThree")]    [UnityEngine.Serialization.FormerlySerializedAs("CurrenctThree")]public int BehaviorProse;
    private Action<MinTypeAndValue> Tiredness;
    /// <summary>
    /// 初始化数据
    /// </summary>
    /// <param name="value"></param>
    /// <param name="valueTwo"></param>
    public void TourCBehavior(int value, int valueTwo, int valueThree, Action<MinTypeAndValue> action)
    {
        BehaviorFur = value;
        BehaviorBat = valueTwo;
        BehaviorProse = valueThree;
        MeetingQuill?.Invoke(value,valueTwo);
        Tiredness = action;
    }
    /// <summary>
    /// 提现成功减去对应货币
    /// </summary>
    /// <param name="robuxData"></param>
    public void FirShoshone(int id)
    {
        FunPortrait = id;
        MinTypeAndValue minTypeAndValue = new MinTypeAndValue();
        minTypeAndValue.type = EarlyOust[id].CostType;
        minTypeAndValue.Value = EarlyOust[id].CostValue;
        if (EarlyOust[id].CostType == 1)
        {
            BehaviorFur -= EarlyOust[id].CostValue;
        }
        else if(EarlyOust[id].CostType == 2)
        {
            BehaviorBat -= EarlyOust[id].CostValue;
        }
        else
        {
            BehaviorProse -= EarlyOust[id].CostValue;
        }
        Tiredness?.Invoke(minTypeAndValue);
        MeetingQuill?.Invoke(BehaviorFur,BehaviorBat);
        //提现成功恭喜弹窗
        ForestPoemRider.instance.NoteDimeRider();
    }

   


    public string PairOakQuill()
    {
        StringBuilder str = new StringBuilder ();
        for (int i = 0; i < ForestPoemOust.Characters_list.Count; i++)
        {
            str.AppendFormat("ID == {0}   Value == {1}    Sum == {2}\n", ForestPoemOust.Characters_list[i].ID,SaveDataManager.GetInt(ForestPoemOust.Characters_list[i].ID.ToString()),ForestPoemOust.Characters_list[i].CostValue);
        }

        for (int i = 0; i < ForestPoemOust.Props_list.Count; i++)
        {
            str.AppendFormat("ID == {0}   Value == {1}    Sum == {2}\n", ForestPoemOust.Props_list[i].ID,SaveDataManager.GetInt(ForestPoemOust.Props_list[i].ID.ToString()),ForestPoemOust.Props_list[i].CostValue);
        }

        return str.ToString();
    }

    /// <summary>
    /// ID为key，给定Item添加进度
    /// </summary>
    /// <param name="id"></param>
    public void Refrigerate(List<AddIdAndValue> value)
    {
        SaveDataManager.SetInt("RobloxPuzzleCount", SaveDataManager.GetInt("RobloxPuzzleCount") +1);
        foreach (AddIdAndValue data in value)
        {
            int id = data.id;
            int WhoQuill= data.value;
            int num = SaveDataManager.GetInt(id.ToString());
            num += WhoQuill;
            SaveDataManager.SetInt(id.ToString(), num);
        }
        //Debug.LogError("id == " + id + "     onceValue == " +  AddValue + "       AddCharacterschedule == " + SaveDataManager.GetInt(id.ToString()));
        //Debug.LogError("path == " + GetIconPathByID(id));
    }


    /// <summary>
    /// 从角色碎片和装饰物碎片中随机获取奖励
    /// </summary>
    /// <returns></returns>
    public AddIdAndValue OakForestGroove()
    {
        AddIdAndValue addIdAndValue = new AddIdAndValue();
        int RandomInt = Random.Range(0, 999);
        float rate = 0;
        int sum = ForestPoemOust.ChipWeight_CA[0] + ForestPoemOust.ChipWeight_CA[1];
        rate +=(float) ForestPoemOust.ChipWeight_CA[0] / sum;
        
        if (RandomInt <= rate * 1000)
        {
            addIdAndValue = OakArbitraryGroove();
        }
        else
        {
            addIdAndValue = OakEpochGroove();
        }

        return addIdAndValue;
    }
    /// <summary>
    /// 获取roblox提现任务
    /// </summary>
    /// <returns></returns>
    public TaskItemData OakForestDime(int id)
    {
        int taskID = EarlyOust[id].TaskID;
        if (taskID >= 0)
        {
            return ForestPoemOust.Task[taskID];
        }
        return null;
    }
    /// <summary>
    /// 统计任务计数
    /// </summary>
    /// <param name="type"></param>
    /// <param name="num"></param>
    public void DogDimeQuill(int type,int num)
    {
        foreach (var game in ForestPoemOust.Shop_class)
        {
            foreach (RobuxData data in game.Shop_list)
            {
                if (SaveDataManager.GetString("RobloxRewardState" + data.ID) == "Withdraw" && type == OakForestDime(data.ID).Type)
                {
                    SaveDataManager.SetInt("RobloxTask_" + data.ID, num + SaveDataManager.GetInt("RobloxTask_" + data.ID));
                }
            }
        }
        /*foreach(RobuxData data in RobloxShopData.Shop_class[currentGame].Shop_list)
        {
            if (SaveDataManager.GetString("RobloxRewardState" + data.ID) == "Withdraw" && type == GetRobloxTask(data.ID).Type)
            {
                SaveDataManager.SetInt("RobloxTask_" + data.ID, num + SaveDataManager.GetInt("RobloxTask_" + data.ID));
            }
        }*/
    }
    /// <summary>
    /// 获取奖励当前任务完成数
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int OakDimeQuill(int id)
    {
        return SaveDataManager.GetInt("RobloxTask_" + id);
    }
    /// <summary>
    /// 获取当前奖励显示任务完成数
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string OakDimeNoteQuill(int id)
    {
        return SaveDataManager.GetInt("RobloxTask_" + id) + "/" + OakForestDime(id).Value;
    }
    /// <summary>
    /// 获取当前奖励显示任务完成进度
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public float OakDimeNoteTreeDesert(int id)
    {
        return SaveDataManager.GetInt("RobloxTask_" + id) / (float)OakForestDime(id).Value;
    }
    #region Shop

    //获取商店指定进度
    public string OakPoemCriticQuill(RobuxData robuxData, int userValue)
    {
        return userValue.ToString() + '/' + robuxData.CostValue;
        
    }

    public float OakPoemFloatQuill(RobuxData robuxData, int userValue)
    {
        return (float) userValue / robuxData.CostValue;
    }

    public string OakArbitraryCriticQuill(RobloxItemData robloxItemData)
    {
        return SaveDataManager.GetInt(robloxItemData.ID.ToString()).ToString() + '/' + robloxItemData.CostValue;
    }
    
    public float OakArbitraryCanoeQuill(RobloxItemData robloxItemData)
    {
        return (float) SaveDataManager.GetInt(robloxItemData.ID.ToString()) / robloxItemData.CostValue;
    }
    
    public string OakEpochCriticQuill(RobloxItemTwoData robloxItemTwoData)
    {
        return SaveDataManager.GetInt(robloxItemTwoData.ID.ToString()).ToString() + '/' + robloxItemTwoData.CostValue;
    }
    
    public float OakEpochCanoeQuill(RobloxItemTwoData robloxItemTwoData)
    {
        return (float) SaveDataManager.GetInt(robloxItemTwoData.ID.ToString()) / robloxItemTwoData.CostValue;
    }

    public AddIdAndValue OakQuill(int id)
    {
        AddIdAndValue addIdAndValue = new AddIdAndValue();
        
        if(id.ToString().StartsWith("2"))
        {
            addIdAndValue = OakArbitraryGroove(id);
            return addIdAndValue;
        }
        else
        {
            addIdAndValue = OakEpochGroove(id);
            return addIdAndValue;
        }
    }



    /// <summary>
    /// 商店物品能否提现
    /// </summary>
    /// <param name="id"></param>
    /// <param name="type"></param>
    /// <param name="userValue"></param>
    /// <returns></returns>
    public bool OakCharacterize(RobuxData robuxData, int type, int userValue)
    {
        
        /*for (int i = 0; i < RobloxShopData.Shop_list.Count; i++)
        {
            if (RobloxShopData.Shop_list[i].ID == id)
            {
                if (userValue >= RobloxShopData.Shop_list[i].CostValue)
                    return true;
                else
                    return false;
            }
        }*/
        return false;
    }



    /// <summary>
    /// 获取指定商店Icon位置
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string OakPoemImaginative(int id, int game)
    {
        for (int i = 0; i < ForestPoemOust.Shop_class[game].Shop_list.Count; i++)
        {
            if (ForestPoemOust.Shop_class[game].Shop_list[i].ID == id)
                return ForestPoemOust.Shop_class[game].Shop_list[i].iconPath;
        }

        return null;
    }

    public string OakForestPoemPacifier()
    {
        return null;
    }


    #endregion



    

    #region CharacterReward

    /// <summary>
    /// 从总的角色奖励中获取角色碎片奖励
    /// </summary>
    /// <returns></returns>
    public AddIdAndValue OakArbitraryGroove()
    {
        OakOnceForeshadowElk();
        int random = Random.Range(0, 999);
        float rate = 0;
        AddIdAndValue addIdAndValue = new AddIdAndValue();
        if (Destructive != 0)
        {
            Debug.Log("总权重:" + Destructive);
            for (int i = 0; i < ForestPoemOust.Characters_list.Count; i++)
            {

                List<int> RookieList = new List<int>(SaveDataManager.GetIntArray("RookieList"));
                float weight = (float)PuzzleArbitraryLend[i];
                //if (SaveDataManager.GetInt("RobloxPuzzleCount") <= RobloxShopData.RookiePackageCount)
                //{
                //    if (RookieList.Contains(RobloxShopData.Characters_list[i].ID))
                //    {
                //        weight = weight * RobloxShopData.RookiePackageMulti;
                //    }
                //}
                Debug.Log("单项权重:" + weight+",--"+ ForestPoemOust.Characters_list[i].Name);
                rate += weight /  Destructive;
                
                //Debug.LogError("random == " + random + "      charatersum == " + charatersum + "      rate == " + rate);
                if (random <= rate * 1000)
                {
                    int addValue = OakWhoQuill(ForestPoemOust.Characters_list[i].ID,true);
                    AddressOn = ForestPoemOust.Characters_list[i].ID;
                    WhoQuill = addValue;
                    addIdAndValue.id = ForestPoemOust.Characters_list[i].ID;
                    addIdAndValue.value = addValue;
                    //Debug.LogError("id == " + RobloxShopData.Characters_list[i].ID + "     value == " + addValue);
                    return addIdAndValue;
                }
            }
        }
        else
        {
            random = Random.Range(0, ForestPoemOust.Characters_list.Count);
            int addValue = OakWhoQuill(ForestPoemOust.Characters_list[random].ID,true);
            AddressOn = ForestPoemOust.Characters_list[random].ID;
            WhoQuill = addValue;
            addIdAndValue.id = ForestPoemOust.Characters_list[random].ID;
            addIdAndValue.value = addValue;
            return addIdAndValue;
        }
        
        return addIdAndValue;
    }

    /// <summary>
    /// 获取指定ID的角色碎片奖励
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public AddIdAndValue OakArbitraryGroove(int id)
    {
        AddIdAndValue addIdAndValue = new AddIdAndValue();
        for (int i = 0; i < ForestPoemOust.Characters_list.Count; i++)
        {
            if (id == ForestPoemOust.Characters_list[i].ID)
            {
                int addValue = OakWhoQuill(id,true);
                AddressOn = id;
                WhoQuill = addValue;
                addIdAndValue.id = id;
                addIdAndValue.value = addValue;
                return addIdAndValue;
            }
        }
        return addIdAndValue;
    }
    
    /// <summary>
    /// 获取指定角色皮肤iD的碎片进度
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private float OakElectrocardiogram(int id)
    {
        for (int i = 0; i < ForestPoemOust.Characters_list.Count; i++)
        {
            if (ForestPoemOust.Characters_list[i].ID == id)
            {
                return (float) SaveDataManager.GetInt(id.ToString()) / ForestPoemOust.Characters_list[i].CostValue;
            }
        }
        return 0;
    }

    private int Destructive= 0;
    private List<int> PuzzleArbitraryLend= new List<int>();
    /// <summary>
    /// 计算当前角色碎片比重下的总和
    /// </summary>
    private void OakOnceForeshadowElk()
    {
        
        Destructive = 0;
        PuzzleArbitraryLend.Clear();
        for (int i = 0; i < ForestPoemOust.Characters_list.Count; i++)
        {
            List<int> RookieList = new List<int>(SaveDataManager.GetIntArray("RookieList"));
            int weight = OakForeshadowBoston(ForestPoemOust.Characters_list[i].ID, i);
            if (SaveDataManager.GetInt("RobloxPuzzleCount") <= ForestPoemOust.RookiePackageCount)
            {
                if (RookieList.Contains(ForestPoemOust.Characters_list[i].ID))
                {
                    weight = weight * ForestPoemOust.RookiePackageMulti;
                }
            }
            Destructive += weight;
            //Debug.LogError("GetOnceSum == " + charatersum + "      weight == " + weight);
            PuzzleArbitraryLend.Add(weight);
        }
        
    }

    /// <summary>
    /// 获得角色比重
    /// </summary>
    /// <param name="id"></param>
    /// <param name="Charactersid"></param>
    /// <returns></returns>
    private int OakForeshadowBoston(int id, int Charactersid)
    {
        float schedule = OakElectrocardiogram(id) * 100;
        
        //Debug.LogError("GetWeight == " + schedule + "     id == " + id);
        for (int i = 0; i < ForestPoemOust.ChipWeight_group.Count; i++)
        {
            if (i == 0 && schedule <= ForestPoemOust.ChipWeight_group[i])
            {
                return int.Parse(ForestPoemOust.Characters_list[Charactersid].Weight[i]);
            }
            else if(i != ForestPoemOust.ChipWeight_group.Count - 1 && i != 0 && schedule > ForestPoemOust.ChipWeight_group[i - 1] && schedule < ForestPoemOust.ChipWeight_group[i])
            {
                return int.Parse(ForestPoemOust.Characters_list[Charactersid].Weight[i]);
            }
            else if(i == ForestPoemOust.ChipWeight_group.Count - 1 && schedule <= ForestPoemOust.ChipWeight_group[i])
            {
                return int.Parse(ForestPoemOust.Characters_list[Charactersid].Weight[i]);
            }
            else if(i == ForestPoemOust.ChipWeight_group.Count - 1 && schedule > ForestPoemOust.ChipWeight_group[i])
            {
                return 0;
            }
        }
        
        return 0;
    }

    #endregion


    #region PropsReward

    private int Vacation= 0;
    private List<int> PuzzleEpochLend= new List<int>();

    /// <summary>
    /// 从总的装饰物奖励中获取角色碎片奖励
    /// </summary>
    /// <returns></returns>
    public AddIdAndValue OakEpochGroove()
    {
        OakNoteEpochElk();
        int random = Random.Range(0, 999);
        float rate = 0;
        AddIdAndValue addIdAndValue = new AddIdAndValue();
        if (Vacation == 0)
        {
            for (int i = 0; i < ForestPoemOust.Props_list.Count; i++)
            {
                rate += (float) PuzzleEpochLend[i] /  Vacation;
                //Debug.LogError("random == " + random + "      charatersum == " + charatersum + "      rate == " + rate);
                if (random <= rate * 1000)
                {
                 
                    int addValue = OakWhoQuill(ForestPoemOust.Props_list[i].ID,false);
                    AddressOn = ForestPoemOust.Props_list[i].ID;
                    WhoQuill = addValue;
                    addIdAndValue.id = ForestPoemOust.Props_list[i].ID;
                    addIdAndValue.value = addValue;
                    //Debug.LogError("id == " + RobloxShopData.Props_list[i].ID + "     value == " + addValue);
                    return addIdAndValue;
                }
            }
        }
        else
        {
            random = Random.Range(0, ForestPoemOust.Props_list.Count);
            int addValue = OakWhoQuill(ForestPoemOust.Props_list[random].ID,false);
            AddressOn = ForestPoemOust.Props_list[random].ID;
            WhoQuill = addValue;
            addIdAndValue.id = ForestPoemOust.Props_list[random].ID;
            addIdAndValue.value = addValue;
            return addIdAndValue;
        }
        return addIdAndValue;
    }

    /// <summary>
    /// 获取指定ID的装饰物碎片奖励
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public AddIdAndValue OakEpochGroove(int id)
    {
        AddIdAndValue addIdAndValue = new AddIdAndValue();
        for (int i = 0; i < ForestPoemOust.Props_list.Count; i++)
        {
            if (id == ForestPoemOust.Props_list[i].ID)
            {
                int addValue = OakWhoQuill(id,false);
                AddressOn = id;
                WhoQuill = addValue;
                addIdAndValue.id = id;
                addIdAndValue.value = addValue;
                return addIdAndValue;
            }
        }
        return addIdAndValue;
    }
    
    /// <summary>
    /// 获取指定装饰物Id的碎片进度
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private float OakConsideration(int id)
    {
        for (int i = 0; i < ForestPoemOust.Props_list.Count; i++)
        {
            if (ForestPoemOust.Props_list[i].ID == id)
            {
                return (float) SaveDataManager.GetInt(id.ToString()) / ForestPoemOust.Props_list[i].CostValue;
            }
        }
        return 0;
    }
    
    /// <summary>
    /// 计算当前装饰物碎片比重下的总和
    /// </summary>
    private void OakNoteEpochElk()
    {
        Vacation = 0;
        PuzzleEpochLend.Clear();
        for (int i = 0; i < ForestPoemOust.Props_list.Count; i++)
        {
            int weight = OakEpochBoston(ForestPoemOust.Props_list[i].ID, i);
            Vacation += weight;
            PuzzleEpochLend.Add(weight);
        }
        
    }

    /// <summary>
    /// 获得装饰物比重
    /// </summary>
    /// <param name="id"></param>
    /// <param name="Charactersid"></param>
    /// <returns></returns>
    private int OakEpochBoston(int id, int Propsid)
    {
        float schedule = OakConsideration(id) * 100;
        
        //Debug.LogError("GetWeight == " + schedule + "     id == " + id);
        for (int i = 0; i < ForestPoemOust.ChipWeight_group.Count; i++)
        {
            if (i == 0 && schedule <= ForestPoemOust.ChipWeight_group[i])
            {
                return int.Parse(ForestPoemOust.Props_list[Propsid].Weight[i]);
            }
            else if(i != ForestPoemOust.ChipWeight_group.Count - 1 && i != 0 && schedule > ForestPoemOust.ChipWeight_group[i - 1] && schedule < ForestPoemOust.ChipWeight_group[i])
            {
                return int.Parse(ForestPoemOust.Props_list[Propsid].Weight[i]);
            }
            else if(i == ForestPoemOust.ChipWeight_group.Count - 1 && schedule <= ForestPoemOust.ChipWeight_group[i])
            {
                return int.Parse(ForestPoemOust.Props_list[Propsid].Weight[i]);
            }
            else if(i == ForestPoemOust.ChipWeight_group.Count - 1 && schedule > ForestPoemOust.ChipWeight_group[i])
            {
                return 0;
            }
        }
        
        return 0;
    }

    #endregion
    


    /// <summary>
    /// 获取增加值
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private int OakWhoQuill(int id, bool isCharacter)
    {
        float schedule;
        if(isCharacter)
            schedule = OakElectrocardiogram(id) * 100;
        else
            schedule = OakConsideration(id) * 100;
        for (int i = 1; i < 12; i++)
        {
            if (schedule <= i * 10)
            {
                //Debug.LogError("schedule == " + schedule + "    i == "  + i + "    sum == "/* + sum*/);
                int sum = 0;
                List<int> weightList = new List<int>();
                for (int j = 0; j < ForestPoemOust.ChipGetValue_group[i - 1].Count; j++)
                {
                    sum += ForestPoemOust.ChipGetValue_group[i - 1][j];
                    
                }
                
                int random = Random.Range(0, 999);
                float rate = 0;
                for (int j = 0; j < ForestPoemOust.ChipGetValue_group[i - 1].Count; j++)
                {
                    rate +=(float) ForestPoemOust.ChipGetValue_group[i - 1][j] / sum;
                    if (random <= rate * 1000)
                    {
                        return 10 - j;
                    }
                }
            }
        }

        return 0;
    }

#if EmojiMerge
    public void ShowRobloxShopPanel()
    {
        UIManager.GetInstance().RobloxCanvas.transform.Find("ForestPoemRider").gameObject.SetActive(true);
    }
#endif
    
    
    
}

public struct AddIdAndValue
{
    public int id;
    public int value;
}

public struct MinTypeAndValue
{
    public int type;
    public int Value;
}
