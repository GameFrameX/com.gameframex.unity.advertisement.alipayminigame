<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Advertisement (Alipay Mini Game)

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.advertisement.alipayminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.alipayminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

<br />

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#quick-start) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 項目簡介

[Game Frame X 廣告系統](https://github.com/GameFrameX/com.gameframex.unity.advertisement)的支付寶小遊戲平台適配器。為發佈到支付寶小遊戲平台的遊戲提供激勵影片廣告整合。

### 功能特性

- 基於支付寶 SDK 的激勵影片廣告支援
- 自動載入廣告，展示失敗自動重試
- IL2CPP 程式碼裁剪保護
- 條件編譯（`ENABLE_ALIPAY_MINI_GAME`、`ENABLE_ALIPAY_MINI_GAME_ADVERTISEMENT`）
- 與 Game Frame X 廣告元件無縫整合

## 架構概覽

本套件是 Game Frame X 廣告核心 `BaseAdvertisementManager` 的**適配器實現**。透過 `AliPayMiniGameAdvertisementBootstrap` 在 `BeforeSceneLoad` 階段把渠道工廠自註冊進主套件 `AdvertisementRegistry`；當巨集 `UNITY_WEBGL && ENABLE_ALIPAY_MINI_GAME && ENABLE_ALIPAY_MINI_GAME_ADVERTISEMENT` 未啟用時代碼被裁剪，註冊不會發生（引用即註冊）。初始化由工廠閉包注入強型別配置。

| 類別 | 說明 |
|------|------|
| `AliPayMiniGameAdvertisementManager` | 激勵影片廣告管理器 — 載入、展示及生命週期管理 |
| `AliPayVideoAdCallback` | 廣告載入/展示事件回調處理器 |
| `GameFrameXAdvertisementAliPayMiniGameCroppingHelper` | IL2CPP link.xml 替代方案 — 保留類型引用 |
| `AliPayMiniGameAdvertisementConfig` | 強型別渠道配置 — 含 `adUnitId` 欄位 |
| `AliPayMiniGameAdvertisementBootstrap` | 渠道啟動註冊 — `BeforeSceneLoad` 自註冊進 `AdvertisementRegistry`，含啟動期 `Config` 靜態屬性 |

## 快速開始

### 安裝

選擇以下任一方式：

1. 編輯 Unity 專案的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：
   ```json
   {
     "scopedRegistries": [
       {
         "name": "GameFrameX",
         "url": "https://gameframex.upm.alianblank.uk",
         "scopes": [
           "com.gameframex"
         ]
       }
     ],
     "dependencies": {
       "com.gameframex.unity.advertisement.alipayminigame": "1.0.0"
     }
   }
   ```

   `scopes` 控制哪些套件透過此註冊表解析。只有以 `com.gameframex` 開頭的套件才會從這個註冊表取得。

2. 直接在 `manifest.json` 的 `dependencies` 節點下添加以下內容：
   ```json
   {
      "com.gameframex.unity.advertisement.alipayminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.alipayminigame.git"
   }
   ```
3. 在 Unity 的 `Package Manager` 中使用 `Git URL` 的方式添加庫，地址為：`https://github.com/gameframex/com.gameframex.unity.advertisement.alipayminigame.git`
4. 直接下載倉庫放置到 Unity 專案的 `Packages` 目錄下，會自動載入識別。

### 渠道註冊與配置

啟動期（首次廣告呼叫前）對 `AliPayMiniGameAdvertisementBootstrap.Config` 賦值，注入強型別渠道配置：

```csharp
using GameFrameX.Advertisement.AliPayMiniGame.Runtime;

AliPayMiniGameAdvertisementBootstrap.Config = new AliPayMiniGameAdvertisementConfig
{
    adUnitId = "你的廣告位ID",
    isDebug = false,
};
```

渠道常數 `AliPayMiniGameAdvertisementManager.ChannelId` 的值為 `"alipayminigame"`；顯式路由 `AdvertisementRegistry.ResolveManager("alipayminigame")` 可用。
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

### 破壞性變更與遷移

- `AdvertisementComponent` 上的 WebGL 支付寶廣告位ID 巨選序列化欄位已移除，`adUnitId` 改經 `AliPayMiniGameAdvertisementBootstrap.Config` 注入；
- 主套件 Inspector 類型下拉已移除，渠道發現統一收斂到 `AdvertisementRegistry`。


## 依賴

| 套件 | 說明 |
|------|------|
| (无) | - |

## 開源協議

詳見 [LICENSE.md](LICENSE.md) 檔案。
