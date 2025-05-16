using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GapDecorRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("ProgressImage")]    [UnityEngine.Serialization.FormerlySerializedAs("ProgressImage")]public Image RelationNomad;
[UnityEngine.Serialization.FormerlySerializedAs("needLevelNumberText")]    [UnityEngine.Serialization.FormerlySerializedAs("needLevelNumberText")]public Text needExtolPointeDawn;
[UnityEngine.Serialization.FormerlySerializedAs("PlayButton")]    [UnityEngine.Serialization.FormerlySerializedAs("PlayButton")]public Button TollUntold;
    public override void Display()
    {
        base.Display();
        BigChestItemData Halt= Dire.instance.WhoBladeSumGemOust();
        RelationNomad.fillAmount = (float)Dire.instance.WhoRakeSumDay() / Halt.Exp;
        int count = Halt.Exp - Dire.instance.WhoRakeSumDay();
        GetComponent<I2.Loc.LocalizationParamsManager>().SetParameterValue("star_box", count.ToString());
        //needLevelNumberText.GetComponent<I2.Loc.Localize>().SetTerm(needLevelNumberText.GetComponent<I2.Loc.Localize>().Term);
        //needLevelNumberText.text = "play " + ((data.Exp - Dire.instance.getStarBoxExp()) / int.Parse(NetInfoMgr.instance.InitData.level_pass_bigchest)) + " more games to unlock big chest";
    }
    // Start is called before the first frame update
    void Start()
    {
        TollUntold.onClick.AddListener(() =>
        {
            CloseUIForm(GetType().Name);
            MessageCenterLogic.GetInstance().Send(CConfig.mg_HomePanelLevelStart);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
