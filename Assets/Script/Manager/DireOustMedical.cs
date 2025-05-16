using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DireOustMedical : MonoSingleton<DireOustMedical>
{
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    public void InitGameData()
//    {
//#if SOHOShop
//        // 提现商店初始化
//        // 提现商店中的金币、现金和amazon卡均为double类型，参数请根据具体项目自行处理
//        SOHOShopManager.instance.InitSOHOShopAction(
//            getToken,
//            getGold, 
//            getAmazon,    // amazon
//            (subToken) => { addToken(-subToken); }, 
//            (subGold) => { addGold(-subGold); }, 
//            (subAmazon) => { addAmazon(-subAmazon); });
//#endif
//    }

//    // 金币
//    public double getGold()
//    {

//        return SaveDataManager.GetDouble(CConfig.sv_GoldCoin);
//    }

//    public void addGold(double gold)
//    {
//        addGold(gold, LavaMedical.instance.transform);
//    }

//    public void addGold(double gold, Transform startTransform)
//    {
//        double oldGold = SaveDataManager.GetDouble(CConfig.sv_GoldCoin);
//        SaveDataManager.SetDouble(CConfig.sv_GoldCoin, oldGold + gold);
//        if (gold > 0)
//        {
//            SaveDataManager.SetDouble(CConfig.sv_CumulativeGoldCoin, SaveDataManager.GetDouble(CConfig.sv_CumulativeGoldCoin) + gold);
//        }
//        MessageData md = new MessageData(oldGold);
//        md.valueTransform = startTransform;
//        MessageCenterLogic.GetInstance().Send(CConfig.mg_ui_addgold, md);
//    }
    
//    // 现金
//    public double getToken()
//    {
//        return SaveDataManager.GetDouble(CConfig.sv_Token);
//    }

//    public void addToken(double token)
//    {
//        addToken(token, LavaMedical.instance.transform);
//    }
//    public void addToken(double token, Transform startTransform)
//    {
//        double oldToken = PlayerPrefs.HasKey(CConfig.sv_Token) ? double.Parse(SaveDataManager.GetString(CConfig.sv_Token)) : 0;
//        double newToken = oldToken + token;
//        SaveDataManager.SetDouble(CConfig.sv_Token, newToken);
//        if (token > 0)
//        {
//            double allToken = SaveDataManager.GetDouble(CConfig.sv_CumulativeToken);
//            SaveDataManager.SetDouble(CConfig.sv_CumulativeToken, allToken + token);
//        }
//#if SOHOShop
//        SOHOShopManager.instance.UpdateCash();
//#endif
//        MessageData md = new MessageData(oldToken);
//        md.valueTransform = startTransform;
//        MessageCenterLogic.GetInstance().Send(CConfig.mg_ui_addtoken, md);
//    }

//    //Amazon卡
//    public double getAmazon()
//    {
//        return SaveDataManager.GetDouble(CConfig.sv_Amazon);
//    }

//    public void addAmazon(double amazon)
//    {
//        addAmazon(amazon, LavaMedical.instance.transform);
//    }
//    public void addAmazon(double amazon, Transform startTransform)
//    {
//        double oldAmazon = PlayerPrefs.HasKey(CConfig.sv_Amazon) ? double.Parse(SaveDataManager.GetString(CConfig.sv_Amazon)) : 0;
//        double newAmazon = oldAmazon + amazon;
//        SaveDataManager.SetDouble(CConfig.sv_Amazon, newAmazon);
//        if (amazon > 0)
//        {
//            double allAmazon = SaveDataManager.GetDouble(CConfig.sv_CumulativeAmazon);
//            SaveDataManager.SetDouble(CConfig.sv_CumulativeAmazon, allAmazon + amazon);
//        }
//        MessageData md = new MessageData(oldAmazon);
//        md.valueTransform = startTransform;
//        MessageCenterLogic.GetInstance().Send(CConfig.mg_ui_addamazon, md);
//    }
}
