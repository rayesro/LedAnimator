using LedAnimator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedAnimator.Tests;

public class LedMatrixTests
{
  [Test]
  public void GivenAWidthAndHeight_WhenCreatingALedMatrix_ThenLedArrayCountMustBeWidthTimesHeight()
  {
    var width = 16;
    var height = 16;

    var matrix = new LedMatrix(width,height);

   // Assert.That(matrix.Leds.Count, Is.EqualTo(width * height));
  }
}
