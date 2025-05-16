using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessyRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("Music_Button")]    [UnityEngine.Serialization.FormerlySerializedAs("Music_Button")]public Button Label_Untold;
[UnityEngine.Serialization.FormerlySerializedAs("Sound_Button")]    [UnityEngine.Serialization.FormerlySerializedAs("Sound_Button")]public Button Whose_Untold;
[UnityEngine.Serialization.FormerlySerializedAs("SoundIcon")]    [UnityEngine.Serialization.FormerlySerializedAs("SoundIcon")]public Image WhoseRail;
[UnityEngine.Serialization.FormerlySerializedAs("MusicIcon")]    [UnityEngine.Serialization.FormerlySerializedAs("MusicIcon")]public Image LabelRail;
[UnityEngine.Serialization.FormerlySerializedAs("Continue_Button")]    [UnityEngine.Serialization.FormerlySerializedAs("Continue_Button")]public Button Particle_Untold;
[UnityEngine.Serialization.FormerlySerializedAs("Restart_Button")]    [UnityEngine.Serialization.FormerlySerializedAs("Restart_Button")]public Button Pendant_Untold;
[UnityEngine.Serialization.FormerlySerializedAs("MusicCloseSprite")]    /*public Button Home_Button;*/
[UnityEngine.Serialization.FormerlySerializedAs("MusicCloseSprite")]    public Sprite LabelOvertRugged;
[UnityEngine.Serialization.FormerlySerializedAs("MusicOpenSprite")]    [UnityEngine.Serialization.FormerlySerializedAs("MusicOpenSprite")]public Sprite LabelDumpRugged;
[UnityEngine.Serialization.FormerlySerializedAs("SoundCloseSprite")]    [UnityEngine.Serialization.FormerlySerializedAs("SoundCloseSprite")]public Sprite WhoseOvertRugged;
[UnityEngine.Serialization.FormerlySerializedAs("SoundOpenSprite")]    [UnityEngine.Serialization.FormerlySerializedAs("SoundOpenSprite")]public Sprite WhoseDumpRugged;

    public override void Display()
    {
        base.Display();
        LabelRail.sprite = MusicMgr.GetInstance().BgMusicSwitch ? LabelDumpRugged : LabelOvertRugged;
        WhoseRail.sprite = MusicMgr.GetInstance().EffectMusicSwitch ? WhoseDumpRugged : WhoseOvertRugged;
        if (SaveDataManager.GetInt(CConfig.sv_Level_Id) == 1)
        {
            //Home_Button.gameObject.SetActive(false);
            Pendant_Untold.gameObject.SetActive(false);
        }
        else
        {
            //Home_Button.gameObject.SetActive(true);
            Pendant_Untold.gameObject.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Particle_Untold.onClick.AddListener(() => {
            CloseUIForm(GetType().Name);
        });
        Pendant_Untold.onClick.AddListener(() => {
            Dire.instance.BraveBlade();
            CloseUIForm(GetType().Name);
        });
        /*Home_Button.onClick.AddListener(() => {
            CloseUIForm(GetType().Name);
            Dire.instance.levelFinish();

        });*/
        Label_Untold.onClick.AddListener(() => 
        {
            
            MusicMgr.GetInstance().BgMusicSwitch = !MusicMgr.GetInstance().BgMusicSwitch;
            LabelRail.sprite = MusicMgr.GetInstance().BgMusicSwitch ? LabelDumpRugged : LabelOvertRugged;
        });
        Whose_Untold.onClick.AddListener(() => 
        {

            MusicMgr.GetInstance().EffectMusicSwitch = !MusicMgr.GetInstance().EffectMusicSwitch;
            WhoseRail.sprite = MusicMgr.GetInstance().EffectMusicSwitch ? WhoseDumpRugged : WhoseOvertRugged;
        });
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
