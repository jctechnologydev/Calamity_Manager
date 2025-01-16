/*
*	<copyright file="TrabalhoLP2_19681_19698_fase1.cs" company="IPCA">
*		Copyright (c) 2021 All Rights Reserved
*	</copyright>
* 	<author>joeljonassi&idelvinafernando</author>
*   <date>4/18/2021 1:06:59 AM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using ExcepcoesDLL;

namespace BussinessObjectDLL
{
    /// <summary>
    /// Purpose: DLL - Trabalho LP2
    /// Created by: Joel Jonassi & Idelvina Fernando
    /// Created on: 4/18/2021 1:06:59 AM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public enum Sexo { Male, Female, Other };

    /// <summary>
    /// 
    /// </summary>
    public enum Symptom { noSymptom, symptom1, symptom2, symptom3, symptom4 }

    /// <summary>
    /// 
    /// </summary>
    public enum StatePatient { unvailable, stable, serious, verySerious };



    [Serializable]
    public class Patient : IComparer<Patient>, IComparable<object>
    {
        #region Attributes

        private string name;
        private int age;
        private string disease;
        private double contact;
        private double sns;
        private double taxNumber;
        private StatePatient statePatient;
        private Sexo gender;
        private DateTime entryDate;
        private DateTime departureDate;
        private bool state;
        private Symptom[] symptoms;
        private static int totPatient = 0;
        private static int totSymptoms = 0;
        private static int totRecovers = 0;
        private static int totDead = 0;
        #endregion

        #region Methods
        #region Constructors

        public Patient() { }
        /// <summary>
        /// Construtor de classe
        /// </summary>
        /// <param name="name">name da doenteP</param>
        /// <param name="age">age da doenteP</param>
        /// <param name="gender">gender da doenteP</param>
        public Patient(string name, int age, DateTime entryDate, Sexo gender, StatePatient state, double telphone, double sns, double taxNumber, Symptom symptom1, Symptom symptom2, Symptom symptom3, Symptom symptom4)
        {
            this.name = name;
            this.age = age;
            this.entryDate = entryDate;
            this.gender = gender;
            this.statePatient = state;
            this.contact = telphone;
            this.sns = sns;
            Symptoms = new Symptom[5];
            symptoms[1] = symptom1;
            symptoms[2] = symptom2;
            symptoms[3] = symptom3;
            symptoms[4] = symptom4;
            this.taxNumber = taxNumber;
        }


        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public bool StateInHospital
        {
            get => state;
            set => state = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Disease
        {
            get => disease;
            set => disease = value;
        }

        public DateTime EntryDate
        {
            get => entryDate;
            set => entryDate = value;
        }

        public DateTime DepartureDate
        {
            get => departureDate;
            set => departureDate = value;
        }
        public double SNS
        {
            get => sns;
            set => sns = value;
        }
        /// <summary>
        /// Propriedade para total de pacientes
        /// </summary>
        public static int TotPatient
        {
            get { return totPatient; }
            set { totPatient = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static int TotDeads
        {
            get { return totDead; }
            set { totDead = value; }
        }

        /// <summary>
        /// Propriedade para dados do paciente
        /// </summary>
        public string NamePatient
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Propriedade para dados do paciente
        /// </summary>
        public static int TotSymptoms
        {
            get { return totSymptoms; }
            set { totSymptoms = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Age
        {
            get { return age; }
            set { age = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public double Sns
        {
            get { return sns; }
            set { sns = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double TaxNumber
        {
            get { return taxNumber; }
            set {taxNumber = value; }
        }

        /// <summary>
        /// Symptoms Parea Avaliar pacientes
        /// </summary>
        public Symptom[] Symptoms
        {
            get { return symptoms; }
            set { symptoms = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static int TotRecover
        {
            get => totRecovers;
            set => totRecovers = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public Sexo GenderPatient
        {
            get { return gender; }
            set { gender = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public StatePatient StatePatient
        {
            get { return statePatient; }
            set { statePatient = value; }
        }


        #endregion

        #region Overrides
        #endregion

        #region OtherMethods

        /// <summary>
        /// Comparar Patients com intuito de ordenar - sort()
        /// IComparable
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public int CompareTo(Object patient)
        {
            try
            {
                if (!(patient is Patient))
                {
                }
                Patient aux = patient as Patient;

                return (this.name.CompareTo(aux.name));
            }
            catch(MyException exception)
            {
                throw new ArgumentException(exception.Message);
            }
            finally
            {
            }
        }

        /// <summary>
        /// Comparar dois patientes
        /// IComparer
        /// </summary>
        /// <param name="pacient"></param>
        /// <param name="pacient"></param>
        /// <returns></returns>
        public int Compare(Patient pacient, Patient pacient1)
        {
            if (pacient == null) return 0;
            if (pacient1 == null) return 0;
            return (string.Compare(pacient.name, pacient1.name));
        }
        #endregion
        #endregion

        #region Destructor
        /// <summary>
        /// Destrutor de Pe
        /// </summary>
        ~Patient()
            {
                totPatient--;
            }
         #endregion
        
    }
}