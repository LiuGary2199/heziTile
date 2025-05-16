using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtil : MonoSingleton<GameUtil>
{

    /// <summary>
    /// 游戏过程中，获得小额奖励
    /// </summary>
    /// <returns></returns>
    public TileReward getSmallReward()
    {
        //// 获奖概率
        if (!RandomUtil.InChance(NetInfoMgr.instance.InitData.small_reward_chance))
        {
            return null;
        }
        TileReward result = new TileReward();
        string type = RandomUtil.GetWeightRandom(NetInfoMgr.instance.InitData.small_reward_weight_group);
        // apple状态只能获得金币奖励
        RewardType rewardType = IsApple() ? RewardType.gold : (RewardType)Enum.Parse(typeof(RewardType), type);
        result.rewardType = rewardType;

        if (rewardType == RewardType.gold)
        {
            result.rewardValue = NetInfoMgr.instance.InitData.small_reward_gold_price * Dire.instance.WhoLordDutch();
        }
        else if (rewardType == RewardType.cash)
        {
            result.rewardValue = NetInfoMgr.instance.InitData.small_reward_cash_price * Dire.instance.WhoCookDutch();
        }

        // Just For Debug
        //TileReward result = new TileReward();
        //result.rewardType = RewardType.gold;
        //result.rewardValue = 10;

        return result;
    }


    public TileReward getBigReward()
    {
        Dire.instance.GapGrooveRed++;
        if (Dire.instance.GapGrooveBladeTerm < NetInfoMgr.instance.InitData.big_reward_time || Dire.instance.GapGrooveRed < GameConfig.BigRewardRemoveTimes)
        {
            return null;
        }

        TileReward result = new TileReward();
        string type = RandomUtil.GetWeightRandom(NetInfoMgr.instance.InitData.big_reward_weight_group);
        // apple状态只能获得金币奖励
        RewardType rewardType = IsApple() ? RewardType.gold : (RewardType)Enum.Parse(typeof(RewardType), type);
        result.rewardType = rewardType;

        if (rewardType == RewardType.gold)
        {
            result.rewardValue = NetInfoMgr.instance.InitData.big_reward_gold_price * Dire.instance.WhoLordDutch();
        }
        else if (rewardType == RewardType.cash)
        {
            result.rewardValue = NetInfoMgr.instance.InitData.big_reward_cash_price * Dire.instance.WhoCookDutch();
        }
        else if (rewardType == RewardType.amazon)
        {
            result.rewardValue = NetInfoMgr.instance.InitData.big_reward_amazon_price * Dire.instance.WhoStraitDutch();
        }
        else if (rewardType == RewardType.puzzle)
        {
            //Puzzle puzzle = SOHOShopManager.instance.GetRewardPuzzle();
            //// 如果没有进度未达到99%的碎片，则重新计算一个奖励
            //if (puzzle == null)
            //{
            //    NetInfoMgr.instance.InitData.big_reward_weight_group["puzzle"] = 0;
            //    return getBigReward();
            //}
            //else
            //{
            //    result.rewardValue = puzzle.reward_count;
            //    result.puzzle = puzzle;
            //}
        }
        return result;
    }

    // 开启星星宝箱所需星星数量
    public static int StarBoxNum()
    {
        int num = GameConfig.MaxStarNum;
        if (IsApple())
        {
            num = 300;
        }
        return num;
    }

    public static bool IsApple()
    {
        return CommonUtil.IsApple();
    }


    /// <summary>
    /// 获取multi系数
    /// </summary>
    /// <returns></returns>
    private static double GetMulti(RewardType type, double cumulative, MultiGroup[] multiGroup)
    {
        foreach (MultiGroup item in multiGroup)
        {
            if (item.max > cumulative)
            {
                if (type == RewardType.cash)
                {
                    float random = UnityEngine.Random.Range((float)NetInfoMgr.instance.InitData.cash_random[0], (float)NetInfoMgr.instance.InitData.cash_random[1]);
                    return item.multi * (1 + random);
                }
                else
                {
                    return item.multi;
                }
            }
        }
        return 1;
    }

    //public static double GetGoldMulti()
    //{
    //    return GetMulti(RewardType.gold, SaveDataManager.GetDouble(CConfig.sv_CumulativeGoldCoin), NetInfoMgr.instance.InitData.gold_group);
    //}

    //public static double GetCashMulti()
    //{
    //    return GetMulti(RewardType.cash, SaveDataManager.GetDouble(CConfig.sv_CumulativeToken), NetInfoMgr.instance.InitData.cash_group);
    //}
    //public static double GetAmazonMulti()
    //{
    //    return GetMulti(RewardType.amazon, SaveDataManager.GetDouble(CConfig.sv_CumulativeAmazon), NetInfoMgr.instance.InitData.amazon_group);
    //}
}


/// <summary>
/// 奖励类型
/// </summary>
public class TileReward
{
    public RewardType rewardType;
    public double rewardValue;
  //  public Puzzle puzzle;
}
public enum RewardType { gold, cash, amazon, puzzle, skill, fish }
