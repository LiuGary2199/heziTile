using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class SpurPoemOpen : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("ScrollView")]    [UnityEngine.Serialization.FormerlySerializedAs("ScrollView")]public Transform DeadlyPlan;
[UnityEngine.Serialization.FormerlySerializedAs("content")]    [UnityEngine.Serialization.FormerlySerializedAs("content")]public Transform Cottage;
[UnityEngine.Serialization.FormerlySerializedAs("SpurPoemClan")]    [UnityEngine.Serialization.FormerlySerializedAs("SpurPoemClan")]public GameObject SpurPoemClan;
[UnityEngine.Serialization.FormerlySerializedAs("FishShowOffset")]    [UnityEngine.Serialization.FormerlySerializedAs("FishShowOffset")]public float SpurNoteLeader;
[UnityEngine.Serialization.FormerlySerializedAs("fishShopItemList")]    [UnityEngine.Serialization.FormerlySerializedAs("fishShopItemList")]public List<SpurPoemClan> SalePoemClanLend;
    GameData FirnOust;
    private void OnEnable()
    {
        MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_FishShopShow);
        UIManager.GetInstance().AddPanel(GetType().Name);
        DeadlyPlan.GetComponent<CanvasGroup>().alpha = 0;
        DeadlyPlan.transform.position = new Vector3(DeadlyPlan.transform.position.x, DeadlyPlan.transform.position.y - SpurNoteLeader, DeadlyPlan.transform.position.z);
        DeadlyPlan.transform.DOMoveY((DeadlyPlan.transform.position.y + SpurNoteLeader), 0.4f).SetEase(Ease.OutBack);
        DeadlyPlan.GetComponent<CanvasGroup>().DOFade(1, 0.4f);
        foreach (SpurPoemClan fishItem in SalePoemClanLend)
        {
            fishItem.Meeting();
        }
        CapExamMedical.GetInstance().AmnesiaStony(TriggerType.Spank_Flannel);
    }
    private void OnDisable()
    {
        UIManager.GetInstance().SubPanel(GetType().Name);
        CapExamMedical.GetInstance().AmnesiaStony(TriggerType.Spank_Flannel);
    }
    // Start is called before the first frame update
    private void Awake()
    {
        shopTour();
    }
    void shopTour()
    {
        SalePoemClanLend = new List<SpurPoemClan>();
        FirnOust = NetInfoMgr.instance.gameData;
        for (int i = 0; i < FirnOust.FishShop.Count; i++)
        {
            GameObject fishItem = Instantiate(SpurPoemClan, Cottage);
            fishItem.name = "FishShopItem_" + i;
            fishItem.GetComponent<SpurPoemClan>().Bend(i);
            SalePoemClanLend.Add(fishItem.GetComponent<SpurPoemClan>());
        }
        Cottage.GetComponent<ScrollViewContentLayout>().setContentLayout();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
