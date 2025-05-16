using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    /// <summary>
    /// 图标的出现动画
    /// </summary>
    /// <param name="IconImage"></param>
    /// <param name="IconMoveYOffset"></param>
    public static void IconUp(GameObject IconImage, float IconMoveYStart, float IconMoveYFinal,System.Action finish)
    {
        /*-------------------------------------初始化------------------------------------*/
        IconImage.GetComponent<Image>().color = new Color(IconImage.GetComponent<Image>().color.r, IconImage.GetComponent<Image>().color.g, IconImage.GetComponent<Image>().color.b, 0);
        IconImage.transform.position = new Vector3(IconImage.transform.position.x, IconMoveYStart, IconImage.transform.position.z);
        /*-------------------------------------动画效果------------------------------------*/
        IconImage.transform.DOMoveY(IconMoveYFinal, 0.5f).SetEase(Ease.OutBack);
        IconImage.GetComponent<Image>().DOFade(1, 0.5f).OnComplete(() => 
        {
            finish();
        });
    }


    /// <summary>
    /// 方块入场
    /// </summary>
    /// <param name="CubeImage"></param>
    /// <param name="CubeMoveFinal"></param>
    /// <param name="CubeMoveStart"></param>
    public static void CubeShow(List<TileAnimationData> list,System.Action finish)
    {
        /*-------------------------------------初始化------------------------------------*/
        int finishCount = 0;
        float delayTime = 0;
        /*-------------------------------------动画效果------------------------------------*/
        for (int i = 0;i<list.Count;i++) 
        {
            if (i > 0) 
            {
                delayTime += Random.Range(0.01f, 0.03f);
            }
            TileAnimationData data = list[i];
            data.Meaty.position = data.Sandy_Nor;
            data.Meaty.DOMove(data.Fix_Nor, 0.5f).SetDelay(delayTime).SetEase(Ease.OutBack).OnComplete(() => 
            {
                if (finishCount % 6 == 0)
                {
                    MusicMgr.GetInstance().PlayEffect(MusicType.SceneMusic.Sound_CubeShow);
                }
                finishCount++;
                if (finishCount == list.Count) 
                {
                    finish();
                }
            });
        }
    }


    /// <summary>
    /// 方块出场
    /// </summary>
    /// <param name="CubeImageDa"></param>
    /// <param name="CubeMoveStartDa"></param>
    public static void CubeHide(List<TileAnimationData> list,System.Action finish)
    {
        /*-------------------------------------初始化------------------------------------*/
        int finishCount = 0;
        float delayTime = 0;
        /*-------------------------------------动画效果------------------------------------*/
        for (int i = 0; i < list.Count; i++)
        {
            if (i > 0) 
            {
                delayTime += Random.Range(0.01f, 0.03f);
            }
            TileAnimationData data = list[i];
            data.Meaty.DOMove(data.Sandy_Nor, 0.5f).SetDelay(delayTime).SetEase(Ease.InBack).OnComplete(() =>
            {
                if (finishCount % 6 == 0)
                {
                    MusicMgr.GetInstance().PlayEffect(MusicType.SceneMusic.Sound_CubeShow);
                }
                finishCount++;
                if (finishCount == list.Count) 
                {
                    finish();
                }
            });
        }
    }


    /// <summary>
    /// 方块合成
    /// </summary>
    /// <param name="CubeImage"></param>
    public static void CubeMergeAni(List<TileAnimationData> list,System.Action finish)
    {
        foreach (TileAnimationData data in list)
        {
            if (data.Meaty.GetComponent<WordClan>().Halt.isRemoving)
            {
                return;
            }
        }
        foreach (TileAnimationData data in list)
        {
            data.Meaty.GetComponent<WordClan>().Halt.isRemoving = true;
        }
        /*-------------------------------------初始化------------------------------------*/
        GameObject test = Resources.Load<GameObject>("Effects/FX_MergeStar");
        int finishCount = 0;
        /*-------------------------------------动画效果------------------------------------*/
        for (int i = 0; i < list.Count; i++) 
        {
            GameObject p = Instantiate<GameObject>(test, list[i].Meaty.parent);
            p.transform.localPosition = list[i].Meaty.localPosition;
            list[i].Meaty.DOScale(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.InBack).OnComplete(() => 
            {
                p.SetActive(true);
                list[0].Meaty.DOScale(new Vector3(0, 0, 0), 0.2f).OnComplete(() =>
                {
                    Destroy(p);
                    finishCount++;
                    if (finishCount == 3)
                    {
                        finish();
                    }
                });
                
                
                
            });

        }

    }



    /// <summary>
    /// 弹窗出现效果
    /// </summary>
    /// <param name="PopBarUp"></param>
    public static void PopShow(GameObject PopBarUp,System.Action finish)
    {
        /*-------------------------------------初始化------------------------------------*/
        PopBarUp.GetComponent<CanvasGroup>().alpha = 0;
        PopBarUp.transform.localScale = new Vector3(0, 0, 0);
        /*-------------------------------------动画效果------------------------------------*/
        PopBarUp.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        PopBarUp.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).OnComplete(() => 
        {
            finish();
        });
    }


    /// <summary>
    /// 弹窗消失效果
    /// </summary>
    /// <param name="PopBarDisapper"></param>
    public static void PopHide(GameObject PopBarDisapper,System.Action finish)
    {
        /*-------------------------------------初始化------------------------------------*/
        PopBarDisapper.GetComponent<CanvasGroup>().alpha = 1;
        PopBarDisapper.transform.localScale = new Vector3(1, 1, 1);
        /*-------------------------------------动画效果------------------------------------*/
        PopBarDisapper.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        PopBarDisapper.transform.DOScale(0, 0.5f).SetEase(Ease.InBack).OnComplete(() => 
        {
            finish();
        });
    }
    /// <summary>
    /// 数字变化动画
    /// </summary>
    /// <param name="startNum"></param>
    /// <param name="endNum"></param>
    /// <param name="text"></param>
    /// <param name="finish"></param>
    public static void ChangeNumber(int startNum, int endNum,float delay, Text text,System.Action finish)
    {
        DOTween.To(() => startNum, x => text.text = x.ToString(), endNum, 0.5f).SetDelay(delay).OnComplete(() =>
        {
            finish();
        });
    }
    public static void ChangeNumber(double startNum, double endNum, float delay, Text text, System.Action finish)
    {
        ChangeNumber(startNum, endNum, delay, text, "", finish);
    }

    public static void ChangeNumber(double startNum, double endNum, float delay, Text text, string prefix, System.Action finish)
    {
        DOTween.To(() => startNum, x => text.text = prefix + NumberUtil.DoubleToStr(x), endNum, 0.5f).SetDelay(delay).OnComplete(() =>
        {
            finish();
        });
    }

    public static void LevelUp(float startNum, float endNum,int nowLevel,int fullCount , float delay, Image image,Text text, System.Action finish)
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(delay);
        for (int i = 0; i < fullCount; i++)
        {
            
            seq.Append(DOTween.To(() => startNum, x => image.fillAmount = x, 1, 1f / fullCount));
            seq.AppendCallback(() =>
            {
                nowLevel++;
                text.text = nowLevel.ToString();
                image.fillAmount = 0;
                startNum = 0;
            });
        }
        if (endNum != 0)
        {
            seq.Append(DOTween.To(() => startNum, x => image.fillAmount = x, endNum, 0.6f));
        }
        seq.AppendCallback(() =>
        {
            finish();
        });
    }
    /// <summary>
    /// 进度条动画
    /// </summary>
    /// <param name="startValue"></param>
    /// <param name="endValue"></param>
    /// <param name="sliderImage"></param>
    /// <param name="finish"></param>
    public static void ChangeSliderValue(float startValue,float endValue,Image sliderImage, System.Action finish, float delay = 0)
    {
        DOTween.To(() => startValue, x => sliderImage.fillAmount = x, endValue, 0.5f).SetDelay(delay).OnComplete(() => {
            finish();
        });
    }


    /// <summary>
    /// 首页TopBar出现/Play按钮消失
    /// </summary>
    /// <param name="HomeTopBar"></param>
    /// <param name="MoveOffset"></param>
    /// <param name="finish"></param>
    public static void HomeShow(GameObject HomeTopBarShow, float MoveOffsetShow, System.Action finish) 
    {
        /*-------------------------------------初始化------------------------------------*/
        HomeTopBarShow.GetComponent<CanvasGroup>().alpha = 0;
        HomeTopBarShow.transform.position = new Vector3(HomeTopBarShow.transform.position.x, HomeTopBarShow.transform.position.y + MoveOffsetShow, HomeTopBarShow.transform.position.z);
        /*-------------------------------------动画效果------------------------------------*/
        HomeTopBarShow.GetComponent<CanvasGroup>().DOFade(1, 0.4f);
        HomeTopBarShow.transform.DOMoveY(HomeTopBarShow.transform.position.y - MoveOffsetShow, 0.5f).SetEase(Ease.OutBack).OnComplete(() => 
        {
            finish();
        });
    }


    /// <summary>
    /// 首页Top消失/Play按钮出现
    /// </summary>
    /// <param name="HomeTopBar"></param>
    /// <param name="MoveOffset"></param>
    /// <param name="finish"></param>
    public static void HomeHide(GameObject HomeTopBarHide, float MoveOffsetHide, System.Action finish)
    {
        /*-------------------------------------初始化------------------------------------*/
        HomeTopBarHide.GetComponent<CanvasGroup>().alpha = 1;
        
        /*-------------------------------------动画效果------------------------------------*/
        HomeTopBarHide.GetComponent<CanvasGroup>().DOFade(0, 0.4f);
        HomeTopBarHide.transform.DOMoveY(HomeTopBarHide.transform.position.y + MoveOffsetHide, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            HomeTopBarHide.transform.position = new Vector3(HomeTopBarHide.transform.position.x, HomeTopBarHide.transform.position.y - MoveOffsetHide, HomeTopBarHide.transform.position.z);
            finish();
        });
    }


    /// <summary>
    /// 首页存钱罐出现
    /// </summary>
    /// <param name="HomeBankShow"></param>
    /// <param name="BankMoveOffsetShow"></param>
    /// <param name="finish"></param>
    public static void HomeBankShow(GameObject HomeBankShow, float BankMoveOffsetShow, System.Action finish) 
    {
        /*-------------------------------------初始化------------------------------------*/
        if (HomeBankShow.GetComponent<CanvasGroup>() == null) 
        {
            HomeBankShow.AddComponent<CanvasGroup>();
        }
        HomeBankShow.GetComponent<CanvasGroup>().alpha = 0;
        HomeBankShow.transform.position = new Vector3(HomeBankShow.transform.position.x - BankMoveOffsetShow, HomeBankShow.transform.position.y, HomeBankShow.transform.position.z);
        /*-------------------------------------动画效果------------------------------------*/
        HomeBankShow.GetComponent<CanvasGroup>().DOFade(1, 0.4f);
        HomeBankShow.transform.DOMoveX(HomeBankShow.transform.position.x + BankMoveOffsetShow, 0.5f).OnComplete(() =>
        {
            finish();
        });
    }


    /// <summary>
    /// 首页存钱罐消失
    /// </summary>
    /// <param name="HomeBankHide"></param>
    /// <param name="BankMoveOffsetHide"></param>
    /// <param name="finish"></param>
    public static void HomeBankHide(GameObject HomeBankHide, float BankMoveOffsetHide, System.Action finish)
    {
        /*-------------------------------------初始化------------------------------------*/
        HomeBankHide.GetComponent<CanvasGroup>().alpha = 1;
        /*-------------------------------------动画效果------------------------------------*/
        HomeBankHide.GetComponent<CanvasGroup>().DOFade(0, 0.4f);
        HomeBankHide.transform.DOMoveX(HomeBankHide.transform.position.x - BankMoveOffsetHide, 0.5f).OnComplete(() =>
        {
            HomeBankHide.transform.position = new Vector3(HomeBankHide.transform.position.x + BankMoveOffsetHide, HomeBankHide.transform.position.y, HomeBankHide.transform.position.z);
            finish();
        });
    }

    /// <summary>
    /// 收金币效果
    /// </summary>
    /// <param name="GoldImage"></param>
    /// <param name="parent"></param>
    /// <param name="a"></param>
    /// <param name="GoldStart"></param>
    /// <param name="GoldFinal"></param>
    /// <param name="finish">这个动画播完了</param>
    public static void GoldMove(GameObject GoldImage, Transform parent, int a, Transform GoldStart, Transform GoldFinal, System.Action finish)
    {

        if (a == 0)
        {
            finish();
        }
        float Delaytime = 0;
        GoldStart.position = GetSystemData.GetInstance().getWorldPoint(GoldStart.gameObject);
        int goldNum = 3;
        for (int i = 0; i < goldNum; i++)
        {
            int t = i;
            /*-------------------------------------初始化------------------------------------*/
            Delaytime += UnityEngine.Random.Range(0.05f, 0.2f);
            if (i == 0)
            {
                Delaytime = 0;
            }
            var s = DOTween.Sequence();
            GameObject GoldIcon = Instantiate(GoldImage, parent);
            
            GoldIcon.SetActive(true);
            GoldIcon.GetComponent<Transform>().position = GoldStart.position;
            GoldIcon.GetComponent<Image>().color = new Color(GoldIcon.GetComponent<Image>().color.r, GoldIcon.GetComponent<Image>().color.g, GoldIcon.GetComponent<Image>().color.b, 0);
            GoldIcon.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
            float OffsetX = UnityEngine.Random.Range(-0.5f, 0.5f);
            float OffsetY = UnityEngine.Random.Range(-0.5f, 0.5f);
            /*-------------------------------------动画效果------------------------------------*/
            //Debug.Log(OffsetX);
            GoldIcon.GetComponent<Transform>().position = new Vector3(GoldIcon.GetComponent<Transform>().position.x + OffsetX, GoldIcon.GetComponent<Transform>().position.y + OffsetY, GoldIcon.GetComponent<Transform>().position.z);
            s.Append(GoldIcon.GetComponent<Image>().DOFade(1, 0.1f));
            s.Insert(0, GoldIcon.GetComponent<Transform>().DOScale(new Vector3(0.8f, 0.8f, 1), 0.2f).SetEase(Ease.OutBack));
            s.Append(GoldIcon.GetComponent<Transform>().DOMove(GoldFinal.position, 0.5f).SetEase(Ease.InBack)).SetDelay(0.1f + Delaytime);
            s.Insert(0.55f + Delaytime, GoldIcon.GetComponent<Transform>().DOScale(new Vector3(0.7f, 0.7f, 0.7f), 0.2f));
            s.AppendCallback(() =>
            {
                s.Kill();
                Destroy(GoldIcon);
                
                if (t == goldNum - 1)
                {
                    finish();
                }
            });
            s.Play();
        }

    }
    /// <summary>
    /// 收金币
    /// </summary>
    /// <param name="GoldImage">金币图标</param>
    /// <param name="a">金币数量</param>
    /// <param name="StartTF">起始位置</param>
    /// <param name="EndTF">最终位置</param>
    /// <param name="finish">结束回调</param>
    public static void GoldMoveBest(GameObject GoldImage,int a,Transform StartTF,Transform EndTF,System.Action finish) 
    {
        //如果没有就算了
        if (a == 0)
        {
            finish();
        }
        //数量不超过15个
        else if (a > 15) 
        {
            a =15;
        }
        //每个金币的间隔
        float Delaytime = 0;
        for (int i = 0; i < a; i++) 
        {
            int t = i;
            //每次延迟+1
            Delaytime += 0.06f;
            //复制一个图标
            GameObject GoldIcon = Instantiate(GoldImage, GoldImage.transform.parent);
            //初始化
            GoldIcon.transform.position = StartTF.position;
            GoldIcon.transform.localScale = new Vector3(1, 1, 1);
            //金币弹出随机位置
            float OffsetX = UnityEngine.Random.Range(-0.8f, 0.8f);
            float OffsetY = UnityEngine.Random.Range(-0.8f, 0.8f);
            //创建动画队列
            var s = DOTween.Sequence();
            //金币出现
            s.Append(GoldIcon.transform.DOMove(new Vector3(GoldIcon.transform.position.x + OffsetX, GoldIcon.transform.position.y + OffsetY, GoldIcon.transform.position.z), 0.15f).SetDelay(Delaytime).OnComplete(()=> 
            {
                //限制音效播放数量
                if (Mathf.Sin(t)>0)
                {
                    MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_GoldCoin);
                }
            }));
            //金币移动到最终位置
            s.Append(GoldIcon.transform.DOMove(EndTF.position, 0.6f).SetDelay(0.2f));
            s.Join(GoldIcon.transform.DOScale(0.8f, 0.3f).SetEase(Ease.InBack));
            s.AppendCallback(() =>
            {
                //收尾
                s.Kill();
                Destroy(GoldIcon);
                if (t == a - 1)
                {
                    finish();
                }
            });
        }
    }




    /// <summary>
    /// 游戏内金币飞入存钱罐效果
    /// </summary>
    /// <param name="GameBankCashImage"></param>
    /// <param name="parent"></param>
    /// <param name="BankCashStart"></param>
    /// <param name="BankCashFinal"></param>
    /// <param name="i"></param>
    public static void BankCashMove(GameObject GameBankCashImage,Transform parent,Transform BankCashStart,Transform BankCashFinal,int i,System.Action finish)
    {
        GameObject GameBankCash = Instantiate(GameBankCashImage, parent);
        GameBankCash.transform.position = BankCashStart.position;
        GameBankCash.GetComponent<Image>().color = new Color(GameBankCash.GetComponent<Image>().color.r, GameBankCash.GetComponent<Image>().color.g, GameBankCash.GetComponent<Image>().color.b, 1);
        GameBankCash.SetActive(true);
        GameBankCash.transform.localScale = new Vector3(1f, 1f, 0.7f);
        if (i <= 2)
        {
            GameBankCash.transform.DOMoveX(BankCashFinal.position.x, 0.7f).SetEase(Ease.InBack);
            GameBankCash.transform.DOMoveY(BankCashFinal.position.y,0.7f).OnComplete(()=>{
                Destroy(GameBankCash);
                finish();
                MusicMgr.GetInstance().PlayEffect(MusicType.SceneMusic.Sound_GameBankGold);
            });
        }
        else if( i==3 )
        {
            float offsetX = UnityEngine.Random.Range(0, 0.5f);
            GameBankCash.transform.DOMoveX(BankCashFinal.position.x, 0.7f).SetEase(Ease.InBack);
            GameBankCash.transform.DOMoveY(BankCashFinal.position.y, 0.7f).OnComplete(() => 
            {
                /*GameBankCash.transform.DOMoveX(BankCashFinal.position.x + offsetX, 0.5f).SetEase(Ease.OutBack);
                GameBankCash.transform.DOMoveY(BankCashFinal.position.y - 0.3f, 0.5f).OnComplete(() => 
                {
                });*/
                    GameBankCash.transform.DOJump(new Vector3(GameBankCash.transform.position.x + offsetX, GameBankCash.transform.position.y-0.2f, GameBankCash.transform.position.z), UnityEngine.Random.Range(0.2f, 0.3f), 2, 0.6f);
                MusicMgr.GetInstance().PlayEffect(MusicType.SceneMusic.Sound_BankCashFull);
                GameBankCash.GetComponent<Image>().DOFade(0,2f).OnComplete(()=> {
                    Destroy(GameBankCash);
                    finish();
                });
            });
        }
    }



    /// <summary>
    /// 宝箱开启
    /// </summary>
    /// <param name="StarBox"></param>
    /// <param name="Content"></param>
    /// <param name="StartPoint"></param>
    /// <param name="MidPoint"></param>
    /// <param name="finish"></param>
    public static void StarBoxMove(GameObject StarBox,float BoxMoveOffset,GameObject Fx_StarBoxOpen, System.Action RewardShow) 
    {

        /*-------------------------------------动画效果------------------------------------*/
        StarBox.GetComponent<CanvasGroup>().DOFade(1, 0.4f);
        StarBox.transform.DOScale(new Vector3(1, 1, 1), 0.4f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            StarBox.transform.DOScaleY(0.8f, 0.2f).SetDelay(0.4f).OnComplete(() => 
            {
                StarBox.transform.DOScaleY(1.2f, 0.2f).SetEase(Ease.OutBack);
                StarBox.transform.DOScaleX(0.7f, 0.2f);
                StarBox.transform.DOMoveY((StarBox.transform.position.y + BoxMoveOffset), 0.2f).OnComplete(() => 
                {
                    StarBox.GetComponent<Transform>().Find("BoxTop").GetComponent<Image>().sprite = Resources.Load<Sprite>("Effects/UI_RewardBoxTopOpen");
                    Fx_StarBoxOpen.SetActive(true);
                    StarBox.transform.DOScaleX(1, 0.2f).OnComplete(() => 
                    {
                        RewardShow();
                        StarBox.transform.DOMoveY((StarBox.transform.position.y - BoxMoveOffset), 0.3f);
                        StarBox.transform.DOScaleY(1, 0.45f).SetEase(Ease.OutBack);
                            /*StarBox.GetComponent<Transform>().Find("BoxTop").GetComponent<Image>().sprite = Resources.Load<Sprite>("Effects/UI_RewardBoxTopClose");*/
                    });
                });
            });
        });
    }

    /// <summary>
    /// 宝箱奖励出现
    /// </summary>
    /// <param name="CardList"></param>
    /// <param name="Count"></param>
    /// <param name="finish"></param>
    public static void StarBoxRewardShow(List<GameObject> CardList, int Count, System.Action finish)
    {
        GameObject Reward = CardList[0];
        float CardW  = Reward.GetComponent<RectTransform>().sizeDelta.x * Reward.GetComponent<RectTransform>().localScale.x;
        float screenW = UIManager.GetInstance().MainCanvas.GetComponent<CanvasScaler>().referenceResolution.x;
        int finishCount = Count;
        if (Count < 3)
        {
            float Space1 = 100f;
            float Space2 = ((UIManager.GetInstance().MainCanvas.GetComponent<CanvasScaler>().referenceResolution.x - Space1 * 2) - CardW * Count) / (Count - 1);
            for (int i = 0; i < Count; i++)
            {
                GameObject card = CardList[i];
                card.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                card.transform.DOLocalMoveY(250f, 0.45f);
                card.transform.DOLocalMoveX(-screenW / 2 + CardW / 2f + Space1 + i * (Space2 + CardW), 0.45f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    finishCount--;
                    GameObject Fx_RewardBG = card.transform.Find("Fx_RewardBG").gameObject;
                    Fx_RewardBG.SetActive(true);
                    if (finishCount == 0)
                    {
                        finish();
                    }
                });
            }
        }//一个或两个奖励
        if (Count == 3) 
        {
            float Space1 = 80f;
            float Space2 = ((UIManager.GetInstance().MainCanvas.GetComponent<CanvasScaler>().referenceResolution.x - Space1 * 2) - CardW * Count) / (Count - 1);
            for (int i = 0; i < Count; i++)
            {
                GameObject card = CardList[i];
                card.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                if (i == 1)
                {
                    card.transform.DOLocalMoveY(300f, 0.45f);
                }
                else 
                {
                    card.transform.DOLocalMoveY(185f, 0.45f);
                }
                card.transform.DOLocalMoveX(-screenW / 2 + CardW / 2f + Space1 + i * (Space2 + CardW), 0.45f).SetEase(Ease.OutBack).OnComplete(() =>
                    {
                        finishCount--;
                        GameObject Fx_RewardBG = card.transform.Find("Fx_RewardBG").gameObject;
                        Fx_RewardBG.SetActive(true);
                        if (finishCount == 0)
                        {
                            finish();
                        }
                    });
            }

        }//三个奖励
        if (Count == 4) 
        {
            float Space1 = 30f;
            float Space2 = ((UIManager.GetInstance().MainCanvas.GetComponent<CanvasScaler>().referenceResolution.x - Space1 * 2) - CardW * Count) / (Count - 1);
            for (int i = 0; i < Count; i++)
            {

                GameObject card = CardList[i];
                card.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                if (i == 1 || i == 2)
                {
                    card.transform.DOLocalMoveY(300f, 0.45f);
                }
                else 
                {
                    card.transform.DOLocalMoveY(185f, 0.45f);
                }
                card.transform.DOLocalMoveX(-screenW / 2 + CardW / 2f + Space1 + i * (Space2 + CardW), 0.45f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    finishCount--;
                    GameObject Fx_RewardBG = card.transform.Find("Fx_RewardBG").gameObject;
                    Fx_RewardBG.SetActive(true);
                    if (finishCount == 0)
                    {
                        finish();
                    }
                });
            }
        }//四个奖励
        if (Count == 5)
        {
            float Space1 = 30f;
            float Space2 = ((UIManager.GetInstance().MainCanvas.GetComponent<CanvasScaler>().referenceResolution.x - Space1 * 2) - CardW * Count) / (Count - 1);
            for (int i = 0; i < Count; i++)
            {

                GameObject card = CardList[i];
                card.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                if (i == 1 || i == 3)
                {
                    card.transform.DOLocalMoveY(400f, 0.45f);
                }
                else
                {
                    card.transform.DOLocalMoveY(185f, 0.45f);
                }
                card.transform.DOLocalMoveX(-screenW / 2 + CardW / 2f + Space1 + i * (Space2 + CardW), 0.45f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    finishCount--;
                    GameObject Fx_RewardBG = card.transform.Find("Fx_RewardBG").gameObject;
                    Fx_RewardBG.SetActive(true);
                    if (finishCount == 0)
                    {
                        finish();
                    }
                });
            }
        }//五个奖励
        if (Count == 6)
        {
            float Space1 = 30f;
            float Space2 = ((UIManager.GetInstance().MainCanvas.GetComponent<CanvasScaler>().referenceResolution.x - Space1 * 2) - CardW * Count/2) / (Count/2 - 1);
            for (int i = 0; i < Count; i++)
            {

                GameObject card = CardList[i];
                card.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
                if (i == 1 || i == 2 || i == 0)
                {
                    card.transform.DOLocalMoveY(400f, 0.45f);
                    card.transform.DOLocalMoveX(-screenW / 2 + CardW / 2f + Space1 + i * (Space2 + CardW), 0.45f).SetEase(Ease.OutBack);
                }
                else if (i == 3 || i == 4)
                {
                    card.transform.DOLocalMoveY(185f, 0.45f);
                    card.transform.DOLocalMoveX(-screenW / 2 + CardW / 2f + Space1 + i * (Space2 + CardW) - screenW- 30f, 0.45f).SetEase(Ease.OutBack);
                }
                else 
                {
                    card.transform.DOLocalMoveY(185f, 0.45f);
                    card.transform.DOLocalMoveX(-screenW / 2 + CardW / 2f + Space1 + i * (Space2 + CardW) - screenW - 30f, 0.45f).SetEase(Ease.OutBack).OnComplete(() =>
                    {
                        
                        GameObject Fx_RewardBG = card.transform.Find("Fx_RewardBG").gameObject;
                        Fx_RewardBG.SetActive(true);
                        finish();
                    });
                }
                
            }
        }//六个奖励

    }

    /// <summary>
    /// 升级时图标转换
    /// </summary>
    /// <param name="UnLevelIcon">颜色比较暗的等级图标</param>
    /// <param name="LevelIcon">正常等级图标</param>
    /// <param name="finish"></param>
    public static void LevelUnlockIConScale(GameObject UnLevelIcon, Sprite LevelIcon, Text text, System.Action finish)
    {
        UnLevelIcon.transform.localScale = new Vector3(1, 1, 1);
        UnLevelIcon.transform.DOScale(new Vector3(0, 0, 0), 0.3f).OnComplete(() =>
        {
            UnLevelIcon.GetComponent<Image>().sprite = LevelIcon;
            text.color = Color.white;
            GameObject Fx_level = Instantiate(Resources.Load<GameObject>("Animation/AniFx/Fx_SoulExplosionOrange"), UnLevelIcon.transform);
            Fx_level.SetActive(true);
            UnLevelIcon.transform.DOScale(new Vector3(1, 1, 1), 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                Destroy(Fx_level);
                finish();
            });
        });

    }

    /// <summary>
    /// 鱼缸切换
    /// </summary>
    /// <param name="BG">需要切换的背景</param>
    /// <param name="FxMoveOffset">粒子向上的偏移距离</param>
    /// <param name="finish"></param>
    public static void ScreenTransitions(GameObject BG, System.Action finish) 
    {
        GameObject Fx_BubbleTransitions = Instantiate((Resources.Load<GameObject>("Effects/FX_BubbleMoveBG")), BG.transform);
        BG.GetComponent<Image>().material = Resources.Load<Material>("Effects/Mat_MoveOffset");
        float Star = 1;
        Fx_BubbleTransitions.SetActive(true);
        Fx_BubbleTransitions.transform.position = new Vector3(Fx_BubbleTransitions.transform.position.x, -GetSystemData.GetInstance().getCameraHeight() / 2, Fx_BubbleTransitions.transform.position.z);
        DOTween.To(() => Star, x => BG.GetComponent<Image>().material.SetFloat("_MoveOffset", Star = x), -10, 1.5f);
        Fx_BubbleTransitions.transform.DOMoveY(GetSystemData.GetInstance().getCameraHeight() / 2, 1.6f).OnComplete(() =>
        {
            Destroy(Fx_BubbleTransitions);
            finish();
            ///关闭窗口
        });
    }

    /// <summary>
    /// 点击领取每日奖励
    /// </summary>
    /// <param name="box"> 箱子默认图 </param>
    /// <param name="RewardImage"> 奖励图片 </param>
    /// <param name="Fx_RewardBG"> 特效 </param>
    /// <param name="finish"></param>
    public static void DailyBonusAni(GameObject box,GameObject Fx_RewardBG,System.Action finish) 
    {
        box.transform.localScale = new Vector3(1, 1, 1);
        Fx_RewardBG.SetActive(false);
        box.transform.DOScale(0.7f, 0.3f).OnComplete(() => 
        {
            Fx_RewardBG.SetActive(true);
            box.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack).OnComplete(() => 
            {
                finish();
            });
        });
    }


    /// <summary>
    /// 呼吸缩放效果
    /// </summary>
    /// <param name="BankBtn"></param>
    /// <param name="i"></param>
    public static void Breathe(GameObject BankBtn,int i) 
    {
        float offset = -0.6f;
        DOTween.Kill("FlashMove");
        BankBtn.GetComponent<Image>().material = null;
        BankBtn.transform.localScale = new Vector3(1, 1, 1);
        if (i == 1)
        {
            BankBtn.GetComponent<Image>().material = Resources.Load<Material>("Effects/Mat_Flash");
            var BankAni = DOTween.Sequence();
            BankAni.Append(BankBtn.transform.DOScale(new Vector3(0.95f, 0.95f, 0.95f), 1.2f));
            BankAni.Append(BankBtn.transform.DOScale(new Vector3(1f, 1f, 1f), 1.2f));
            BankAni.Insert(0, DOTween.To(() => offset, x => BankBtn.GetComponent<Image>().material.SetFloat("_LightOffset", offset = x), 0.6f, 1f).SetDelay(1).OnComplete
                (() =>
                {
                    BankBtn.GetComponent<Image>().material.SetFloat("_LightOffset", -0.6f);
                }));
            BankAni.SetLoops(-1);
            BankAni.SetId<Tween>("FlashMove");
            BankAni.Play();
        }
    }

   

    /// <summary>
    /// Topbar Icon跳动动画
    /// </summary>
    /// <param name="IconImage">Icon图标</param>
    public static void IconJump(GameObject IconImage)
    {
        IconImage.transform.DOScale(1.2f, 0.1f).OnComplete(() =>
        {
            IconImage.transform.DOScale(1f, 0.1f);

        });
    }


    public static void GuideAnimation(int i,Image GuidePlayCube_R, Image GuidePlayCube_B, GameObject GuidePlayBG,Transform startTF,Text GuidePlayText,System.Action finish) 
    {
        /*-------------------------------------初始化------------------------------------*/
        if (i == 0)
        {
            DOTween.Kill("GuidePlay");
            //GuidePlayText.text = null;
            GuidePlayCube_R.DOKill();
            GuidePlayCube_R.transform.DOKill();
            GuidePlayCube_B.DOKill();
            GuidePlayCube_B.transform.DOKill();
            GuidePlayBG.transform.DOKill();
            GuidePlayText.DOKill();
            GuidePlayCube_R.transform.localScale = new Vector3(0, 0, 0);
            GuidePlayCube_R.color = new Color(1, 1, 1, 0);
            GuidePlayCube_R.transform.eulerAngles = new Vector3(0, 0, 0);
            GuidePlayCube_B.transform.localScale = new Vector3(0, 0, 0);
            GuidePlayCube_B.color = new Color(1, 1, 1, 0);
            GuidePlayCube_B.transform.eulerAngles = new Vector3(0, 0, 0);
            GuidePlayBG.transform.localScale = new Vector3(0, 0, 0);
            
        }
        /*-------------------------------------动画部分------------------------------------*/
        else if (i == 1) 
        {
            string content = GuidePlayText.text;
            GuidePlayText.text = null;
            GuidePlayBG.GetComponent<RectTransform>().position = new Vector3(GuidePlayBG.GetComponent<RectTransform>().position.x, startTF.position.y, GuidePlayBG.GetComponent<RectTransform>().position.z);
            GuidePlayText.DOText(content, 0.5f);
            GuidePlayBG.transform.DOScale(1, 0.2f).SetEase(Ease.OutBack);
            GuidePlayCube_R.DOFade(1, 0.5f);
            GuidePlayCube_R.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
            GuidePlayCube_R.transform.DORotate(new Vector3(0, 0, -15), 0.5f);
            GuidePlayCube_B.DOFade(1, 0.5f);
            GuidePlayCube_B.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
            GuidePlayCube_B.transform.DORotate(new Vector3(0, 0, 25), 0.6f).OnComplete(() =>
            {
                Sequence a = DOTween.Sequence();
                a.Append(GuidePlayBG.transform.DOMoveY((GuidePlayBG.transform.position.y + 0.08f),3f));
                a.Append(GuidePlayBG.transform.DOMoveY((GuidePlayBG.transform.position.y), 2f));
                a.SetLoops(-1);
                a.SetId<Tween>("GuidePlay");
                a.Play();
            });
        }
    }


    /// <summary>
    /// 横向滚动
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="addPosition"></param>
    /// <param name="Finish"></param>
    public static void HorizontalScroll(GameObject obj, float addPosition, System.Action Finish)
    {
        float positionX = obj.transform.localPosition.x;
        float endPostion = positionX + addPosition;
        obj.transform.DOLocalMoveX(endPostion, 2f).SetEase(Ease.InOutQuart).OnComplete(() => {
            Finish?.Invoke();
        });
    }
}
