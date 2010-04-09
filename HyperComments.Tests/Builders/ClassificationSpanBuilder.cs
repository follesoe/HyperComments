using System.Linq;
using System.Collections.Generic;

using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

using Moq;

namespace HyperComments.Tests.Builders
{
    public class ClassificationSpanBuilder
    {        
        public static IEnumerable<ClassificationSpan> FromStrings(params string[] lines)
        {
            return lines.Select(CreateSpan);
        }

        private static ClassificationSpan CreateSpan(string text)
        {
            var snapshot = new Mock<ITextSnapshot>();
            snapshot.Setup(s => s.Length).Returns(text.Length);
            snapshot.Setup(s => s.LineCount).Returns(1);
            snapshot.Setup(s => s.GetText(It.IsAny<Span>())).Returns(text);

            var snapshotSpan = new SnapshotSpan(snapshot.Object, 0, 5);
            return new ClassificationSpan(snapshotSpan, new Mock<IClassificationType>().Object);
        }
    }
}
