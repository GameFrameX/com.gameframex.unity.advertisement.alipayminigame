<div align="center">

![GameFrameX Logo](https://download.alianblank.com/gameframex/gameframex_logo_320.png)

# Game Frame X Advertisement (Alipay Mini Game)

[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.alipayminigame?label=version&color=green)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/releases)
[![License](https://img.shields.io/badge/license-MIT+Apache%202.0-orange.svg)](LICENSE.md)
[![Documentation](https://img.shields.io/badge/docs-gameframex-brightgreen.svg)](https://gameframex.doc.alianblank.com)

**独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使**

[📖 文档](https://gameframex.doc.alianblank.com) • [🚀 快速开始](#快速开始) • [💬 QQ群](https://qm.qq.com/q/urCUAqJCJm)

---

🌐 **语言**: [English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

</div>

## 项目简介

Game Frame X Unity 框架的支付宝小游戏广告组件。为发布到支付宝小游戏平台的游戏提供激励视频广告集成。

### 功能特性

- 基于支付宝 SDK 的激励视频广告支持
- 自动加载广告，展示失败自动重试
- IL2CPP 代码裁剪保护
- 条件编译（`ENABLE_ALIPAY_MINI_GAME`、`ENABLE_ALIPAY_MINI_GAME_ADVERTISEMENT`）

## 架构概览

本包实现了 Game Frame X 广告核心的 `BaseAdvertisementManager` 抽象：

| 类 | 说明 |
|----|------|
| `AliPayMiniGameAdvertisementManager` | 激励视频广告管理器 — 加载、展示及生命周期管理 |
| `AliPayVideoAdCallback` | 广告加载/展示事件回调处理器 |
| `GameFrameXAdvertisementAliPayMiniGameCroppingHelper` | IL2CPP link.xml 替代方案 — 保留类型引用 |

## 快速开始

### 安装

通过 Unity Package Manager (UPM) 添加包：

```json
{
  "dependencies": {
    "com.gameframex.unity.advertisement.alipayminigame": "https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame.git"
  }
}
```

或在 Unity Package Manager 窗口中通过 git URL 添加。

### 使用示例

```csharp
using GameFrameX.Advertisement.AliPayMiniGame.Runtime;

// 使用广告单元 ID 初始化
var manager = new AliPayMiniGameAdvertisementManager();
manager.Initialize("your_ad_unit_id");

// 播放激励视频广告
manager.Play((watchedComplete) =>
{
    if (watchedComplete)
    {
        // 发放奖励
    }
});
```

## 平台支持

| 平台 | 支持 |
|------|------|
| 支付宝小游戏 (WebGL) | 是 |
| Android | 否 |
| iOS | 否 |
| Standalone | 否 |

> 需要 `UNITY_WEBGL` 和 `ENABLE_ALIPAY_MINI_GAME` 脚本宏定义。

## 文档与资源

- [Game Frame X 文档](https://gameframex.doc.alianblank.com)
- [支付宝小游戏开发者平台](https://opendocs.alipay.com/mini/game)

## 社区与支持

- QQ群：[加入](https://qm.qq.com/q/urCUAqJCJm)
- GitHub Issues：[报告问题](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/issues)

## 更新日志

### v1.0.0

- 初始发布
- 支持支付宝小游戏平台激励视频广告
- IL2CPP 裁剪保护

## 开源协议

本项目基于 [MIT 许可证](LICENSE.md) 和 [Apache 许可证 2.0](LICENSE.md) 双重授权。
