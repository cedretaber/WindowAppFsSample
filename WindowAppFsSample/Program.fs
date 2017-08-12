open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

open FsXaml

type MainWindow = XAML<"MainWindow.xaml">

let force_int_of_string : string -> int =
  fun str -> match Int32.TryParse str with _, n -> n
 
[<STAThread>]
[<EntryPoint>]
let main argv =
  let mainWindow = MainWindow () in

  let f = fun _ ->
    let x = force_int_of_string mainWindow.numberX.Text in
    let y = force_int_of_string mainWindow.numberY.Text in
    mainWindow.numberZ.Text <- (x + y).ToString ()
  
  mainWindow.numberX.TextChanged |> Event.add f
  mainWindow.numberY.TextChanged |> Event.add f

  (new Application()).Run mainWindow