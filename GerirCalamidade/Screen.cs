/*
*	<copyright file="GerirCalamage.cs" company="IPCA">
*		Copyright (c) 2021 All Rights Reserved
*	</copyright>
* 	<author>Joel Jonasssi</author>
*   <date>5/19/2021 11:08:08 PM</date>
*	<description></description>
**/
using System;
using System.Collections;
using System.Collections.Generic;
using BussinessObjectDLL;
using BussinessRulesDLL;
using ExcepcoesDLL;


namespace ManageHealthCrisis
{
    /// <summary>
    /// Purpose:
    /// Created by: Joel Jonasssi
    /// Created on: 5/19/2021 11:08:08 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Screen
    {
       
        /// <summary>
        /// Mostrar Dados dos Patients
        /// </summary>
        public static void ShowALL(IList aux)
        {
            
            foreach (Patient p in aux)
            {
                Console.Write($"NamePatient:{p.NamePatient} \nAge:{p.Age} \nGenero:{p.GenderPatient}\n");
                Console.WriteLine($"Estado:{p.StateInHospital} \nIdFiscal:{p.TaxNumber} \nSNS:{p.Sns}\n");
            }
        }

        /// <summary>
        /// Mostrar Dados dos Patients
        /// </summary>
        public static void ShowALLF(IList aux)
        {

            foreach (Worker worker in aux)
            {
                Console.Write($"Name do Medico:{worker.NameWorker} \nNr Cedula:{worker.License} \nGenero:{worker.GenderWorker}\n");
                Console.WriteLine($"Salary:{worker.Salary} \n");
            }
        }
        /// <summary>
        /// Mostrar Informações do Worker
        /// </summary>
        /// <param name="name">Insert o name do Patient</param>
        public void ShowInfo(string name)
        {
            foreach (Worker worker in Rules.AllWorkers())
            {
                Console.WriteLine($"Name: {worker.NameWorker}\nSlario: {worker.Salary}\nGenero: {worker.GenderWorker}\nCargo: {worker.WorkerType}");
            }
        }

        /// <summary>
        /// Consultar ficha do paciente num determinado hospital
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static void ShowPatient(double Idfiscal)
        {
            foreach (Patient a in Rules.AllPatients())
            {
                if (Rules.Equals(a.TaxNumber, Idfiscal))
                {
                    Console.WriteLine($"Name: {a.NamePatient}\nAge: {a.Age}\nTelphone: {a.Contact}\nSNS: {a.Sns}\nId Fiscal{a.TaxNumber}");
                    return;
                }
               
            }
          
                Console.WriteLine("Inexistente");
         
        }


    }
}