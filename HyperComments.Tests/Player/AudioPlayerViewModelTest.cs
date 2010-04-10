using System;
using System.Collections.Generic;
using System.Windows;
using HyperComments.Player;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HyperComments.Tests.Player
{
    [TestClass]
    public class AudioPlayerViewModelTest
    {
        [TestMethod]
        public void Has_default_display_message()
        {
            Assert.AreEqual("Filename not set...", viewModel.Message);
        }

        [TestMethod]
        public void Has_default_time_position()
        {
            Assert.AreEqual("00:00:00", viewModel.CurrentPosition);
        }

        [TestMethod]
        public void Displays_filename_if_set()
        {
            viewModel.Filename = "comment.mp3";
            Assert.AreEqual("comment.mp3", viewModel.Message);
        }

        [TestMethod]
        public void Displays_only_filename_and_not_directory()
        {
            viewModel.Filename = @"c:\comment.mp3";
            Assert.AreEqual("comment.mp3", viewModel.Message);            
        }

        [TestMethod]
        public void Displays_message_if_file_does_not_exist()
        {
            fileAccess = new Mock<IAccessFiles>();
            fileAccess.Setup(f => f.Exists(It.IsAny<string>())).Returns(false);
            viewModel.FileAccess = fileAccess.Object;

            viewModel.Filename = "comment.mp3";
            Assert.AreEqual("File comment.mp3 does not exist...", viewModel.Message);
        }

        [TestMethod]
        public void Fires_change_notification_for_both_message_and_filename()
        {
            viewModel.Filename = "comment.mp3";
            Assert.AreEqual("Filename", notifications.Dequeue());
            Assert.AreEqual("Message", notifications.Dequeue());
        }

        [TestMethod]
        public void Fires_change_notification_for_slider_max_value_when_duration_is_set()
        {
            viewModel.Duration = new Duration(new TimeSpan(0, 0, 0, 60));
            Assert.AreEqual("Duration", notifications.Dequeue());
            Assert.AreEqual("ScrubberMaxValue", notifications.Dequeue());
            Assert.AreEqual(60*1000, viewModel.ScrubberMaxValue);
        }
        
        [TestInitialize]
        public void Setup()
        {
            fileAccess = new Mock<IAccessFiles>();
            fileAccess.Setup(f => f.Exists(It.IsAny<string>())).Returns(true);

            viewModel = new AudioPlayerViewModel();
            viewModel.PropertyChanged += (o, e) => notifications.Enqueue(e.PropertyName);
            viewModel.FileAccess = fileAccess.Object;

            notifications = new Queue<string>();
        }

        private Mock<IAccessFiles> fileAccess;
        private AudioPlayerViewModel viewModel;
        private Queue<string> notifications;
    }
}
