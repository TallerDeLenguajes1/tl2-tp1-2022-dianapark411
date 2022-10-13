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
        Nombre = CrearNombre();
        Dni = random.Next(1000000,60000000);
        FechaNacimiento = RandomDay(); 
        FechaIngreso = RandomDay(FechaNacimiento.Year + 16, fechaActual.Year); // para que por lo menos tengan 16 años cuando empiecen a trabajar jejj
        Direccion = "Direccion empleado";
        SueldoBasico = random.Next(20000,100000);
        Salario = calcularSalario(); 
        EsCasado = Convert.ToBoolean(random.Next(0,2));
        CantHijos = random.Next(0,5);
        if(esCasado == false){
            esDivorciado = false;
            FechaDivorcio = new DateTime(9999,9,9); //seria como un indefinido
        }else{
            EsDivorciado = Convert.ToBoolean(random.Next(0,2));
            FechaDivorcio = RandomDay(FechaNacimiento.Year + 20, fechaActual.Year); // para que no se case y divorcie antes de los 20
        }
        
        TieneTituloUniversitario = Convert.ToBoolean(random.Next(0,2));
        if(tieneTituloUniversitario == true){
            Titulo = "Titulo";
            Universidad = "UNT";
        }else{
            Titulo = "No tiene titulo";
            Universidad = "-";
        }
        
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
    public string CrearNombre(){ 
        Random r = new Random();
        string[] nombres = { "Lucia ", "Jose ", "Maria ", "Pedro ", "Martina ", "Lucas ", "Romina"};
        string[] apellidos = { "Gomez", "Perez", "Fernandez", "Juarez", "Martinez"};
        
        string name = "";
        
        name = nombres[r.Next(0, nombres.Length - 1)];
        name += apellidos[r.Next(0, apellidos.Length - 1)];

        return name;
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

    public void mostrarInfoAdicional(Empleado emp){
        Console.WriteLine("\n--------MAS INFORMACION--------");
        Console.WriteLine($"Es casado: {emp.esCasado}");
        Console.WriteLine($"Cantidad de hijos: {emp.cantHijos}");
        Console.WriteLine($"Es divorciado: {emp.esDivorciado}");
        if(esDivorciado == true){
            Console.WriteLine($"Fecha divorcio: {emp.fechaDivorcio}");
        }
        Console.WriteLine($"Tiene titulo universitario: {emp.tieneTituloUniversitario}");
        if(tieneTituloUniversitario == true){
            Console.WriteLine($"Titulo: {emp.titulo}");
            Console.WriteLine($"Universidad: {emp.universidad}");
        }
    }


    public DateTime RandomDay(int anio_inicio = 1930, int anio_fin = 2005) {
        DateTime start = new DateTime(anio_inicio, 1, 1); 
        DateTime end = new DateTime(anio_fin, 1, 1); 
        Random gen = new Random(); 
        try{
            int range = (end - start).Days; 
            return start.AddDays(gen.Next(range)); 
        }catch(Exception ex){
            Console.WriteLine("Error message: " + ex.Message);
            Console.WriteLine("Fecha actual por defecto");
            return DateTime.Today;
        }
    }
    
}