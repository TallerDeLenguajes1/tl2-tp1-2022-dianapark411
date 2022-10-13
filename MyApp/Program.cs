// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Text.Json;
using System;

System.Console.WriteLine("Ingrese la cantidad de empleados que desea ingresar: ");
int n = Convert.ToInt32(Console.ReadLine());

List<Empleado> list_empleados = new List<Empleado>();

for (int i = 0; i < n; i++)
{
    System.Console.WriteLine($"Ingrese la direccion del empleado {i+1}: ");
    string direccion = Console.ReadLine();

    list_empleados.Insert(i, new Empleado(){ Direccion = direccion} );

}


for (int i = 0; i < n; i++)
{
    list_empleados[i].mostrarUnEmpleado(list_empleados[i]);
    list_empleados[i].mostrarInfoAdicional(list_empleados[i]);
    
}

