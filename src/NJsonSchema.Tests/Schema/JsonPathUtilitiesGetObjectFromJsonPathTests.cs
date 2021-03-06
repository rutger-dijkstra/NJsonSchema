﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NJsonSchema.Tests.Schema
{
    [TestClass]
    public class JsonPathUtilitiesGetObjectFromJsonPathTests
    {
        [TestMethod]
        public void When_object_is_in_property_then_path_should_be_built_correctly()
        {
            //// Arrange
            var objectToSearch = new JsonSchema4();
            var obj = new
            {
                Property = new
                {
                    Property1 = new { },
                    Property2 = objectToSearch
                }
            };

            //// Act
            var foundObject = JsonPathUtilities.GetObjectFromJsonPath(obj, "#/Property/Property2");

            //// Assert
            Assert.AreEqual(foundObject, objectToSearch);
        }

        [TestMethod]
        public void When_object_is_in_list_then_path_should_be_built_correctly()
        {
            //// Arrange
            var objectToSearch = new JsonSchema4();
            var obj = new
            {
                Property = new
                {
                    List = new List<object>
                    {
                        new { },
                        new { },
                        objectToSearch
                    }
                }
            };

            //// Act
            var foundObject = JsonPathUtilities.GetObjectFromJsonPath(obj, "#/Property/List/2");

            //// Assert
            Assert.AreEqual(foundObject, objectToSearch);
        }

        [TestMethod]
        public void When_object_is_in_dictionary_then_path_should_be_built_correctly()
        {
            //// Arrange
            var objectToSearch = new JsonSchema4();
            var obj = new
            {
                Property = new
                {
                    List = new Dictionary<string, object>
                    {
                        { "Test1", new { } },
                        { "Test2", new { } },
                        { "Test3", objectToSearch },
                    }
                }
            };

            //// Act
            var foundObject = JsonPathUtilities.GetObjectFromJsonPath(obj, "#/Property/List/Test3");

            //// Assert
            Assert.AreEqual(foundObject, objectToSearch);
        }

        [TestMethod]
        public void When_object_is_root_then_path_should_be_built_correctly()
        {
            //// Arrange
            var objectToSearch = new JsonSchema4();
            
            //// Act
            var foundObject = JsonPathUtilities.GetObjectFromJsonPath(objectToSearch, "#");

            //// Assert
            Assert.AreEqual(foundObject, objectToSearch);
        }
    }
}