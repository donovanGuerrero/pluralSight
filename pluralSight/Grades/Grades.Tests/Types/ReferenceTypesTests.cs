﻿
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Tests.Types
{
  [TestClass]
  public class TypesTests
  {

    [TestMethod]
    public void ValueTypesPassByValue()
    {
      int x = 46;
      IncrementNumber(x);

      Assert.AreEqual(46, x);
    }

    private void IncrementNumber(int num)
    {
      num += 1;
    }

    [TestMethod]
    public void ReferenceTypesPassByValue()
    {
      var x = 4.25;
      GradeBook book1 = new GradeBook();
      GradeBook book2 = book1;

      GiveBookAName(book2);
      Assert.AreEqual("A GradeBook", book1.Name);
    }

    private void GiveBookAName(GradeBook book)
    {
      book.Name = "A GradeBook";
    }

    [TestMethod]
    public void StringComparisons()
    {
      string name1 = "Scott";
      string name2 = "scott";

      bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);

      Assert.IsTrue(result);

    }

    [TestMethod]
    public void IntVariablesHoldAValue()
    {
      int x1 = 100;
      int x2 = x1;

      x1 = 4;
      Assert.AreNotEqual(x1, x2);
    }

    [TestMethod]
    public void GradeBookVariablesHoldAReference()
    {
      GradeBook g1 = new GradeBook();
      GradeBook g2 = g1;

      g1.Name = "Scott's grade book";
      Assert.AreEqual(g1.Name, g2.Name);
    }
  }
}
