<div align="center">

![GameFrameX Logo](https://download.alianblank.com/gameframex/gameframex_logo_320.png)

# Game Frame X Advertisement (Alipay Mini Game)

[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.alipayminigame?label=version&color=green)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/releases)
[![License](https://img.shields.io/badge/license-MIT+Apache%202.0-orange.svg)](LICENSE.md)
[![Documentation](https://img.shields.io/badge/docs-gameframex-brightgreen.svg)](https://gameframex.doc.alianblank.com)

**All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams**

[📖 Documentation](https://gameframex.doc.alianblank.com) • [🚀 Quick Start](#quick-start) • [💬 QQ Group](https://qm.qq.com/q/urCUAqJCJm)

---

🌐 **Language**: **English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

</div>

## Project Overview

Alipay Mini Game advertisement component for the Game Frame X Unity framework. Provides rewarded video ad integration for games published on the Alipay Mini Game platform.

### Features

- Rewarded video ad support via Alipay SDK
- Automatic ad loading with show-failure retry
- IL2CPP code stripping protection
- Conditional compilation (`ENABLE_ALIPAY_MINI_GAME`, `ENABLE_ALIPAY_MINI_GAME_ADVERTISEMENT`)

## Architecture

This package implements the `BaseAdvertisementManager` abstraction from the Game Frame X Advertisement core:

| Class | Description |
|-------|-------------|
| `AliPayMiniGameAdvertisementManager` | Rewarded video ad manager — load, show, and lifecycle |
| `AliPayVideoAdCallback` | Callback handler for ad load/show events |
| `GameFrameXAdvertisementAliPayMiniGameCroppingHelper` | IL2CPP link.xml alternative — preserves type references |

## Quick Start

### Installation

Add the package via Unity Package Manager (UPM):

```json
{
  "dependencies": {
    "com.gameframex.unity.advertisement.alipayminigame": "https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame.git"
  }
}
```

Or add via git URL in the Unity Package Manager window.

### Usage

```csharp
using GameFrameX.Advertisement.AliPayMiniGame.Runtime;

// Initialize with your ad unit ID
var manager = new AliPayMiniGameAdvertisementManager();
manager.Initialize("your_ad_unit_id");

// Play rewarded video ad
manager.Play((watchedComplete) =>
{
    if (watchedComplete)
    {
        // Reward the user
    }
});
```

## Platform Support

| Platform | Supported |
|----------|-----------|
| Alipay Mini Game (WebGL) | Yes |
| Android | No |
| iOS | No |
| Standalone | No |

> Requires `UNITY_WEBGL` and `ENABLE_ALIPAY_MINI_GAME` scripting define symbols.

## Documentation & Resources

- [Game Frame X Documentation](https://gameframex.doc.alianblank.com)
- [Alipay Mini Game Developer Portal](https://opendocs.alipay.com/mini/game)

## Community & Support

- QQ Group: [Join](https://qm.qq.com/q/urCUAqJCJm)
- GitHub Issues: [Report a bug](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/issues)

## Changelog

### v1.0.0

- Initial release
- Rewarded video ad support for Alipay Mini Game platform
- IL2CPP cropping protection

## License

This project is licensed under the [MIT License](LICENSE.md) and [Apache License 2.0](LICENSE.md).
