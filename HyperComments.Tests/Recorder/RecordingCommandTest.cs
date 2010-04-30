using System;
using HyperComments.Recorder;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HyperComments.Tests.Recorder
{
    [TestClass]
    public class RecordingCommandTest
    {
        [TestMethod]
        public void Command_is_allways_executable()
        {
            Assert.IsTrue(command.CanExecute(null), "Should allways be able to execute the command.");
        }

        [TestMethod]
        public void Default_recorder_is_mp3()
        {
            command = new RecordingCommand(RecordingCompletedCallback);
            Assert.IsInstanceOfType(command.AudioRecorder, typeof(Mp3AudioRecorder));
        }

        [TestMethod]
        public void Starts_recording_when_comand_is_executed()
        {
            audioRecorder.Setup(a => a.Start(It.IsAny<string>())).AtMostOnce().Verifiable("Did not start recording.");
            command.AudioRecorder = audioRecorder.Object;

            command.Execute(null);
        }

        [TestMethod]
        public void Stops_recording_is_currently_recording()
        {
            audioRecorder.Setup(a => a.Start(It.IsAny<string>())).AtMostOnce().Verifiable("Did not start recording.");
            audioRecorder.Setup(a => a.Stop(It.IsAny<Action<string>>())).AtMostOnce().Verifiable("Did not stop recording.");
            command.AudioRecorder = audioRecorder.Object;

            command.Execute(null);
            command.Execute(null);

            audioRecorder.VerifyAll();
        }

        [TestMethod]
        public void Generates_filename_for_recording()
        {
            SystemTime.Now = () => new DateTime(2010, 4, 15, 9, 35, 0);

            string username = command.GetCurrentUser();
            string expectedFilename = @"c:\150410-093500-MyFile-" + username + ".mp3";

            audioRecorder = new Mock<IRecordAudio>();
            audioRecorder.Setup(a => a.Start(It.Is<string>(filename => filename == expectedFilename)))
                         .AtMostOnce().Verifiable("Did not start recording with expected filename.");
            command.AudioRecorder = audioRecorder.Object;

            command.Execute(null);

            audioRecorder.VerifyAll();
        }       

        [TestInitialize]
        public void Setup()
        {
            audioRecorder = new Mock<IRecordAudio>();
            audioRecorder.Setup(a => a.Start(It.IsAny<string>()));
            audioRecorder.Setup(a => a.Stop(It.IsAny<Action<string>>()));

            command = new RecordingCommand(RecordingCompletedCallback);
            command.RecordingDirectory = @"c:\";
            command.ActiveDocument = "MyFile.cs";
            command.AudioRecorder = audioRecorder.Object;
        }

        private void RecordingCompletedCallback(string filename)
        {
            recordedFilename = filename;
        }

        private string recordedFilename;
        private RecordingCommand command;
        private Mock<IRecordAudio> audioRecorder;
    }
}
