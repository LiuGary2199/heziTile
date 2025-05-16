using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrooveMedical : MonoSingleton<GrooveMedical>
{
    public void DumpExtolEmphasisRider(RewardPanelData data)
    {
        KeyValuesUpdate keyValues = new KeyValuesUpdate(CriticBrush.WhoGrooveOust, data);
        NetInfoMgr.instance.flyreward = keyValues;
        UIManager.GetInstance().ShowUIForms(nameof(GrooveRiderCap));
        MessageCenter.SendMessage(CriticBrush.WhoGrooveOust, keyValues);
    }

    /// <summary>
    /// �ѻ������ӵ�������
    /// </summary>
    /// <param name="Dic_Reward"></param>
    public void WhoCrackMeCubic(Dictionary<RewardType, double> Dic_Reward)
    {
        foreach (var item in Dic_Reward)
        {
            if (item.Key == RewardType.gold)
            {
                //���
                Dire.instance.OwnLord(item.Value);
            }
            else if (item.Key == RewardType.cash)
            {
                //�ֽ�
                Dire.instance.OwnCook(item.Value);
            }
            else if (item.Key == RewardType.amazon)
            {
                ////����ѷ
                //DireOustMedical.GetInstance().addAmazon(item.Value);
                //SendScoreUpdate(Dic_Reward);
            }
            //else if (item.Key == RewardType.rocket)
            //{
            //    //SkillManager.GetInstance().SetRocketNumber((int)item.Value);
            //}
            //else if (item.Key == RewardType.universal)
            //{
                //SkillManager.GetInstance().SetOmnipotentNumber((int)item.Value);
            //}
           // else if (item.Key == RewardType.laser)
            //{
               // SkillManager.GetInstance().SetLaserNumber((int)item.Value);
           // }
        }
    }

    /// <summary>
    /// ���ӻ���
    /// </summary>
    /// <param name="score"></param>
    public void WhoProbe(int index, double score)
    {
        Dictionary<RewardType, double> Row_Groove= new();
        if (index == 10)
        {

            Dire.instance.OwnLord(score);
            //���
            //DireOustMedical.GetInstance().addGold(score);
            //Dic_Reward.Add(RewardType.gold, score);
        }
        else if (index == 11)
        {
            //����ѷ
            Dire.instance.OwnStrait(score);
           // Dic_Reward.Add(RewardType.amazon, score);
        }
        else if (index == 12)
        {
            //�ֽ�
            Dire.instance.OwnCook(score);
          //  Dic_Reward.Add(RewardType.cash, score);
        }
     //   SendScoreUpdate(null);
        //SendScoreUpdate(Dic_Reward);
    }

    public void TearProbeSatire(Dictionary<RewardType, double> Dic_Reward)
    {
        //KeyValuesUpdate key = new KeyValuesUpdate(CriticBrush.SendScoreUpdate, Dic_Reward);
        //MessageCenter.SendMessage(CriticBrush.SendScoreUpdate, key);
    }
}


public class RewardPanelData
{
    /// <summary>
    /// С��Ϸ����
    /// </summary>
    public string RustLace;
    public Dictionary<RewardType, double> Row_Groove;

    public RewardPanelData()
    {
        Row_Groove = new();
    }
}
