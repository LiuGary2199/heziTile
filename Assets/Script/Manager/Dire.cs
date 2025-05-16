using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RewardFrom
{
    LevelPass,
    HomeBank,
    LevelBank
}
public class Dire : MonoBehaviour
{
    public static Dire instance;
[UnityEngine.Serialization.FormerlySerializedAs("levelCreate")]    [UnityEngine.Serialization.FormerlySerializedAs("levelCreate")]public ExtolReelScheme BraveScheme;
[UnityEngine.Serialization.FormerlySerializedAs("tileSelectGroup")]    [UnityEngine.Serialization.FormerlySerializedAs("tileSelectGroup")]public GameObject MealMetricModel;
[UnityEngine.Serialization.FormerlySerializedAs("FishManagerObj")]    [UnityEngine.Serialization.FormerlySerializedAs("FishManagerObj")]public GameObject SpurMedicalSum;
[UnityEngine.Serialization.FormerlySerializedAs("cashShowNumber")]    [UnityEngine.Serialization.FormerlySerializedAs("cashShowNumber")]public string SlamNotePointe;
[UnityEngine.Serialization.FormerlySerializedAs("goldShowNumber")]    [UnityEngine.Serialization.FormerlySerializedAs("goldShowNumber")]public string goldNotePointe;
[UnityEngine.Serialization.FormerlySerializedAs("amazonShowNumber")]    [UnityEngine.Serialization.FormerlySerializedAs("amazonShowNumber")]public string RevereNotePointe;
[UnityEngine.Serialization.FormerlySerializedAs("expShowNumber")]    [UnityEngine.Serialization.FormerlySerializedAs("expShowNumber")]public int OatNotePointe;
[UnityEngine.Serialization.FormerlySerializedAs("userLevelShowNumber")]    [UnityEngine.Serialization.FormerlySerializedAs("userLevelShowNumber")]public int SuitExtolNotePointe;
[UnityEngine.Serialization.FormerlySerializedAs("starBoxShowExp")]    [UnityEngine.Serialization.FormerlySerializedAs("starBoxShowExp")]public int CrewBoxNoteDay;
[UnityEngine.Serialization.FormerlySerializedAs("haveNeedUnlockFishTank")]    [UnityEngine.Serialization.FormerlySerializedAs("haveNeedUnlockFishTank")]public bool BengHerbCementSpurFold;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("BigRewardStartTime")]    [UnityEngine.Serialization.FormerlySerializedAs("BigRewardStartTime")]public int GapGrooveBladeTerm; // 大额奖励上次初始时间
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("BigRewardNum")]    [UnityEngine.Serialization.FormerlySerializedAs("BigRewardNum")]public int GapGrooveRed;    // 大额奖励消除次数
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("BigReward")]    [UnityEngine.Serialization.FormerlySerializedAs("BigReward")]public TileReward GapGroove;    // 大额奖励
    private Coroutine DogGrooveSymbolize;
    private bool NoCrouch= false;
    /// <summary>
    /// 初始金币
    /// </summary>
    [Header("初始金币")]
[UnityEngine.Serialization.FormerlySerializedAs("initGoldValue")]    [UnityEngine.Serialization.FormerlySerializedAs("initGoldValue")]public int BendLordQuill;
    /// <summary>
    /// 初始现金
    /// </summary>
    [Header("初始现金")]
[UnityEngine.Serialization.FormerlySerializedAs("initCashValue")]    [UnityEngine.Serialization.FormerlySerializedAs("initCashValue")]public float BendCookQuill;

    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("GuideTiles")]    [UnityEngine.Serialization.FormerlySerializedAs("GuideTiles")]public string[][] PivotForty= { new string[] { "8", "11" }, new string[] { "10", "11" }, new string[] { "12", "11" } };

    private void OnApplicationFocus(bool focus)
    {
        
    }
    void Awake()
    {
        Application.targetFrameRate = 60;
        instance = this;
    }

    
    /// <summary>
    /// 游戏初始化
    /// </summary>
    public void FirnTour()
    {
        if (!SaveDataManager.GetBool(CConfig.sv_IsNewPlayer))
        {
            SaveDataManager.SetInt(CConfig.sv_UserLevel, 1);
            SaveDataManager.SetInt(CConfig.sv_SelectFishTank, 2);
            SaveDataManager.SetIntArray(CConfig.sv_UnlockFishTankList, new int[] { 0 });
            SaveDataManager.SetInt(CConfig.sv_StarBoxLevel, 1);
            SaveDataManager.SetInt(CConfig.sv_DailyBounsLastDay, System.DateTime.Now.Day);
            //addGold(initGoldValue);
            //addCash(initCashValue);
            SaveDataManager.SetBool(CConfig.sv_IsNewPlayer, true);
            if (CommonUtil.IsApple())
            {
                SaveDataManager.SetBool(CConfig.sv_NewUserStep + "1-1", true);
                SaveDataManager.SetBool(CConfig.sv_NewUserStep + "1-2", true);
                SaveDataManager.SetBool(CConfig.sv_NewUserStep + "1-3", true);
                SaveDataManager.SetBool(CConfig.sv_NewUserStep + "3", true);
            }
        }
        SpurMedicalSum.SetActive(true);

        goldNotePointe = NumberUtil.DoubleToStr(WhoLord());

        SlamNotePointe = NumberUtil.DoubleToStr(WhoCook());

        RevereNotePointe = NumberUtil.DoubleToStr(WhoStrait());

        OatNotePointe = WhoDay();

        CrewBoxNoteDay = WhoRakeSumDay();
        List<int> unlockFishTankList = new List<int>(SaveDataManager.GetIntArray(CConfig.sv_UnlockFishTankList));

        for (int i = 0; i < NetInfoMgr.instance.gameData.AquariumShop.Count; i++)
        {
            AquariumShopItemData aquariumData = NetInfoMgr.instance.gameData.AquariumShop[i];
            if (aquariumData.UnlockValue <= WhoMessSpurGrass() && !unlockFishTankList.Contains(i))
            {
                unlockFishTankList.Add(i);
            }
        }

        SaveDataManager.SetIntArray(CConfig.sv_UnlockFishTankList, unlockFishTankList.ToArray());
        SuitExtolNotePointe = WhoExamExtol();
        MusicMgr.GetInstance().PlayBg(MusicType.UIMusic.Sound_TileFishBGM);
        BraveBlade();

//#if SOHOShop
//        SOHOShopManager.instance.InitSOHOShop();
//#endif
//        // 提现商店初始化
//        SOHOShopManager.instance.InitSOHOShopAction(getCash, getGold, getAmazon, subCash, subGold, subAmazon);
    }
    /// <summary>
    /// 关卡开始
    /// </summary>
    public void BraveBlade()
    {
        BraveScheme.gameObject.SetActive(true);
        MealMetricModel.SetActive(true);
        BraveScheme.BendExtol();

        if (DogGrooveSymbolize == null)
        {
            DogGrooveSymbolize = StartCoroutine(OwnGapGrooveTerm());
        }
        
    }

    public void LargeGapGrooveTerm()
    {
        GapGrooveBladeTerm = 0;
        GapGrooveRed = 0;
    }

    public void RailGapGrooveTerm()
    {
        if (DogGrooveSymbolize != null)
        {
            StopCoroutine(DogGrooveSymbolize);
            DogGrooveSymbolize = null;
        }
    }
    public void DogDireCrouch(bool isfinish)
    {
        NoCrouch = isfinish;
    }

    public bool OakDireCrouch()
    {
        return NoCrouch;
    }
    /// <summary>
    /// 关卡通过
    /// </summary>
    public void BraveEmphasis()
    {
        
        BraveScheme.gameObject.SetActive(false);
        MealMetricModel.SetActive(false);
        MessageCenterLogic.GetInstance().Send(CConfig.mg_LevelPanel_Hide);
    }
    /// <summary>
    /// 广告通过关卡
    /// </summary>
    public Dictionary<string,int> ToExtolCrouch()
    {
        double cashNumber = Dire.instance.WhoExtolLoveCook();
        Dire.instance.OwnCook(cashNumber);
        Dictionary<string, int> dic = new Dictionary<string, int>();
        dic.Add("cash", (int)cashNumber);
        return dic;
    }
    /// <summary>
    /// 关卡结束
    /// </summary>
    public void BraveCrouch()
    {
        //PostEventScript.GetInstance().SendEvent("1207", levelCreate.levelNumber.ToString(), levelCreate.mainData.target.Count.ToString());
        Dire.instance.FirnMessyArabHis();
        BraveScheme.GetComponent<ExtolToll>().SewPluck = false;
        BraveScheme.RareWordFormation(()=> { 
            BraveScheme.gameObject.SetActive(false);
            MealMetricModel.SetActive(false);
            MessageCenterLogic.GetInstance().Send(CConfig.mg_LevelPanel_Hide);
            Dire.instance.ChafeDireMessyArabHis();
        });
    }
    /// <summary>
    /// 屏蔽游戏全部操作
    /// </summary>
    public void FirnMessyArabHis()
    {
        BraveScheme.GetComponent<ExtolToll>().SewPluck = false;
        UIManager.GetInstance().ShowUIForms(nameof(GrooveRider));
    }
    /// <summary>
    /// 取消全部屏蔽
    /// </summary>
    public void ChafeDireMessyArabHis()
    {
        //if(SaveDataManager.GetBool(CConfig.sv_NewUserStep + "1-2"))
        //{
        //    levelCreate.GetComponent<ExtolToll>().canTouch = true;
        //    UIManager.GetInstance().CloseOrReturnUIForms("GrooveRider");
        //}

        BraveScheme.GetComponent<ExtolToll>().SewPluck = true;
        UIManager.GetInstance().CloseOrReturnUIForms("GrooveRider");
    }
    /// <summary>
    /// 获取现金alpha系数
    /// </summary>
    /// <returns></returns>
    public float WhoCookDutch()
    {
        float random = UnityEngine.Random.Range((float)NetInfoMgr.instance.InitData.cash_random[0], (float)NetInfoMgr.instance.InitData.cash_random[1]);
        double cumulativeCash = SaveDataManager.GetDouble(CConfig.sv_CumulativeCashNumber);
        foreach (GroupItem item in NetInfoMgr.instance.InitData.cash_group)
        {
            if (item.max > cumulativeCash)
            {

                return item.multi * (1 + random);
            }
        }
        return 1;
    }
 

    /// <summary>
    /// 获取金币alpha系数
    /// </summary>
    /// <returns></returns>
    public int WhoLordDutch()
    {
        double cumulativeGold = SaveDataManager.GetDouble(CConfig.sv_CumulativeGoldNumber);
        foreach (GroupItem item in NetInfoMgr.instance.InitData.gold_group)
        {
            if (item.max > cumulativeGold)
            {

                return item.multi;
            }
        }
        return 1;
    }


    /// <summary>
    /// 获取amazon alpha系数
    /// </summary>
    /// <returns></returns>
    public int WhoStraitDutch()
    {
        double cumulativeAmazon = SaveDataManager.GetDouble(CConfig.sv_CumulativeAmazonNumber);
        foreach (GroupItem item in NetInfoMgr.instance.InitData.amazon_group)
        {
            if (item.max > cumulativeAmazon)
            {

                return item.multi;
            }
        }
        return 1;
    }

    /// <summary>
    /// 加金币
    /// </summary>
    /// <param name="gold_num"></param>
    public void OwnLord(double gold_num, Transform transform = null)
    {
        double num = WhoLord();
        num += gold_num;
        SaveDataManager.SetDouble(CConfig.sv_GoldNumber, num);
        MessageData md = new MessageData(transform);
        md.valueDouble = gold_num;
        MessageCenterLogic.GetInstance().Send(CConfig.mg_LevelPanel_AddGold, md);

        double cumulativeGold = SaveDataManager.GetDouble(CConfig.sv_CumulativeGoldNumber);
        cumulativeGold += gold_num;
        SaveDataManager.SetDouble(CConfig.sv_CumulativeGoldNumber, cumulativeGold);
    }
    /// <summary>
    /// 减金币
    /// </summary>
    /// <param name="gold_num"></param>
    public void RobLord(double gold_num)
    {
        double num = WhoLord();
        num -= gold_num;
        goldNotePointe = NumberUtil.DoubleToStr(num);
        SaveDataManager.SetDouble(CConfig.sv_GoldNumber, num);
        MessageData md = new MessageData(-gold_num);
        MessageCenterLogic.GetInstance().Send(CConfig.mg_LevelPanel_AddGold, md);
    }
    /// <summary>
    /// 获取金币
    /// </summary>
    /// <returns></returns>
    public double WhoLord()
    {
        return SaveDataManager.GetDouble(CConfig.sv_GoldNumber);
    }
    /// <summary>
    /// 加现金
    /// </summary>
    /// <param name="cash_num"></param>
    public void OwnCook(double cash_num, Transform transform = null)
    {
        double num = WhoCook();
        num += cash_num;
        SaveDataManager.SetDouble(CConfig.sv_CashNumber, num);
        //SOHOShopManager.instance.AddCash(cash_num);
        MessageData md = new MessageData(transform);
        md.valueDouble = cash_num;
        MessageCenterLogic.GetInstance().Send(CConfig.mg_LevelPanel_AddCash, md);

        double cumulativeCash = SaveDataManager.GetDouble(CConfig.sv_CumulativeCashNumber);
        cumulativeCash += cash_num;
        SaveDataManager.SetDouble(CConfig.sv_CumulativeCashNumber, cumulativeCash);
    }
    /// <summary>
    /// 减现金
    /// </summary>
    /// <param name="cash_num"></param>
    public void RobCook(double cash_num)
    {
        double num = WhoCook();
        num -= cash_num;
        SlamNotePointe = NumberUtil.DoubleToStr(num);
        SaveDataManager.SetDouble(CConfig.sv_CashNumber, num);
        MessageCenterLogic.GetInstance().Send(CConfig.mg_LevelPanel_AddCash, new MessageData(-cash_num));
    }
    /// <summary>
    /// 获取现金
    /// </summary>
    /// <returns></returns>
    public double WhoCook()
    {
        return SaveDataManager.GetDouble(CConfig.sv_CashNumber);
    }

    /// <summary>
    /// 增加Amazon卡
    /// </summary>
    /// <returns></returns>
    public void OwnStrait(double amazon_num, Transform transform = null)
    {
        double num = WhoStrait();
        num += amazon_num;
        SaveDataManager.SetDouble(CConfig.sv_AmazonNumber, num);
        MessageData md = new MessageData(transform);
        md.valueDouble = amazon_num;
        MessageCenterLogic.GetInstance().Send(CConfig.mg_LevelPanel_AddAmazon, md);

        double cumulativeAmazon = SaveDataManager.GetDouble(CConfig.sv_CumulativeAmazonNumber);
        cumulativeAmazon += amazon_num;
        SaveDataManager.SetDouble(CConfig.sv_CumulativeAmazonNumber, cumulativeAmazon);
    }
    public void RobStrait(double amazon_num)
    {
        double num = WhoStrait();
        num -= amazon_num;
        RevereNotePointe = NumberUtil.DoubleToStr(num);
        SaveDataManager.SetDouble(CConfig.sv_AmazonNumber, num);
        MessageCenterLogic.GetInstance().Send(CConfig.mg_LevelPanel_AddAmazon, new MessageData(-amazon_num));
    }

    public double WhoStrait()
    {
        return SaveDataManager.GetDouble(CConfig.sv_AmazonNumber);
    }

    /// <summary>
    /// 获取通关现金奖励
    /// </summary>
    /// <returns></returns>
    public double WhoExtolLoveCook()
    {
        double baseCash = NetInfoMgr.instance.InitData.passlevel_cash_price;
        int passLevel = SaveDataManager.GetInt(CConfig.sv_CashLevelPass);
        passLevel++;
        float levelPassCashNumber = 0;
        
        SaveDataManager.SetInt(CConfig.sv_CashLevelPass, passLevel);
        return levelPassCashNumber;
    }

    /// <summary>
    /// 增加经验
    /// </summary>
    /// <param name="exp"></param>
    public void OwnDay(int exp)
    {
        GameData FirnOust= NetInfoMgr.instance.gameData;
        int now_exp = WhoDay();
        now_exp += exp;
        int now_level = WhoExamExtol();
        UserLevelItemData next_level_data = null;
        foreach (UserLevelItemData leveldata in FirnOust.UserLevel)
        {
            if (leveldata.Level > now_level)
            {
                next_level_data = leveldata;
                int nextNeedExp = next_level_data.Exp;
                if (nextNeedExp <= now_exp)
                {
                    now_exp -= nextNeedExp;
                    now_level++;
                } 
                else
                {
                    break;
                }
            }
        }
        SaveDataManager.SetInt(CConfig.sv_UserExp, now_exp);
        SaveDataManager.SetInt(CConfig.sv_UserLevel, now_level);
    }
    /// <summary>
    /// 获取当前经验
    /// </summary>
    /// <returns></returns>
    public int WhoDay()
    {
        return SaveDataManager.GetInt(CConfig.sv_UserExp);
    }
    /// <summary>
    /// 获取升级进度
    /// </summary>
    /// <returns></returns>
    public float WhoNoteExtolIfRelation()
    {
        GameData FirnOust= NetInfoMgr.instance.gameData;
        int now_level = SuitExtolNotePointe;
        int nowExp = OatNotePointe;
        UserLevelItemData next_level_data = null;
        foreach (UserLevelItemData leveldata in FirnOust.UserLevel)
        {
            if (leveldata.Level > now_level)
            {
                next_level_data = leveldata;
                break;
            }
        }
        int nextNeedExp = next_level_data.Exp;
        return (float)nowExp / (float)nextNeedExp;
    }
    /// <summary>
    /// 获取实际升级进度
    /// </summary>
    /// <returns></returns>
    public float WhoDuckExtolIfRelation()
    {
        GameData FirnOust= NetInfoMgr.instance.gameData;
        int now_level = WhoExamExtol();
        int nowExp = WhoDay();
        UserLevelItemData next_level_data = null;
        foreach (UserLevelItemData leveldata in FirnOust.UserLevel)
        {
            if (leveldata.Level > now_level)
            {
                next_level_data = leveldata;
                break;
            }
        }
        int nextNeedExp = next_level_data.Exp;
        return (float)nowExp / (float)nextNeedExp;
    }
    /// <summary>
    /// 获取当前等级
    /// </summary>
    /// <returns></returns>
    public int WhoExamExtol()
    {
        return SaveDataManager.GetInt(CConfig.sv_UserLevel);
    }
    /// <summary>
    /// 获取商店鱼的状态
    /// </summary>
    /// <returns></returns>
    public int WhoSpurLace(int fish_index)
    {
        GameData FirnOust= NetInfoMgr.instance.gameData;
        if (FirnOust.FishShop.Count > fish_index)
        {
            FishShopItemData lastItemData = null;
            if (fish_index > 0)
            {
                lastItemData = FirnOust.FishShop[fish_index - 1];
            }
            FishShopItemData itemData = FirnOust.FishShop[fish_index];
            if (itemData.UnlockType == "level")
            {
                if (itemData.UnlockValue <= WhoExamExtol())
                {
                    //解锁状态
                    return 0;
                }
                else
                {
                    if (lastItemData != null)
                    {
                        if (lastItemData.UnlockValue <= WhoExamExtol())
                        {
                            //即将解锁
                            return 1;
                        }
                        else
                        {
                            //锁定状态
                            return 2;
                        }
                    }
                    else
                    {
                        //锁定状态
                        return 1;
                    }
                }
            }
        }
        return 0;
    }
    /// <summary>
    /// 获取商店鱼的价格
    /// </summary>
    /// <param name="fish_index"></param>
    /// <returns></returns>
    public int WhoPoemSpurSpore(int fish_index)
    {
        GameData FirnOust= NetInfoMgr.instance.gameData;

        if (FirnOust.FishShop.Count > fish_index)
        {
            FishShopItemData itemData = NetInfoMgr.instance.gameData.FishShop[fish_index];
            int basePrice = itemData.BasePrice;
            int buyCount = SaveDataManager.GetInt(CConfig.sv_FishCount + fish_index);
            if (!CommonUtil.IsApple() && fish_index == 0)
            {
                buyCount--;
            }
            int addPrice = itemData.AddPrice;
            int nowPrice = basePrice + buyCount * addPrice;
            return nowPrice;
        }
        return 0;
    }
    /// <summary>
    /// 购买鱼
    /// </summary>
    /// <param name="fish_index"></param>
    /// <returns></returns>
    public int FewSpur(int fish_index)
    {
        //if (getGold() >= getShopFishPrice(fish_index) && getNowTankHaveFishCount() < 25)
        //{
        //    subGold(getShopFishPrice(fish_index));
        //    SpurMedical.instance.AddFish(fish_index);
        //    return 1;
        //}
        //else
        //{
        //    if (getGold() < getShopFishPrice(fish_index))
        //    {
        //        return 2;
        //    }
        //    if (getNowTankHaveFishCount() >= 25)
        //    {
        //        return 3;
        //    }
        //}
        SpurMedical.instance.WhoSpur(fish_index);
        return 1;
    }
    /// <summary>
    /// 获取即将解锁的鱼
    /// </summary>
    public int WhoHaleCementSpurOust()
    {
        
        List<string> fishUnlockList = new List<string>(SaveDataManager.GetStringArray(CConfig.sv_UnlockFishList));
        foreach (FishShopItemData data in NetInfoMgr.instance.gameData.FishShop)
        {
            if (data.UnlockType == "level")
            {
                if (!fishUnlockList.Contains(data.Name))
                {
                    if (SuitExtolNotePointe >= data.UnlockValue)
                    {
                        fishUnlockList.Add(data.Name);
                        SaveDataManager.SetStringArray(CConfig.sv_UnlockFishList, fishUnlockList.ToArray());
                    }
                    else
                    {
                        return NetInfoMgr.instance.gameData.FishShop.IndexOf(data);
                    }
                }
            }
        }
        return 0;
    }
    /// <summary>
    /// 获取拥有鱼的数量
    /// </summary>
    /// <returns></returns>
    public int WhoMessSpurGrass()
    {
        int count = 0;
        for (int i = 0; i < NetInfoMgr.instance.gameData.FishShop.Count; i++)
        {
            count += SaveDataManager.GetInt(CConfig.sv_FishCount + i);
        }
        return count;
    }
    /// <summary>
    /// 获取当前鱼缸拥有鱼的数量
    /// </summary>
    /// <returns></returns>
    public int WhoGemFoldMessSpurGrass()
    {
        int Boost= SaveDataManager.GetInt(CConfig.sv_SelectFishTank);
        int tankFishCount = SaveDataManager.GetIntArray(CConfig.sv_TankHaveFishList).Length;
        return tankFishCount;
    }
    /// <summary>
    /// 星星宝箱放鱼
    /// </summary>
    /// <param name="rewardFishIndex"></param>
    List<int> SaleFoldLend= new List<int>(new int[] { 2, 1, 3, 0, 4 });
    List<int> SaleFoldCementLend= new List<int>(new int[] { 2, 10, 20, 30 });
    public void RakeSumIdeaSpur(int rewardFishIndex)
    {
        Dire.instance.FirnMessyArabHis();
        BraveScheme.GetComponent<ExtolToll>().SewPluck = false;
        BraveScheme.gameObject.SetActive(false);
        MealMetricModel.SetActive(false);
        Dire.instance.FewSpur(rewardFishIndex);
        
        StartCoroutine(IdeaCrouchCentTerm(rewardFishIndex));
    }
    IEnumerator IdeaCrouchCentTerm(int rewardFishIndex)
    {
        //yield return new WaitForSeconds(1f);
        int fishCount = SaveDataManager.GetIntArray(CConfig.sv_TankHaveFishList).Length;
        //if (fishTankUnlockList.Contains(fishCount))
        //{
        //    int index = fishTankUnlockList.IndexOf(fishCount) + 1;
        //}
        SpurMedical.instance.AbsorbSpurFold(SaleFoldLend[(fishCount - 1) % 5]);
        yield return new WaitForSeconds(2f);
        
        BraveScheme.NoteWordFormation(() =>
        {
            Dire.instance.ChafeDireMessyArabHis();
            BraveScheme.GetComponent<ExtolToll>().SewPluck = true;
            if (!GameUtil.IsApple() && (!PlayerPrefs.HasKey(CConfig.sv_ready_rate + "Bool") || !SaveDataManager.GetBool(CConfig.sv_ready_rate)))
            {
                UIManager.GetInstance().ShowUIForms(nameof(DeafRider));
            }
        });
        BraveScheme.gameObject.SetActive(true);
        MealMetricModel.SetActive(true);
    }
    /// <summary>
    /// 获取等级所需经验
    /// </summary>
    public int WhoExtolHerbDay(int level)
    {
        foreach (UserLevelItemData data in NetInfoMgr.instance.gameData.UserLevel)
        {
            if (data.Level >= level)
            {
                return data.Exp;
            }
        }
        return 100;
    }
    /// <summary>
    /// 获取鱼缸是否满足解锁条件
    /// </summary>
    public bool WhoSpurFoldMeCement(int index)
    {
        AquariumShopItemData Halt= NetInfoMgr.instance.gameData.AquariumShop[index];
        int fishCount = WhoMessSpurGrass();
        if (CommonUtil.IsApple())
        {
            fishCount++;
        }
        if (Halt.UnlockValue <= fishCount)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// 获取满足条件未解锁鱼缸
    /// </summary>
    public int WhoSpurFoldHerbCement()
    {
        List<int> unlockFishTankList = new List<int>(SaveDataManager.GetIntArray(CConfig.sv_UnlockFishTankList));
        for (int i = 0; i < NetInfoMgr.instance.gameData.AquariumShop.Count; i++)
        {
            AquariumShopItemData aquariumData = NetInfoMgr.instance.gameData.AquariumShop[i];
            if (aquariumData.UnlockValue <= WhoMessSpurGrass() && !unlockFishTankList.Contains(i))
            {
                return i;
            }
        }
        return 0;
    }
    /// <summary>
    /// 解锁新鱼缸
    /// </summary>
    public void BalsamFoldSpur(int index)
    {
        List<int> unlockFishTankList = new List<int>(SaveDataManager.GetIntArray(CConfig.sv_UnlockFishTankList));
        unlockFishTankList.Add(index);
        SaveDataManager.SetIntArray(CConfig.sv_UnlockFishTankList,unlockFishTankList.ToArray());
    }
    /// <summary>
    /// 获取当前宝箱需要经验
    /// </summary>
    /// <returns></returns>
    public int WhoRakeSumHerbDay()
    {
        GameData FirnOust= NetInfoMgr.instance.gameData;
        int boxLevel = SaveDataManager.GetInt(CConfig.sv_StarBoxLevel);
        foreach(BigChestItemData data in FirnOust.BigChest)
        {
            if (boxLevel < data.Level)
            {
                return data.Exp;
            }
        }
        return 10000;
    }
    /// <summary>
    /// 获取当前宝箱数值
    /// </summary>
    /// <returns></returns>
    public BigChestItemData WhoBladeSumGemOust()
    {
        GameData FirnOust= NetInfoMgr.instance.gameData;
        int boxLevel = SaveDataManager.GetInt(CConfig.sv_StarBoxLevel);
        foreach (BigChestItemData data in FirnOust.BigChest)
        {
            if (boxLevel < data.Level)
            {
                return data;
            }
        }
        return null;
    }
    /// <summary>
    /// 获取星星宝箱当前经验值
    /// </summary>
    /// <returns></returns>
    public int WhoRakeSumDay()
    {
        int starBoxExp = SaveDataManager.GetInt(CConfig.sv_StarBoxExp);
        return starBoxExp;
    }
    /// <summary>
    /// 增加星星经验值
    /// </summary>
    /// <returns></returns>
    public void WhosRakeSumDay()
    {
        int starBoxExp = SaveDataManager.GetInt(CConfig.sv_StarBoxExp) + 1;
        int nextExp = SaveDataManager.GetInt(CConfig.sv_StarBoxNextExp); ;
        if (starBoxExp > WhoRakeSumHerbDay())
        {
            nextExp += starBoxExp - WhoRakeSumHerbDay();
            starBoxExp = WhoRakeSumHerbDay();
        }
        SaveDataManager.SetInt(CConfig.sv_StarBoxNextExp, nextExp);
        SaveDataManager.SetInt(CConfig.sv_StarBoxExp, starBoxExp);
    }
    /// <summary>
    /// 增加星星等级
    /// </summary>
    public void WhoRakeSumExtol()
    {
        BigChestItemData Halt= WhoBladeSumGemOust();
        foreach (ValueGroupData valueData in Halt.ValueGroup)
        {
            switch (valueData.type)
            {
                case "Gold":
                    OwnLord(valueData.value);
                    break;
                case "Undo":
                    WhoFlairGrass(valueData.type,valueData.value);
                    break;
                case "Hint":
                    WhoFlairGrass(valueData.type, valueData.value);
                    break;
                case "Shuffle":
                    WhoFlairGrass(valueData.type, valueData.value);
                    break;
            }
        }
        SaveDataManager.SetInt(CConfig.sv_StarBoxLevel, SaveDataManager.GetInt(CConfig.sv_StarBoxLevel) + 1);
        BigChestItemData nextData = WhoBladeSumGemOust();
        CrewBoxNoteDay = SaveDataManager.GetInt(CConfig.sv_StarBoxNextExp);
        if (CrewBoxNoteDay > WhoRakeSumHerbDay())
        {
            SaveDataManager.SetInt(CConfig.sv_StarBoxNextExp, CrewBoxNoteDay - WhoRakeSumHerbDay());
            CrewBoxNoteDay = WhoRakeSumHerbDay();
        }
        else
        {
            SaveDataManager.SetInt(CConfig.sv_StarBoxNextExp, 0);
        }
        SaveDataManager.SetInt(CConfig.sv_StarBoxExp, CrewBoxNoteDay);
    }
    /// <summary>
    /// 增加技能次数
    /// </summary>
    public void WhoFlairGrass(string type,int count)
    {
        string saveKey = CConfig.sv_SkillUndoCount;
        switch (type)
        {

            case "Undo":
                saveKey = CConfig.sv_SkillUndoCount;
                break;
            case "Hint":
                saveKey = CConfig.sv_SkillHintCount;
                break;
            case "Shuffle":
                saveKey = CConfig.sv_SkillRefreshCount;
                break;
        }
        SaveDataManager.SetInt(saveKey, SaveDataManager.GetInt(saveKey) + count);

        MessageCenterLogic.GetInstance().Send("RefreshSkill");
    }
    /// <summary>
    /// 减少技能次数
    /// </summary>
    public void EkeFlairGrass(string type, int count)
    {
        string saveKey = CConfig.sv_SkillUndoCount;
        switch (type)
        {

            case "Undo":
                saveKey = CConfig.sv_SkillUndoCount;
                break;
            case "Hint":
                saveKey = CConfig.sv_SkillHintCount;
                break;
            case "Shuffle":
                saveKey = CConfig.sv_SkillRefreshCount;
                break;
        }
        SaveDataManager.SetInt(saveKey, SaveDataManager.GetInt(saveKey) - count);
    }
    /// <summary>
    /// 获取技能剩余次数
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public int WhoFlairGrass(string type)
    {
        string saveKey = CConfig.sv_SkillUndoCount;
        switch (type)
        {

            case "Undo":
                saveKey = CConfig.sv_SkillUndoCount;
                break;
            case "Hint":
                saveKey = CConfig.sv_SkillHintCount;
                break;
            case "Shuffle":
                saveKey = CConfig.sv_SkillRefreshCount;
                break;
        }
        return SaveDataManager.GetInt(saveKey);
    }
    /// <summary>
    /// 获得当前签次数
    /// </summary>
    public int FifthFluteOakThink()
    {
        int lastDay = SaveDataManager.GetInt(CConfig.sv_DailyBounsLastDay);
        int Boost= SaveDataManager.GetInt(CConfig.sv_DailyBounsGetCount);
        if (lastDay != System.DateTime.Now.Day)
        {
            return Boost;
        }
        else
        {
            return 8;
        }
        
    }
    /// <summary>
    /// 领取签到奖励
    /// </summary>
    public void FifthSillyOakGroove(bool isAD)
    {
        int lastDay = SaveDataManager.GetInt(CConfig.sv_DailyBounsLastDay);
        int Boost= SaveDataManager.GetInt(CConfig.sv_DailyBounsGetCount);
        SaveDataManager.SetInt(CConfig.sv_DailyBounsGetCount, Boost + 1 >= 7 ? 0: Boost + 1);
        SaveDataManager.SetInt(CConfig.sv_DailyBounsLastDay, System.DateTime.Now.Day);
        if (lastDay != System.DateTime.Now.Day)
        {
            if (NetInfoMgr.instance.gameData.DailyBonus[Boost].Type == "Gold")
            {
                if (isAD)
                {
                    OwnLord(NetInfoMgr.instance.gameData.DailyBonus[Boost].Value * 5);
                }
                else
                {
                    OwnLord(NetInfoMgr.instance.gameData.DailyBonus[Boost].Value);   
                }
            }
        }
    }

    public void WhoSpurRumorOust()
    {
        int fishCount = WhoMessSpurGrass();
        foreach (NewFishBonusItemData shelldata in NetInfoMgr.instance.gameData.NewFishBonus)
        {
            if (shelldata.FishNumber == fishCount)
            {
                SaveDataManager.SetInt(CConfig.sv_ShellRewardCount, SaveDataManager.GetInt(CConfig.sv_ShellRewardCount) + 1);
                break;
            }
        }
    }

    public void WhoRake()
    {
        int star = SaveDataManager.GetInt(CConfig.sv_StarNum);
        star += 1;
        SaveDataManager.SetInt(CConfig.sv_StarNum, star);
        MessageCenterLogic.GetInstance().Send(CConfig.mg_ChangeStar);
    }

    public int OakRakeRed()
    {
        return SaveDataManager.GetInt(CConfig.sv_StarNum);
    }

    public void AsianRakeRed()
    {
        SaveDataManager.SetInt(CConfig.sv_StarNum, 0);
        MessageCenterLogic.GetInstance().Send(CConfig.mg_ChangeStar);
    }


    private IEnumerator OwnGapGrooveTerm()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            GapGrooveBladeTerm++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PostEventScript.GetInstance().SendEvent("1001");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
