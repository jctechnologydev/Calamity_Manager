/*
*	<copyright file="DadosDLL.cs" company="IPCA">
*		Copyright (c) 2021 All Rights Reserved
*	</copyright>
* 	<author>Joel Jonasssi</author>
*   <date>5/17/2021 11:58:24 PM</date>
*	<description></description>
**/
using System;
using BussinessObjectDLL;
using System.Collections;
using System.Collections.Generic;
using ExcepcoesDLL;

/// <summary>
/// Purpose: Trabalho LP2
/// Created by: Joel Jonassi & Idelvina Fernando
/// Created on: 04/27/2021 00:20:55 PM
/// </summary>
/// <remarks></remarks>
/// <example></example>
namespace DadosDLL
{
    /// <summary>
    /// Purpose:
    /// Created by: Joel Jonasssi e Idelvina Fernando
    /// Created on: 5/17/2021 11:58:24 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Schedule
    {
        #region Attributes
        static Dictionary<string, List<Patient>> scheduleWorker;
        static Hospital hospital;
        static Patients pacients;
        static Workers workers;
        #endregion
        
        #region Methods

        #region Constructors

        static Schedule() 
        { 
            scheduleWorker = new Dictionary<string, List<Patient>> (); 
        }
        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Schedule(Hospital h, Patients ps, Workers fs)
        {
            Schedule.hospital = h;
            Schedule.pacients = ps;
            Schedule.workers = fs;
        }

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public static Hospital H
        {
            get => hospital;
            set => hospital = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public static Patients P
        {
            get => pacients;
            set => pacients = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public static Workers F
        {
            get => workers;
            set => workers = value;
        }

        /// <summary>
        /// /
        /// </summary>
        public static Dictionary<string, List<Patient>> ScheduleWorker
        {
            get => scheduleWorker;
            set => scheduleWorker = value;
        }

        /// <summary>
        /// Propriedade de List
        /// </summary>
        public static Hospital Hosp
        {
            get => hospital;
            set => hospital = value;
        }

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
        #endregion

        #region OtherMethods


        /// <summary>
        /// Verifica se existe paciente no hospital
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool ExistPatient(Patient pacient)
        {
            if (pacient != null)
            {
                foreach (Patient p in Patients.ListPatients) //Se o Patient existe na lista retorna false
                {
                    if (p == pacient) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Consultar Schedule de um determinado Worker
        /// Mostra o numero de funcionarios que um funcionario tem
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static List<Patient> SearchSchedule(string f)
        {
            List<Patient> aux = new List<Patient>();
            IList auxList = Workers.ListWorkers;
            foreach (Worker workers in auxList)
            {
                if (Equal(workers.NameWorker, f))
                {
                    IList auxListI = scheduleWorker[workers.NameWorker];
                    foreach (Patient pacient in auxListI)
                    {
                        if (auxListI.Contains(pacient)) aux.Add(pacient);
                    }
                }
            }
            return aux;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameWorker"></param>
        /// <returns></returns>
        public static bool CreateListaPatient(string nameWorker)
        {
            scheduleWorker.Add(nameWorker, new List<Patient>());
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <summary>
        /// Atribuir Patient a um Worker num determinado Hospital
        /// Se p existe return false
        /// Verifica se paciente inserido é nullo
        /// verifica a cahve/funcionario existe
        /// verifica se o funcionario pode receber mais pacientes
        /// Insere o paciente na lista agenda e na lista Patients
        /// </summary>
        /// <param name="nameWorker"></param>
        /// <param name="pacient"></param>
        /// <returns></returns>
        public static bool InsertPatient(string nameWorker, Patient pacient)
        {
            try
            {
                Worker worker = new Worker();
                if (pacient != null)
                {
                    IList auxList = Workers.ListWorkers;
                    foreach (Worker workers in auxList)
                    {
                        if (Equal(workers.NameWorker, nameWorker))
                        {
                            IList auxListII = scheduleWorker[workers.NameWorker];
                            foreach (Patient a in auxListII)
                            {
                                if (!auxListII.Contains(pacient) && auxListII.Count <= Constantes.MAX)
                                {
                                    scheduleWorker[workers.NameWorker].Add(pacient);
                                    Patients.Insert(pacient);
                                    Patient.TotPatient++;
                                    return true;
                                }
                                else if (auxListII == null)
                                {
                                   scheduleWorker[workers.NameWorker] = new List<Patient>();
                                   scheduleWorker[workers.NameWorker].Add(pacient);
                                   Patients.Insert(pacient);
                                   Patient.TotPatient++;
                                   return true;
                                }
                                else return false;
                            }
                        }
                    }
                }
                return false;
            }
            catch (MyException exception)
            {
                throw new Exception(exception.Message);
            }
        }


        /// <summary>
        /// Remover paciente e i
        /// </summary>
        /// <param name="nameFunc"></param>
        /// <param name="p"></param>
        /// <param name="dataSaida"></param>
        /// <returns></returns>
        public static bool RemovePatient(string nameFunc, string namePatient, string dataSaida)
        {
            try
            {
                Worker worker = new Worker();
                Patients pacients = new Patients();
 
                IList auxList = Workers.ListWorkers;
                foreach (Worker workerr in auxList)
                {
                    if (Hospital.ExistWorker(workerr) && Equal(workerr.NameWorker, nameFunc))
                    {
                        IList auxListII = scheduleWorker[workerr.NameWorker];
                        foreach (Patient pacient in auxListII)
                        {

                            if (auxListII.Contains(namePatient) && Patients.Equals(pacient.NamePatient, namePatient))
                            {
                                scheduleWorker[workerr.NameWorker].Remove(pacient);
                                Patients.RemoveP(pacient, DateTime.Parse(dataSaida));
                                Patient.TotPatient++;
                                return true;
                            }
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (MyException e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// Remover funcionario e atribuir os apacientes a ele associado a um funcionário auxliar
        /// </summary>
        /// <param name="nameFunc"></param>
        /// <param name="funcAuxiliar"></param>
        /// <returns></returns>
        public static bool RemoveWorker(string nameFunc, string funcAuxiliar)
        {
            try
            {
                Worker ff = new Worker();
                Workers ffs = new Workers();

                IList auxList = Workers.ListWorkers;
                foreach (Worker fs in auxList)
                {
                    if (Hospital.ExistWorker(fs) && Equal(fs.NameWorker, nameFunc))
                    {
                        IList auxListII = scheduleWorker[fs.NameWorker];
                        foreach (Patient a in auxListII)
                        {

                            if (auxList.Contains(nameFunc) && (auxListII != null) && auxList.Contains(funcAuxiliar))
                            {
                                scheduleWorker[funcAuxiliar] = scheduleWorker[fs.NameWorker];
                                Workers.Remove(fs);
                                return true;
                            }
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (MyException m)
            {
                throw new Exception(m.Message);
            }
        }

        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Schedule()
        {
        }
        #endregion

        #endregion
    }
}
