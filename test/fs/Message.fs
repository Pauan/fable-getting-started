namespace Test

open Fable.Core.Testing

[<TestFixture>]
module Message =
    [<Test>]
    let ``message``() =
        equal "Hello world!" Message.message
