using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.Text.Classification;
using Moq;

namespace HyperComments.Tests
{
    [TestClass]
    public class AudioPlayerTaggerTest 
    {
        [TestInitialize]
        public void Setup()
        {
            classifier = new Mock<IClassifier>().Object;
            tagger = new AudioPlayerTagger(classifier);            
        }

        private AudioPlayerTagger tagger;
        private IClassifier classifier;
    }
}
