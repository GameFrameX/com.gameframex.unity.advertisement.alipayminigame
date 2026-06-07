<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Advertisement (Alipay Mini Game)

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.advertisement.alipayminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.alipayminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## Project Overview

Alipay Mini Game platform adapter for the [Game Frame X Advertisement](https://github.com/GameFrameX/com.gameframex.unity.advertisement) system. This package provides rewarded video ad integration for games published on the Alipay Mini Game platform.

### Features

- Rewarded video ad support via Alipay SDK
- Automatic ad loading with show-failure retry
- IL2CPP code stripping protection
- Conditional compilation (`ENABLE_ALIPAY_MINI_GAME`, `ENABLE_ALIPAY_MINI_GAME_ADVERTISEMENT`)
- Seamless integration with the Game Frame X Advertisement component

## Architecture

This package is an **adapter implementation** of `BaseAdvertisementManager` from the Game Frame X Advertisement core. It is discovered and loaded automatically by `AdvertisementComponent` via Unity Inspector configuration.

| Class | Description |
|-------|-------------|
| `AliPayMiniGameAdvertisementManager` | Rewarded video ad manager — load, show, and lifecycle |
| `AliPayVideoAdCallback` | Callback handler for ad load/show events |
| `GameFrameXAdvertisementAliPayMiniGameCroppingHelper` | IL2CPP link.xml alternative — preserves type references |

## Quick Start

### Installation

Edit your Unity project's `Packages/manifest.json` and add the `scopedRegistries` section:

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
  ]
}
```

`scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex` will be fetched from it.

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.advertisement.alipayminigame": "1.0.0"
  }
}
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


## Dependencies

| Package | Description |
|---------|-------------|
| (无) | - |

## License

See [LICENSE.md](LICENSE.md) for license information.
