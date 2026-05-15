<div align="center">

![GameFrameX Logo](https://download.alianblank.com/gameframex/gameframex_logo_320.png)

# Game Frame X Advertisement (Alipay Mini Game)

[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.alipayminigame?label=version&color=green)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame/releases)
[![License](https://img.shields.io/badge/license-MIT+Apache%202.0-orange.svg)](LICENSE.md)
[![Documentation](https://img.shields.io/badge/docs-gameframex-brightgreen.svg)](https://gameframex.doc.alianblank.com)

**인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현**

[📖 문서](https://gameframex.doc.alianblank.com) • [🚀 빠른 시작](#빠른-시작) • [💬 QQ 그룹](https://qm.qq.com/q/urCUAqJCJm)

---

🌐 **언어**: [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

---

</div>

## 프로젝트 개요

Game Frame X Unity 프레임워크의 Alipay 미니 게임 광고 컴포넌트. Alipay 미니 게임 플랫폼에 게시되는 게임을 위한 리워드 동영상 광고 통합을 제공합니다.

### 기능

- Alipay SDK 기반 리워드 동영상 광고 지원
- 광고 자동 로드 및 표시 실패 시 재시도
- IL2CPP 코드 스트리핑 보호
- 조건부 컴파일 (`ENABLE_ALIPAY_MINI_GAME`, `ENABLE_ALIPAY_MINI_GAME_ADVERTISEMENT`)

## 아키텍처

이 패키지는 Game Frame X 광고 코어의 `BaseAdvertisementManager` 추상화를 구현합니다:

| 클래스 | 설명 |
|--------|------|
| `AliPayMiniGameAdvertisementManager` | 리워드 동영상 광고 관리자 — 로드, 표시 및 수명 주기 관리 |
| `AliPayVideoAdCallback` | 광고 로드/표시 이벤트 콜백 핸들러 |
| `GameFrameXAdvertisementAliPayMiniGameCroppingHelper` | IL2CPP link.xml 대체 — 타입 참조 유지 |

## 빠른 시작

### 설치

Unity Package Manager (UPM)로 패키지 추가:

```json
{
  "dependencies": {
    "com.gameframex.unity.advertisement.alipayminigame": "https://github.com/GameFrameX/com.gameframex.unity.advertisement.alipayminigame.git"
  }
}
```

또는 Unity Package Manager 창에서 git URL로 추가.

### 사용 예시

```csharp
using GameFrameX.Advertisement.AliPayMiniGame.Runtime;

// 광고 유닛 ID로 초기화
var manager = new AliPayMiniGameAdvertisementManager();
manager.Initialize("your_ad_unit_id");

// 리워드 동영상 광고 재생
manager.Play((watchedComplete) =>
{
    if (watchedComplete)
    {
        // 사용자에게 보상 지급
    }
});
```

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

## 라이선스

이 프로젝트는 [MIT 라이선스](LICENSE.md) 및 [Apache 라이선스 2.0](LICENSE.md) 듀얼 라이선스입니다.
