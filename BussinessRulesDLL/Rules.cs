/*
*	<copyright file="TrabalhoLP2_19681_19698_fase1.cs" company="IPCA">
*		Copyright (c) 2021 All Rights Reserved
*	</copyright>
* 	<author>joeljonassi&idelvinafernando</author>
*   <date>4/27/2021 1:06:59 AM</date>
*	<description></description>
**/
using BussinessObjectDLL;
using DadosDLL;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Purpose: Trabalho LP2
/// Created by: Joel Jonassi & Idelvina Fernando
/// Created on: 04/27/2021 23:41:59 PM
/// </summary>
/// <remarks></remarks>
/// <example></example>
namespace BussinessRulesDLL
{
    public class Rules
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <param name="f1"></param>
        /// <returns></returns>
        public static bool Equal(object f, object f1)
        {
            if (f == null) return false;
            if (f1 == null) return false;
            return f.Equals(f1);
        }
        /// <summary>
        /// Avaliar Patient,, Se tiver mais de três symptoms caso suspeito, encaminhar para exames.
        /// </summary>
        /// <param name="symptom1">Registar Symptom1</param>
        /// <param name="symptom2">Registar Symptom2</param>
        /// <param name="symptom3">Registar Symptom3</param>
        /// <param name="symptom4">Registar Symptom4</param>
        /// <returns></returns>
        internal static bool CheckCase(Symptom symptom1, Symptom symptom2, Symptom symptom3, Symptom symptom4)
        {
            Patient p = new Patient();
            //Se tiver mais de três symptoms Caso Suspeito, Contabiliza
            //Por construir
            Patient.TotSymptoms = 0;
            
            if (symptom1 != 0 )
            {
                Patient.TotSymptoms++;
            }
            if(symptom2 != 0)
            {
                Patient.TotSymptoms++;
            }
            if(symptom3 != 0)
            {
                Patient.TotSymptoms++;
            }
            if (symptom4 != 0)
            {
                Patient.TotSymptoms++;
            }
            
            if (Patient.TotSymptoms >= Constantes.NRMINSINTOMAS)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Create Ficha do Patient
        /// </summary>
        /// <param name="p"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="dataEntrada"></param>
        /// <param name="gender"></param>
        /// <param name="state"></param>
        /// <param name="telphone"></param>
        /// <param name="sns"></param>
        /// <param name="taxNumber"></param>
        /// <param name="symptom1"></param>
        /// <param name="symptom2"></param>
        /// <param name="symptom3"></param>
        /// <param name="symptom4"></param>
        /// <returns></returns>
        public static Patient CreateFichaPatient(string name, int age, string dataEntrada, Sexo gender, StatePatient state, double telphone, double sns, double taxNumber, Symptom symptom1, Symptom symptom2, Symptom symptom3, Symptom symptom4)
        {
            Patient p = new Patient(name, age, DateTime.Parse(dataEntrada), gender, state, telphone >= 910000000 && telphone <= 949999999 ? telphone : 0, sns >= 1 && sns <= 999999999 ? sns : 0, taxNumber >= 1 && taxNumber <= 9999999999 ? taxNumber : 0, symptom1, symptom2, symptom3, symptom4);
            return p;

        }

        /// <summary>
        /// Create ficha do funcionario
        /// </summary>
        /// <param name="f"></param>
        /// <param name="name"></param>
        /// <param name="codigo"></param>
        /// <param name="func"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static Worker CreateFichaWorker( string name, int codigo,  TypeWorker func, Sexo gender, double salary)
        {         
           Worker f = new Worker(name, codigo, func, gender, salary);     
            if(f != null)
            {
                return f;
            }
            return f;           
        }

        /// <summary>
        /// Insert Patient no grupo de infetados se caso psositivo
        /// </summary>
        /// <param name="pacient"></param>
        /// <param name="symptom1"></param>
        /// <param name="symptom2"></param>
        /// <param name="symptom3"></param>
        /// <param name="symptom4"></param>
        /// <returns></returns>
        public static bool ConfirmCase(Hospital hospital, string worker, Patient pacient, Symptom symptom1, Symptom symptom2, Symptom symptom3, Symptom symptom4)
        {
            bool aux = false;
            if (CheckCase(symptom1, symptom2, symptom3, symptom4))
            {
                aux = Schedule.InsertPatient(worker, pacient);
                return aux;
            }
            //Hospital.InsertP(p);
            Patient.TotPatient--;
            return aux;
        }

        /// <summary>
        /// Organizar Patients
        /// </summary>
        /// <param name="pacients"></param>
        /// <returns></returns>
        public static List<Patient> SortPatient(Patients pacients)
        {
            if (pacients != null)
            {
                List<Patient> aux = Patients.ListPatients;
                aux.Sort();
                return aux;
            }return null;
        }

        /// <summary>
        /// Compara Patients por age
        /// </summary>
        /// <param name="pacient"></param>
        /// <param name="pacient2"></param>
        /// <returns></returns>
        public static int Compare(Patient pacient, Patient pacient2)
        {
            if (pacient == null) return 0;
            if (pacient2 == null) return 0;
            return (string.Compare(pacient.NamePatient, pacient2.NamePatient));
        }

        /// <summary>
        ///  Avalia o state do paciente, se caso recuperado adiciona o paciente aos casos recuperados e retira-o a lista de infetados
        /// </summary>
        /// <param name="p"></param>
        /// <param name="symptom1"></param>
        /// <param name="symptom2"></param>
        /// <param name="symptom3"></param>
        /// <param name="symptom4"></param>
        /// <returns></returns>
        public static bool Recover(Patient p, string dataSaida, Symptom symptom1, Symptom symptom2, Symptom symptom3, Symptom symptom4)
        {
            Patients ps = new Patients();
            if (!CheckCase(symptom1, symptom2, symptom3, symptom4))
            {
                Patients.RemoveP(p, DateTime.Parse(dataSaida));
                Patient.TotRecover++;
                Patients.UpdateNrPatients();
                return true;
            }
            return false;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcionario"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool InsertPatientSchedule(string funcionario, Patient p)
        {
            bool aux = Schedule.InsertPatient(funcionario, p);
            return aux;
        }

        /// <summary>
        /// Insert Patient no hospital
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool InsertPacient(Patient p)
        {
            bool aux = Patients.Insert(p);
            return aux;
        }
        /// <summary>
        /// Cria a chave/Worker "Schedule"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CreateListSchedule(string name)
        {           
            bool aux = Schedule.CreateListaPatient(name);
            return aux;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static bool InsertWorker(Worker f)
        {
            bool aux = Workers.Insert(f);
            return aux;
        }
        /// <summary>
        /// Remover paciente da agenda e da lista de pacientes
        /// </summary>
        /// <param name="nameWorker"></param>
        /// <param name="namePatient"></param>
        /// <returns></returns>
        public static bool Morto(string nameWorker, string namePatient, string dataSaida)
        {           
            IList auxList = Patients.ListPatients;
            IList auxListII = Workers.ListWorkers;
            foreach (Worker f in Workers.ListWorkers) 
            {
                if (Workers.Equal(f.NameWorker, nameWorker))
                {


                    foreach (Patient p in auxList)
                    {
                        if (Patients.Equal(p.NamePatient, namePatient))
                        {
                            Schedule.RemovePatient(nameWorker, namePatient, dataSaida);
                            Patients.RemoveP(p, DateTime.Parse(dataSaida));
                        return true;
                        }
                    }
                }
            }
            return false;
        }

       /// <summary>
       /// Verificar Patient
       /// Função recebe o name do funcioanrio e o name do paciente
       /// </summary>
       /// <param name="nameWorker"></param>
       /// <param name="namePatient"></param>
       /// <returns> true or false</returns>
        public static bool Infetado(string nameWorker, string namePatient)
        {
            bool aux;            
            foreach (Patient pacient in Patients.ListPatients)
            {
                aux = Rules.CheckCase(pacient.Symptoms[1], pacient.Symptoms[2], pacient.Symptoms[3], pacient.Symptoms[4]);
                if (Patients.Equals(pacient.NamePatient, namePatient) && !aux && Workers.Exist(nameWorker))
                {
                    pacient.StateInHospital = aux;
                    Patient.TotRecover++;
                    Patients.UpdateNrPatients();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Patient Recover
        /// </summary>
        /// <param name="name">Name do Patient</param>
        /// <returns></returns>
        public static bool Recover(string nameWorker, string namePatient, string departureDate)
        {
            foreach (Patient pacient in Patients.ListPatients)
            {
                if (Patients.Equals(pacient.NamePatient, namePatient) && !Rules.CheckCase(pacient.Symptoms[1], pacient.Symptoms[2], pacient.Symptoms[3], pacient.Symptoms[4]))
                {
                    Schedule.RemovePatient(nameWorker, namePatient, departureDate);
                    Patient.TotRecover++;
                    Patients.UpdateNrPatients();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Obter lista de pacientes
        /// </summary>
        /// <returns>Lista de Patients</returns>
         public static List<Patient> AllPatients()
            {
            IList auxList = Patients.ListPatients;
            List<Patient> aux = new List<Patient>();
            foreach(Patient pacient in auxList)
            {
                aux.Add(pacient);
            }
            return aux;        
        }

        /// <summary>
        /// Obter lista de funcionarios
        /// </summary>
        /// <returns>Lista de Workers</returns>
        public static List<Worker> AllWorkers()
        {
            IList auxList = Workers.ListWorkers;
            List<Worker> aux = new List<Worker>();
            foreach (Worker f in auxList)
            {
                aux.Add(f);
            }
            return aux;
        }

        /// <summary>
        /// Search By LINQ
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static List<Patient> PatientsSearchLINQ(int age)
        {
            var all = Patients.PatientSearchByAgesLINQ(age);
            return all;
        }
        /// <summary>
        /// Search By LINQ
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static List<Patient> PatientsSearchLINQ2(int age)
        {
            var all = Patients.PatientSearchByAgesLINQ2(age);
            return all;
        }


        /// <summary>
        /// Search without LINQ
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static List<Patient> PatientsSearch(int age)
        {
            var all = Patients.PatientSearchByAges(age);
            return all;
        }

        /// <summary>
        /// Abrir Ficheiro
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>verdade ou falso</returns>
        public static List<Patient> Load(string fileName, List<Patient> aux)
        {     
            aux = Patients.Load(fileName, aux);
            return aux;
        }

        /// <summary>
        /// Abrir Ficheiro
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>verdade ou falso</returns>
        public static bool Load(string fileName)
        {
            bool aux;
            aux = Patients.Load(fileName);
            return aux;
        }
        /// <summary>
        /// Guardar pacientes num ficheiro
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool Save(string fileName)
        {
            bool aux;
            aux = Patients.Save(fileName);
            return aux;
        }
    }
}


