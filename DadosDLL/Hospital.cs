/*
*	<copyright file="DadosDLL.cs" company="IPCA">
*		Copyright (c) 2021 All Rights Reserved
*	</copyright>
* 	<author>Joel Jonasssi</author>
*   <date>5/18/2021 12:07:26 AM</date>
*	<description></description>
**/
using BussinessObjectDLL;
using ExcepcoesDLL;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DadosDLL
{
    /// <summary>
    /// Purpose:
    /// Created by: Joel Jonasssi
    /// Created on: 5/18/2021 12:07:26 AM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>

    public class Hospital: IComparer<Patient>
    {
        #region Attribute
        string nameHospital;
        string regiao;
        static int totalHospitalized = 0;
        //private static int totRecovers = 0;
        static Schedule ag;
        static Patients ps;
        static Workers fs;
        static Historic h;

        #endregion


        #region Methods
        #region Constructors

        //public Hospital()   {  }

       public Hospital(Patients ps, Workers fs, Schedule ag,Historic h, string nameHospital, string regiao)
        {
            Hospital.Ag = ag;
            Hospital.Ps = ps;
            Hospital.Fs = fs;
            Hospital.h = h;
            this.nameHospital = nameHospital;
            this.regiao = regiao;
        }


        #endregion

        #region PropertieS
        /// <summary>
        /// Propriedade de List
        /// </summary>
        public static Workers Fs
        {
            get => fs;
            set => fs = value;
        }
        
        /// <summary>
        /// Reescreve a propriedade
        /// </summary>
        public static Patients Ps
    {
        get => ps; 
        set => ps = value; 
    }
    /// <summary>
    /// 
    /// </summary>
    public string NameHospital
    {
        get { return nameHospital; }
        set { nameHospital = value; }
    }
        public string Regiao
        {
            get { return regiao; }
            set { regiao = value; }
        }
        /// <summary>
        /// Propriedade agenda
        /// </summary>
        public static Schedule Ag
        {
            get => ag;
            set => ag = value;
        }

        public static Historic Historic
        {
            get => h;
            set => h = value;
        }
        public static int TotHospitalizados
        {
            get => totalHospitalized;
            set => totalHospitalized = value;
        }
        public static Historic Hist
        {
            get => h;
            set => h = value;
        }
        #endregion
        #region Overrides

        #endregion

        #region OtherMethods

        /// <summary>
        /// Compara dois Patients
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public int Compare(Patient p1, Patient p2)
    {
        if (p1 == null) return 0;
        if (p2 == null) return 0;
        return (string.Compare(p1.NamePatient, p2.NamePatient));
    }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ExistePatient(string name)
        {
            foreach (Patient c in Patients.ListPatients)
            {
                if (c.NamePatient == name) { }
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
       public static  bool ExistWorker(Worker worker)
        {
            foreach (Worker workers in Workers.ListWorkers) //Se a chave existe ou Worker
            {
                if (worker == workers) return true;
            }
            return false;
        }


        public static bool Exist(Patient p)
        {
            foreach(Patient ps in Patients.ListPatients) //Se a chave existe ou Worker
            {
                if (p == ps) return true;
            }
            return false;
        }

        /// <summary>
        /// Consultar state do paciente
        /// </summary>
        /// <param name="taxNumber"></param>
        /// <returns></returns>
        public static StatePatient EstadoPatient(int taxNumber)
        {
            foreach (Patient p in Patients.ListPatients)
            {
                if (p.TaxNumber == taxNumber)
                {
                    return p.StatePatient;
                }
            }
            return 0;
        }

        /// <summary>
        /// Consultar o medico do paciente
        /// </summary>
        /// <param name="taxNumber"></param>
        /// <returns></returns>
        public static Worker ConsultarTratamento(int taxNumber)
        {
            Worker aux = new Worker();
            IList auxList = Workers.ListWorkers;
            foreach (Worker fs in auxList)
            {
                if (ExistWorker(fs))
                {
                    IList auxListI = Schedule.ScheduleWorker[fs.NameWorker];
                    foreach (Patient p in auxListI)
                    {
                        if (auxListI.Contains(p)) aux = fs;
                    }
                }
            }
            return aux;
        }

        /// <summary>
        /// Função auxiliar para comparar hospitais
        /// </summary>
        /// <param name="total">total de Patients no Hospital</param>
        /// <returns></returns>
        internal int PercentageOfPatients(int total)
        {
            try
            {
                int aux;
                aux = (total * Constantes.PERCENTAGE) / totalHospitalized;
                return aux;
            }
            catch (MyException d)
            {
                throw new DivideByZeroException(d.Message);
            }
        }

       
        
        #endregion
        /// <summary>
        /// Destrutor
        /// </summary>
        #region Destructor
        ~Hospital()
    {

    }
    #endregion
    #endregion
}

    }

