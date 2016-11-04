module Test.Message

open Fable.Core.Testing

[<TestFixture>]
module Message =
    [<Test>]
    let ``message is correct``() =
        equal "Hello world!" App.Message.message
