using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlatterRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("Sound_Button")]    [UnityEngine.Serialization.FormerlySerializedAs("Sound_Button")]public Button Whose_Untold;
[UnityEngine.Serialization.FormerlySerializedAs("Music_Button")]    [UnityEngine.Serialization.FormerlySerializedAs("Music_Button")]public Button Label_Untold;
[UnityEngine.Serialization.FormerlySerializedAs("SoundIcon")]    [UnityEngine.Serialization.FormerlySerializedAs("SoundIcon")]public Image WhoseRail;
[UnityEngine.Serialization.FormerlySerializedAs("MusicIcon")]    [UnityEngine.Serialization.FormerlySerializedAs("MusicIcon")]public Image LabelRail;
[UnityEngine.Serialization.FormerlySerializedAs("Continue_Button")]    [UnityEngine.Serialization.FormerlySerializedAs("Continue_Button")]public Button Particle_Untold;
[UnityEngine.Serialization.FormerlySerializedAs("Restart_Button")]    [UnityEngine.Serialization.FormerlySerializedAs("Restart_Button")]public Button Pendant_Untold;
[UnityEngine.Serialization.FormerlySerializedAs("MusicCloseSprite")]    [UnityEngine.Serialization.FormerlySerializedAs("MusicCloseSprite")]public Sprite LabelOvertRugged;
[UnityEngine.Serialization.FormerlySerializedAs("MusicOpenSprite")]    [UnityEngine.Serialization.FormerlySerializedAs("MusicOpenSprite")]public Sprite LabelDumpRugged;
[UnityEngine.Serialization.FormerlySerializedAs("SoundCloseSprite")]    [UnityEngine.Serialization.FormerlySerializedAs("SoundCloseSprite")]public Sprite WhoseOvertRugged;
[UnityEngine.Serialization.FormerlySerializedAs("SoundOpenSprite")]    [UnityEngine.Serialization.FormerlySerializedAs("SoundOpenSprite")]public Sprite WhoseDumpRugged;

    public override void Display()
    {
        base.Display();
        LabelRail.sprite = MusicMgr.GetInstance().BgMusicSwitch ? LabelDumpRugged : LabelOvertRugged;
        WhoseRail.sprite = MusicMgr.GetInstance().EffectMusicSwitch ? WhoseDumpRugged : WhoseOvertRugged;
    }
    // Start is called before the first frame update
    void Start()
    {
        Particle_Untold.onClick.AddListener(() => {
            CloseUIForm(GetType().Name);
        });
        Pendant_Untold.onClick.AddListener(() => {
            CloseUIForm(GetType().Name);
        });
        
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

}
