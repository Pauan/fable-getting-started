namespace Test

open Fable.Core.Testing

[<TestFixture>]
module Foo =
    [<Test>]
    let foo () =
        equal "Hello world!" App.Message.message
