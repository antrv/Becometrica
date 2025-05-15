using Becometrica.FileFormats.Bluray;

namespace Becometrica.FileFormats.Tests;

public class BlurayIndexTest
{
    [Fact]
    public void ReadFromFile()
    {
        BlurayPlaylist playlist = new();
        playlist.ReadFrom("00001.mpls");

        TimeSpan inTime = playlist.Items[0].InTime;
        TimeSpan outTime = playlist.Items[0].OutTime;
    }
}