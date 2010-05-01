using HyperComments.Player;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HyperComments.Tests.Player
{
    [TestClass]
    public class AudioPlayerTagTest : BDD<AudioPlayerTagTest>
    {
        [TestMethod]
        public void The_audio_player_tag_should_display_the_audio_player_control()
        {
            Assert.IsInstanceOfType(tag.Adornment, typeof(AudioPlayer));
        }

        [TestMethod]
        public void Sets_the_path_of_the_audio_file_on_the_player()
        {
            Assert.AreEqual("comment.mp3", tag.PlayerView.ViewModel.Filename);
        }

        [TestInitialize]
        public void Setup()
        {
            tag = new AudioPlayerTag("comment.mp3");
        }

        private AudioPlayerTag tag;
    }
}
