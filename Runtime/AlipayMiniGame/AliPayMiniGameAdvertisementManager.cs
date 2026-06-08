#if UNITY_WEBGL && ENABLE_ALIPAY_MINI_GAME && ENABLE_ALIPAY_MINI_GAME_ADVERTISEMENT

using System;
using GameFrameX.Advertisement.Runtime;
using GameFrameX.Runtime;
using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.Advertisement.AliPayMiniGame.Runtime
{
    /// <summary>
    /// 支付宝小游戏激励视频广告管理器，负责广告的加载、展示和生命周期管理。
    /// </summary>
    /// <remarks>
    /// Alipay mini-game rewarded video ad manager, responsible for ad loading, display, and lifecycle management.
    /// </remarks>
    [Preserve]
    public class AliPayMiniGameAdvertisementManager : BaseAdvertisementManager
    {
        private AlipaySdk.Ad.AlipayAdEntity _adManager;
        private string _adUnitId;
        private AliPayVideoAdCallback _aliPayVideoAdCallback;

        /// <summary>
        /// 初始化支付宝小游戏广告管理器。
        /// </summary>
        /// <remarks>
        /// Initializes the Alipay mini-game advertisement manager.
        /// </remarks>
        /// <param name="adUnitId">广告单元Id / Ad unit ID</param>
        /// <param name="debug">是否启用调试模式 / Whether to enable debug mode</param>
        /// <exception cref="ArgumentException">当 <paramref name="adUnitId"/> 为 null 或空字符串时抛出 / Thrown when <paramref name="adUnitId"/> is null or empty</exception>
        [Preserve]
        public override void Initialize(string adUnitId, bool debug = false)
        {
            GameFrameworkGuard.NotNullOrEmpty(adUnitId, nameof(adUnitId));
            _adUnitId = adUnitId;
            _aliPayVideoAdCallback = new AliPayVideoAdCallback();
        }

        /// <summary>
        /// 广告关闭回调，处理观看结果并通知展示结果回调。
        /// </summary>
        /// <remarks>
        /// Ad close callback, handles the viewing result and notifies the show result callback.
        /// </remarks>
        /// <param name="isEnded">是否完整观看广告 / Whether the ad was watched to completion</param>
        [Preserve]
        void OnCloseCallback(bool isEnded)
        {
            _aliPayVideoAdCallback.ShowResult?.Invoke(isEnded);
            _aliPayVideoAdCallback.ShowResult = null;
            _adManager = null;
        }

        /// <summary>
        /// 播放激励视频广告，自动完成加载和展示流程。
        /// </summary>
        /// <remarks>
        /// Plays a rewarded video ad, automatically completing the loading and display process.
        /// </remarks>
        /// <param name="playResult">播放结果回调，参数表示是否成功观看完整广告 / Play result callback, parameter indicates whether the ad was watched completely</param>
        /// <param name="customData">自定义透传数据 / Custom transparent data</param>
        [Preserve]
        public override void Play(Action<bool> playResult, string customData = null)
        {
            Show((s) => { Log.Debug(s); }, (f) => { Log.Error(f); }, playResult, customData);
        }

        /// <summary>
        /// 使用播放选项播放激励视频广告。
        /// </summary>
        /// <remarks>
        /// Plays a rewarded video ad using the specified play options.
        /// </remarks>
        /// <param name="option">广告播放选项，包含成功、失败和展示结果回调 / Ad play options containing success, failure, and show result callbacks</param>
        public override void Play(AdvertisementPlayOption option)
        {
#pragma warning disable CS0618
            Show(option.OnSuccess, option.OnFail, option.OnShowResult, option.customData);
#pragma warning restore CS0618
        }

        /// <summary>
        /// 展示激励视频广告，如果展示失败则尝试重新加载并再次展示。
        /// </summary>
        /// <remarks>
        /// Shows the rewarded video ad, retrying with load + show if show fails.
        /// </remarks>
        /// <param name="success">展示成功回调 / Show success callback</param>
        /// <param name="fail">展示失败回调 / Show failure callback</param>
        /// <param name="onShowResult">展示结果回调，参数表示用户是否观看完整广告 / Show result callback, parameter indicates whether the user watched the ad completely</param>
        /// <param name="customData">自定义透传数据 / Custom transparent data</param>
        [Preserve]
        public override void Show(Action<string> success, Action<string> fail, Action<bool> onShowResult, string customData = null)
        {
            OnShowResult = onShowResult;
            _aliPayVideoAdCallback.SetShowCallback(success, fail);
            _aliPayVideoAdCallback.ShowResult = onShowResult;

            if (_adManager == null)
            {
                var adManager = AlipaySdk.AP.GetAdManager();
                _adManager = adManager.CreateRewardAd(_adUnitId);
            }

            DoShow(success, fail, onShowResult);
        }

        /// <summary>
        /// 执行广告展示，内部处理展示失败后的重试逻辑。
        /// </summary>
        /// <remarks>
        /// Executes the ad show, handling retry logic if show fails.
        /// </remarks>
        private void DoShow(Action<string> success, Action<string> fail, Action<bool> onShowResult)
        {
            if (_adManager == null)
            {
                fail?.Invoke("广告未初始化");
                onShowResult?.Invoke(false);
                return;
            }

            _adManager.OnClose += OnCloseCallback;
            _adManager.Show();
        }

        /// <summary>
        /// 加载激励视频广告资源。
        /// </summary>
        /// <remarks>
        /// Loads the rewarded video ad resources. The ad auto-loads on creation, this method supports retry logic.
        /// </remarks>
        /// <param name="success">加载成功回调 / Load success callback</param>
        /// <param name="fail">加载失败回调 / Load failure callback</param>
        /// <param name="customData">自定义透传数据 / Custom transparent data</param>
        [Preserve]
        public override void Load(Action<string> success, Action<string> fail, string customData = null)
        {
            if (_adManager != null)
            {
                success?.Invoke(customData);
                return;
            }

            var adManager = AlipaySdk.AP.GetAdManager();
            _adManager = adManager.CreateRewardAd(_adUnitId);

            _adManager.OnLoad += () =>
            {
                Debug.Log($"[AliPayMiniGame] Ad Loaded successfully");
                success?.Invoke(customData);
            };

            _adManager.OnError += (error) =>
            {
                Debug.LogError($"[AliPayMiniGame] Ad Load Error: {error}");
                fail?.Invoke(error);
            };
        }
    }
}

#endif