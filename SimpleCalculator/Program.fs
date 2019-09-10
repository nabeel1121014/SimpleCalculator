open System


let split_numbers(equation: String) : String[]=
    (* Split the number based on , delimiter *)
    equation.Split(',')
    
let summation(number1: int , number2: int) :int = number1 + number2   

let process_equation(equation: String ) :int =
    (* Convert List of String numbers to integers and get summation *)
    let numbers = split_numbers(equation)
    let mutable  result = 0 
    for number in numbers do
        result <- summation(result,Int32.Parse(number))
    result    
            
let calculate_results(equation: String)=
     (* Check if the equation is empty return 0 if not process the equation
     equation : string that contain the equation to calculate
     return sum: int fot the summation results 
     *)
     match equation.Length with
    | 0  ->  0  // return 0 if the equation is empty 
    | _ -> process_equation(equation)

[<EntryPoint>]
let main argv =
    let equation  = Console.ReadLine()
    let sumResult= calculate_results(equation)
    printfn "summation  is %d" sumResult
    Console.ReadKey() |> ignore 
    0 // return an integer exit code

   
 