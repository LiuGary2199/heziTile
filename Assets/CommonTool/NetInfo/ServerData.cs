using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//登录服务器返回数据
public class RootData 
{
    public int code { get; set; }
    public string msg { get; set; }
    public ServerData data { get; set; }
}
//用户登录信息
public class ServerUserData
{
    public int code { get; set; }
    public string msg { get; set; }
    public int data { get; set; }
}
//服务器的数据
public class ServerData
{
    public string init { get; set; }
    public string apple_pie { get; set; }
    public string bgswitch { get; set; }
    public string inter_b2f_count { get; set; }
    public string inter_b2f_freq { get; set; }
    public string ad_fail_interval { get; set; }
    public string ad_limit_interval { get; set; }
    public string ad_limit_hour { get; set; }
    public string game_data { get; set; }
    public string ad_limit { get; set; }
    public string inter_freq { get; set; }
    public string inter_delay { get; set; }
    public string inter_count { get; set; }
    public string relax_interval { get; set; }
    public string trial_MaxNum { get; set; }
    public string version { get; set; }
    public string nextlevel_interval { get; set; }
    public string init_ru { get; set; }
    public string init_br { get; set; }
    public string init_jp { get; set; }
    public string init_us { get; set; }
    public string adjust_init_rate_act { get; set; }
    public string adjust_init_act_position { get; set; }
    public string adjust_init_adrevenue { get; set; }
    public string soho_shop { get; set; }
    public string soho_shop_jp { get; set; }
    public string soho_shop_br { get; set; }
    public string soho_shop_ru { get; set; }
    public string soho_shop_us { get; set; }
    public string task_data { get; set; }
    public string task_data_jp { get; set; }
    public string task_data_br { get; set; }
    public string task_data_ru { get; set; }
    public string task_data_us { get; set; }
}
public class Init
{
    public double[] cash_random { get; set; }
    /// <summary>
    /// 星星宝箱 - 现金基数(需要*multi)
    /// </summary>
    public double starbox_cash_price { get; set; }
    /// <summary>
    /// 星星宝箱 - 金币基数(需要*multi)
    /// </summary>
    public double starbox_gold_price { get; set; }
    /// <summary>
    /// 星星宝箱 - amazon基数(需要*multi)
    /// </summary>
    public double starbox_amazon_price { get; set; }
    /// <summary>
    /// 星星宝箱 - 出现技能概率
    /// </summary>
    public double starbox_skill_chance { get; set; }

    /// <summary>
    /// 关卡结算 - 现金基数(需要*multi)
    /// </summary>
    public double passlevel_cash_price { get; set; }

    /// <summary>
    /// 小额奖励 - 触发概率
    /// </summary>
    public double small_reward_chance { get; set; }
    /// <summary>
    /// 小额奖励 - 权重(key:gold,cash)
    /// </summary>
    public Dictionary<string, int> small_reward_weight_group { get; set; }
    /// <summary>
    /// 小额奖励 - 现金基数(需要*multi)
    /// </summary>
    public double small_reward_cash_price { get; set; }
    /// <summary>
    /// 小额奖励 - 金币基数(需要*multi)
    /// </summary>
    public double small_reward_gold_price { get; set; }

    /// <summary>
    /// 大额奖励 - 间隔时间
    /// </summary>
    public int big_reward_time { get; set; }
    /// <summary>
    /// 大额奖励 - 权重(key:gold,cash,puzzle,amazon)
    /// </summary>
    public Dictionary<string, int> big_reward_weight_group { get; set; }
    /// <summary>
    /// 大额奖励 - 现金基数(需要*multi)
    /// </summary>
    public double big_reward_cash_price { get; set; }
    /// <summary>
    /// 大额奖励 - 金币基数(需要*multi)
    /// </summary>
    public double big_reward_gold_price { get; set; }
    /// <summary>
    /// 大额奖励 - amazon基数(需要*multi)
    /// </summary>
    public double big_reward_amazon_price { get; set; }

    public List<GroupItem> cash_group { get; set; }
    public List<GroupItem> gold_group { get; set; }
    public List<GroupItem> amazon_group { get; set; }

    public int hint_price { get; set; }
    public int undo_price { get; set; }
    public int shuffle_price { get; set; }
    public int revive_price { get; set; }

    public List<SlotItem> slot_group { get; set; }

}

public class GroupItem
{
    /// <summary>
    /// 
    /// </summary>
    public int max { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int multi { get; set; }
    
}

public class MultiGroup
{
    public int max { get; set; }
    public double multi { get; set; }
    public double weight_multi { get; set; }
}
public class SlotItem
{
    public int multi { get; set; }
    public int weight { get; set; }
}

public class FlyBubbleCfg
{    
    public FlyBubble fly_bubble_config { get; set; }
}

public class FlyBubble
{
    public string type { get; set; }
    public double multi { get; set; }
    public int cold_down { get; set; }
}
