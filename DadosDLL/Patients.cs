/*
*	<copyright file="DadosDLL.cs" company="IPCA">
*		Copyright (c) 2021 All Rights Reserved
*	</copyright>
* 	<author>Joel Jonasssi</author>
*   <date>5/19/2021 11:03:10 PM</date>
*	<description></description>
**/

using System;
using BussinessObjectDLL;
using ExcepcoesDLL;
using InterfacesDLL;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace DadosDLL
{
    /// <summary>
    /// Purpose:
    /// Created by: Joel Jonasssi e Idelvina Fernando
    /// Created on: 5/19/2021 11:03:10 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    /// 
    [Serializable]
    public class Patients : IComparer<Patient>
    {
        #region Attributes

        private static List<Patient> listPatients;
       
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static Patients()
        {
            listPatients = new List<Patient>();
        }


        #endregion

        #region Properties

        /// <summary>
        /// Propriety
        /// </summary>
        public static List<Patient> ListPatients
        {
            get => listPatients;
            set => listPatients = value;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Metodo Equals Reescrito
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="worker1"></param>
        /// <returns></returns>
        public static bool Equal(object worker, object worker1)
        {
            if (worker == null) return false;
            if (worker1 == null) return false;
            return worker.Equals(worker1);
        }

      
        /// <summary>
        /// Compara dois Patients
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public int Compare(Patient pacient, Patient pacient1)
        {
            if (pacient == null) return 0;
            if (pacient1 == null) return 0;
            return (string.Compare(pacient.NamePatient, pacient1.NamePatient));
        }
        #endregion

        #region OtherMethods

        /// <summary>
        /// Insert Patient
        /// </summary>
        /// <param name="y">Patient</param>
        /// <returns></returns>
        /// 
        public static bool Insert(Patient pacient)
        {
            if ((pacient != null) && (listPatients.Count <= Constantes.MAX))
            {
                IList auxListII = listPatients;

                if (!listPatients.Contains(pacient) && listPatients == null)
                {
                    listPatients = new List<Patient>();
                    listPatients.Add(pacient);
                    Historic.UpdateHistory(pacient);
                    Worker.TotWorkers++;
                    return true;
                }
                else
                    if (!listPatients.Contains(pacient))
                {
                    listPatients.Add(pacient);
                    Historic.UpdateHistory(pacient);
                    Worker.TotWorkers++;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Consultar Patients de uma determinada age na agenda do medico - Sem LINQ
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static List<Patient> PatientSearchByAges(int age)
        {
            try
            {
                List<Patient> aux = new List<Patient>();
                IList auxList = listPatients;
                foreach (Patient pacient in auxList)
                {
                    if (Patients.Exist(pacient.NamePatient) && Equal(pacient.Age, age))
                    {
                        if (auxList.Contains(pacient)) aux.Add(pacient);
                    }
                }
                return aux;
            }
            catch (MyException e)
            {
                throw new FormatException(e.Message);
            }
        }


        /// <summary>
        /// Consultar Patients de uma determinada age na agenda do medico - LINQ
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static List<Patient> PatientSearchByAgesLINQ(int age)
        {
            try
            {
                var patients = ListPatients.Where(s => s.Age == age).ToList<Patient>();
                return patients;
            }
            catch (MyException e)
            {
                throw new FormatException(e.Message);
            }
        }

        /// <summary>
        /// Consultar Patients de uma determinada age na agenda do medico - LINQ
        /// Solve this Method
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static List<Patient> PatientSearchByAgesLINQ2(int age)
        {
            try
            {               
                var patients = from p in ListPatients
                               where p.Age == age
                               select p;
                List<Patient> s = (List<Patient>)patients;
                return s;
            }
            catch (MyException e)
            {
                throw new FormatException(e.Message);
            }
        }


        /// <summary>
        /// Remover Patient, retirar a contagem no totpaciente e retira-lo na genda do funcionario
        /// </summary>
        /// <param name="pacient"></param>
        /// <returns></returns>
        public static bool RemoveP(Patient pacient, DateTime departureDate)
        {
           if (Remove(pacient))
            {
                pacient.DepartureDate = departureDate;
                Patient.TotPatient--;
                Hospital.TotHospitalizados--;
                return true;
            }return false;             
        }

        public static bool Remove(Patient p)
        {
            try
            {
                
                if (listPatients.Contains(p))
                {
                    listPatients.Remove(p);
                    return true;
                }
                return false;
            }
            catch(MyException a)
            {
                throw new Exception(a.Message);
            }
        }

        /// <summary>
        /// Verifica se Patient existe
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool Exist(string name)
        {       
            foreach (Patient a in listPatients)
            {
                if (a.NamePatient== name) return true;
            }
            return false;
        }
        /// <summary>
        /// Consultar Patients de uma determinada age
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static List<string> PatientAge(int age)
        {
            List<string> aux = new List<string>();
            IList auxList = listPatients;
            foreach (Patient paciente in auxList)
            {
                if (Equal(paciente.Age, age))
                {
                    if (auxList.Contains(paciente)) aux.Add(paciente.NamePatient);                  
                }
            }
            return aux;
        }

        /// <summary>
        /// Consultar sexo dos pacientes num detrminado state
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Sexo> PatientsSexo(StatePatient statePatient)
        {
            try
            {
                List<Sexo> aux = new List<Sexo>();
                IList auxList = listPatients;
                foreach (Patient pacient in auxList)
                {
                    if (Equal(pacient.StatePatient, statePatient))
                    {
                        if (auxList.Contains(pacient)) aux.Add(pacient.GenderPatient);
                    }
                }
                return aux;
            }
            catch(MyException f){
                throw new FormatException(f.Message);
            }
        }
       

        /// <summary>
        /// Atualizar o numero total de 
        /// es
        /// </summary>
        /// <param name="h"></param>
        public static void UpdateNrPatients()
        {
            int auxI, auxII;
            auxI = Patient.TotRecover + Patient.TotDeads;
            auxII = Patient.TotPatient - auxI;
            Patient.TotPatient = auxII;
         }

        /// <summary>
        /// Gravar Ficheiro
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool Save(string fileName)
        {
            try
            {
                Stream s = File.Open(fileName, FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, listPatients);
                s.Flush();
                s.Close();
                s.Dispose();
            }
            catch (MyException e)
            {
                throw new Exception(e.Message);
            }
            return true;
        }

        /// <summary>
        /// Abrir Ficheiro
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Patient> Load(string fileName, List<Patient> listPatient)
        {
            try
            {
                Stream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter binary = new BinaryFormatter();
                listPatient = (List<Patient>)binary.Deserialize(stream);
                stream.Flush();
                stream.Close();
                stream.Dispose();
                return listPatient;
            }
            catch(MyException e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// Abrir Ficheiro
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool Load(string fileName)
        {
            try
            {
                Stream s = File.Open(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter binary = new BinaryFormatter();
                listPatients = (List<Patient>)binary.Deserialize(s);
                s.Flush();
                s.Close();
                s.Dispose();
                return true;
            }
            catch (MyException e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor
        /// </summary>
        ~Patients()
        {
        }
        #endregion

        #endregion
    }
}