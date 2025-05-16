using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExtolDDMedical
{
    DateTime BraveBladeTerm;        //关卡开始时间
    int BraveTollTerm;              //关卡已使用时间
    int Stuff3SillyTerm;            //每次消除进行一次时间补偿
    public int BraveProbe;          //关卡的实时评分
    public levelDD SuitExtolDD;     //用户的实时难度等级计算
    public enum levelDD
    {
        master = 0,
        hard = -1,
        mid = -2,
        easy = -3
    }

    public static ExtolDDMedical instance;
    public static ExtolDDMedical Datebase    {
        get
        {
            if(null == instance)
            {
                instance = new ExtolDDMedical();
            }
            return instance;
        }
    }

    private ExtolDDMedical()
    {

    }

    
    public void BraveProbeTour()
    {
        BraveBladeTerm = DateTime.Now;
        BraveTollTerm = 0;
        Stuff3SillyTerm = 0;
    }

    public void BraveProbeHero()
    {
        Stuff3SillyTerm += 1;
        BraveTollTerm += GetSystemData.GetInstance().SecDateDiff(BraveBladeTerm.ToString(), DateTime.Now);
        BraveBladeTerm = DateTime.Now;
        BraveProbe = BraveTollTerm - Stuff3SillyTerm;
        if (BraveProbe <= 60)
        {
            SuitExtolDD = levelDD.master;
        }
        else if (BraveProbe > 60 && BraveProbe <= 150)
        {
            SuitExtolDD = levelDD.hard;
        }
        else if (BraveProbe > 150 && BraveProbe <= 240)
        {
            SuitExtolDD = levelDD.mid;
        }
        else
        {
            SuitExtolDD = levelDD.easy;
        }
        //Debug.Log("Level: " + SaveDataManager.GetInt(CConfig.sv_Level_Id) + ", levelScore: " + levelScore + ", userLevelDD: " + userLevelDD);
    }

}
