namespace Test

[<AutoOpen>]
module Util =
    open Fable.Core.Testing

    // Convenience method
    let equal (expected: 'T) (actual: 'T) =
        // TODO is this correct ?
        Assert.AreEqual(true, (expected = actual))
