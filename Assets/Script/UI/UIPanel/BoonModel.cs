using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoonModel : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("InitGroup")]    [UnityEngine.Serialization.FormerlySerializedAs("InitGroup")]public GameObject TourModel;

    private GameObject IntrigueDutchBasalt;
    private float FordDrama= 120f; // 两个item的position.x之差

    // Start is called before the first frame update
    void Start()
    {
        IntrigueDutchBasalt = TourModel.transform.Find("SlotCard_1").gameObject;
        float x= FordDrama * 3;
        int multiCount = NetInfoMgr.instance.InitData.slot_group.Count;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < multiCount; j++)
            {
                GameObject fangkuai = Instantiate(IntrigueDutchBasalt, TourModel.transform);
                fangkuai.transform.localPosition = new Vector3(x + FordDrama * multiCount * i + FordDrama * j, IntrigueDutchBasalt.transform.localPosition.y, 0);
                fangkuai.transform.Find("Text").GetComponent<Text>().text = "×" + NetInfoMgr.instance.InitData.slot_group[j].multi;
            }
        }
    }

    public void BendDutch()
    {
        TourModel.GetComponent<RectTransform>().localPosition = new Vector3(0, -10, 0);
    }

    public void Flop(int index, Action<int> finish)
    {
        MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_OneArmBandit);
        AnimationController.HorizontalScroll(TourModel, -(FordDrama * 2 + FordDrama * NetInfoMgr.instance.InitData.slot_group.Count * 3 + FordDrama * (index + 1)), () =>
        {
            finish?.Invoke(NetInfoMgr.instance.InitData.slot_group[index].multi);
        });
    }
}
