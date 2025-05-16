using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GallonAthens : MonoBehaviour,IDragHandler, IEndDragHandler
{
[UnityEngine.Serialization.FormerlySerializedAs("SchemePlane")]    [UnityEngine.Serialization.FormerlySerializedAs("SchemePlane")]public SchemePlane SchemePlane;//主要作用创建item
[UnityEngine.Serialization.FormerlySerializedAs("ClanBlister")]    [UnityEngine.Serialization.FormerlySerializedAs("ClanBlister")]public ClanBlister ClanBlister;//进行无限制的左右滑动
    void Start()
    {
        SchemePlane.Flout(this);
        ClanBlister.Tour(this,SchemePlane);
        //SchemePlane.ListItem[2].OnPointerClick(null);
    }


    public void OnDrag(PointerEventData eventData)
    {
        ClanBlister.OnDrag(eventData.delta);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ClanBlister.SedentaryFollow();
    }

    public void ClanFollow(Plane item)
    {
        ClanBlister.ClanFollow( item);
    }
}
