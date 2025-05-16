using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SpurFoldClan : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("BannerImage")]    [UnityEngine.Serialization.FormerlySerializedAs("BannerImage")]public Image WateryNomad;
[UnityEngine.Serialization.FormerlySerializedAs("LockMask")]    [UnityEngine.Serialization.FormerlySerializedAs("LockMask")]public GameObject LashArab;
[UnityEngine.Serialization.FormerlySerializedAs("NameText")]    [UnityEngine.Serialization.FormerlySerializedAs("NameText")]public Text LobeDawn;
[UnityEngine.Serialization.FormerlySerializedAs("CapacityText")]    [UnityEngine.Serialization.FormerlySerializedAs("CapacityText")]public Text StrategyDawn;
[UnityEngine.Serialization.FormerlySerializedAs("Button")]    [UnityEngine.Serialization.FormerlySerializedAs("Button")]public Button Untold;
[UnityEngine.Serialization.FormerlySerializedAs("selectImage")]    [UnityEngine.Serialization.FormerlySerializedAs("selectImage")]public Image CooperNomad;
[UnityEngine.Serialization.FormerlySerializedAs("selectSprite")]    [UnityEngine.Serialization.FormerlySerializedAs("selectSprite")]public Sprite CooperRugged;
[UnityEngine.Serialization.FormerlySerializedAs("normalSprite")]    [UnityEngine.Serialization.FormerlySerializedAs("normalSprite")]public Sprite BreezeRugged;
[UnityEngine.Serialization.FormerlySerializedAs("TankIcon")]    [UnityEngine.Serialization.FormerlySerializedAs("TankIcon")]public Image FoldRail;
    int Boost;
    private void Awake()
    {
        Untold.onClick.AddListener(() =>
        {
            if (SaveDataManager.GetInt(CConfig.sv_SelectFishTank) != Boost && Dire.instance.WhoSpurFoldMeCement(Boost))
            {
                MessageCenterLogic.GetInstance().Send(CConfig.mg_SelectFishTank,new MessageData(Boost));
                CooperNomad.sprite = CooperRugged;
            }
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_SelectFishTank, (messageData) =>
        {
            if (messageData.valueInt != Boost)
            {
                CooperNomad.sprite = BreezeRugged;
            }
        });
    }
    public void Bend(int i)
    {
        Boost = i;
        
        WateryNomad.sprite = Resources.Load<Sprite>(CConfig.TankBannerFishTankSC + (1+i));
        FoldRail.sprite = Resources.Load<Sprite>(CConfig.SScTex_TileFishBG + (Boost + 1) + CConfig.ScTex_TileFishBG + (Boost + 1) + CConfig.ScTank);
        LobeDawn.text = I2.Loc.LocalizationManager.GetTranslation("Aq/"+ NetInfoMgr.instance.gameData.AquariumShop[i].Name);
        
        Extract();
    }
    public void Extract()
    {
        if (Dire.instance.WhoSpurFoldMeCement(Boost))
        {
            LashArab.SetActive(false);
        }
        else
        {
            LashArab.SetActive(true);
        }
        if (SaveDataManager.GetInt(CConfig.sv_SelectFishTank) == Boost)
        {
            CooperNomad.sprite = CooperRugged;
        }
        else
        {
            CooperNomad.sprite = BreezeRugged;
        }
        StrategyDawn.text = SaveDataManager.GetIntArray(CConfig.sv_TankHaveFishList).Length + "/" + NetInfoMgr.instance.gameData.AquariumShop[Boost].Capacity;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
