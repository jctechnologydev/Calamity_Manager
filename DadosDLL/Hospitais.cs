/*
*	<copyright file="TrabalhoLP2_19681_19698_fase1.cs" company="IPCA">
*		Copyright (c) 2021 All Rights Reserved
*	</copyright>
* 	<author>joeljonassi&idelvinafernando</author>
*   <date>4/27/2021 1:06:59 AM</date>
*	<description></description>
**/
using BussinessObjectDLL;
using ExcepcoesDLL;
using System.Collections.Generic;

namespace DadosDLL
{
    /// <summary>
    /// Purpose: Trabalho LP2
    /// Created by: Joel Jonassi & Idelvina Fernando
    /// Created on: 04/27/2021 23:41:59 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Hospitais<H> : IComparer<Hospital>
    {
        #region Attribute
        static List<Hospital> listHospitais;


        #endregion

        #region Methods
        #region Constructors
        //public Hospitais()   {  }
        static Hospitais()
        {

            listHospitais = new List<Hospital>(); //Create instancia ao inserir hospital

        }

        #endregion

        #region PropertieS

        /// <summary>
        /// Propriedade
        /// Retorna uma copia da lista
        /// </summary>
        public List<Hospital> ListHospitais
        {
            get { return listHospitais; }
            set { listHospitais = value; }
        }


        #endregion
        #region Overrides

        #endregion

        #region OtherMethods
        /// <summary>
        /// Compara dois hospitais
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public int Compare(Hospital h, Hospital h1)
        {
            if (h == null) return 0;
            if (h1 == null) return 0;
            return Compare(h, h1);
        }
       /// <summary>
       /// Compara dois hospitais
       /// </summary>
       /// <param name="h"></param>
       /// <param name="h1"></param>
       /// <returns></returns>
        public bool Equals(Hospital h, Hospital h1)
        {
            if (h == null) return false;
            if (h == null) return false;
            return (h.NameHospital.Equals(h.NameHospital));
        }

        /// <summary>
        /// Compara dois 
        /// 
        /// es
        /// </summary>
        /// <param name="p1">Patient 1</param>
        /// <param name="p2">Patient 2</param>
        /// <returns></returns>
        public int Compare(Patient p1, Patient p2)
        {
            if (p1 == null) return 0;
            if (p2 == null) return 0;
            return (string.Compare(p1.NamePatient, p2.NamePatient));
        }

        /// <summary>
        /// Insert novo Hospital na lista de Hospitais
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public bool InsertHospital(Hospital f)
        {
            if (!listHospitais.Contains(f))
            {
                listHospitais.Add(f);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Verifica se o hospital existe
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ExisteHospital(string hospital)
        {

            foreach (Hospital a in listHospitais)
            {
                if (a.NameHospital == hospital) return true;
            }
            return false;
        }

        #endregion
        #region Destructor
        /// <summary>
        /// Destrutor
        /// </summary>
        ~Hospitais()
        {

        }
        #endregion
        #endregion
    }
}



   


