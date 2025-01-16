/*
*	<copyright file="DadosDLL.cs" company="IPCA">
*		Copyright (c) 2021 All Rights Reserved
*	</copyright>
* 	<author>Joel Jonasssi</author>
*   <date>5/20/2021 7:12:18 AM</date>
*	<description></description>
**/
using System;
using BussinessObjectDLL;
//using Excepcoes;
using InterfacesDLL;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;   
using System.Xml.Serialization;
namespace DadosDLL
{
    /// <summary>
    /// Purpose:Historico do Patient
    /// Created by: Joel Jonasssi
    /// Created on: 5/20/2021 7:12:18 AM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Historic
    {
        #region Attributes
        private bool dead;
        private bool recover;
        private static List<Patient> listHistory;
       
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        static Historic( )
        {
            listHistory = new List<Patient>();   
        }

        #endregion

        #region Properties
        public static List<Patient> ListHistory
        {
            get => listHistory;
            set => listHistory = value;
        }
       
        #endregion

        #region Overrides
        #endregion

        #region OtherMethods

        /// <summary>
        /// Dia de Entrada e saida no hospital
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<DateTime> DateHistory(string name)
        {
            List<DateTime> aux = new List<DateTime>();
            foreach(Patient pa in Patients.ListPatients)
            {
                if(Patients.Equal(pa.NamePatient, name))
                {
                    aux.Add(pa.EntryDate);
                    aux.Add(pa.DepartureDate);
                    return aux;
                }
            }return null;
        }

        /// <summary>
        /// Atualizar historico
        /// </summary>
        /// <param name="p">Name do 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// e</param>
        /// <returns></returns>
        public static bool UpdateHistory(Patient p)
        {
           if (!listHistory.Contains(p))
            {
                listHistory.Add(p);
                return true;
            }return false;
        }

        /// <summary>
        /// Limpar historico
        /// </summary>
        /// <returns></returns>
        public static bool ClearAllHistory()
        {
            listHistory.Clear();
            return true;
        }
        /// <summary>
        /// Pesquisar Patient no historico
        /// </summary>
        /// <param name="name">Name do Patient</param>
        /// <returns></returns>
        public static Patient ConsultarHistorico(string name)
        {
            Patient aux = null;
            IList auxList = Patients.ListPatients;
            foreach (Patient p in auxList)
            {
                if (Patients.Equal(p.NamePatient, name)) aux = p;              
            }return aux;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor
        /// </summary>
        ~Historic()
        {
        }
        #endregion

        #endregion
    }
}
