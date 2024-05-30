using Newtonsoft.Json.Linq;
using System.Diagnostics;

public class mkvmerge {
    private readonly string _bin;

    public mkvmerge() {
        _bin = @"C:\Program Files\MKVToolNix\mkvmerge.exe";
    }

    public List<SubtitleTrack> GetSubtitleTracks(string mkvFilePath) {
        List<SubtitleTrack> subtitleTracks = new List<SubtitleTrack>();

        ProcessStartInfo startInfo = new ProcessStartInfo {
            FileName = _bin,
            Arguments = $"-J \"{mkvFilePath}\"",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using(Process process = new Process { StartInfo = startInfo }) {
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            JObject jsonOutput = JObject.Parse(output);
            JArray tracks = (JArray)jsonOutput["tracks"];

            foreach(JObject track in tracks) {
                string trackType = (string)track["type"];
                if(trackType == "subtitles") {
                    string languageCode = (string)track["properties"]["language"];
                    string language = GetLanguageName(languageCode);

                    string track_name = (string)track["properties"]["track_name"];

                    subtitleTracks.Add(new SubtitleTrack { 
                        Langauge = language,
                        TrackName = track_name 
                    });
                }
            }
        }

        return subtitleTracks;
    }

    private string GetLanguageName(string code) {
        Dictionary<string,string> languageMap = new Dictionary<string,string>
        {
                { "eng", "English" },
                { "ger", "German" },
                // Add more language codes and names here as needed
            };

        return languageMap.ContainsKey(code) ? languageMap[code] : code;
    }

    public class SubtitleTrack {
        public string Langauge { get; set; }
        public string TrackName { get; set; }
    }
}