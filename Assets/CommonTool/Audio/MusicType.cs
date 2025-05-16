/**
 * 
 * 音乐类型管理的枚举列表
 * 
 * **/

//所有音乐名称的枚举列表

public class MusicType
{
    //ui使用的音乐音效
    public enum UIMusic
    {
        None,
        Sound_UIButton,
        Sound_LevelComplete,
        Sound_PopShow,
        Sound_ReviveShow,
        Sound_TileFishBGM,
        Sound_BuyFishInTank,
        Sound_LevelUp,
        Sound_UnlockFish,
        Sound_BubbleShow,
        Sound_Transitions,
        Sound_OpenStarBox,
        Sound_FishRewardShow,
        Sound_FishShopShow,
        Sound_OneArmBandit,
        Sound_AutoMerge,
        Sound_Coin,
        Sound_GoldCoin,
        scratch_reward,
        wheel_rotate,
        wheel_reward,
        reward_panel_open,
        level_success,
        multi_wheel_rotate,
        get_reward,
        game_over,
        level_fail,
        bgm,
        combo_good,
        combo_great,
        combo_amazing,
        combo_excellent,
        piggy_open
    }

    //场景中的音效，包括场景中所有音效，包括背景音效
    public enum SceneMusic
    {
        None,
        Sound_GameBankGold,
        Sound_HomeGold,
        Sound_TouchCube,
        Sound_MergeDisapper,
        Sound_CubeShow,
        Sound_BankCashFull,
        bubble_shoot,
        bubble_hit,
        bubble_dismiss,
        bubble_drop,
        bubble_switch,
        bubble_in_hole,
        bubble_push,
        ice_dismiss,
        rocket_shoot,
        rocket_bomb,
        laser_shoot,
        bomb,
        Tile_Note_01,
        Tile_Note_02,
        Tile_Note_03,
        Tile_Note_04,
        Tile_Note_05,
        Tile_Note_06,
        Tile_Note_07,
        Tile_Note_08,
        Tile_Note_09,
        Tile_Note_10,
        Tile_Note_11,
        Tile_Note_12,
        Tile_Note_13,
        Tile_Note_14,
        Tile_Note_15,

    }

}

