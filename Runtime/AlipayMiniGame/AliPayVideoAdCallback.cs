#if UNITY_WEBGL && ENABLE_ALIPAY_MINI_GAME && ENABLE_ALIPAY_MINI_GAME_ADVERTISEMENT

using System;
using UnityEngine.Scripting;

namespace GameFrameX.Advertisement.AliPayMiniGame.Runtime
{
    /// <summary>
    /// 支付宝小游戏视频广告回调处理器，管理广告加载、展示和关闭等事件的回调。
    /// </summary>
    /// <remarks>
    /// Alipay mini-game video ad callback handler, managing callbacks for ad loading, display, and close events.
    /// </remarks>
    [Preserve]
    internal class AliPayVideoAdCallback
    {
        private Action<string> loadSuccess;
        private Action<string> loadFail;
        private Action<string> showSuccess;
        private Action<string> showFail;

        /// <summary>
        /// 获取或设置广告展示结果回调，参数表示用户是否完整观看广告。
        /// </summary>
        /// <remarks>
        /// Gets or sets the ad show result callback, parameter indicates whether the user watched the ad completely.
        /// </remarks>
        /// <value>展示结果回调 / Show result callback</value>
        [Preserve]
        public Action<bool> ShowResult { get; set; }

        /// <summary>
        /// 设置广告加载阶段的回调。
        /// </summary>
        /// <remarks>
        /// Sets the callbacks for the ad loading phase.
        /// </remarks>
        /// <param name="success">加载成功回调 / Load success callback</param>
        /// <param name="fail">加载失败回调 / Load failure callback</param>
        [Preserve]
        public void SetLoadCallback(Action<string> success, Action<string> fail)
        {
            loadSuccess = success;
            loadFail = fail;
        }

        /// <summary>
        /// 设置广告展示阶段的回调。
        /// </summary>
        /// <remarks>
        /// Sets the callbacks for the ad display phase.
        /// </remarks>
        /// <param name="success">展示成功回调 / Show success callback</param>
        /// <param name="fail">展示失败回调 / Show failure callback</param>
        [Preserve]
        public void SetShowCallback(Action<string> success, Action<string> fail)
        {
            showSuccess = success;
            showFail = fail;
        }

        /// <summary>
        /// 通知加载成功。
        /// </summary>
        /// <remarks>
        /// Notifies that the ad has loaded successfully.
        /// </remarks>
        [Preserve]
        public void OnLoadSuccess()
        {
            loadSuccess?.Invoke(null);
        }

        /// <summary>
        /// 通知加载失败。
        /// </summary>
        /// <remarks>
        /// Notifies that the ad has failed to load.
        /// </remarks>
        /// <param name="error">错误信息 / Error message</param>
        [Preserve]
        public void OnLoadError(string error)
        {
            loadFail?.Invoke(error);
        }
    }
}
#endif