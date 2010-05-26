using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

using HyperComments.Recorder;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HyperComments.Tests.Recorder
{
    [TestClass]
    public class AudioRecorderTaggerProviderTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Throws_exception_if_buffer_is_null()
        {
            provider.CreateTagger<RecorderTag>(null);
        }

        [TestMethod]
        public void Creates_the_AudioRecorderTagger()
        {
            var buffer = new Mock<ITextBuffer>().Object;
            var tagger = provider.CreateTagger<RecorderTag>(buffer);

            Assert.IsNotNull(tagger);
            Assert.IsInstanceOfType(tagger, typeof(RcorderTagger));
        }

        [TestInitialize]
        public void Setup()
        {
            var aggregatorService = new Mock<IClassifierAggregatorService>();
            aggregatorService.Setup(a => a.GetClassifier(It.IsAny<ITextBuffer>()))
                             .Returns(new Mock<IClassifier>().Object);

            AggregatorService = aggregatorService.Object;
            ServiceProvider = new Mock<SVsServiceProvider>().Object;

            provider = new RecorderTaggerProvider();

            var batch = new CompositionBatch();
            batch.AddPart(this);
            batch.AddPart(provider);

            var catalog = new AggregateCatalog();
            var container = new CompositionContainer(catalog);
            container.Compose(batch);
        }

        [Export]
        public IClassifierAggregatorService AggregatorService;

        [Export]
        public SVsServiceProvider ServiceProvider;

        private RecorderTaggerProvider provider;
    }
}
