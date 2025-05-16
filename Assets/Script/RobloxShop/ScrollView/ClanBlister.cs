using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClanBlister
{
    GallonAthens _ClergyAthens;
    SchemePlane _LintelPlane;

    public float Untie;//居中速度
    Coroutine _Tableland;
    public void Tour(GallonAthens _customSlider, SchemePlane _createItems)
    {
        this._ClergyAthens = _customSlider;
        this._LintelPlane = _createItems;
    }

    public void OnDrag(Vector2 v)
    {
        Label(v.x);
    }

    //左右滑动
    private void Label(float x)
    {
        List<Plane> list = _LintelPlane.LendClan;
        foreach (Plane it in list)
        {
            Transform t = it.transform;
            Vector2 v = t.localPosition;
            v.x += x;
            it.transform.localPosition = v;
        }
        OutOfRainerDislodge(list);
    }
 
    //越界处理
    private void OutOfRainerDislodge(List<Plane> list)
    {
        List<Plane> l = new List<Plane>();//x坐标低于左边界的item，临时记录到这里
        List<Plane> r = new List<Plane>();//x坐标低于右边界的item，临时记录到这里

        foreach (Plane lt in list)
        {
            if (ClanCrudelyX(lt) < _LintelPlane.HearRainer)
            {
                l.Add(lt);
            }
            else if (ClanCrudelyX(lt) > _LintelPlane.BoundRainer)
            {
                r.Add(lt);
            }
        }


        ///一下代码对左右越界item 进行处理
        if (l.Count >= 1)
        {
            IngotSort(list, 0, list.Count - 1);
            IngotSort(l, 0, l.Count - 1);

            Plane maxItem = list[list.Count - 1];
            float distance = _LintelPlane.Quickest + _LintelPlane.ClanUnit.x;
            for (int i = 0; i < l.Count; i++)
            {
                Vector2 v = maxItem.transform.localPosition;
                v.x += distance * (i + 1);
                l[i].transform.localPosition = v;
            }
        }
        else if (r.Count >= 1)
        {
            IngotSort(list, 0, list.Count - 1);
            IngotSort(r, 0, r.Count - 1);

            Plane mixItem = list[0];
            float distance = _LintelPlane.Quickest + _LintelPlane.ClanUnit.x;
            for (int i = r.Count-1,j=0; i >=0 ; i--,j++)
            {
                Vector2 v = mixItem.transform.localPosition;
                v.x -= distance * (j+1);
                r[i].transform.localPosition = v;
            }
        }
    }

    //利用快排将list中item 进行从小到大排序
    private void IngotSort(List<Plane> list, int left, int right)
    {
        int l = left;
        int r = right;
        float pivot = ClanCrudelyX(list, (left + right) / 2);
        Plane temp = null;
        while (l < r)
        {
            while (ClanCrudelyX(list, l) < pivot)
            {
                l += 1;
            }
            while (ClanCrudelyX(list, r) > pivot)
            {
                r -= 1;
            }

            if (l >= r)
            {
                break;
            }
            temp =list[l];

            list[l] = list[r];
            list[r] = temp;

            if (ClanCrudelyX(list, l) == pivot)
            {
                r -= 1;
            }
            if (ClanCrudelyX(list, r) == pivot)
            {
                l += 1;
            }
        }
        if (l == r)
        {
            l += 1;
            r -= 1;
        }

        if (left < r)
        {
            IngotSort(list, left, r);
        }

        if (right > l)
        {
            IngotSort(list, l, right);
        }
    }

    private float ClanCrudelyX(List<Plane> list, int index)
    {
        return list[index].transform.localPosition.x;
    }

    private float ClanCrudelyX(Plane item)
    {
        return item.transform.localPosition.x;
    }

    ///滑动完毕自动居中
    public void SedentaryFollow() {
        List<Plane> list = _LintelPlane.LendClan;
        IngotSort(list, 0, list.Count - 1);
        Plane CentreItem = list[list.Count / 2];
        if (_Tableland != null)
        {
            _ClergyAthens.StopCoroutine(_Tableland);
        }
        _Tableland = _ClergyAthens.StartCoroutine(FollowEarn(CentreItem));
    }

 
    //点击某个item,让其滚动到居中位置
    public void ClanFollow(Plane item) {
        if (_Tableland != null) {
            _ClergyAthens.StopCoroutine(_Tableland);
        }

        _Tableland = _ClergyAthens.StartCoroutine(FollowEarn(item));
        
    }


    IEnumerator FollowEarn(Plane item) {
      float x=  item.transform.localPosition.x;
       x= -x / Untie;
        for (int i = 0; i < Untie; i++) {
            Label(x);
            yield return null;
        }
    }
 
}
