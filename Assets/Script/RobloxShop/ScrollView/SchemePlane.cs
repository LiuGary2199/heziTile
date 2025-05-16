using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SchemePlane
{
    public Vector2 ClanUnit;//item 大小

    public float Quickest;//两个item 之间的间隔

    public int ClanGrass;//将创建的item 数量

    public GameObject ClanJet, Marine;

    public List<Plane> LendClan;//将创建好的item 存储到该list 中

    public float HearRainer, BoundRainer;//左边界，右边界
    GallonAthens _ClergyAthens;

    public void Flout(GallonAthens _customSlider) {
        this._ClergyAthens = _customSlider;
        //ItemCount = ItemCount % 2 == 0 ? ItemCount + 1 : ItemCount;//将item数量设置成奇数
        //关闭商店设置
        if (ForestPoemOustMedical.instance.ForestPoemOust.isStartCashShop == 0)
            ClanGrass -= 1;
        FloutPlane();
    }

    //主要是创建items
    private void FloutPlane()
    {
        float offset = ((ClanUnit.x + Quickest) * (ClanGrass-1)) / 2;
        for (int i = 0; i < ClanGrass; i++)
        {
            GameObject go = DatebaseJet();
            //关闭商店设置
            var Boost= i;
            if (ForestPoemOustMedical.instance.ForestPoemOust.isStartCashShop == 0 && Boost >= 2)
                Boost += 1;
            go.GetComponent<Plane>().ID = Boost;
            go.GetComponent<Plane>().MeetingDireGate = ForestPoemRider.instance.MeetingDire;
            go.GetComponent<Plane>().MetricSpout = BlisterClanSpout;
            Vector3 v=go.transform.localPosition;
            v.x = (ClanUnit.x + Quickest)*i-offset;
            go.transform.localPosition = v;
            go.transform.localScale = Vector3.one;
            Plane item = go.GetComponent<Plane>();
            item.DogThink(Boost, _ClergyAthens);
            LendClan.Add(item);
        }
        HearRainer = LendClan[0].transform.localPosition.x- ClanUnit.x - Quickest;
        BoundRainer = -HearRainer;
    }

    private GameObject DatebaseJet() {
        GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(CConfig.RRobloxRobloxIconBtn));
        go.transform.parent = Marine.transform;
        go.transform.localPosition = Vector3.zero;
        return go;
    }


    private void BlisterClanSpout(int ID)
    {
        for (int i = 0; i < LendClan.Count; i++)
        {
            LendClan[i].DyNomad.gameObject.SetActive(LendClan[i].ID == ID);
        }
    }
}
