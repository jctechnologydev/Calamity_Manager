/*
*	<copyright file="DadosDLL.cs" company="IPCA">
*		Copyright (c) 2021 All Rights Reserved
*	</copyright>
* 	<author>Joel Jonasssi</author>
*   <date>5/19/2021 11:03:27 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using BussinessObjectDLL;
using BussinessRulesDLL;
using ExcepcoesDLL;

/// <summary>
/// Purpose: DLL - Trabalho LP2
/// Created by: Joel Jonassi & Idelvina Fernando
/// Created on: 4/18/2021 1:06:59 AM
/// </summary>
/// <remarks></remarks>
/// <example></example>
namespace ManageHealthCrisis
{
    /// <summary>
    /// Purpose: Trabalho LP2
    /// Created by: Joel Jonassi & Idelvina Fernando
    /// Created on: 4/16/2021 1:20:02 AM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    class Program
    {

        static void Main(string[] args)
        {    
            #region Instancias e declaração de Váriaveis
            string name, telphone, sns, taxNumber;
            int age, cod;
            Sexo gender;
            StatePatient state;
            TypeWorker func;
            Symptom symptom1, symptom2, symptom3, symptom4;
            #endregion
 
            try
            {

                Worker worker = new Worker();

                worker = Rules.CreateFichaWorker("Idelvina", 1234, TypeWorker.Doctor, Sexo.Female, 20000);
                
                Console.WriteLine(Worker.IsWorker(f,1233));
                Worker.ShowWorkerDetails(worker);


                

                //inserir na lista
                Rules.InsertWorker(worker);
                Rules.CreateListSchedule(worker.NameWorker);

                
                Patient patient = Rules.CreateFichaPatient("Joel Jonassi", 21, "1/1/0001 12:00:00 AM", Sexo.Male, StatePatient.stable, 936159188, 1234567, 287060357, Symptom.symptom1, Symptom.symptom2, Symptom.noSymptom, Symptom.symptom4);
                Rules.InsertPacient(patient);
                Patient patient2 = Rules.CreateFichaPatient("Idelvina Fernando", 21, "1/1/0001 12:00:00 AM", Sexo.Female, StatePatient.stable, 936159188, 123456, 2801, Symptom.symptom1, Symptom.symptom2, Symptom.noSymptom, Symptom.symptom4);
                Rules.InsertPacient(patient2);

                //Pesquisa de pacientes por idade
                var all = Rules.PatientsSearchLINQ(21);
                //Rules.Recover();


                Screen.ShowALL(Rules.AllPatients());
                Screen.ShowALLF(Rules.AllWorkers());

                Console.WriteLine("Insira Idfiscal:");
                Screen.ShowPatient(2801);

                Rules.Save(@"Patient.bin");

                List<Patient> listPatient = new List<Patient>();
                listPatient = Rules.Load(@"Patient.bin", listPatient);
            }
            catch(MyException f)
            {
                throw new MyException(f.Message);
            }
            finally
            {
                Console.WriteLine("Excellent!!!");
            }
            Console.ReadLine();
        }
    }
}






