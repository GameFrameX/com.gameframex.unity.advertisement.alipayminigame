<div align="center">

![GameFrameX Logo](https://download.alianblank.com/gameframex/gameframex_logo_320.png)

# Game Frame X Advertisement (Alipay Mini Game)

[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.alipayminigame?label=version&color=green)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/releases)
[![License](https://img.shields.io/badge/license-MIT+Apache%202.0-orange.svg)](LICENSE.md)
[![Documentation](https://img.shields.io/badge/docs-gameframex-brightgreen.svg)](https://gameframex.doc.alianblank.com)

**獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使**

[📖 文檔](https://gameframex.doc.alianblank.com) • [🚀 快速開始](#快速開始) • [💬 QQ群](https://qm.qq.com/q/urCUAqJCJm)

---

🌐 **語言**: [English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

---

</div>

## 項目簡介

Game Frame X Unity 框架的支付寶小遊戲廣告元件。為發佈到支付寶小遊戲平台的遊戲提供激勵影片廣告整合。

### 功能特性

- 基於支付寶 SDK 的激勵影片廣告支援
- 自動載入廣告，展示失敗自動重試
- IL2CPP 程式碼裁剪保護
- 條件編譯（`ENABLE_ALIPAY_MINI_GAME`、`ENABLE_ALIPAY_MINI_GAME_ADVERTISEMENT`）

## 架構概覽

本套件實現了 Game Frame X 廣告核心的 `BaseAdvertisementManager` 抽象：

| 類別 | 說明 |
|------|------|
| `AliPayMiniGameAdvertisementManager` | 激勵影片廣告管理器 — 載入、展示及生命週期管理 |
| `AliPayVideoAdCallback` | 廣告載入/展示事件回調處理器 |
| `GameFrameXAdvertisementAliPayMiniGameCroppingHelper` | IL2CPP link.xml 替代方案 — 保留類型引用 |

## 快速開始

### 安裝

透過 Unity Package Manager (UPM) 新增套件：

```json
{
  "dependencies": {
    "com.gameframex.unity.advertisement.alipayminigame": "https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame.git"
  }
}
```

或在 Unity Package Manager 視窗中透過 git URL 新增。

### 使用範例

```csharp
using GameFrameX.Advertisement.AliPayMiniGame.Runtime;

// 使用廣告單元 ID 初始化
var manager = new AliPayMiniGameAdvertisementManager();
manager.Initialize("your_ad_unit_id");

// 播放激勵影片廣告
manager.Play((watchedComplete) =>
{
    if (watchedComplete)
    {
        // 發放獎勵
    }
});
```

## 平台支援

| 平台 | 支援 |
|------|------|
| 支付寶小遊戲 (WebGL) | 是 |
| Android | 否 |
| iOS | 否 |
| Standalone | 否 |

> 需要 `UNITY_WEBGL` 和 `ENABLE_ALIPAY_MINI_GAME` 腳本巨集定義。

## 文檔與資源

- [Game Frame X 文檔](https://gameframex.doc.alianblank.com)
- [支付寶小遊戲開發者平台](https://opendocs.alipay.com/mini/game)

## 社區與支援

- QQ群：[加入](https://qm.qq.com/q/urCUAqJCJm)
- GitHub Issues：[回報問題](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/issues)

## 更新日誌

### v1.0.0

- 初始發佈
- 支援支付寶小遊戲平台激勵影片廣告
- IL2CPP 裁剪保護

## 開源協議

本專案基於 [MIT 授權](LICENSE.md) 和 [Apache 授權 2.0](LICENSE.md) 雙重授權。
