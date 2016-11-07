namespace Test

open Fable.Core.Testing

[<TestFixture>]
module Message =
    [<Test>]
    let foo () =
        equal "Hello world!" App.Message.message
