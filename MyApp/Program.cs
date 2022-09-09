// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Text.Json;

/*
Console.WriteLine("---PROBLEMA 1: CALCULAR CUADRADO---");
Console.WriteLine("Ingrese un numero: ");

try{
    int num = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"El cuadrado de {num} es: " + num*num);
}
catch(FormatException e){
    
    Console.WriteLine("Valor ingresado no valido");
}
*/

/*
Console.WriteLine("---PROBLEMA 2: DIVIDIR DOS NUMEROS---");
Console.WriteLine("Ingrese el primer numero: ");
int num1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ingrese el segundo numero: ");
int num2 = Convert.ToInt32(Console.ReadLine());

try{
    Console.WriteLine($"{num1}/{num2} =  " + num1/num2);
}
catch(Exception ex){
    var msj = "Error message: " + ex.Message;
    Console.WriteLine(msj);
}
*/

/*
Console.WriteLine("---PROBLEMA 3: CALCULAR km/lts---");
Console.WriteLine("Ingrese los km conducidos: ");
try{
    //porque km recorridos, lts usados no pueden ser negativos
    uint km = Convert.ToUInt32(Console.ReadLine());
    Console.WriteLine("Ingrese los lts usados: ");
    uint lts = Convert.ToUInt32(Console.ReadLine());
    double result =  lts/km;
    Console.WriteLine($"Los kms por lts son: " + result);
}
catch(Exception ex){
    var msj = "Error message: " + ex.Message;
    Console.WriteLine(msj);
}
*/

Console.WriteLine("---PROBLEMA 4:---");
//para guardar los datos de la api
Root provincias = new Root();
List<string> nombresProv = new List<string>();

provincias = ApiProvincias(provincias);

Console.WriteLine("Provincias argentinas y sus id: ");
foreach (var item in provincias.provincias)
{   
    nombresProv.Add(item.nombre);
    Console.WriteLine(item.nombre + " - " + item.id);
}

Root ApiProvincias(Root nombresProv){

    string url = $"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
    var request = (HttpWebRequest) WebRequest.Create(url);

    request.Method = "GET";
    request.Accept = "application/json";
    request.ContentType = "application/json";

    try
    {
        using (WebResponse respuesta = request.GetResponse())
        {
            using (Stream reader = respuesta.GetResponseStream())
            {
                if(reader != null){

                    using (StreamReader objectReader = new StreamReader(reader))
                    {
                        string body = objectReader.ReadToEnd();
                        nombresProv = JsonSerializer.Deserialize<Root>(body);
                    }
                }
            }
        }
    }
    catch (WebException excepcion)
    {
        Console.WriteLine("Error al conectar a la API!!!");
    }

    return nombresProv;
}
