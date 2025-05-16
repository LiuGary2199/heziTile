using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticBrush 
{
    /// <summary>
    /// ��ͨ����·��
    /// </summary>
    public const string InsultYellowKeen= "Prefab/Bubbles/NormalBubble";
    /// <summary>
    /// �Ƴ�����·��
    /// </summary>
    public const string EasilyYellowKeen= "Prefab/Bubbles/RemoveBubble";
    /// <summary>
    /// ��������·��
    /// </summary>
    public const string GrooveYellowKeen= "Prefab/Bubbles/RewardBubble";
    /// <summary>
    /// �����Ƴ�����·��
    /// </summary>
    public const string AxEasilyYellowKeen= "Prefab/Bubbles/UnRemoveBubble";
    /// <summary>
    /// ��������·��
    /// </summary>
    public const string FlairYellowKeen= "Prefab/Bubbles/SkillBubble";
    /// <summary>
    /// С��Ϸ����·��
    /// </summary>
    public const string RustDireYellowKeen= "Prefab/Bubbles/MiniGameBubble";
    /// <summary>
    /// ������Ϣ·��
    /// </summary>
    public const string LocustImpairKeen= "Assets/Editor/GameBubbleData";
    /// <summary>
    /// ����һ���ͼƬ
    /// </summary>
    public const string RyeLocustRugged= "Art/Tex/UI/UI_Bubble/Ice2";

    /// <summary>
    /// ���
    /// </summary>
    public const string LordRuggedKeen= "Art/Tex/UI/UI_BonusReward/Ui_Bonus_Gold";
    /// <summary>
    /// �ֽ�
    /// </summary>
    public const string CrackRuggedKeen= "Art/Tex/UI/UI_BonusReward/Ui_Bonus_Cash";
    /// <summary>
    /// ����ѷ
    /// </summary>
    public const string StraitRuggedKeen= "Art/Tex/UI/UI_BonusReward/Ui_Bonus_Amazon";

    public const string StraitZRuggedKeen= "SOHOShop/UI_Redeem/UI_ShopZ";

    /// <summary>
    /// ���  
    /// </summary>
    public const string InsureRuggedKeen= "Art/Tex/UI/Item/Reward_Rocket";
    /// <summary>
    /// ����
    /// </summary>
    public const string ChillRuggedKeen= "Art/Tex/UI/Item/Reward_Laser";
    /// <summary>
    /// ����
    /// </summary>
    public const string BacteriumRuggedKeen= "Art/Tex/UI/Item/Reward_Universal";

    public const string LocustChillRuggedKeen= "Art/Tex/UI/UI_Bubble/LaserBall";

    public const string DistanceManure= "Art/Tex/UI/Item/DoublingOrange";

    public const string DistanceShore= "Art/Tex/UI/Item/DoublingGreen";

    public const string DistanceNarrow= "Art/Tex/UI/Item/DoublingPurple";
    #region ����
    /// <summary>
    /// ���ý���
    /// </summary>
    public const string FlatterRider= "FlatterRider";
    /// <summary>
    /// ��ʾ����
    /// </summary>
    public const string Learn= "Toast";
    /// <summary>
    /// ������Ϸ������
    /// </summary>
    public const string LocustDireRider= "BubbleGamePanel";
    /// <summary>
    /// ������
    /// </summary>
    public const string PreyRider= "HomePanel";
    /// <summary>
    /// �ιο�����
    /// </summary>
    public const string ConnectZealRider= "ScratchCardPanel";
    /// <summary>
    /// ���ؽ��棨�������棩
    /// </summary>
    public const string ExtolEmphasisRider= "ExtolEmphasisRider";
    /// <summary>
    /// �������
    /// </summary>
    public const string LaundryRider= "RevivalPanel";
    /// <summary>
    /// ʧ�ܽ���
    /// </summary>
    public const string DireFlopRider= "GameOverPanel";
    /// <summary>
    /// ��������
    /// </summary>
    public const string GrooveRider= "GrooveRider";

    public const string NebulaRider= "NewbiePanel";

    public const string MoveRider= "MoveRider";

    public const string DeafUsRider= "DeafUsRider";

    public const string PiggyBossRider= "PiggyBankPanel";

    public const string LunarNotchRider= "LuckyWheelPanel";

    public const string DimeRider= "TaskPanel";
    #endregion

    #region ��Ϣ
    /// <summary>
    /// comb��Ϣ
    /// </summary>
    public const string DoorPangaea= "CombMessage";
    /// <summary>
    /// ������ɾ��
    /// </summary>
    public const string HissLocustLichen= "FallBubbleDelete";
    /// <summary>
    /// ���ؽ���
    /// </summary>
    public const string ExtolEmphasisOust= "LevelCompleteData";
    /// <summary>
    /// ���ؽ���
    /// </summary>
    public const string WhoGrooveOust= "FlyRewardData";
    /// <summary>
    /// �ȼ�ˢ��
    /// </summary>
    public const string ExtolSatire= "LevelUpdate";
    /// <summary>
    /// ���߷�����
    /// </summary>
    public const string BegWharfConfederate= "RayPointOrientation";
    /// <summary>
    /// �������Ӵ�Ǯ�޽���
    /// </summary>
    public const string TearWhoJungle= "SendAddEnergy";
    /// <summary>
    /// ���ʹ�Ǯ�޽��ȶ���
    /// </summary>
    public const string TearWhoJungleFormation= "SendAddEnergyAnimation";
    /// <summary>
    /// ���ͷ�������Ϣ
    /// </summary>
    public const string TearLocustInnate= "SendBubbleLaunch";
    /// <summary>
    /// ����ȡ������
    /// </summary>
    public const string TearAlkaliSkyFlairPangaea= "SendCancelUseSkillMessage";
    /// <summary>
    /// ������ͼƬ����
    /// </summary>
    public const string TearMoveNomadLichen= "SendHandImageDelete";
    /// <summary>
    /// ������ͼƬ��ʾ
    /// </summary>
    public const string TearMoveNomadNote= "SendHandImageShow";
    /// <summary>
    /// �����Ƿ���������
    /// </summary>
    public const string TearMeDumpJungle= "SendIsOpenEnergy";
    /// <summary>
    /// ʣ��С����֪ͨ
    /// </summary>
    public const string TearAugustPointeSatire= "SendLanuchNumberUpdate";
    /// <summary>
    /// ��������С����Ϣ
    /// </summary>
    public const string TearLaundryWhoLocust= "SendRevivalAddBubble";
    /// <summary>
    /// ����������������
    /// </summary>
    public const string TearNebulaOust= "SendNewbieData";
    /// <summary>
    /// ����tips��Ϣ
    /// </summary>
    public const string TearMoveRiderOust= "SendTipsPanelData";
    /// <summary>
    /// ���Ͳ��Ų������
    /// </summary>
    public const string TearTollFlowerAD= "SendPlayInsertAD";
    /// <summary>
    /// ���ʹ���޽���ˢ��
    /// </summary>
    public const string TearProbeSatire= "SendScoreUpdate";
    /// <summary>
    /// ����ʹ�ü���index
    /// </summary>
    public const string TearFlairThink= "SendSkillIndex";
    /// <summary>
    /// ���ͼ��ܵ�λ��Ϣ
    /// </summary>
    public const string TearFlairBeg= "SendSkillRay";
    /// <summary>
    /// ���ͼ���indexˢ��
    /// </summary>
    public const string TearFlairPointeSatire= "SendSkillNumberUpdate";
    /// <summary>
    /// �����Ƿ�ʹ�ü���
    /// </summary>
    public const string TearSkyFlairPangaea= "SendUseSkillMessage";
    /// <summary>
    /// ������Ϸ�Ƿ���ͣ
    /// </summary>
    public const string TearDireMeMessy= "SendGameIsPause";
    /// <summary>
    /// ������������ˢ��
    /// </summary>
    public const string TearDimeOustSatire= "SendTaskDataUpdate";

    public const string TearGrassCornDimeTermSatire= "SendCountDownTaskTimeUpdate";
    #endregion
}
