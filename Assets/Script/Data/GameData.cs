//
// Auto Generated Code By excel2json
// https://neil3d.gitee.io/coding/excel2json.html
// 1. 每个 Sheet 形成一个 Struct 定义, Sheet 的名称作为 Struct 的名称
// 2. 表格约定：第一行是变量名称，第二行是变量类型

// Generate From D:\_工作文件\TF数值.xlsx.xlsx
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameData
{
	public List<FishShopItemData> FishShop;
    public List<AquariumShopItemData> AquariumShop;
    public List<DailyBonusItemData> DailyBonus;
    public List<BigChestItemData> BigChest;
    public List<UserLevelItemData> UserLevel;
    public List<ShellBonusItemData> ShellBonus;
    public List<NewFishBonusItemData> NewFishBonus;
    public List<NewUserGuideItemData> NewUserGuide;
}


public class FishShopItemData
{
	public string Name; // 名称
	public int BasePrice; // 价格基础值
	public int AddPrice; // 价格增值
	public string UnlockType; // 解锁条件类型
	public int UnlockValue; // 解锁条件数值
	public string ArtPath; // 资源路径
	public string SkinName; // 资源路径
    public double Pos_X; // 鱼在气泡中的相对位置
    public double Pos_Y; // 鱼在气泡中的相对位置
}

public class AquariumShopItemData
{
    public string Name; // 名称
    public int UnlockValue; // 解锁需要鱼的数量
    public int Capacity; // 最大可放鱼的数量
}

public class DailyBonusItemData
{
    public int Day; // 天数
    public string Type; // 奖励类型
    public int Value; // 奖金数量
}

public class BigChestItemData
{
    public int Level; // 等级
    public int Exp; // 升到下一级级所需经验值
    public List<ValueGroupData> ValueGroup; // 奖励内容
}
public class ValueGroupData
{
    public string type;
    public int value;
}
public class UserLevelItemData
{
    public int Level; // 等级
    public int Exp; // 升到该等级所需经验值
    public string FishName; // 对应鱼的名称
}
public class ShellBonusItemData
{
    public int RequiredLevel;
}
public class NewFishBonusItemData
{
    public int FishNumber;
}

public class NewUserGuideItemData
{
    public int ID; // 事件ID
    public string Trigger; // 触发条件
    public List<Dictionary<string, string>> Condition;
    public string TargetPanel; // 目标组件所在Panel
    public string TargetPath; // 目标组件路径
    public double HandOffset_X; // 小手偏移X
    public double HandOffset_Y; // 小手偏移Y
    public double MaskAlpha; // 遮罩Alpha
    public string Content; // 引导文案，没有的话为空
    public double ContentPos_X; // 文案位置X，没有的话为空
    public double ContentPos_Y; // 文案位置Y，没有的话为空
}
// End of Auto Generated Code
