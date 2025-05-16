using System;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 矩形遮罩镂空
/// </summary>
public class WhigDutchman : MonoBehaviour
{
    public static WhigDutchman instance;
[UnityEngine.Serialization.FormerlySerializedAs("target")]    [UnityEngine.Serialization.FormerlySerializedAs("target")]/// <summary>
    /// 高亮显示目标
    /// </summary>
    public Image Charge;
[UnityEngine.Serialization.FormerlySerializedAs("ClickBtn")]
[UnityEngine.Serialization.FormerlySerializedAs("ClickBtn")]    public Button SpeedFin;
[UnityEngine.Serialization.FormerlySerializedAs("Text")]    [UnityEngine.Serialization.FormerlySerializedAs("Text")]public Text Dawn;
    /// <summary>
    /// 区域范围缓存
    /// </summary>
    private Vector3[] Scholar= new Vector3[4];
    /// <summary>
    /// 镂空区域中心
    /// </summary>
    private Vector4 Anchor;
    /// <summary>
    /// 最终的偏移x
    /// </summary>
    private float ChargeLeaderX= 0;
    /// <summary>
    /// 最终的偏移y
    /// </summary>
    private float ChargeLeaderY= 0;
    /// <summary>
    /// 遮罩材质
    /// </summary>
    private Material Resemble;
    /// <summary>
    /// 当前的偏移x
    /// </summary>
    private float GermanyLeaderX= 0f;
    /// <summary>
    /// 当前的偏移y
    /// </summary>
    private float GermanyLeaderY= 0f;
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
        SpeedFin.onClick.AddListener(() =>
        {
            if (Illumination != 5)
            {
                gameObject.SetActive(false);
                ForestPoemRider.instance.Pivot(Illumination + 1);
            }
        });
    }
[UnityEngine.Serialization.FormerlySerializedAs("Currentindex")]
[UnityEngine.Serialization.FormerlySerializedAs("Currentindex")]    public int Illumination;
    public void Tour(Image target, int index)
    {
        this.Charge = target;
        Illumination = index;
        if (index == 0)
        {
            Dawn.transform.parent.gameObject.SetActive(true);
            Dawn.transform.parent.GetChild(1).gameObject.SetActive(true);
            Dawn.transform.parent.GetChild(0).gameObject.SetActive(false);
            //Text.text = "Use diamond and gold to claim";
        }
        else if(index == 2)
        {
            Dawn.transform.parent.gameObject.SetActive(true);
            Dawn.transform.parent.GetChild(1).gameObject.SetActive(false);
            Dawn.transform.parent.GetChild(0).gameObject.SetActive(true);
            //Text.text = "Play game and collect skin pieces";
        }
        else
        {
            Dawn.transform.parent.gameObject.SetActive(false);
        }

        if (index == 1 && index == 3)
        {
            ProveMigration = GetComponent<DutchmanStonyMigration>();
            if (ProveMigration != null)
            { 
                ProveMigration.DogMarvelNomad(target);
            }
        }
        
#if EmojiMerge
        Canvas canvas = GameObject.Find("RobloxCanvas(Clone)").GetComponent<Canvas>();
#else
        Canvas canvas = GameObject.Find("Canvas(Clone)").GetComponent<Canvas>();
#endif
        
        //Canvas canvas = /*GameController.Instance.Canvas*/null;
        //获取高亮区域的四个顶点的世界坐标
        target.rectTransform.GetWorldCorners(Scholar);
        //计算高亮显示区域在画布中的范围
        ChargeLeaderX = Vector2.Distance(MercyMeVirtueIcy(canvas, Scholar[0]), MercyMeVirtueIcy(canvas, Scholar[3])) / 2f;
        ChargeLeaderY = Vector2.Distance(MercyMeVirtueIcy(canvas, Scholar[0]), MercyMeVirtueIcy(canvas, Scholar[1])) / 2f;
        //计算高亮显示区域的中心
        float x= Scholar[0].x + ((Scholar[3].x - Scholar[0].x) / 2);
        float y= Scholar[0].y + ((Scholar[1].y - Scholar[0].y) / 2);
        Vector3 centerWorld = new Vector3(x, y, 0);
        Vector2 Anchor= MercyMeVirtueIcy(canvas, centerWorld);
        //设置遮罩材质中的中心变量
        Vector4 centerMat = new Vector4(Anchor.x, Anchor.y, 0, 0);
        Resemble = GetComponent<Image>().material;
        Resemble.SetVector("_Center", centerMat);
        //计算当前高亮显示区域的半径
        RectTransform canRectTransform = canvas.transform as RectTransform;
        if (canRectTransform != null)
        {
            //获取画布区域的四个顶点
            canRectTransform.GetWorldCorners(Scholar);
            //计算偏移初始值
            for (int i = 0; i < Scholar.Length; i++)
            {
                if (i % 2 == 0)
                {
                    GermanyLeaderX = Mathf.Max(Vector3.Distance(MercyMeVirtueIcy(canvas, Scholar[i]), Anchor), GermanyLeaderX);
                }
                else
                {
                    GermanyLeaderY = Mathf.Max(Vector3.Distance(MercyMeVirtueIcy(canvas, Scholar[i]), Anchor), GermanyLeaderY);
                }
            }
        }
        //设置遮罩材质中当前偏移的变量
        Resemble.SetFloat("_SliderX", GermanyLeaderX);
        Resemble.SetFloat("_SliderY", GermanyLeaderY);
    }
    /// <summary>
    /// 收缩速度
    /// </summary>
    private float MomentIntervalX= 0f;
    private float MomentIntervalY= 0f;
    private void Update()
    {
        //从当前偏移量到目标偏移量差值显示收缩动画
        float valueX = Mathf.SmoothDamp(GermanyLeaderX, ChargeLeaderX, ref MomentIntervalX, MomentTerm);
        float valueY = Mathf.SmoothDamp(GermanyLeaderY, ChargeLeaderY, ref MomentIntervalY, MomentTerm);
        if (!Mathf.Approximately(valueX, GermanyLeaderX))
        {
            GermanyLeaderX = valueX;
            Resemble.SetFloat("_SliderX", GermanyLeaderX);
        }
        if (!Mathf.Approximately(valueY, GermanyLeaderY))
        {
            GermanyLeaderY = valueY;
            Resemble.SetFloat("_SliderY", GermanyLeaderY);
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
