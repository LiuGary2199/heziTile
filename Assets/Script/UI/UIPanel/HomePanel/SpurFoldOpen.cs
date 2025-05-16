using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SpurFoldOpen : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("BG")]    [UnityEngine.Serialization.FormerlySerializedAs("BG")]public GameObject BG;
[UnityEngine.Serialization.FormerlySerializedAs("content")]    [UnityEngine.Serialization.FormerlySerializedAs("content")]public Transform Cottage;
[UnityEngine.Serialization.FormerlySerializedAs("FishShowOffset")]    [UnityEngine.Serialization.FormerlySerializedAs("FishShowOffset")]public float SpurNoteLeader;
[UnityEngine.Serialization.FormerlySerializedAs("FishTankItemPrefab")]    [UnityEngine.Serialization.FormerlySerializedAs("FishTankItemPrefab")]public GameObject SpurFoldClanYellow;
[UnityEngine.Serialization.FormerlySerializedAs("fishTankItemList")]    [UnityEngine.Serialization.FormerlySerializedAs("fishTankItemList")]public List<SpurFoldClan> SaleFoldClanLend;
[UnityEngine.Serialization.FormerlySerializedAs("contentLayout")]    [UnityEngine.Serialization.FormerlySerializedAs("contentLayout")]public ScrollViewContentLayout CottageSyntax;
    
    private void OnEnable()
    {
        MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_FishShopShow);
        UIManager.GetInstance().AddPanel(GetType().Name);
        //换图
        //BG.GetComponent<Image>().sprite = Resources
        BG.GetComponent<Image>().material = null;
        Cottage.gameObject.SetActive(true);
        if (SaleFoldClanLend.Count > 0)
        {
            foreach (SpurFoldClan item in SaleFoldClanLend)
            {
                item.Extract();
            }
        }
        CapExamMedical.GetInstance().AmnesiaStony(TriggerType.Spank_Flannel);
    }
    private void OnDisable()
    {
        UIManager.GetInstance().SubPanel(GetType().Name);
        CapExamMedical.GetInstance().AmnesiaStony(TriggerType.Spank_Flannel);
    }
    public void Bend()
    {
        SaleFoldClanLend = new List<SpurFoldClan>();
        for (int i = 0; i < NetInfoMgr.instance.gameData.AquariumShop.Count; i++)
        {
            GameObject fishTankItem = Instantiate<GameObject>(SpurFoldClanYellow,CottageSyntax.transform);
            AquariumShopItemData Halt= NetInfoMgr.instance.gameData.AquariumShop[i];
            fishTankItem.name = "FishTankItem_" + i;
            fishTankItem.GetComponent<SpurFoldClan>().Bend(i);
            SaleFoldClanLend.Add(fishTankItem.GetComponent<SpurFoldClan>());
        }
        CottageSyntax.setContentLayout();
        Cottage.GetComponent<CanvasGroup>().alpha = 0;
        Cottage.transform.position = new Vector3(Cottage.transform.position.x, Cottage.transform.position.y - SpurNoteLeader, Cottage.transform.position.z);

        Cottage.transform.DOMoveY((Cottage.transform.position.y + SpurNoteLeader), 0.4f).SetEase(Ease.OutBack);
        Cottage.GetComponent<CanvasGroup>().DOFade(1, 0.4f);
    }

    
    // Start is called before the first frame update
    void Awake()
    {
        MessageCenterLogic.GetInstance().Register(CConfig.mg_SelectFishTank, (messageData) =>
        {
            //Dire.instance.gamePauseMaskAll();
            //AnimationController.ScreenTransitions(BG, content.gameObject, () =>
            //{
            //    Dire.instance.canelGamePauseMaskAll();
            //    MessageCenterLogic.GetInstance().Send(CConfig.mg_HomePanelSwitchPage, new MessageData(1));

            //});

        });
        Bend();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
/*public float FishTankShowOffset;
public List<GameObject> FishTank;

private void OnEnable()
{
    FishTankShow(FishTank, () => { });
}
public void FishTankShow(List<GameObject> FishTankImage, System.Action finish)
{

    int finishCount = 0;
    float delayTime = 0;
    for (int i = 0; i < FishTankImage.Count; i++)
    {
        if (i > 0)
        {
            delayTime += Random.Range(0.1f, 0.2f);
        }
        GameObject TFimage = FishTankImage[i];
        TFimage.transform.position = new Vector3(TFimage.transform.position.x, TFimage.transform.position.y - FishTankShowOffset, TFimage.transform.position.z);
        TFimage.transform.DOMoveY((TFimage.transform.position.y + FishTankShowOffset), 0.4f).SetDelay(delayTime).SetEase(Ease.OutBack);
        TFimage.GetComponent<CanvasGroup>().DOFade(1, 0.4f).OnComplete(() =>
        {
            finishCount++;
            if (finishCount == FishTankImage.Count)
            {
                finish();
            }
        });
    }
}*/