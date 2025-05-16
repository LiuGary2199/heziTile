using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PhysicsFalcon : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("PuzzleImage")]    [UnityEngine.Serialization.FormerlySerializedAs("PuzzleImage")]public GameObject FalconNomad;  //��ƤͼƬ
[UnityEngine.Serialization.FormerlySerializedAs("PuzzleGroup")]    [UnityEngine.Serialization.FormerlySerializedAs("PuzzleGroup")]public GameObject FalconModel;  //�Աߵ���ʾ��
[UnityEngine.Serialization.FormerlySerializedAs("P")]    [UnityEngine.Serialization.FormerlySerializedAs("P")]public Transform P;             //��ʾ���ĳ�ʼλ��
    public Text Value;              //��Ƭ������

    
    /// <summary>
    /// ��Ƭ�ռ�����
    /// </summary>
    public void FalconFormation()
    {
        //��ʼ��
        Specialization();
        //��������
        var A = DOTween.Sequence();
        //��ƬͼƬ�Ŵ�
        A.Append(FalconNomad.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack));
        //�Աߵ���ʾ������
        A.Append(FalconModel.transform.DOMoveX(FalconModel.transform.position.x - 1.5f, 0.3f));
        //��Ƭλ�Ƶ���ʾ��
        A.Join(FalconNomad.GetComponent<RectTransform>().DOMove(new Vector3(FalconModel.GetComponent<Transform>().Find("PuzzleIcon").position.x-1.5f, FalconModel.transform.position.y, FalconModel.transform.position.z), 0.5f).SetEase(Ease.InQuad).SetDelay(0.6f).OnComplete(()=> 
        {
            //λ�Ƶ�������ɵ�
            FalconNomad.SetActive(false);
            //�����޸���Ƭ������
            

        }));
        //�޸���Ƭ��С
        A.Join(FalconNomad.GetComponent<RectTransform>().DOScale(0.5f, 0.3f).SetEase(Ease.OutBack));
        //��ʾ����ʧ
        A.Append(FalconModel.transform.DOMoveX(P.position.x, 0.5f)); 
        //��ɻص�
        A.AppendCallback(() =>
        {
            A.Kill();
            gameObject.SetActive(false);
        });
    }
    /// <summary>
    /// ��ʼ����Ƭλ��
    /// </summary>
    public void Specialization()
    {
        gameObject.SetActive(true);
        FalconNomad.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        FalconNomad.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);
        FalconModel.GetComponent<RectTransform>().Find("PuzzleIcon").GetComponent<Image>().sprite = FalconNomad.GetComponent<Image>().sprite;
        FalconNomad.SetActive(true);
    }
    void Start()
    {
        P = FalconModel.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
