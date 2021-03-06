﻿using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HyperComments.Player;

namespace HyperComments.Tests.Player
{
    [TestClass]
    public class AudioPlayerTaggerProviderTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Throws_exception_if_buffer_is_null()
        {
            provider.CreateTagger<PlayerTag>(null);
        }

        [TestInitialize]
        public void Setup()
        {
            var aggregatorService = new Mock<IClassifierAggregatorService>();
            aggregatorService.Setup(a => a.GetClassifier(It.IsAny<ITextBuffer>()))
                             .Returns(new Mock<IClassifier>().Object);

            AggregatorService = aggregatorService.Object;

            provider = new PlayerTaggerProvider();                                 

            var batch = new CompositionBatch();
            batch.AddPart(this);
            batch.AddPart(provider);

            var catalog = new AggregateCatalog();
            var container = new CompositionContainer(catalog);
            container.Compose(batch);
        }

        [Export]
        public IClassifierAggregatorService AggregatorService;

        private PlayerTaggerProvider provider;
    }
}
