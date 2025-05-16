using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WordClan : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("tileImage")]    [UnityEngine.Serialization.FormerlySerializedAs("tileImage")]public GameObject MealNomad;
[UnityEngine.Serialization.FormerlySerializedAs("tileCash")]    [UnityEngine.Serialization.FormerlySerializedAs("tileCash")]public GameObject MealCook;
[UnityEngine.Serialization.FormerlySerializedAs("tileBlack")]    [UnityEngine.Serialization.FormerlySerializedAs("tileBlack")]public GameObject MealMaker;
[UnityEngine.Serialization.FormerlySerializedAs("data")]    [UnityEngine.Serialization.FormerlySerializedAs("data")]public LevelItemData Halt;
[UnityEngine.Serialization.FormerlySerializedAs("move_speed")]    [UnityEngine.Serialization.FormerlySerializedAs("move_speed")]public float Kiln_Rider= 15;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("isMoving")]    [UnityEngine.Serialization.FormerlySerializedAs("isMoving")]public bool NoAppear= false;
    Vector3 Charge_Nor;
    Action Impend_Ratify;

    /// <summary>
    /// 设置层级
    /// </summary>
    /// <param name="layerName"></param>
    /// <param name="layerInt"></param>
    public void BusLeave(string layerName,int layerInt)
    {
        GetComponent<SpriteRenderer>().sortingLayerName = layerName;
        GetComponent<SpriteRenderer>().sortingOrder = layerInt;
        MealNomad.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
        MealNomad.GetComponent<SpriteRenderer>().sortingOrder = layerInt + 1;
        MealMaker.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
        MealMaker.GetComponent<SpriteRenderer>().sortingOrder = layerInt + 3;
        MealCook.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
        MealCook.GetComponent<SpriteRenderer>().sortingOrder = layerInt + 2;
    }
    /// <summary>
    /// 根据对应层级显示遮罩
    /// </summary>
    /// <param name="diff_layer"></param>
    public void SpringState(int diff_layer)
    {
        if (diff_layer == 0)
        {
            MealMaker.SetActive(false);
        }
        else
        {
            MealMaker.SetActive(true);
        }
    }
    /// <summary>
    /// 设置图片
    /// </summary>
    /// <param name="index"></param>
    public void BusWordNomad(int index)
    {
        MealNomad.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(CConfig.TTileTestCube + index);
    }

    public void MealSackMe(Vector2 targetPos,Action finish)
    {
        if (targetPos.y == transform.position.y)
        {
            Kiln_Rider = 15;
        }
        else
        {
            Kiln_Rider = 10;
        }
        //Debug.Log(targetPos);
        Charge_Nor = targetPos;
        Impend_Ratify = finish;
        NoAppear = true;
    }

    void Update()
    {
        if (NoAppear)
        {
            Vector3 moveV2 = (Charge_Nor - transform.position).normalized;
            if (Mathf.Abs((Charge_Nor - transform.position).magnitude) < Mathf.Abs((moveV2 * Time.deltaTime * Kiln_Rider).magnitude) || moveV2.magnitude == 0)
            {
                transform.position = Charge_Nor;
                NoAppear = false;
                Impend_Ratify();
            }
            else
            {
                transform.position += moveV2 * Time.deltaTime * Kiln_Rider;
                
            }
        }
    }
}
