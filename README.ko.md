<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Advertisement (Alipay Mini Game)

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.advertisement.alipayminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.alipayminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현

<br />

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#quick-start) · QQ 그룹: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

</div>

## 프로젝트 개요

[Game Frame X 광고 시스템](https://github.com/GameFrameX/com.gameframex.unity.advertisement)의 Alipay 미니 게임 플랫폼 어댑터. Alipay 미니 게임 플랫폼에 게시되는 게임을 위한 리워드 동영상 광고 통합을 제공합니다.

### 기능

- Alipay SDK 기반 리워드 동영상 광고 지원
- 광고 자동 로드 및 표시 실패 시 재시도
- IL2CPP 코드 스트리핑 보호
- 조건부 컴파일 (`ENABLE_ALIPAY_MINI_GAME`, `ENABLE_ALIPAY_MINI_GAME_ADVERTISEMENT`)
- Game Frame X 광고 컴포넌트와 원활한 통합

## 아키텍처

이 패키지는 Game Frame X 광고 코어의 `BaseAdvertisementManager` **어댑터 구현**입니다. `AliPayMiniGameAdvertisementBootstrap`가 `BeforeSceneLoad` 단계에서 코어의 `AdvertisementRegistry`에 자동 등록합니다. 매크로 `UNITY_WEBGL && ENABLE_ALIPAY_MINI_GAME && ENABLE_ALIPAY_MINI_GAME_ADVERTISEMENT`가 활성화되지 않으면 코드가 스트리핑되어 등록이 일어나지 않습니다(참조 곧 등록). 초기화는 팩토리 클로저를 통해 강타입 설정을 주입합니다.

| 클래스 | 설명 |
|--------|------|
| `AliPayMiniGameAdvertisementManager` | 리워드 동영상 광고 관리자 — 로드, 표시 및 수명 주기 관리 |
| `AliPayVideoAdCallback` | 광고 로드/표시 이벤트 콜백 핸들러 |
| `GameFrameXAdvertisementAliPayMiniGameCroppingHelper` | IL2CPP link.xml 대체 — 타입 참조 유지 |
| `AliPayMiniGameAdvertisementConfig` | 강타입 채널 설정 — `adUnitId` 필드 포함 |
| `AliPayMiniGameAdvertisementBootstrap` | 채널 시작 등록 — `BeforeSceneLoad`에서 `AdvertisementRegistry`에 자동 등록, 시작 시점 `Config` 정적 속성 포함 |

## 빠른 시작

### 설치

다음 방법 중 하나를 선택하세요:

1. Unity 프로젝트의 `Packages/manifest.json`을 편집하여 `scopedRegistries` 섹션을 추가하세요:
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

   `scopes`는 이 레지스트리를 통해 어떤 패키지를 해석할지 제어합니다. `com.gameframex`로 시작하는 패키지만 이 레지스트리에서 가져옵니다.

2. `manifest.json`의 `dependencies`에 직접 추가:
   ```json
   {
      "com.gameframex.unity.advertisement.alipayminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.alipayminigame.git"
   }
   ```
3. Unity의 **Package Manager**에서 **Git URL**을 사용하여 추가: `https://github.com/gameframex/com.gameframex.unity.advertisement.alipayminigame.git`
4. 리포지토리를 Unity 프로젝트의 `Packages` 디렉토리에 클론하세요. 자동으로 로드됩니다.

### 채널 등록 및 설정

시작 시점(첫 광고 호출 전)에 `AliPayMiniGameAdvertisementBootstrap.Config`에 값을 할당하여 강타입 채널 설정을 주입합니다:

```csharp
using GameFrameX.Advertisement.AliPayMiniGame.Runtime;

AliPayMiniGameAdvertisementBootstrap.Config = new AliPayMiniGameAdvertisementConfig
{
    adUnitId = "광고 유닛 ID",
    isDebug = false,
};
```

채널 상수 `AliPayMiniGameAdvertisementManager.ChannelId`의 값은 `"alipayminigame"`입니다. 명시적 라우팅 `AdvertisementRegistry.ResolveManager("alipayminigame")`도 사용할 수 있습니다.
## 플랫폼 지원

| 플랫폼 | 지원 |
|--------|------|
| Alipay 미니 게임 (WebGL) | 예 |
| Android | 아니요 |
| iOS | 아니요 |
| Standalone | 아니요 |

> `UNITY_WEBGL` 및 `ENABLE_ALIPAY_MINI_GAME` 스크립트 정의 기호가 필요합니다.

## 문서 및 자료

- [Game Frame X 문서](https://gameframex.doc.alianblank.com)
- [Alipay 미니 게임 개발자 포털](https://opendocs.alipay.com/mini/game)

## 커뮤니티 및 지원

- QQ 그룹: [가입](https://qm.qq.com/q/urCUAqJCJm)
- GitHub Issues: [버그 보고](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/issues)

## 변경 로그

### v1.0.0

- 초기 릴리스
- Alipay 미니 게임 플랫폼 리워드 동영상 광고 지원
- IL2CPP 스트리핑 보호

### 파괴적 변경 및 마이그레이션

- `AdvertisementComponent`의 WebGL Alipay 매크로 선택 광고 유닛 ID 직렬화 필드가 제거되었습니다. `adUnitId`는 이제 `AliPayMiniGameAdvertisementBootstrap.Config`를 통해 주입됩니다;
- 코어 패키지의 Inspector 타입 드롭다운이 제거되었으며, 채널 발견은 `AdvertisementRegistry`로 통합되었습니다.


## 의존성

| 패키지 | 설명 |
|--------|------|
| (无) | - |

## 라이선스

자세한 내용은 [LICENSE.md](LICENSE.md) 파일을 참조하세요.
