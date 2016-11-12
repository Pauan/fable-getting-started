namespace Test

open Fable.Core.Testing

[<TestFixture>]
module Message =
    [<Test>]
    let ``message should be correct`` () =
        App.Message.message |> equal "Hello world!"
