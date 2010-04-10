using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HyperComments.Player;
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
        public void Fires_change_notification_for_both_message_and_filename()
        {
            viewModel.Filename = "comment.mp3";
            Assert.AreEqual("Filename", properties.Dequeue());
            Assert.AreEqual("Message", properties.Dequeue());
        }

        [TestInitialize]
        public void Setup()
        {
            viewModel = new AudioPlayerViewModel();
            viewModel.PropertyChanged += (o, e) => properties.Enqueue(e.PropertyName);
            properties = new Queue<string>();
        }

        private AudioPlayerViewModel viewModel;
        private Queue<string> properties;
    }
}
