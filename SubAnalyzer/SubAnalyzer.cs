using System.Text.RegularExpressions;

class SubAnalyzer {
    public string Path { get; set; }
    public SubAnalyzer(string arg) {
        Path = arg;        
    }
    public void Run() {
        Console.WriteLine($"Time: {DateTime.Now.ToString("ddd dd.MM.yyyy HH:mm:ss")}\n");

        var tvShows = Directory.GetDirectories(Path);
        foreach (var show in tvShows) {
            var showName = System.IO.Path.GetFileName(show);
            var seasons = Directory.GetDirectories(show);
            var padding = 50;

            var dummyTest = "English Full\tGerman Full\tGerman Forced";

            if(seasons.Length == 0) {
                Console.Write($"\n═══ {showName.PadRight(padding)}{dummyTest}");
                // AnalyzeWithoutSeasonFolders
            } else {
                string lastItem = seasons[seasons.Length - 1];
                Console.Write($"\n══╗ {showName.PadRight(padding)}{dummyTest}");

                foreach(var season in seasons) {
                    // Analyzing ...

                    // Console Output
                    string seasonName = System.IO.Path.GetFileName(season);
                    string seasonNameShort = Regex.Match(seasonName,@"S[0-9]{2}|Specials").ToString();
                    if(season != lastItem) {
                        Console.Write($"\n  ╠═ {seasonNameShort.PadRight(padding-1)}{dummyTest}");
                    } else {
                        Console.Write($"\n  ╚═ {seasonNameShort.PadRight(padding-1)}{dummyTest}");
                    }
                    
                }
            }
        }







        //string mkvFilePath = @"E:\TV SHOWS\Utopia\Utopia - S01\Utopia.S01E01.1080p.BluRay-iNTENTiON.mkv";

        //mkvmerge mkvMerge = new();
        //List<mkvmerge.SubtitleTrack> subtitleTracks = mkvMerge.GetSubtitleTracks(mkvFilePath);

        //foreach(mkvmerge.SubtitleTrack track in subtitleTracks) {
        //Console.WriteLine($"Subtitle: {track.Langauge} ({track.TrackName})");
        //}
    }
}
