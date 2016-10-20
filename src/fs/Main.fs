module Main

open Fable.Import
open Message

open System

type MyObserver<'T>(f) =
    interface IObserver<'T> with
        member x.OnNext v = f v
        member x.OnError e = ()
        member x.OnCompleted() = ()

type MyObservable<'T>() =
    let listeners = ResizeArray<IObserver<'T>>()
    member x.Trigger v =
        for lis in listeners do
            lis.OnNext v
    interface IObservable<'T> with
        member x.Subscribe w =
            listeners.Add(w)
            { new IDisposable with
                member x.Dispose() = listeners.Remove(w) |> ignore }

let main () =
    let source = MyObservable()
    Observable.add (fun x -> Browser.console.log x) source
    source.Trigger 5
    source.Trigger 10

do
    main ()
