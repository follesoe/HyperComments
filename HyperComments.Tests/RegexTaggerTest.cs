using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HyperComments.Tests.Builders;
using HyperComments.Tests.Stubs;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HyperComments.Tests
{
    [TestClass]
    public class RegexTaggerTest : TaggerTest<RegexTaggerTest, TestTag>
    {
        [TestMethod]
        public void Creates_no_tags_if_no_spans_to_check()
        {
            When.we_get_the_tags();
            
            Assert.AreEqual(0, tags.Count());
        }

        [TestMethod]
        public void Creates_tag_if_matching_text_is_found()
        {
            Given.we_have_one_span_matching_search_expression();            
            When.we_get_the_tags();

            Assert.AreEqual(1, tags.Count());
        }

        [TestMethod]
        public void Creates_one_tag_for_each_match()
        {
            Given.we_have_two_spans_matching_search_expression();
            When.we_get_the_tags();

            Assert.AreEqual(2, tags.Count());
        }

        [TestMethod]
        public void Returns_same_instance_of_tag_if_allready_created()
        {
            Given.we_have_one_span_matching_search_expression();

            var tag1 = tagger.GetTags(spans).First();
            var tag2 = tagger.GetTags(spans).First();

            Assert.AreSame(tag1, tag2, "The tagger should reuse the tag instance if allready created.");
        }

        [TestMethod]
        public void The_span_the_tag_is_associated_with_should_have_correct_size()
        {
            Given.we_have_one_span_matching_search_expression();
            When.we_get_the_tags();

            var tag = tags.First();
            
            Assert.AreEqual(10, tag.Span.Start, "The span should start at position the text is matched.");
            Assert.AreEqual(4, tag.Span.Length, "The length of the span should be the length of matched text.");
        }

        [TestInitialize]
        public void Setup()
        {                    
            tagger = new TestTagger(classifier.Object, Regex);
        }

        private const string Regex = "test";

        private void we_have_one_span_matching_search_expression()
        {
            create_spans("this is a test");            
        }

        private void we_have_two_spans_matching_search_expression()
        {
            create_spans("this is a test", "this is also a test");
        }
    }
}
