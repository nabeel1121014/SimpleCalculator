open System
open System.Text.RegularExpressions


let getNumbersFromEquation(equation: String)=
    (*Get the numbers from the equation
      Example //;\n1,2;3,4  will return 1,2;3,4  
     *)
    let index = System.Text.RegularExpressions.Regex.Match(equation,"\d").Index
    equation.[index..]
let splitNumbers(equation: String, delimiters: String[]) : String[]=
    (* Split the number based on specified delimiters and return array*)
    equation.Split(delimiters,StringSplitOptions.RemoveEmptyEntries)
    
let summation(numbers: String[])=
    (* Calculate the summations of all numbers *)
    let mutable  result = 0 
    for number in numbers do
        result <- result + Int32.Parse(number)
    result
    
let ParseDelimitersFromEquationLine(equation: String): String[]=
     (* Get the Custom delimiters specified in the equation
     Example //;\n  ";" will be returned *)
     [|equation.[2..2]|]
    
let getDelimiters(equation: String)=
    (*Combine the default delimiters ',' and '\n' with the custom  *)
    let defaultDelimiters : String [] = [|",";"\\n"|]
    let mutable customDelimiters: String[] = [||]
    if equation.Chars(0) = '/' then
        customDelimiters <- ParseDelimitersFromEquationLine(equation)
    Array.concat [ customDelimiters ; defaultDelimiters ]
    
let processEquation(equation: String ) :int =
    (* Convert List of String numbers to integers and get summation *)
    
    let delimiters = getDelimiters(equation)
    let equationNumbers = getNumbersFromEquation(equation)
    let parsedNumbers = splitNumbers(equationNumbers, delimiters)
    let result = summation(parsedNumbers)
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
    let mutable equation  = Console.ReadLine()
    let sumResult= calculateResults(equation)
    printfn "summation  is %d" sumResult
    Console.ReadKey() |> ignore 
    0 // return an integer exit code

   
 