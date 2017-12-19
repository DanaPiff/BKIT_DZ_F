
open System

///Тип решения квадратного уравнения
type SquareRootResult = 
    | NoRoots
    | OneRoot of double
    | TwoRoots of double * double //кортеж из двух double 

///Функция вычисления корней уравнения
let CalculateRoots(a:double, b:double, c:double):SquareRootResult = 
    let D = b*b - 4.0*a*c;
    if D < 0.0 then NoRoots
    else if D = 0.0 then 
        let rt = -b / (2.0 * a)
        OneRoot rt       
    else 
        let sqrtD = Math.Sqrt(D)
        let rt1 = (-b + sqrtD) / (2.0 * a);
        let rt2 = (-b - sqrtD) / (2.0 * a);
        TwoRoots (rt1,rt2)

///Вывод корней (тип unit - аналог void)
let PrintRoots(a:double, b:double, c:double):unit = 
    printf "Коэффициенты: a=%A, b=%A, c=%A. " a  b  c
    let root = CalculateRoots(a,b,c)
    //Оператор сопоставления с образцом
    let textResult = 
        match root with 
        | NoRoots -> "Корней нет"  
        | OneRoot(rt) -> "Один корень " + rt.ToString()
        | TwoRoots(rt1,rt2) -> "Два корня " + rt1.ToString() + " и " + rt2.ToString()
    printfn "%s" textResult

let rec ReadInDouble()=
    match System.Double.TryParse (System.Console.ReadLine()) with
    |false, _-> printf "Повторите ввод "; ReadInDouble ()
    |_,x -> x


[<EntryPoint>]
let main argv = 
    
    Console.WriteLine ("Введите значения коэффициентов \na= ");
    let  a = ReadInDouble ();
    Console.WriteLine ("\nb= ");
    let  b = ReadInDouble ();
    Console.WriteLine ("\nc= ");
    let  c = ReadInDouble ();

    PrintRoots(a,b,c)

    //|> ignore - перенаправление потока с игнорирование результата вычисления
    Console.ReadLine() |> ignore
    0 // возвращение целочисленного кода выхода
