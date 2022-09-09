using System;

public class Empleado{
    private string nombre;
    private long dni;
    private DateTime fechaNacimiento;
    private DateTime fechaIngreso;
    private string direccion;
    private double sueldoBasico;
    private double salario;


    public string Nombre { get => nombre; set => nombre = value; }
    public long Dni {get;set;}
    public DateTime FechaNacimiento{get;set;}
    public DateTime FechaIngreso{get;set;}
    public string Direccion {get;set;}
    public double SueldoBasico { get => sueldoBasico; set => sueldoBasico = value; }
    public double Salario { get => salario; set => salario = value; }

    public Empleado(){
        Random random = new Random();
        //Inicializo a mano para no perder tiempo
        Nombre = "Ana";
        Dni = 25000000;
        FechaNacimiento = new DateTime(1974, 1, 1); 
        FechaIngreso = new DateTime(2009,3,26);
        Direccion = "Mate de Luna 1000";
        SueldoBasico = random.Next(20000,100000);
        Salario = calcularSalario(); 
    }

    private DateTime fechaActual = DateTime.Today;
    public int calcularEdad(){
        int edad = 0;
        edad = fechaActual.Year - FechaNacimiento.Year;
        if(FechaNacimiento.Month > fechaActual.Month){
            edad = edad-1;
        }
        return edad;
    }
    
    public int calcularAntiguedad(){
        int antiguedad = 0;
        antiguedad = fechaActual.Year - FechaIngreso.Year;
        if(FechaIngreso.Month > fechaActual.Month){
            antiguedad = antiguedad-1;
        }
        return antiguedad;
    }
    public double calcularSalario(){
        return SueldoBasico + calcularAdicional() - calcularDescuento();
    }
    private double calcularDescuento(){
        return 0.15 * SueldoBasico;
    }
    private double calcularAdicional(){
        if(calcularAntiguedad()<20){
            return 0.01 * SueldoBasico * calcularAntiguedad();
        }else{
            return 0.25 * SueldoBasico;
        }
    }

    public void mostrarUnEmpleado(Empleado emp){
        Console.WriteLine("\n--------DATOS DEL EMPLEADO--------");
        Console.WriteLine($"Nombre: {emp.Nombre}");
        Console.WriteLine($"DNI: {emp.Dni}");
        Console.WriteLine($"Fecha de nacimiento: {emp.FechaNacimiento.ToShortDateString()}");
        Console.WriteLine($"Edad: {emp.calcularEdad()}");
        Console.WriteLine($"Direccion: {emp.Direccion}");
        Console.WriteLine($"Fecha de ingreso a la empresa: {emp.FechaIngreso.ToShortDateString()}");
        Console.WriteLine($"Antiguedad: {emp.calcularAntiguedad()}");
        Console.WriteLine($"Sueldo Basico: {emp.SueldoBasico}");
        Console.WriteLine($"Descuento: {emp.calcularDescuento()}");
        Console.WriteLine($"Adicional: {emp.calcularAdicional()}");
        Console.WriteLine($"Salario: {emp.Salario}");
    }
}