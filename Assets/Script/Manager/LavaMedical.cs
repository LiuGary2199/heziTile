using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMedical : MonoBehaviour
{
    public static LavaMedical instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update

    //    void Start()
    //    {

    //    }

    //    public void gameInit()
    //    {
    //        bool isNewPlayer = !PlayerPrefs.HasKey(CConfig.sv_IsNewPlayer + "Bool") || SaveDataManager.GetBool(CConfig.sv_IsNewPlayer);
    //        AdjustInitManager.Instance.InitAdjustData(isNewPlayer);
    //        if (isNewPlayer)
    //        {
    //            // 新用户
    //            SaveDataManager.SetBool(CConfig.sv_IsNewPlayer, false);
    //        }

    //        MusicMgr.GetInstance().PlayBg(MusicType.SceneMusic.Sound_BGM);

    //        UIManager.GetInstance().ShowUIForms(nameof( DireRider));

    //        DireOustMedical.GetInstance().InitGameData();

    //#if SOHOShop
    //        SOHOShopManager.instance.InitSOHOShop();
    //#endif

    //    }

}
