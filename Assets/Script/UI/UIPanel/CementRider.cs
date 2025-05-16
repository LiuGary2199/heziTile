using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CementRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("ad_button")]    [UnityEngine.Serialization.FormerlySerializedAs("ad_button")]public Button ad_Indeed;
[UnityEngine.Serialization.FormerlySerializedAs("Home_Button")]    [UnityEngine.Serialization.FormerlySerializedAs("Home_Button")]public Button Prey_Untold;
    // Start is called before the first frame update
    public override void Display()
    {
        base.Display();
        MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_ReviveShow);
    }
    void Start()
    {
        ad_Indeed.onClick.AddListener(() => {
            ADManager.Instance.playRewardVideo((success) =>
            {
                if (success)
                {
                    MessageCenterLogic.GetInstance().Send(CConfig.mg_revive);
                    UIManager.GetInstance().CloseOrReturnUIForms(this.name.Split('(')[0]);
                }
            }, "105");
        });
        Prey_Untold.onClick.AddListener(() => {
            ADManager.Instance.NoThanksAddCount();
            CloseUIForm(GetType().Name);
            Dire.instance.BraveBlade();
        });


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
