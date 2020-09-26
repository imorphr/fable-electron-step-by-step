module App

open Fable.Core.JsInterop
open Electron
open Node

let createWindow () = 
    let options = jsOptions<BrowserWindowOptions>(fun x -> 
        x.width <- 800
        x.height <- 600
        x.webPreferences <- jsOptions<WebPreferences>(fun wp -> 
            wp.nodeIntegration <- true
        )
    )
    
    let win = main.BrowserWindow.Create(options)

    let indexFile = path.join(__dirname, "index.html")
    win.loadFile(indexFile) |> ignore

    win.webContents.openDevTools()


main.app.onReady(fun _ _ -> createWindow()) |> ignore

main.app.onWindowAllClosed(fun _ -> 
    if  process.platform <> Base.Platform.Darwin
    then
        main.app.quit () 
) |> ignore

main.app.onActivate(fun _ _ -> 
    if  main.BrowserWindow.getAllWindows().Length = 0
    then
        createWindow ()
) |> ignore