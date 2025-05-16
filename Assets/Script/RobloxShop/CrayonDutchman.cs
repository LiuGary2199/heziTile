using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 圆形遮罩镂空
/// </summary>
public class CrayonDutchman : MonoBehaviour
{
    public static CrayonDutchman instance;
[UnityEngine.Serialization.FormerlySerializedAs("target")]    [UnityEngine.Serialization.FormerlySerializedAs("target")]/// <summary>
    /// 高亮显示目标
    /// </summary>
    public Image Charge;
[UnityEngine.Serialization.FormerlySerializedAs("ClickBtn")]    
[UnityEngine.Serialization.FormerlySerializedAs("ClickBtn")]    public Button SpeedFin;
    //public Text Text;
    /// <summary>
    /// 区域范围缓存
    /// </summary>
    private Vector3[] Scholar= new Vector3[4];
    /// <summary>
    /// 镂空区域中心
    /// </summary>
    private Vector4 Anchor;
    /// <summary>
    /// 镂空区域半径
    /// </summary>
    private float radius;
    /// <summary>
    /// 遮罩材质
    /// </summary>
    private Material Resemble;
    /// <summary>
    /// 当前高亮区域半径
    /// </summary>
    private float GermanyListen;
    /// <summary>
    /// 高亮区域缩放的动画时间
    /// </summary>
    private float MomentTerm= 0.3f;
    /// <summary>
    /// 事件渗透组件
    /// </summary>
    private DutchmanStonyMigration ProveMigration;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SpeedFin.onClick.AddListener( (() =>
        {
            ForestPoemRider.instance.CaneFinSpeed();
            gameObject.SetActive(false);
        }));
    }

    public void Tour(Image target)
    {
        this.Charge = target;
        /*eventPenetrate = GetComponent<DutchmanStonyMigration>();
        if (eventPenetrate != null)
        {
            eventPenetrate.SetTargetImage(target);
        }*/
#if EmojiMerge
        Canvas canva = GameObject.Find("RobloxCanvas(Clone)").GetComponent<Canvas>();
#else
        Canvas canva = GameObject.Find("Canvas(Clone)").GetComponent<Canvas>();
#endif
        //Canvas canva = /*GameController.Instance.Canvas*/null;
        //获取高亮区域的四个顶点的世界坐标
        target.rectTransform.GetWorldCorners(Scholar);
        //计算最终高亮显示区域的半径
        radius = Vector2.Distance(MercyMeVirtueIcy(canva, Scholar[0]), MercyMeVirtueIcy(canva, Scholar[2])) / 2;
        //计算高亮显示区域的中心
        float x= Scholar[0].x + ((Scholar[3].x - Scholar[0].x) / 2);
        float y= Scholar[0].y + ((Scholar[1].y - Scholar[0].y) / 2);
        Vector3 centerWorld = new Vector3(x, y, 0);
        Vector2 Anchor= MercyMeVirtueIcy(canva, centerWorld);
        //设置遮罩材质中的中心变量
        Vector4 centerMat = new Vector4(Anchor.x, Anchor.y, 0, 0);
        Resemble = GetComponent<Image>().material;
        Resemble.SetVector("_Center", centerMat);
        //计算当前高亮显示区域的半径
        RectTransform canRectTransform = canva.transform as RectTransform;
        if (canRectTransform != null)
        {
            //获取画布区域的四个顶点
            canRectTransform.GetWorldCorners(Scholar);
            //将画布顶点距离高亮区域中心最近的距离昨晚当前高亮区域半径的初始值
            foreach (var corner in Scholar)
            {
                GermanyListen = Mathf.Max(Vector3.Distance(MercyMeVirtueIcy(canva, corner), corner), GermanyListen);
            }
        }
        Resemble.SetFloat("_Slider", GermanyListen);
    }
    /// <summary>
    /// 收缩速度
    /// </summary>
    private float MomentInterval= 0f;
    private void Update()
    {
        //从当前半径到目标半径差值显示收缩动画
        //float value = Mathf.SmoothDamp(currentRadius, radius, ref shrinkVelocity, shrinkTime);
        /*if (currentRadius < 150)
        {
            currentRadius = Mathf.SmoothDamp(radius, 500, ref shrinkVelocity, shrinkTime);
            currentRadius = 350;
            material.SetFloat("_Slider", currentRadius);
        }*/
        /*else
        {
            if (!Mathf.Approximately(value, currentRadius))
            {
                currentRadius = value;
                material.SetFloat("_Slider", currentRadius);
            }
        }*/
        
        //从当前半径到目标半径差值显示收缩动画
        float value = Mathf.SmoothDamp(GermanyListen, radius, ref MomentInterval, MomentTerm);
        if (!Mathf.Approximately(value, GermanyListen))
        {
            GermanyListen = value;
            Resemble.SetFloat("_Slider", GermanyListen);
            
        }
        
    }

    /// <summary>
    /// 世界坐标转换为画布坐标
    /// </summary>
    /// <param name="canvas">画布</param>
    /// <param name="world">世界坐标</param>
    /// <returns></returns>
    private Vector2 MercyMeVirtueIcy(Canvas canvas, Vector3 world)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, world, canvas.GetComponent<Camera>(), out position);
        return position;
    }
}
