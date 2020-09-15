using System;
using System.Collections.Generic;

namespace PARCIALOBJETOSJPC_LFL.Salon
{
    public class Salon
    {
        #region Properties
                
        public bool AirePrendido { get; set; }
        public bool LuzPrendida{ get; set; }
        public bool EnMantenimiento{ get; set; }
        public bool Abierto{ get; set; }
        public int Temperatura{ get; set; }

        #endregion Properties


        #region Methods

        public List<List<int>> inicializarSalones(){                                                    //✔️
            List<List<int>> horariosSalones = new List<List<int>>();
            

            for(int i=0; i<20; i++){
                List<int> sublist = new List<int>();
                for(int j=0; j<12; j++){
                    sublist.Add(0);
                }horariosSalones.Add(sublist);
            }


                
            Console.Write("Hora:\t\t");
            for(int s=0; s<12; s++){
                Console.Write(s+7+":00" + "\t");
            }
            Console.WriteLine();
            for(int i=0; i<20; i++){
                Console.Write("Salon  "+ (i+1) + "\t");
                for(int j=0; j<12; j++){
                    Console.Write(horariosSalones[i][j] + "\t");
                }Console.WriteLine();
            }

            return horariosSalones;
        }

        public void EstadoSalon(List<List<int>> horariosSalones, List<Salon> estadoSalones, int horaSistema){       //✔️
            string salonDeseado;
            int salon = -1;
            horaSistema -= 7;
            while(salon>19 || salon<0){
                Console.WriteLine("Salon a revisar estados (1-20): ");
                salonDeseado = Console.ReadLine();  
                salon = Convert.ToInt32(salonDeseado) - 1;
            }
            if(horariosSalones[salon][horaSistema] == 0){
                
                estadoSalones[salon].AirePrendido = false;
                estadoSalones[salon].LuzPrendida = false;
                estadoSalones[salon].EnMantenimiento = false;
                if(horariosSalones[salon][horaSistema+1] == 1){
                    estadoSalones[salon].Abierto = true;        //previo a una clase --> Puerta abierta (no hay intervalos menores a 1hr)
                }else{
                    estadoSalones[salon].Abierto = false;
                }


                Console.WriteLine("Salon " + salon + ":\n"+
                                "Aire Prendido: " + estadoSalones[salon].AirePrendido + "\n"+
                                "Luz Prendida: " + estadoSalones[salon].LuzPrendida + "\n"+
                                "En Mantenimiento: " + estadoSalones[salon].EnMantenimiento + "\n"+
                                "Abierto: " + estadoSalones[salon].Abierto + "\n"+
                                "Temperatura: " + estadoSalones[salon].Temperatura + "°C\n");
                

            }else if(horariosSalones[salon][horaSistema] == 1){
                
                estadoSalones[salon].AirePrendido = true;
                estadoSalones[salon].LuzPrendida = true;
                estadoSalones[salon].EnMantenimiento = false;
                estadoSalones[salon].Abierto = false;                                            //durante clase --> Puerta cerrada
                estadoSalones[salon].Temperatura = 23;

                Console.WriteLine("Salon " + salon + ":\n"+
                                "Aire Prendido: " + estadoSalones[salon].AirePrendido + "\n"+
                                "Luz Prendida: " + estadoSalones[salon].LuzPrendida + "\n"+
                                "En Mantenimiento: " + estadoSalones[salon].EnMantenimiento + "\n"+
                                "Abierto: " + estadoSalones[salon].Abierto + "\n"+
                                "Temperatura: " + estadoSalones[salon].Temperatura + "°C\n");
                

            }else{
                
                estadoSalones[salon].AirePrendido = false;
                estadoSalones[salon].LuzPrendida = false;
                estadoSalones[salon].EnMantenimiento = true;
                estadoSalones[salon].Abierto = false;                               //Puerta cerrada durante mantenimiento

                Console.WriteLine("Salon " + salon + ":\n"+
                                "Aire Prendido: " + estadoSalones[salon].AirePrendido + "\n"+
                                "Luz Prendida: " + estadoSalones[salon].LuzPrendida + "\n"+
                                "En Mantenimiento: " + estadoSalones[salon].EnMantenimiento + "\n"+
                                "Abierto: " + estadoSalones[salon].Abierto + "\n"+
                                "Temperatura: " + estadoSalones[salon].Temperatura + "°C\n");
                
            }
        }




        public List<Salon> inicializarEstados(){                                                                    //✔️
            List<Salon> estadoSalones = new List<Salon>();
            for(int i=0; i<20; i++){
                Salon myObj1 = new Salon();

                myObj1.AirePrendido = false;
                myObj1.LuzPrendida = false;
                myObj1.EnMantenimiento = false;
                myObj1.Abierto = false;
                myObj1.Temperatura = 21;

                estadoSalones.Add(myObj1);
            }

            return estadoSalones;                                                   //Regresa array 1D de salones

        }


        public List<Salon> modificarTemp(List<Salon> estadoSalones){                                                //✔️
            string salonDeseado, tempDeseada;
            int room = -1, temp;

            while(room>19 || room<0){
                Console.WriteLine("Salon a cambiar temperatura (1-20): ");
                salonDeseado = Console.ReadLine();  
                room = Convert.ToInt32(salonDeseado) - 1;
            }

            Console.WriteLine("Nueva temperatura: ");
            tempDeseada = Console.ReadLine();  
            temp = Convert.ToInt32(tempDeseada);


            estadoSalones[room].Temperatura = temp;

            Console.WriteLine("Temperatura Asignada");

            Console.WriteLine("Nueva temperatura del salon " + room + ": " + estadoSalones[room].Temperatura);

            return estadoSalones;
        }



        #endregion Methods
    }
}





            