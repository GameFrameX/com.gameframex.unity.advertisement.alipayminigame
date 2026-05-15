<div align="center">

![GameFrameX Logo](https://download.alianblank.com/gameframex/gameframex_logo_320.png)

# Game Frame X Advertisement (Alipay Mini Game)

[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.alipayminigame?label=version&color=green)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/releases)
[![License](https://img.shields.io/badge/license-MIT+Apache%202.0-orange.svg)](LICENSE.md)
[![Documentation](https://img.shields.io/badge/docs-gameframex-brightgreen.svg)](https://gameframex.doc.alianblank.com)

**インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援**

[📖 ドキュメント](https://gameframex.doc.alianblank.com) • [🚀 クイックスタート](#クイックスタート) • [💬 QQグループ](https://qm.qq.com/q/urCUAqJCJm)

---

🌐 **言語**: [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

---

</div>

## プロジェクト概要

Game Frame X Unity フレームワークの Alipay ミニゲーム広告コンポーネント。Alipay ミニゲームプラットフォームに公開するゲーム向けにリワード動画広告の統合を提供します。

### 機能

- Alipay SDK によるリワード動画広告サポート
- 広告の自動ロードと表示失敗時のリトライ
- IL2CPP コードストリッピング保護
- 条件付きコンパイル（`ENABLE_ALIPAY_MINI_GAME`、`ENABLE_ALIPAY_MINI_GAME_ADVERTISEMENT`）

## アーキテクチャ

本パッケージは Game Frame X 広告コアの `BaseAdvertisementManager` 抽象を実装しています：

| クラス | 説明 |
|--------|------|
| `AliPayMiniGameAdvertisementManager` | リワード動画広告マネージャー — ロード、表示、ライフサイクル管理 |
| `AliPayVideoAdCallback` | 広告ロード/表示イベントのコールバックハンドラー |
| `GameFrameXAdvertisementAliPayMiniGameCroppingHelper` | IL2CPP link.xml の代替 — 型参照を保持 |

## クイックスタート

### インストール

Unity Package Manager (UPM) でパッケージを追加：

```json
{
  "dependencies": {
    "com.gameframex.unity.advertisement.alipayminigame": "https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame.git"
  }
}
```

または Unity Package Manager ウィンドウで git URL から追加。

### 使用例

```csharp
using GameFrameX.Advertisement.AliPayMiniGame.Runtime;

// 広告ユニット ID で初期化
var manager = new AliPayMiniGameAdvertisementManager();
manager.Initialize("your_ad_unit_id");

// リワード動画広告を再生
manager.Play((watchedComplete) =>
{
    if (watchedComplete)
    {
        // ユーザーに報酬を付与
    }
});
```

## プラットフォーム対応

| プラットフォーム | 対応 |
|------------------|------|
| Alipay ミニゲーム (WebGL) | はい |
| Android | いいえ |
| iOS | いいえ |
| Standalone | いいえ |

> `UNITY_WEBGL` と `ENABLE_ALIPAY_MINI_GAME` スクリプト定義シンボルが必要です。

## ドキュメントとリソース

- [Game Frame X ドキュメント](https://gameframex.doc.alianblank.com)
- [Alipay ミニゲーム開発者ポータル](https://opendocs.alipay.com/mini/game)

## コミュニティとサポート

- QQグループ：[参加](https://qm.qq.com/q/urCUAqJCJm)
- GitHub Issues：[バグ報告](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/issues)

## 変更履歴

### v1.0.0

- 初回リリース
- Alipay ミニゲームプラットフォームのリワード動画広告対応
- IL2CPP ストリッピング保護

## ライセンス

本プロジェクトは [MIT ライセンス](LICENSE.md) および [Apache ライセンス 2.0](LICENSE.md) のデュアルライセンスです。
