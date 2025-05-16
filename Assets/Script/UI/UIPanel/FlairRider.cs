using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlairRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("skill_icon")]    [UnityEngine.Serialization.FormerlySerializedAs("skill_icon")]public Image Scowl_icon;
[UnityEngine.Serialization.FormerlySerializedAs("undo_sprite")]    [UnityEngine.Serialization.FormerlySerializedAs("undo_sprite")]public Sprite Doll_Ashore;
[UnityEngine.Serialization.FormerlySerializedAs("hint_sprite")]    [UnityEngine.Serialization.FormerlySerializedAs("hint_sprite")]public Sprite Auto_Ashore;
[UnityEngine.Serialization.FormerlySerializedAs("shuffle_sprite")]    [UnityEngine.Serialization.FormerlySerializedAs("shuffle_sprite")]public Sprite Overrun_Ashore;
[UnityEngine.Serialization.FormerlySerializedAs("undo_text")]    [UnityEngine.Serialization.FormerlySerializedAs("undo_text")]public GameObject Doll_Mood;
[UnityEngine.Serialization.FormerlySerializedAs("hint_text")]    [UnityEngine.Serialization.FormerlySerializedAs("hint_text")]public GameObject Auto_Mood;
[UnityEngine.Serialization.FormerlySerializedAs("shuffle_text")]    [UnityEngine.Serialization.FormerlySerializedAs("shuffle_text")]public GameObject Overrun_Mood;
[UnityEngine.Serialization.FormerlySerializedAs("ad_button")]    [UnityEngine.Serialization.FormerlySerializedAs("ad_button")]public Button ad_Indeed;
    string type;
    public override void Display()
    {
        base.Display();
        

    }
    // Start is called before the first frame update
    override protected void Awake()
    {
        base.Awake();
        int ad_index = 0;
        MessageCenterLogic.GetInstance().Register(CConfig.mg_SkillType, (data) =>
        {
            type = data.valueString;
            
            switch (data.valueString)
            {
                case "mg_undo":
                    ad_index = 102;
                    Scowl_icon.sprite = Doll_Ashore;
                    Doll_Mood.SetActive(true);
                    Auto_Mood.SetActive(false);
                    Overrun_Mood.SetActive(false);
                    break;
                case "mg_hint":
                    ad_index = 103;
                    Scowl_icon.sprite = Auto_Ashore;
                    Doll_Mood.SetActive(false);
                    Auto_Mood.SetActive(true);
                    Overrun_Mood.SetActive(false);
                    break;
                case "mg_shuffle":
                    ad_index = 104;
                    Scowl_icon.sprite = Overrun_Ashore;
                    Doll_Mood.SetActive(false);
                    Auto_Mood.SetActive(false);
                    Overrun_Mood.SetActive(true);
                    break;
            }
        });
        ad_Indeed.onClick.AddListener(() =>
        {
            ADManager.Instance.playRewardVideo((success) =>
            {   
                if (success)
                {
                    MessageCenterLogic.GetInstance().Send(type);
                    UIManager.GetInstance().CloseOrReturnUIForms(this.name.Split('(')[0]);
                }
            }, ad_index.ToString());
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
