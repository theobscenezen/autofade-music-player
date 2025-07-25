# Windows Forms Music Player with Crossfade Playback 🎵

A lightweight C# Windows Forms application to play MP3 files from a selected directory. Supports essential playback controls, volume adjustment, and a special **"Next Autofade"** feature that seamlessly crossfades between two tracks.

## ✨ Features

- 🎧 Play, Pause, Previous, Next, Autofade Previous, Autofade Next
- 📁 Load music files from a folder
- 🎚️ Adjustable volume
- 🎼 Playlist view with track selection
- 🔄 **Crossfade support**: Smoothly transition between songs with overlapping fade-in/out
- 💡 Built using [NAudio](https://github.com/naudio/NAudio)

## 🖼️ UI Overview

- `ListBox`: Displays playlist with track names
- Playback Buttons: `Play`, `Pause`, `Previous`, `Next`, `Next Autofade`
- `TrackBar`: Controls master volume

## 🚀 Getting Started

### Requirements

- .NET Framework or .NET Core/6.0+
- Visual Studio (Windows Forms project template)
- MP3 files to test with

### Setup

1. Clone the repository:
```bash
git clone https://github.com/yourusername/winforms-mp3-crossfade.git
cd winforms-mp3-crossfade
```

2. Open the solution in Visual Studio.
3. Install dependencies via NuGet:
```bash 
dotnet restore
```

4. Build and run the app.

🔊 Crossfade Logic

The Next Autofade button overlaps the end of the current song with the start of the next song by:

- Fading out the current track
- Simultaneously fading in the next track
- Ensuring a seamless, DJ-style transition

This is done using two simultaneous WaveOutEvent instances provided by NAudio.

🛠️ Future Enhancements

📄 License

MIT License. See LICENSE file for details.

Made with ❤️ using C# and NAudio