using System;

public class Empleado{
    private string nombre;
    private long dni;
    private DateTime fechaNacimiento;
    private DateTime fechaIngreso;
    private string direccion;
    private double sueldoBasico;
    private double salario;

    //otra informacion
    private bool esCasado;
    private int cantHijos;
    private bool esDivorciado;
    private DateTime fechaDivorcio;
    private bool tieneTituloUniversitario;
    private string titulo;
    private string universidad;



    public string Nombre { get => nombre; set => nombre = value; }
    public long Dni {get;set;}
    public DateTime FechaNacimiento{get;set;}
    public DateTime FechaIngreso{get;set;}
    public string Direccion {get;set;}
    public double SueldoBasico { get => sueldoBasico; set => sueldoBasico = value; }
    public double Salario { get => salario; set => salario = value; }
    public bool EsCasado { get => esCasado; set => esCasado = value; }
    public int CantHijos { get => cantHijos; set => cantHijos = value; }
    public bool EsDivorciado { get => esDivorciado; set => esDivorciado = value; }
    public bool TieneTituloUniversitario { get => tieneTituloUniversitario; set => tieneTituloUniversitario = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public DateTime FechaDivorcio { get => fechaDivorcio; set => fechaDivorcio = value; }
    public string Universidad { get => universidad; set => universidad = value; }

    public Empleado(){
        Random random = new Random();
        //Inicializo a mano para no perder tiempo
        Nombre = "Nombre empleado";
        Dni = 10000000;
        FechaNacimiento = RandomDay(); 
        FechaIngreso = RandomDay(FechaNacimiento.Year + 16); // para que por lo menos tengan 16 años cuando empiecen a trabajar jejj
        Direccion = "Direccion empleado";
        SueldoBasico = random.Next(20000,100000);
        Salario = calcularSalario(); 
        EsCasado = false;
        CantHijos = 0;
        EsDivorciado = false;
        FechaDivorcio = new DateTime(1900,1,1);
        TieneTituloUniversitario = true;
        Titulo = "Titulo";
        Universidad = "Universidad";
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
        Console.WriteLine($"Edad: {emp.calcularEdad()}");
        Console.WriteLine($"Antiguedad: {emp.calcularAntiguedad()}");
        Console.WriteLine($"Salario: {emp.Salario}");
    }

    public bool get_esCasado(){
        return esCasado;
    }

    public int get_cantHijos(){
        return cantHijos;
    }

    public bool get_esDivorciado(){
       return esDivorciado;
    }

    public DateTime get_fechaDivorcio(){
        return fechaDivorcio;
    }

    public bool get_tieneTituloUniversitario(){
        return tieneTituloUniversitario;
    }

    public string get_titulo(){
        return titulo;
    }
    public string get_universidad(){
        return Universidad;
    }

    public DateTime RandomDay(int anio_inicio = 1930) {
        DateTime start = new DateTime(anio_inicio, 1, 1); 
        Random gen = new Random(); 
        try{
            int range = (DateTime.Today - start).Days; 
            return start.AddDays(gen.Next(range)); 
        }catch(System.Exception ex){
            var msj = "Error message: " + ex.Message;
            Console.WriteLine(msj);
            return new DateTime(1,1,1);
        }
        
    }
    
}