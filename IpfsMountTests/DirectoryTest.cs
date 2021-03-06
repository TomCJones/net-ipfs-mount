﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ipfs.VirtualDisk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipfs.VirtualDisk.Tests
{
    [TestClass]
    public class DirectoryTest
    {

        [TestMethod]
        public void Exists()
        {
            Assert.IsTrue(Directory.Exists("t:/ipfs/QmRCJXG7HSmprrYwDrK1GctXHgbV7EYpVcJPQPwevoQuqF"));
        }

        [TestMethod]
        public void Directory_Info()
        {
            var info = new DirectoryInfo("t:/ipfs/QmRCJXG7HSmprrYwDrK1GctXHgbV7EYpVcJPQPwevoQuqF");

            Assert.IsTrue(info.Exists);
            Assert.AreEqual(2, info.GetFileSystemInfos("*.*").Length);
        }

        [TestMethod]
        public void All_Files_and_Directories()
        {
            var names = Directory.GetFileSystemEntries(@"t:\ipfs\QmRCJXG7HSmprrYwDrK1GctXHgbV7EYpVcJPQPwevoQuqF", "*.*", SearchOption.AllDirectories);
            Assert.AreEqual(7, names.Count());
            CollectionAssert.Contains(names, @"t:\ipfs\QmRCJXG7HSmprrYwDrK1GctXHgbV7EYpVcJPQPwevoQuqF\cat.jpg");
            CollectionAssert.Contains(names, @"t:\ipfs\QmRCJXG7HSmprrYwDrK1GctXHgbV7EYpVcJPQPwevoQuqF\test\baz\f");
        }

    }
}