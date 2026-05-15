using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.Advertisement.AliPayMiniGame.Runtime
{
    /// <summary>
    /// 支付宝小游戏广告裁剪辅助器，用于确保类型引用在 IL2CPP 裁剪时被保留。
    /// </summary>
    /// <remarks>
    /// Alipay mini-game advertisement cropping helper, used to ensure type references are preserved during IL2CPP stripping.
    /// </remarks>
    [Preserve]
    public class GameFrameXAdvertisementAliPayMiniGameCroppingHelper : MonoBehaviour
    {
        [Preserve]
        private void Start()
        {
#if UNITY_WEBGL && ENABLE_ALIPAY_MINI_GAME && ENABLE_ALIPAY_MINI_GAME_ADVERTISEMENT
            _ = typeof(AliPayMiniGameAdvertisementManager);
            _ = typeof(GameFrameX.Advertisement.AliPayMiniGame.Runtime.AliPayVideoAdCallback);
#endif
        }
    }
}