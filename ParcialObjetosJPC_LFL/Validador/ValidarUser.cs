using System;
using System.Collections.Generic;
using PARCIALOBJETOSJPC_LFL.Usuario;


namespace PARCIALOBJETOSJPC_LFL.Validador
{

    
    public class ValidarUser
    {


        #region Methods

        
        
        public bool Login(){

            List<userClass> users = new List<userClass>();
            
            userClass myObj1 = new userClass();
            myObj1.name = "user1";
            myObj1.pass = "pass1";
            myObj1.EsAdmin = true;

            users.Add(myObj1);

            myObj1 = new userClass();
            myObj1.name = "Jeff";
            myObj1.pass = "Stonks";
            myObj1.EsAdmin = true;

            users.Add(myObj1);                                                              //Usuarios pre-definidos

            myObj1 = new userClass();
            myObj1.name = "user2";
            myObj1.pass = "pass2";
            myObj1.EsAdmin = false;

            users.Add(myObj1);

            myObj1 = new userClass();
            myObj1.name = "Gustavo";
            myObj1.pass = "LaVenganzaDeSalazar";
            myObj1.EsAdmin = false;

            users.Add(myObj1);

            /*for(int i=0; i<users.Count; i++){
                Console.WriteLine(users[i].name + "\n" + users[i].pass + "\n" + users[i].EsAdmin +"\n");                //Display de usuarios y contraseñas
            }*/

            

            bool javeriano = false;
            string inpName;
            string inpPass;
            bool admin = false;

            while(javeriano == false){

            Console.WriteLine("Digite su usuario: ");
            inpName = Console.ReadLine();

            Console.WriteLine("Contraseña: ");
            inpPass = Console.ReadLine();

                for(int i=0; i<users.Count; i++){
                
                    if(String.Compare(users[i].name, inpName) == 0 && String.Compare(users[i].pass, inpPass) == 0){

                        if(users[i].EsAdmin == true){
                            if(admin == true){}
                            admin = true;
                            javeriano = true;
                            Console.WriteLine("Usuario admin verificado. Bienvenido Sr. " + users[i].name);
                            break;
                        }else{
                            Console.WriteLine("Usuario de estudiante verificado. Ingresando...");
                            javeriano = true;
                            break;
                        }

                    }
                }if(javeriano == true){break;}
                Console.WriteLine("Que asco, un estudiante de icesi. Coga seriedad\n");
            }
            return admin;
        }

        public void MenuGeneral(){
            Console.WriteLine("Que desea hacer?\n"+
                                "1. Reservar salon\n"+
                                "2. Consultar salon\n"+
                                "3. Ver estado salon\n");

        }

        public void MenuAdmin(){
            Console.WriteLine("Que desea hacer?\n"+
                                "1. Reservar salon\n"+
                                "2. Consultar salon\n"+
                                "3. Ver estado salon\n"+
                                "Funciones ADMIN:\n"+
                                "4. Modificar temperatura salon\n"+
                                "5. Modificar hora sistema\n"+
                                "6. Poner en mantenimiento\n"+
                                "7. Finalizar mantenimiento\n");

        }

        #endregion Methods
    }
}
