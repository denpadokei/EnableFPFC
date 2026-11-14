# EnableFPFC

[![Build and Release](https://github.com/denpadokei/EnableFPFC/actions/workflows/build-and-release.yml/badge.svg)](https://github.com/denpadokei/EnableFPFC/actions/workflows/build-and-release.yml)

起動引数 `FPFC` が付いているときに First Person Flying Camera を有効化する MOD です。Oculus 環境でゲームシーン中に FPFC が使えなくなった問題を、カメラを差し替えることで回避します。

## 機能

- コマンドライン引数に `FPFC` があるかを起動時に判定する (`FPFC` が無ければ何もしない)
- `FirstPersonFlyingController` を複製して生成する
- `MainCamera` を無効化し、FPFC 側のカメラを有効化する
- SiraUtil の Zenject でゲームシーンにコントローラをバインドする
- コントローラ破棄時に生成した FPFC を後始末する

## 動作環境

| 項目 | 内容 |
| --- | --- |
| Beat Saber | 1.11.1 |
| 依存 MOD | BSIPA 4.0.5 以降 / SiraUtil (コードが参照) |

## インストール

1. Beat Saber を 1.11.1 に合わせる (BSManager などのバージョン管理ツールを推奨)
2. BSIPA と上記の依存 MOD をインストールする
3. [Releases](https://github.com/denpadokei/EnableFPFC/releases) から `EnableFPFC-0.0.1-bs1.11.1.zip` をダウンロードし、`Plugins` フォルダをゲームフォルダへ上書きコピーする

## 使い方

ランチャーの起動オプションに `FPFC` を追加してゲームを起動します。Steam 版ならプロパティの起動オプションに `FPFC` を入力します。

```
"Beat Saber.exe" FPFC
```

引数が無い場合は FPFC を有効化せず、通常のカメラのまま起動します。

## ビルド

```powershell
git clone https://github.com/denpadokei/EnableFPFC.git
cd EnableFPFC
dotnet build .\EnableFPFC\EnableFPFC.csproj -c Release
```

`BeatSaberDir` (または `GameDirectory`) に Beat Saber のインストール先を設定すると、ゲームの参照アセンブリを解決できます。

GitHub Actions の `build-and-release.yml` が push ごとにビルドし、`X.X.X` 形式のタグを push するとリリースを作成します。

## ライセンス

Apache License 2.0 (`LICENSE`)
