using System.Linq;
using HyperComments.Recorder;
using HyperComments.Tests.Builders;
using HyperComments.Tests.Stubs;
using Microsoft.VisualStudio.Text;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HyperComments.Tests.Recorder
{
    [TestClass]
    public class AudioRecorderTagTest
    {
        [TestMethod]
        public void Expose_the_audio_recorder_adornment()
        {
            Assert.IsNotNull(tag.RecorderView);
        }

        [TestMethod]
        public void Sets_the_recording_directory_when_tag_is_created()
        {
            Assert.AreEqual(recordingDirectory, tag.RecorderView.ViewModel.RecordingDirectory);
        }

        [TestMethod]
        public void Sets_the_active_document_when_tag_is_created()
        {
            Assert.AreEqual(activeDocument, tag.RecorderView.ViewModel.ActiveDocument);
        }

        [TestMethod]
        public void Replaces_recorder_template_with_filename_when_recording_complete()
        {
            textBuffer = new Mock<ITextBuffer>(MockBehavior.Strict);
            textBuffer.Setup(t => t.Replace(It.IsAny<Span>(), It.IsRegex("// {audio: (.*)}")))
                      .Returns(new Mock<ITextSnapshot>().Object).AtMostOnce()
                      .Verifiable("Expects the tag to replace {recorder} with {audio: ...}");

            tag = new RecorderTag(recordingDirectory, activeDocument);
            tag.RecorderView.ViewModel.RecordingCommand.AudioRecorder = new AudioRecorderStub();

            tag.RecorderView.ViewModel.RecordingCommand.Execute(null);
            tag.RecorderView.ViewModel.RecordingCommand.Execute(null);

            textBuffer.Verify();
        }

        [TestInitialize]
        public void Setup()
        {
            textBuffer = new Mock<ITextBuffer>();
            span = ClassificationSpanBuilder.FromStrings("// {recorder}").First().Span;

            activeDocument = "myfile.cs";
            recordingDirectory = @"c:\recordings";
            tag = new RecorderTag(recordingDirectory, activeDocument);            
        }

        private string recordingDirectory;
        private string activeDocument;        
        private RecorderTag tag;
        private Mock<ITextBuffer> textBuffer;
        private SnapshotSpan span;
    }
}
