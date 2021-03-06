# GoProGPS
[English version](README_en.md)

GoProで撮影した動画（mp4）からGPSデータを抽出し，GPXおよびKML形式のファイルを出力するシンプルなコンソールアプリです．
（HERO 10で撮影したmp4ファイルで動作確認しています）
## プログラムの動きと，必要な外部ファイルについて
1. GoProで撮影した動画から
2. ffmpegでメタデータを抽出して（バイナリファイルに保存）
3. GPSデータをGPXとKML形式で書き出す

という流れで動作しますので，FFMpegをインストールする必要があります．

- ffmpeg.exeへのパスや，処理対象のmp4ファイル名はソースコード内に直接記述していますので，適宜変更して下さい
- 実行すると，GPXファイル（ファイル名：tmp.gpx）と，KMLファイル（ファイル名：tmp.kml）が出力されます

ファイル名は，"Program.cs"内で指定しています．

- データ出力頻度は1Hzに固定しています
- 出力されるGPSデータは，3次元測位時かつDOP<=5.0の場合に限っています

出力頻度と出力条件は，"DataOutPut.cs"内で指定しています．

#### 外部リンク
- [GoPro HERO10の動画（mp4）からGPSデータ等を抽出する方法（調査編）](https://skyrail.tech/archives/102)
- [GoPro HERO10の動画（mp4）からFFMpegでメタデータを抽出する](https://skyrail.tech/archives/147)
- [GoPro HERO10 で撮影したmp4からGPSデータを抽出するプログラムをC#で作成する（メタデータ取り出し後の処理を解説）](https://skyrail.tech/archives/171)
