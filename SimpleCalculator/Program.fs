open System
open System.Text.RegularExpressions


let splitNumbers(equation: String) : String[]=
    (* Split the number based on , and \n delimiter *)
    let mutable it : String [] = [|",";"\\n"|] 
    equation.Split(it,StringSplitOptions.RemoveEmptyEntries)
    
let summation(number1: int , number2: int) :int = number1 + number2   

let processEquation(equation: String ) :int =
    (* Convert List of String numbers to integers and get summation *)
    let numbers = splitNumbers(equation)
    let mutable  result = 0 
    for number in numbers do
        result <- summation(result,Int32.Parse(number))
    result    
            
let calculateResults(equation: String)=
     (* Check if the equation is empty return 0 if not process the equation
     equation : string that contain the equation to calculate
     return sum: int fot the summation results 
     *)
     match equation.Length with
    | 0  ->  0  // return 0 if the equation is empty 
    | _ -> processEquation(equation)

[<EntryPoint>]
let main argv =
    let equation  = Console.ReadLine()
    let sumResult= calculateResults(equation)
    printfn "summation  is %d" sumResult
    Console.ReadKey() |> ignore 
    0 // return an integer exit code

   
 