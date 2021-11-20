using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static GoProGPS.Definitions;
using static GoProGPS.Decode;
using static GoProGPS.DataOutPut;

namespace GoProGPS
{
    class Program
    {
        // ffprobeの実行
        static void Main(string[] args)
        {
            using (Process process = new Process())
            {
                string ffprobePath = Path.GetFullPath(@".\ffprobe.exe");
                string mp4Path = Path.GetFullPath(@".\GX010002.MP4");
                process.StartInfo.FileName = ffprobePath;
                process.StartInfo.Arguments = mp4Path;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                StreamReader reader = process.StandardOutput;
                string output = reader.ReadToEnd();
                Console.WriteLine(output);
                process.WaitForExit();
            }

            // ffmpegの実行
            using (Process process = new Process())
            {
                string ffprobePath = Path.GetFullPath(@".\ffmpeg.exe");
                string mp4Path = Path.GetFullPath(@".\GX010002.MP4");
                process.StartInfo.FileName = ffprobePath;
                process.StartInfo.Arguments = "-y -i " + mp4Path + " -codec copy -map 0:3 -f rawvideo tmp.bin";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                StreamReader reader = process.StandardOutput;
                string output = reader.ReadToEnd();
                Console.WriteLine(output);
                process.WaitForExit();
            }

            var tmp = File.ReadAllBytes("tmp.bin");
            List<GpsInfo> gpsInfos = new();
            List<byte[]> Devcs = SplitToDEVC(tmp);
            foreach (var d in Devcs)
            {
                var devinfo = GetDevInfo(d);
                GpsInfo gps = GetGpsInfo(d);
                gpsInfos.Add(gps);
            }

            var s = GetGPX(gpsInfos);
            File.WriteAllLines("tmp.gpx", s);
            Console.WriteLine("\n\nGPX file: tmp.gpx has been written\n");

            var kml = GetKML(gpsInfos);
            File.WriteAllLines("tmp.kml", kml);
            Console.WriteLine("KML file: tmp.kml has been written\n");

            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadLine();

        }
    }
}
