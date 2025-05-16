/**
 * 
 * 常量配置
 * 
 * 
 * **/
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CConfig 
{
    #region 常量字段
    //登录url
    public const string LoginUrl = "/api/client/user/getId?gameCode=";
    //配置url
    public const string ConfigUrl = "/api/client/config?gameCode=";
    //时间戳url
    public const string TimeUrl = "/api/client/common/current_timestamp?gameCode=";
    //更新AdjustId url
    public const string AdjustUrl = "/api/client/user/setAdjustId?gameCode=";
    #endregion

    #region 本地存储的字符串
    /// <summary>
    /// 本地用户id (string)
    /// </summary>
    public const string sv_LocalUserId = "sv_LocalUserId";
    /// <summary>
    /// 本地服务器id (string)
    /// </summary>
    public const string sv_LocalServerId = "sv_LocalServerId";
    /// <summary>
    /// 是否是新用户玩家 (bool)
    /// </summary>
    public const string sv_IsNewPlayer = "sv_IsNewPlayer";
    /// <summary>
    /// 关卡id (int)
    /// </summary>
    public const string sv_Level_Id = "sv_Level_Id";
    /// <summary>
    /// 金币余额 (int)
    /// </summary>
    public const string sv_GoldNumber = "sv_GoldNumber";
    /// <summary>
    /// 累计金币数量
    /// </summary>
    public const string sv_CumulativeGoldNumber = "sv_CumulativeGoldNumber";
    /// <summary>
    /// 现金余额 (float)
    /// </summary>
    public const string sv_CashNumber = "sv_CashNumber";
    /// <summary>
    /// 累计现金数量
    /// </summary>
    public const string sv_CumulativeCashNumber = "sv_CumulativeCashNumber";
    /// <summary>
    /// Amazon余额
    /// </summary>
    public const string sv_AmazonNumber = "sv_AmazonNumber";
    /// <summary>
    /// 累计Amazon卡
    /// </summary>
    public const string sv_CumulativeAmazonNumber = "sv_CumulativeAmazonNumber";
    
    /// <summary>
    /// 贝壳余额 (int)
    /// </summary>
    public const string sv_ShellNumber = "sv_ShellNumber";
    /// <summary>
    /// 通过现金奖励间隔 (int)
    /// </summary>
    public const string sv_CashLevelPass = "sv_CashLevelPass";
    /// <summary>
    /// 存钱罐当前钱数 (float)
    /// </summary>
    public const string sv_BankNumber = "sv_BankNumber";
    /// <summary>
    /// 存钱罐累计钱数 (float)
    /// </summary>
    public const string sv_BankAllGetNumber = "sv_BankAllGetNumber";
    /// <summary>
    /// 关卡持续时间 (int)
    /// </summary>
    public const string sv_LevelAllTime = "sv_LevelAllTime";
    /// <summary>
    /// 用户等级 (int)
    /// </summary>
    public const string sv_UserLevel = "sv_UserLevel";
    /// <summary>
    /// 当前经验值 (int)
    /// </summary>
    public const string sv_UserExp = "sv_UserExp";
    /// <summary>
    /// 拥有某种鱼的总数量(计算鱼的售价使用) 需要拼接鱼的id (int)
    /// </summary>
    public const string sv_FishCount = "sv_FishCount_";
    /// <summary>
    ///解锁鱼的列表 (int array)
    /// </summary>
    public const string sv_UnlockFishList = "sv_UnlockFishList";
    /// <summary>
    /// 鱼缸包含鱼列表 需要拼接鱼缸的id (int array)
    /// </summary>
    public const string sv_TankHaveFishList = "sv_TankHaveFishList";
    /// <summary>
    /// 当前选用鱼缸 (int)
    /// </summary>
    public const string sv_SelectFishTank = "sv_SelectFishTank";
    /// <summary>
    /// 解锁鱼缸列表 (int array)
    /// </summary>
    public const string sv_UnlockFishTankList = "sv_UnlockFishTankList";
    /// <summary>
    /// 星星宝箱等级 (int)
    /// </summary>
    public const string sv_StarBoxLevel = "sv_StarBoxLevel";
    /// <summary>
    /// 星星宝箱经验值 (int)
    /// </summary>
    public const string sv_StarBoxExp = "sv_StarBoxExp";
    /// <summary>
    /// 星星宝箱溢出经验值 (int)
    /// </summary>
    public const string sv_StarBoxNextExp = "sv_StarBoxNextExp";
    /// <summary>
    /// 回退技能免费次数 (int)
    /// </summary>
    public const string sv_SkillUndoCount = "sv_SkillUndoCount";
    /// <summary>
    /// 提示技能免费次数 (int)
    /// </summary>
    public const string sv_SkillHintCount = "sv_SkillHintCount";
    /// <summary>
    /// 刷新技能免费次数 (int)
    /// </summary>
    public const string sv_SkillRefreshCount = "sv_SkillRefreshCount";
    /// <summary>
    /// 签到次数 (int)
    /// </summary>
    public const string sv_DailyBounsGetCount = "sv_DailyBounsGetCount";
    /// <summary>
    /// 签到最后日期 (int)
    /// </summary>
    public const string sv_DailyBounsLastDay = "sv_DailyBounsLastDay";
    /// <summary>
    /// 鱼奖励未发放金币金额 (int)
    /// </summary>
    public const string sv_FishRewardGoldNum = "sv_FishRewardGoldNum";
    /// <summary>
    /// 鱼奖励剩余发放金币次数 (int)
    /// </summary>
    public const string sv_FishRewardGoldCount = "sv_FishRewardGoldCount";
    /// <summary>
    /// 鱼奖励未发放现金金额 (float)
    /// </summary>
    public const string sv_FishRewardCashNum = "sv_FishRewardCashNum";
    /// <summary>
    /// 鱼奖励剩余发放现金次数 (int)
    /// </summary>
    public const string sv_FishRewardCashCount = "sv_FishRewardCashCount";

    /// <summary>
    /// 鱼已经生成的金币奖励队列 (int array)
    /// </summary>
    public const string sv_FishHaveGoldArray = "sv_FishHaveGoldArray";
    /// <summary>
    /// 鱼已经生成的现金奖励队列 (int array)
    /// </summary>
    public const string sv_FishHaveCashArray = "sv_FishHaveGoldArray";

    /// <summary>
    /// 贝壳已产生数量 (int)
    /// </summary>
    public const string sv_ShellHaveCount = "sv_ShellHaveCount";
    /// <summary>
    /// 贝壳奖励种类List (string array)
    /// </summary>
    public const string sv_ShellRewardTypeList = "sv_ShellRewardTypeList";
    /// <summary>
    /// 碎片以生产数量
    /// </summary>
    public const string sv_PuzzleHaveCount = "sv_PuzzleHaveCount";
    /// <summary>
    /// 碎片待释放数量
    /// </summary>
    public const string sv_PuzzleRewardCount = "sv_PuzzleRewardCount";
    /// <summary>
    /// 贝壳待释放数量 (int)
    /// </summary>
    public const string sv_ShellRewardCount = "sv_ShellRewardCount";
    /// <summary>
    /// 新手引导步数完成状态需要拼接id(bool)
    /// </summary>
    public const string sv_NewUserStep = "sv_NewUserStep_";
    /// <summary>
    /// 评价弹窗 (bool)
    /// </summary>
    public const string sv_ready_rate = "sv_ready_rate";
    /// <summary>
    /// 星星数量
    /// </summary>
    public const string sv_StarNum = "sv_StarNum";
    /// <summary>
    /// 是否为第一次结算翻倍
    /// </summary>
    public const string sv_FirstSlot = "sv_FirstSlot";

    /// <summary>
    /// adjust adid
    /// </summary>
    public const string sv_AdjustAdid = "sv_AdjustAdid";

    /// <summary>
    /// 签到最后日期 (int)
    /// </summary>
    public const string sv_DailyBounsDate = "sv_DailyBounsDate";

    /// <summary>
    /// 金币余额
    /// </summary>
    public const string sv_GoldCoin = "sv_GoldCoin";
    /// <summary>
    /// 累计金币总数
    /// </summary>
    public const string sv_CumulativeGoldCoin = "sv_CumulativeGoldCoin";
    /// <summary>
    /// 钻石/现金余额
    /// </summary>
    public const string sv_Cash = "sv_Cash";
    /// <summary>
    /// 累计钻石/现金总数
    /// </summary>
    public const string sv_CumulativeCash = "sv_CumulativeCash";
    /// <summary>
    /// 钻石Amazon
    /// </summary>
    public const string sv_Amazon = "sv_Amazon";
    /// <summary>
    /// 累计Amazon总数
    /// </summary>
    public const string sv_CumulativeAmazon = "sv_CumulativeAmazon";
    /// <summary>
    /// 游戏总时长
    /// </summary>
    public const string sv_TotalGameTime = "sv_TotalGameTime";
    /// <summary>
    /// 第一次获得钻石奖励
    /// </summary>
    public const string sv_FirstGetToken = "sv_FirstGetToken";
    /// <summary>
    /// 是否已显示评级弹框
    /// </summary>
    public const string sv_HasShowRatePanel = "sv_HasShowRatePanel";
    /// <summary>
    /// 累计Roblox奖券总数
    /// </summary>
    public const string sv_CumulativeLottery = "sv_CumulativeLottery";
    /// <summary>
    /// 已经通过一次的关卡(int array)
    /// </summary>
    public const string sv_AlreadyPassLevels = "sv_AlreadyPassLevels";
    /// <summary>
    /// 新手引导
    /// </summary>
    public const string sv_NewUserStepFinish = "sv_NewUserStepFinish";
    public const string sv_task_level_count = "sv_task_level_count";

    /// <summary>
    /// 广告相关 - trial_num
    /// </summary>
    public const string sv_ad_trial_num = "sv_ad_trial_num";
    /// <summary>
    /// 看广告总次数
    /// </summary>
    public const string sv_total_ad_num = "sv_total_ad_num";
    /// <summary>
    /// 语言
    /// </summary>
    public const string sys_language = "Language";
    /// <summary>
    /// 语言
    /// </summary>
    public const string sys_Newbg = "sys_Newbg";
    #endregion

    #region 监听发送的消息
    /// <summary>
    /// undo技能
    /// </summary>
    public static string mg_undo = "mg_undo";
    /// <summary>
    /// hint
    /// </summary>
    public static string mg_hint = "mg_hint";
    /// <summary>
    /// shuffle
    /// </summary>
    public static string mg_shuffle = "mg_shuffle";
    /// <summary>
    /// revive
    /// </summary>
    public static string mg_revive = "mg_revive";
    /// <summary>
    /// 有窗口打开
    /// </summary>
    public static string mg_WindowOpen = "mg_WindowOpen";
    /// <summary>
    /// 窗口关闭
    /// </summary>
    public static string mg_WindowClose = "mg_WindowClose";
    /// <summary>
    /// LevelPanel关卡id刷新
    /// </summary>
    public static string mg_LevelPanel_LevelNumber = "mg_LevelPanel_LevelNumber";
    /// <summary>
    /// 技能种类
    /// </summary>
    public static string mg_SkillType = "mg_SkillType";
    /// <summary>
    /// LevelCompletePanel奖励刷新
    /// </summary>
    public static string mg_LevelCompletePanel_Reward = "mg_LevelCompletePanel_Reward";
    /// <summary>
    /// levelPanel存钱罐增加刷新
    /// </summary>
    public static string mg_LevelPanel_BankAdd = "mg_LevelPanel_BankAdd";
    /// <summary>
    /// levelPanel存钱罐取出后状态刷新
    /// </summary>
    public static string mg_LevelPanel_BankClear = "mg_LevelPanel_BankClear";
    /// <summary>
    /// HomePanel存钱罐取出后状态刷新
    /// </summary>
    public static string mg_HomePanel_BankClear = "mg_HomePanel_BankClear";
    /// <summary>
    /// levelpanel增加现金
    /// </summary>
    public static string mg_LevelPanel_AddCash = "mg_LevelPanel_AddCash";
    /// <summary>
    /// 增加金币
    /// </summary>
    public static string mg_LevelPanel_AddGold = "mg_LevelPanel_AddGold";
    /// <summary>
    /// 增加amazon
    /// </summary>
    public static string mg_LevelPanel_AddAmazon = "mg_LevelPanel_AddAmazon";
    /// <summary>
    /// homePanel 增加钱数
    /// </summary>
    public static string mg_HomePanel_AddCash = "mg_HomePanel_AddCash";
    /// <summary>
    /// RewardPanel动画播放
    /// </summary>
    public static string mg_RewardPanel_Play = "mg_RewardPanel_Play";
    /// <summary>
    /// 关卡中需要提高余额层级
    /// </summary>
    public static string mg_LevelPanel_CashOrderChange = "mg_LevelPanel_CashOrderChange";
    /// <summary>
    /// 首页中需要提高余额层级
    /// </summary>
    public static string mg_HomePanel_CashOrderChange = "mg_HomePanel_CashOrderChange";
    /// <summary>
    /// 存钱罐页面打开来源
    /// </summary>
    public static string mg_BankPanel_From = "mg_BankPanel_From";
    /// <summary>
    /// levelPanel关闭动画
    /// </summary>
    public static string mg_LevelPanel_Hide = "mg_LevelPanel_Hide";
    /// <summary>
    /// BuyFishPanel传递哪条鱼
    /// </summary>
    public static string mg_BuyFishPanel_FishIndex = "mg_BuyFishPanel_FishIndex";
    /// <summary>
    /// 刷新金额
    /// </summary>
    public static string mg_RefreshGoldCash = "mg_RefreshGoldCash";
    /// <summary>
    /// 首页三个也面的切换通知
    /// </summary>
    public static string mg_HomePanelSwitchPage = "mg_HomePanelSwitchPage";
    /// <summary>
    /// 首页开始游戏
    /// </summary>
    public static string mg_HomePanelLevelStart = "mg_HomePanelLevelStart";
    /// <summary>
    /// 传递homepanel商店按键坐标点
    /// </summary>
    public static string mg_LevelUnlockEndPos = "mg_LevelUnlockEndPos";
    /// <summary>
    /// 选中鱼缸
    /// </summary>
    public static string mg_SelectFishTank = "mg_SelectFishTank";
    /// <summary>
    /// 解锁鱼缸页面传递鱼缸id
    /// </summary>
    public static string mg_UnlockFishTankPanelIndex = "mg_UnlockFishTankPanelIndex";
    /// <summary>
    /// 领取星星宝箱奖励
    /// </summary>
    public static string mg_GetStarBoxReward = "mg_GetStarBoxReward";
    /// <summary>
    /// 点击鱼奖励
    /// </summary>
    public static string mg_HomePanelGetFishReward = "mg_HomePanelGetFishReward";
    /// <summary>
    /// 新手引导消息传递2
    /// </summary>
    public static string mg_HomePanelRobloxGuide = "mg_HomePanelRobloxGuide";
    /// <summary>
    /// 新手引导消息传递3
    /// </summary>
    public static string mg_HomePanelNextGuide = "mg_HomePanelNextGuide";
    /// <summary>
    /// 新手引导消息传递4
    /// </summary>
    public static string mg_HomePanelPlayGuide = "mg_HomePanelPlayGuide";
    /// <summary>
    /// 碎片动画
    /// </summary>
    public static string mg_HomePanelAddPuzzle = "mg_HomePanelAddPuzzle";
    /// <summary>
    /// 显示自动收按键
    /// </summary>
    public static string mg_ShowAutoButton = "mg_ShowAutoButton";
    /// <summary>
    /// 隐藏自动收按键
    /// </summary>
    public static string mg_DissmissAutoButton = "mg_DissmissAutoButton";
    /// <summary>
    /// 修改星星数量
    /// </summary>
    public static string mg_ChangeStar = "mg_ChangeStar";
    /// <summary>
    /// 技能引导
    /// </summary>
    public static string mg_ShowSkillGuide = "mg_ShowSkillGuide";
    /// <summary>
    /// 提现商店引导
    /// </summary>
    public static string mg_ShowCashShopGuide = "mg_ShowCashShopGuide";

    public static string msg_close_panel_and_start = "msg_close_panel_and_start";
    /// <summary>
    /// 关卡结算时传值
    /// </summary>
    public static string mg_ui_levelcomplete = "mg_ui_levelcomplete";
    /// <summary>
    /// 增加金币
    /// </summary>
    public static string mg_ui_addgold = "mg_ui_addgold";
    /// <summary>
    /// 增加钻石/现金
    /// </summary>
    public static string mg_ui_addtoken = "mg_ui_addtoken";
    /// <summary>
    /// 增加amazon
    /// </summary>
    public static string mg_ui_addamazon = "mg_ui_addamazon";

    /// <summary>
    /// 游戏暂停/继续
    /// </summary>
    public static string mg_GameSuspend = "mg_GameSuspend";

    /// <summary>
    /// 游戏资源数量变化
    /// </summary>
    public static string mg_ItemChange_ = "mg_ItemChange_";

    /// <summary>
    /// 活动状态变更
    /// </summary>
    public static string mg_ActivityStateChange_ = "mg_ActivityStateChange_";

    /// <summary>
    /// 关卡最大等级变更
    /// </summary>
    public static string mg_LevelMaxLevelChange = "mg_LevelMaxLevelChange";

    /// <summary>
    /// 关卡结束
    /// </summary>
    public static string mg_PassLevel = "mg_PassLevel";

    /// <summary>
    /// 关卡结束
    /// </summary>
    public static string mg_StartLevel = "mg_StartLevel";
    #endregion

    #region 动态加载资源的路径
    //关卡的路径
    public static string LevelPath = "LevelArea/";
    //关卡上的节点
    public static string LevelNodePath = "LevelNode/";

    public static string SScTex_TileFishBG = "ScTex/ScTex_TileFishBG_";
    public static string ScTex_TileFishBG= "/ScTex_TileFishBG_";
    public static string ScBack = "_Back";
    public static string ScTank = "_Tank";

    public static string ScFront = "_Front";
    public static string ScMid = "_Mid";
    public static string AnimationFishAni = "Animation/FishAni/";
    public static string EffectsMatShellFlash = "Effects/Mat_ShellFlash";
    public static string EffectsFxStar = "Effects/Fx_Star";
    public static string AAniFxSoulExplosionOrange = "Animation/AniFx/Fx_SoulExplosionOrange";
    public static string AAniFxBubbleMid = "Animation/AniFx/FX_BubbleMid";
    public static string LevelJsonLevel = "LevelJson/Level_";
    public static string PrefabTileItem = "Prefab/WordClan";
    public static string TTileTestCube = "TileTestCube/TileTestCube_";
    public static string Empty = "Empty";
    public static string Full = "Full";
    public static string PrefabLevelLayer = "Prefab/ExtolLeave";
    public static string PrefabTileEditItem = "Prefab/WordSpitClan";
    public static string RobloxShopRobloxImagerobloximgLevel = "RobloxShop/RobloxImage/robloximg_Level";
    public static string RRobloxJsonCountryData = "RobloxShop/RobloxJson/CountryData";
    public static string RRobloxJsonRobloxData = "RobloxShop/RobloxJson/RobloxData";
    public static string RRobloxJsonrobloximgLevel = "RobloxShop/RobloxImage/robloximg_Level";

    public static string RRobloxRobloxIconBtn = "RobloxShop/RobloxProfab/RobloxIconBtn";
    public static string AUi_Bonus_Gold = "Art/Tex/UI/UI_BonusReward/Ui_Bonus_Gold";
    public static string AUi_Bonus_Cash = "Art/Tex/UI/UI_BonusReward/Ui_Bonus_Cash";
    public static string AUi_Bonus_Amazon = "Art/Tex/UI/UI_BonusReward/Ui_Bonus_Amazon";

    public static string Fish = "Fish/";
    public static string EffectsDailyReward7 = "Effects/UI_DailyReward7";
    public static string EffectsDailyReward = "Effects/UI_DailyReward";
    public static string EffectsDailyReward7Open = "Effects/UI_DailyReward7Open";
    public static string EffectsDailyOpen = "Effects/UI_DailyOpen";
    public static string TankBannerFishTankSC = "TankBanner/UI_FishTankSC";
    public static string EffectsFXPower = "Effects/FX_Power";
    public static string EffectsRewardBoxTopClose = "Effects/UI_RewardBoxTopClose";
    public static string EffectsMoveOffset = "Effects/Mat_MoveOffset";



    








    #endregion
}

