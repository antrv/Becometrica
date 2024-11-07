namespace Becometrica.FileFormats.Bluray;

public enum SubPathType
{
    PrimaryAudioPresentation = 0x02, // Primary audio presentation path of the Browsable slideshow
    InteractiveGraphicsPresentationMenu = 0x03, // Interactive Graphics presentation menu
    TextSubtitlePresentation = 0x04, // Text subtitle presentation path
    OutOfMuxSynchronousPath = 0x05, // Out-of-mux and Synchronous type of one or more elementary streams path
    OutOfMuxAsynchronousPath = 0x06, // Out-of-mux and Asynchronous type of PIP presentation path
    InMuxSynchronousPath = 0x07, // In-mux and Synchronous type of PIP presentation path
    StereoscopicVideo = 0x08, // Stereoscopic video
    StereoscopicIgMenu = 0x09, // Stereoscopic IG Menu
    DolbyVisionEnhancementLayer = 0x0A, // Dolby Vision Enhancement Layer
}