using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobloxShopDataConfig
{
    //public List<RobuxData> Robux_list { get; set; }
    public List<Roblox_gameItem> Shop_class { get; set; }
    public List<RobloxItemData> Characters_list { get; set; }
    public List<RobloxItemTwoData> Props_list { get; set; }
    public List<int> ChipWeight_group { get; set; }
    public List<List<int>> ChipGetValue_group { get; set; }
    public string ChipGetAds_CD;
    public List<int> ChipWeight_CA { get; set; }
    public List<int> RookiePackage { get; set; }
    public List<TaskItemData> Task { get; set; }
    public int RookiePackageCount { get; set; }
    public int RookiePackageMulti { get; set; }
    
    public int isStartCashShop { get; set; }
}

public class Roblox_gameItem
{
    public List<RobuxData> Shop_list { get; set; }
    public string unitName { get; set; }
    public string iconPath { get; set; }
    public string bgPath { get; set; }
    public string logoPath { get; set; }
}

public class RobuxData
{
    public int ID;
    public int currencyValue;
    public int CostType;
    public int CostValue;
    public string iconPath;
    public int TaskID;
}

public class RobloxItemData
{
    public int ID;
    public string Name;
    public string Description;
    public string Level;
    public string Img;
    public int CostType;
    public int CostValue;
    public List<string> Weight;
    public string Msg;
}

public class RobloxItemTwoData
{
    public int ID;
    public string Name;
    public string Description;
    public string Level;
    public string Img;
    public string Subcategory;
    public int CostType;
    public int CostValue;
    public List<string> Weight;
    public string Msg;
}
public class TaskItemData
{
    public int Type;
    public int Value;
    public string PicURI;
    public string Description;

}

public class CountryInfo
{
    public List<CountryData> Country_Info { get; set; }
}

public class CountryData
{
    public List<int> GetValue;
    public string countryName;
    public string currencyName;
    public string iconPath;
}

