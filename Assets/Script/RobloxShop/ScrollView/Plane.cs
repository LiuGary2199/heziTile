using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Plane : MonoBehaviour,IPointerClickHandler
{
[UnityEngine.Serialization.FormerlySerializedAs("ID")]    [UnityEngine.Serialization.FormerlySerializedAs("ID")]public int ID;
[UnityEngine.Serialization.FormerlySerializedAs("itemImage")]    [UnityEngine.Serialization.FormerlySerializedAs("itemImage")]public Image FordNomad;
[UnityEngine.Serialization.FormerlySerializedAs("BgImage")]    [UnityEngine.Serialization.FormerlySerializedAs("BgImage")]public Image DyNomad;
    GallonAthens _ClergyAthens;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshGameInfo")]    [UnityEngine.Serialization.FormerlySerializedAs("RefreshGameInfo")]public Action<int> MeetingDireGate;
[UnityEngine.Serialization.FormerlySerializedAs("SelectStage")]    [UnityEngine.Serialization.FormerlySerializedAs("SelectStage")]public Action<int> MetricSpout;
    
    public void DogThink(int _index, GallonAthens _customSlider) {
        ID = _index;
        this._ClergyAthens = _customSlider;
        FordNomad.sprite = ForestPoemOustMedical.instance.OakRuggedMeID(ForestPoemOustMedical.instance.ForestPoemOust.Shop_class[ID].logoPath);
        if(ID == 3 && ForestPoemOustMedical.instance.ForestPoemOust.isStartCashShop == 0 )
        {
            DyNomad.gameObject.SetActive(true);
        }
        if(ID == 2)
            DyNomad.gameObject.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_ClergyAthens != null) {
            _ClergyAthens.ClanFollow(this);
            MetricSpout?.Invoke(ID);
            MeetingDireGate?.Invoke(ID);
        }
    }

}
