namespace Test

open Fable.Core.Testing

[<TestFixture>]
module Message =
    [<Test>]
    let ``message is correct``() =
        equal "Hello world!" MyProject.Message.message
