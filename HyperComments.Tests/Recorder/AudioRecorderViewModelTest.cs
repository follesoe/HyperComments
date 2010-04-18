using System.Collections.Generic;
using HyperComments.Recorder;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HyperComments.Tests.Recorder
{
    [TestClass]
    public class AudioRecorderViewModelTest
    {
        [TestMethod]
        public void Has_default_value_for_duration()
        {
            Assert.AreEqual("00:00:00", viewModel.DurationText);
        }

        [TestMethod]
        public void Fires_change_notification_for_duration()
        {
            viewModel.DurationText = "00:00:01";
            Assert.AreEqual("DurationText", notifications.Dequeue());
        }

        [TestInitialize]
        public void Setup()
        {
            notifications = new Queue<string>();
            viewModel = new AudioRecorderViewModel();
            viewModel.PropertyChanged += (o, e) => notifications.Enqueue(e.PropertyName);

            fileSystem = new Mock<IAccessFiles>();
            audioRecorder = new Mock<IRecordAudio>();
        }

        private Queue<string> notifications;
        private AudioRecorderViewModel viewModel;
        private Mock<IAccessFiles> fileSystem;
        private Mock<IRecordAudio> audioRecorder;
    }
}