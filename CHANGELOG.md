# [2.0.0](https://github.com/gameframex/com.gameframex.unity.advertisement.alipayminigame/compare/1.0.3...2.0.0) (2026-10-15)


### Features

* **advertisement.alipayminigame:** 适配 GameFrameX 3.0.0 ([d4a14b6](https://github.com/gameframex/com.gameframex.unity.advertisement.alipayminigame/commit/d4a14b669c5761c030c024d5b2d895995087a91f))
* **ad:** 引入 Bootstrap + 强类型 Config ([fd3a3df](https://github.com/gameframex/com.gameframex.unity.advertisement.alipayminigame/commit/fd3a3df300626556b605c09bbd4dbca2b579ab79))


### BREAKING CHANGES

* **ad:** 移除 AdvertisementComponent 上的 WebGL 支付宝广告位 ID
宏选序列化字段，adUnitId 改为启动期由 AliPayMiniGameAdvertisementBootstrap.Config
注入；主包 Inspector 类型下拉同步移除，渠道发现统一收敛到 AdvertisementRegistry。

## [1.0.3](https://github.com/gameframex/com.gameframex.unity.advertisement.alipayminigame/compare/1.0.2...1.0.3) (2026-07-29)


### Bug Fixes

* **deps:** 补齐 alipayminigame 广告包缺失的依赖声明 ([0e73ffd](https://github.com/gameframex/com.gameframex.unity.advertisement.alipayminigame/commit/0e73ffd7c1d9ba151462368696453d0f84214939))

## [1.0.2](https://github.com/gameframex/com.gameframex.unity.advertisement.alipayminigame/compare/1.0.1...1.0.2) (2026-06-08)


### Bug Fixes

* 补全包规范文件（LICENSE/CHANGELOG/URL 字段/unity 字段） ([38a05ee](https://github.com/gameframex/com.gameframex.unity.advertisement.alipayminigame/commit/38a05eebed8f254742106921e2ccce61d17b7d9f))

## [1.0.1](https://github.com/gameframex/com.gameframex.unity.advertisement.alipayminigame/compare/1.0.0...1.0.1) (2026-06-08)


### Bug Fixes

* **ad:** 简化广告管理器为空时的初始化逻辑 ([9b73fcc](https://github.com/gameframex/com.gameframex.unity.advertisement.alipayminigame/commit/9b73fcc7d73b0282acb9a1f8137742d3391ddf56))

# 1.0.0 (2026-05-15)


### Features

* initial commit for Alipay Mini Game advertisement component ([c41f259](https://github.com/gameframex/com.gameframex.unity.advertisement.alipayminigame/commit/c41f259254d586ec3472c8a650bda7c511a62bd1))
