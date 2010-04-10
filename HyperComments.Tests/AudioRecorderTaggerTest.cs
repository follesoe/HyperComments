using System.Linq;
using HyperComments.Recorder;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.VisualStudio.Text;

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
            textBuffer = new Mock<ITextBuffer>();
            serviceProvider = new Mock<SVsServiceProvider>();
            tagger = new AudioRecorderTagger(serviceProvider.Object, textBuffer.Object, classifier.Object);
        }

        private void we_have_one_span_matching_audio_comment()
        {
            create_spans(@"// {recorder}");
        }

        private Mock<ITextBuffer> textBuffer;
        private Mock<SVsServiceProvider> serviceProvider;
    }
}
