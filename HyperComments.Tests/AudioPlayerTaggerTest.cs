using System.Linq;
using HyperComments.Player;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HyperComments.Tests
{
    [TestClass]
    public class AudioPlayerTaggerTest : TaggerTest<AudioPlayerTaggerTest, AudioPlayerTag>
    {
        [TestMethod]
        public void Creates_tag_if_audio_file_comment_is_found()
        {
            Given.we_have_one_span_matching_audio_comment();
            When.we_get_the_tags();

            Assert.AreEqual(1, tags.Count());            
        }

        [TestMethod]
        public void Tag_should_contain_audio_filename()
        {
            Given.we_have_one_span_matching_audio_comment();
            When.we_get_the_tags();

            Assert.AreEqual(@"c:\comment.mp3", tags.First().Tag.Filename);
        }

        [TestInitialize]
        public void Setup()
        {         
            tagger = new AudioPlayerTagger(classifier.Object);
        }

        private void we_have_one_span_matching_audio_comment()
        {
            create_spans(@"// {audio: c:\comment.mp3}");
        }
    }
}
