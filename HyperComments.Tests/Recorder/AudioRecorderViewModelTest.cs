using System.Collections.Generic;
using HyperComments.Recorder;

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

        [TestMethod]
        public void Fires_event_when_recording_is_complete()
        {
            string filename = null;
            viewModel.RecordingComplete += (o, e) => filename = e.Filename;

            viewModel.RecordingCommand.Execute(null); // Start recording
            viewModel.RecordingCommand.Execute(null); // Stop recording

            Assert.IsNotNull(filename, "Should fire event when recording is complete.");
        }

        [TestMethod]
        public void Expose_command_to_start_and_stop_recording()
        {
            Assert.IsNotNull(viewModel.RecordingCommand);
            Assert.IsInstanceOfType(viewModel.RecordingCommand, typeof(RecordingCommand));
        }

        [TestInitialize]
        public void Setup()
        {
            notifications = new Queue<string>();
            viewModel = new AudioRecorderViewModel();
            viewModel.PropertyChanged += (o, e) => notifications.Enqueue(e.PropertyName);
        }

        private Queue<string> notifications;
        private AudioRecorderViewModel viewModel;
    }
}