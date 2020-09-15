using System;
using System.Collections.Generic;
using PARCIALOBJETOSJPC_LFL.Salon;

namespace PARCIALOBJETOSJPC_LFL.Usuario
{

    public class userClass
{
    public string name {get; set; }
    public string pass {get; set; }
    public bool EsAdmin {get; set; }

    /*public userClass(string name, string pass, bool EsAdmin){
        this.name = name;
        this.pass = pass;
        this.EsAdmin = EsAdmin;
    }*/
        #region Methods


        public List<List<int>> ReservarSalon(List<List<int>> horariosSalones){                          //✔️
            string salonDeseado, horaDeseada;
            int room = -1, time = -1;


            while(room>19 || room<0){
                Console.WriteLine("Salon a reservar (1-20): ");
                salonDeseado = Console.ReadLine();  
                room = Convert.ToInt32(salonDeseado) - 1;
            }

            while(time>11 || time<0){
                Console.WriteLine("Hora de reserva (Hora militar de 7 a 19): ");
                horaDeseada = Console.ReadLine();  
                time = Convert.ToInt32(horaDeseada) - 7;
            }
            

            if(horariosSalones[room][time] == 0){
                Console.WriteLine("Salon disponible. Creando reserva...");
                horariosSalones[room][time] = 1;
            }else if(horariosSalones[room][time] == 1){
                Console.WriteLine("Salon ya reservado en ese horario.");
            }else{
                Console.WriteLine("El salon se encuentra en mantenimiento. Favor contactar a un administrador.");
            }

            //---------------------------//
            Console.Write("Hora:\t\t");
            for(int s=0; s<12; s++){
                Console.Write(s+7+":00" + "\t");
            }Console.WriteLine();
            for(int i=0; i<20; i++){                                                                //imprimir horario
                Console.Write("Salon  "+ (i+1) + "\t");
                for(int j=0; j<12; j++){
                        Console.Write(horariosSalones[i][j] + "\t");
                }
                Console.WriteLine();
            }
            //---------------------------//

            return horariosSalones;
        }

        public void ConsultarSalon(List<List<int>> horariosSalones){                                //✔️
            string salonDeseado;
            int room = -1;
            
            while(room>19 || room<0){
                Console.WriteLine("Salon a consultar (1-20): ");
                salonDeseado = Console.ReadLine();  
                room = Convert.ToInt32(salonDeseado) - 1;
            }

            Console.Write("Salon  " + (room+1) + ("\t"));
            for(int i=0; i<12;i++){
                Console.Write(horariosSalones[room][i] + "\t");
            }
            
        }


        public int modificarHora(){
            string horaSelec;
            int hora = 0;
            while(hora>18 || hora<7){
                Console.WriteLine("Que hora desea que sea (7-18): ");
                horaSelec = Console.ReadLine();
                hora = Convert.ToInt32(horaSelec);
            }            
            return hora;
        }

        public List<List<int>> ponerEnMantenimiento(List<List<int>> horariosSalones){
            string salonMant;
            int salon = -1;
            while(salon>19 || salon<0){
                Console.WriteLine("Salon a poner en mantenimiento (1-20): ");
                salonMant = Console.ReadLine();  
                salon = Convert.ToInt32(salonMant) - 1;
            }

            if(horariosSalones[salon][0] < 2 ){
                Console.WriteLine("Poniendo en mantenimiento...");
                for(int i=0; i<12; i++){
                    horariosSalones[salon][i] += 2;
                }
            }else{
                Console.WriteLine("Salon ya esta en mantenimiento");
            }
            Console.Write("Hora:\t\t");
            for(int s=0; s<12; s++){
                Console.Write(s+7+":00" + "\t");
            }Console.WriteLine();
            for(int i=0; i<20; i++){
                Console.Write("Salon  "+ (i+1) + "\t");
                for(int j=0; j<12; j++){
                    Console.Write(horariosSalones[i][j] + "\t");
                }Console.WriteLine();
            }
            
            return horariosSalones;
        }

        public List<List<int>> finalizarMantenimiento(List<List<int>> horariosSalones){
            string salonMant;
            int salon = -1;
            while(salon>19 || salon<0){
                Console.WriteLine("Salon a finalizar mantenimiento (1-20): ");
                salonMant = Console.ReadLine();  
                salon = Convert.ToInt32(salonMant) - 1;
            }

            if(horariosSalones[salon][0] >= 2 ){
                Console.WriteLine("Habilitando salon...");
                for(int i=0; i<12; i++){
                    horariosSalones[salon][i] -= 2;
                }
            }else{
                Console.WriteLine("Salon no se encuentra en mantenimiento");
            }
            Console.Write("Hora:\t\t");
            for(int s=0; s<12; s++){
                Console.Write(s+7+":00" + "\t");
            }Console.WriteLine();
            for(int i=0; i<20; i++){
                Console.Write("Salon  "+ (i+1) + "\t");
                for(int j=0; j<12; j++){
                    Console.Write(horariosSalones[i][j] + "\t");
                }Console.WriteLine();
            }
            
            return horariosSalones;
        }

     
        #endregion Methods
    }
}
