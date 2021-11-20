# GoProGPS
GoProGPS is a simple C# console application which extracts GPS data from an mp4 movie file recorded by GoPro and outputs GPX and KML files. 

(It has been checked with mp4 files recorded by GoPro HERO 10.)

## Flow of its process and required external programs
The procedure of GoProGPS is as follows: 
1. Extracts meta data from an mp4 file by using ffmpeg.exe
2. Parse GPS data from the meta data
3. Convert GPS data to GPX and KML formats and outputs them to files individually
Therefore, FFMpeg should be installed.

- The path to ffmpeg.exe and file name of the mp4 file to be processed are directly specified in the source code (Program.cs). Please change them according to your environment.
- Build the project and excute.
- Then GPX file (name: tmp.gpx) and KML file (name: tmp.kml) will be obtained.

- Output rate is fixed to 1Hz (data point is written for every 1sec onto gpx and kml).
- Only 3D positioning results satisfying DOP<=5.0 are output. 

The output rate and conditions are specified directly in "DataOutPut.cs".

#### External Links
- [GoPro HERO10の動画（mp4）からGPSデータ等を抽出する方法（調査編）](https://skyrail.tech/archives/102)
- [GoPro HERO10の動画（mp4）からFFMpegでメタデータを抽出する](https://skyrail.tech/archives/147)
- [GoPro HERO10 で撮影したmp4からGPSデータを抽出するプログラムをC#で作成する（メタデータ取り出し後の処理を解説）](https://skyrail.tech/archives/171)
