HyperComments - Multimedia annotations for Visual Studio 2010
=============================================================

HyperComments is an extension to Visual Studio 2010 that enables you to add multimedia annotations to your source code. The current build only supports audio files. You can record new audio comments directly from the code editor in Visual Studio 2010. The extension will scan your source file for special comments.

The *"// {recorder}"*-comment will insert a simple audio recorder that will record your default microphone to a mp3 file stored in a "Audio Comment" folder relative to your solution file. Once you stop the recording the extension will replace the *"// {recorder}"*-comment with a new comment; *"// {audio c:\path_to\audio_file.mp3"*. This comment will insert a audio player in your editor that can play back the audio file. 

To build the solution you need to [download and install the Visual Studio 2010 SDK][1].

**Future plans for the extension:**

  - Support for streaming audio from online sources such as podcasts.
  - Enable to specify start position using a syntax similar to: {audio: c:\file.mp3?start=00:25:00}. This would enable linking to a section within a podcast discussing something relevant.
  - Add support for video and image files.
  - UI to right click and say "record comment", as well as code snippet to insert the *"//{recorder}"-comment*.

** Screenshot of player and recorder inside the Visual Studio editor: **
![Screenshot of player and recorder][2]

  [1]: http://www.microsoft.com/downloads/details.aspx?FamilyID=47305cf4-2bea-43c0-91cd-1b853602dcc5&displaylang=en
  [2]: http://follesoe.github.com/HyperComments/Images/AudioRecordingScreenshot.PNG