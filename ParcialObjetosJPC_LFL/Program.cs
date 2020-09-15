using System;
using System.Collections;
using System.Collections.Generic;
using PARCIALOBJETOSJPC_LFL.Salon;
using PARCIALOBJETOSJPC_LFL.Usuario;
using PARCIALOBJETOSJPC_LFL.Validador;


namespace ParcialObjetosJPC_LFL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola Usuario. La leyenda (key) del horario es: \n"+
                            "0. SALON DISPONIBLE EN DICHA HORA\n"+
                            "1. SALON RESERVADO A ESA HORA\n"+
                            "2. SALON EN MANTENIMIENTO Y SIN RESERVA A ESA HORA\n"+
                            "3. SALON EN MANTENIMIENTO Y CON RESERVA A ESA HORA\n\n"+
                            "Para acceder como administrador, ingresar 'user1' como nombre y 'pass1' como contraseña.\n"+
                            "Para acceder como estudiante, ingresar 'user2' como nombre y 'pass2' como contraseña\n\n");

            ValidarUser objValidar = new ValidarUser();
            Salon objSalon = new Salon();                                                           //Instancias de clases
            userClass objUsuario = new userClass();

            int horaSistema = 7;        //HORA GLOBAL
            bool estadoAdmin = objValidar.Login();                                                  //Para verificar si el usuario es admin o estudiante

            Console.WriteLine("Bienvenido al sistema de salones");

            List<List<int>> horariosSalones = objSalon.inicializarSalones();                                 //Crea la matriz de [salones] [hora]

            List<Salon> estadoSalones = objSalon.inicializarEstados();                                          //Crea la lista de objetos (salones)


            int choice = 0;


            string opcMenu;
            

            while(choice != -1){

                if(estadoAdmin == true){    
                    objValidar.MenuAdmin();                     //ADMIN MENU
                    Console.WriteLine("Digite la opcion: ");
                    opcMenu = Console.ReadLine();
                    choice = Convert.ToInt32(opcMenu);

                    switch(choice){
                        case 1:                                                             //1. Reservar Salon
                            horariosSalones = objUsuario.ReservarSalon(horariosSalones);
                            Console.WriteLine();
                            break;
                        
                        case 2:                                                             //Consultar Disponibilidad Salon
                            objUsuario.ConsultarSalon(horariosSalones);
                            Console.WriteLine();
                            break;

                        case 3:                                                             //Ver estado salon (aire, abierto?, luz). En la hora que fija el admin
                            objSalon.EstadoSalon(horariosSalones, estadoSalones, horaSistema);
                            Console.WriteLine();
                            break;

                        case 4:                                                             //Modificar temperatura salon (propositos de la modelacion)
                            estadoSalones = objSalon.modificarTemp(estadoSalones);
                            break;

                        case 5:                                                             //Modificar hora (para ver estado (case 3))
                            horaSistema = objUsuario.modificarHora();
                            Console.WriteLine("La nueva hora es: " + horaSistema);
                            break;

                        case 6:                                                             //Poner salon en mantenimiento
                            horariosSalones = objUsuario.ponerEnMantenimiento(horariosSalones);
                            Console.WriteLine();
                            break;

                        case 7:                                                             //Finalizar mantenimiento
                            horariosSalones = objUsuario.finalizarMantenimiento(horariosSalones);
                            Console.WriteLine();
                            break;

                        default:
                            Console.WriteLine();
                            break;
                    }
                }else{
                    objValidar.MenuGeneral();
                    Console.WriteLine("Digite la opcion: ");
                    opcMenu = Console.ReadLine();
                    choice = Convert.ToInt32(opcMenu);

                    switch(choice){
                        case 1:                                                             //1. Reservar Salon
                            horariosSalones = objUsuario.ReservarSalon(horariosSalones);
                            Console.WriteLine();
                            break;
                        
                        case 2:                                                             //Consultar Disponibilidad Salon
                            objUsuario.ConsultarSalon(horariosSalones);
                            break;

                        case 3:                                                             //Ver estado salon (aire, abierto?, luz). En la hora que fija el admin
                            objSalon.EstadoSalon(horariosSalones, estadoSalones, horaSistema);
                            Console.WriteLine();
                            break;

                        default:
                            Console.WriteLine();
                            break;
                }


            

            }
            
        }
    }
}
}
