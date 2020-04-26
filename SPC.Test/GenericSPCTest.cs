using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPC.Core;

namespace SPC.Test
{
    [TestClass]
    public class GenericSPCTest
    {
        [TestMethod]
        public void SetGenericSPC()
        {
            var spcA = new SpcA();
            var spcB = new SpcB();
            var spcA2 = new SpcA();

            Assert.AreEqual(spcA2, SPCContainer.GetSPC<SpcA>());
            Assert.AreEqual(spcB, SPCContainer.GetSPC<SpcB>());
        }
    }


    public class SpcA : SPCBase
    {
        
    }

    public class SpcB : SPCBase
    {
        
    }

}
