module Main

#r "../node_modules/fable-core/Fable.Core.dll"

#load "Foo.fsx"
#load "Message.fsx"

open Fable.Import
open Message

let main () =
    Browser.console.log message

do
    main ()
