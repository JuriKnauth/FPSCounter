using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using BeamXR.FPSConuter;

public class FramesPerSecondCounterTest
{
    [UnityTest]
    public IEnumerator FramePerSecondCounterTestWithEnumeratorPasses()
    {
        Assert.Pass();

        yield return null;
    }
}
