using System.Collections.Generic;

public class TvShow {
    public string Name { get; set; }
    public List<Season> Seasons { get; set; } = new List<Season>();
}

public class Season {
    public int SeasonNumber { get; set; }
    public List<Episode> Episodes { get; set; } = new List<Episode>();
}

public class Episode {
    public string FileName { get; set; }
    public List<SubtitleTrack> SubtitleTracks { get; set; } = new List<SubtitleTrack>();
}

public class SubtitleTrack {
    public int TrackNumber { get; set; }
    public string Language { get; set; }
}
