using System.Linq;
using HyperComments.Recorder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HyperComments.Tests
{
    [TestClass]
    public class AudioRecorderTaggerTest : TaggerTest<AudioRecorderTaggerTest, AudioRecorderTag>
    {
        [TestMethod]
        public void Creates_tag_if_audio_file_comment_is_found()
        {
            Given.we_have_one_span_matching_audio_comment();
            When.we_get_the_tags();

            Assert.AreEqual(1, tags.Count());
            Assert.IsNotNull(tags.First().Tag);
        }

        [TestInitialize]
        public void Setup()
        {
            tagger = new AudioRecorderTagger(classifier.Object);
        }

        private void we_have_one_span_matching_audio_comment()
        {
            create_spans(@"// {recorder}");
        }        
    }
}
