module Message

open Fable.Core

[<Import("message", "/js/Message.js")>]
let message: string = jsNative
