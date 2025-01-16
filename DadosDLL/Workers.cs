/*
*	<copyright file="DadosDLL.cs" company="IPCA">
*		Copyright (c) 2021 All Rights Reserved
*	</copyright>
* 	<author>Joel Jonasssi</author>
*   <date>5/19/2021 11:03:27 PM</date>
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



namespace DadosDLL
{
    /// <summary>
    /// Purpose:
    /// Created by: Joel Jonasssi
    /// Created on: 5/19/2021 11:03:27 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    /// 
    [Serializable]
    public class Workers : IComparer<Worker>
    {
        #region Attributes
        private static List<Worker> listWorkers;
        private Schedule agendaWorker;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Construtor
        /// </summary>
        static Workers()
        {
            listWorkers = new List<Worker>();
            
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public  static List<Worker> ListWorkers
        {
            get => listWorkers;
            set => listWorkers = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public Schedule ScheduleWorker
        {
            get => agendaWorker;
            set => agendaWorker = value;
        }

        #endregion

        #region Overrides
        /// <summary>
        /// Compara dois funcionarios
        /// </summary>
        /// <param name="h"></param>
        /// <param name="h1"></param>
        /// <returns></returns>
        public static bool Equal(object f, object f1)
        {
            if (f == null) return false;
            if (f1 == null) return false;
            return (f.Equals(f1));
        }

        /// <summary>
        /// Compara Worker
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public int Compare(Worker f, Worker f1)
        {
            if (f == null) return 0;
            if (f1 == null) return 0;
            return (string.Compare(f.NameWorker, f.NameWorker));
        }
        #endregion

        #region OtherMethods

        /// <summary>
        /// Insert Worker
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        /// 
        public static bool Insert(Worker worker)
        {
             try
            {
                if ((worker != null) )
                {
                    IList auxListII = listWorkers;

                    if (!listWorkers.Contains(worker) && listWorkers == null)
                    {
                        listWorkers = new List<Worker>();
                        listWorkers.Add(worker);
                        Worker.TotWorkers++;
                        return true;
                    }
                    else
                        if (!listWorkers.Contains(worker))
                    {
                        listWorkers.Add(worker);
                        Worker.TotWorkers++;
                        return true;
                    }
                }
                return false;
            }
            catch(MyException a)
            {
                throw new Exception(a.Message);
            }
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static bool Exist(string name)
        {
            foreach (Worker worker in listWorkers) //Se a chave existe ou Worker
            {
                if (Equals(worker.NameWorker, name)) return true;
            }
            return false;
        }


        /// <summary>
        /// Remover 
        /// e, retirar a contagem no totpaciente e retira-lo na genda do funcionario
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Remove(Worker worker)
        {
            try
            {
                if (worker == null)
                {
                    //Se tiver menos de três symptoms 
                    if (listWorkers.Contains(worker))
                    {
                        listWorkers.Remove(worker);
                        return true;
                    }
                }
                return false;
            }catch(MyException exception)
            {
                throw new Exception(exception.Message);
            }
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
                b.Serialize(s, listWorkers);
                s.Flush();
                s.Close();
                s.Dispose();
            }
            catch (MyException e)
            {
                throw new Exception (e.Message); 
            }
            return true;
        }

        /// <summary>
        /// Abrir Ficheiro e carrega-lo em memória
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool Load(string fileName)
        {
            try
            {
                Stream s = File.Open(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                listWorkers = (List<Worker>)b.Deserialize(s);
                s.Flush();
                s.Close();
                s.Dispose();
                return true;
            }
            catch(MyException a)
            {
                throw new Exception(a.Message);
            }
        }
        #endregion
        #region Destructor
        /// <summary>
        /// The destructor
        /// </summary>
        ~Workers()
        {
        }
        #endregion

        #endregion
    }
}
