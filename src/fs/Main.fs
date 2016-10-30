module Main

open Fable.Import
open Message

let main () =
    Browser.console.log (message + Test.Message.message)

do
    main ()
