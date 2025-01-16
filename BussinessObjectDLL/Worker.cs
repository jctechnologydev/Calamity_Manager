/*
*	<copyright file="TrabalhoLP2_19681_19698_fase1.cs" company="IPCA">
*		Copyright (c) 2021 All Rights Reserved
*	</copyright>
* 	<author>joelj</author>
*   <date>4/17/2021 11:54:17 PM</date>
*	<description></description>
**/

using ExcepcoesDLL;
using System;
using System.Collections.Generic;

namespace BussinessObjectDLL
{
    /// <summary>
    /// Purpose: DLL - Trabalho LP2
    /// Created by: Joel Jonassi & Idelvina Fernando
    /// Created on: 4/18/2021 1:06:59 AM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public enum TypeWorker { Nerse, Doctor, Other };

    
    public class Worker : IComparer<Worker>, IComparable<object>
    {
        #region Attributes
        private string name;
        private TypeWorker workerType;
        private int cod;
        private Sexo gender;
        private double salary;
        private static int totWorkers = 0;
        #endregion

        #region Methods

        #region Constructors
        public Worker() { }

        /// <summary>
        /// Construtor de Worker
        /// </summary>
        /// <param name="name">name do funcionario</param>
        /// <param name="cod">Certfifca a Area do Worker</param>
        /// <param name="workType">Tipo de Worker</param>
        public Worker(string name, int cod, TypeWorker workType, Sexo gender, double salary)
        {
            this.name = name;
            this.cod = cod;
            this.workerType = workType;
            this.gender = gender;
            this.salary = salary;
        }

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string NameWorker
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public TypeWorker WorkerType
        {
            get { return workerType; }
            set { workerType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int License
        {
            get { return cod; }
            set { cod = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Sexo GenderWorker
        {
            get => gender;
            set => gender = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public double Salary
        {
            get => salary;
            set => salary = value;
        }
        public static int TotWorkers
        {
            get => totWorkers;
            set => totWorkers = value;
        }
        #endregion

        /// <summary>
        /// Comparar Funcionarios com intuito de ordenar - sort()
        /// IComparable
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public int CompareTo(Object worker)
        {
            try
            {
                if (!(worker is Worker))
                {
                }
                Worker aux = worker as Worker;

                return (this.Salary.CompareTo(aux.Salary));
            }
            catch (MyException exception)
            {
                throw new ArgumentException(exception.Message);
            }
            finally
            {
            }
        }

        /// <summary>
        /// Comparar dois Funcionarios
        /// IComparer
        /// </summary>
        /// <param name="pacient"></param>
        /// <param name="pacient"></param>
        /// <returns></returns>
        public int Compare(Worker worker, Worker worker1)
        {
            if (worker == null) return 0;
            if (worker1 == null) return 0;
            return (string.Compare(worker.name, worker1.name));
        }

        /// <summary>
        /// Lambda Function
        /// </summary>
        public static Func<Worker, int, bool> IsWorker = (worker, lincese) => worker.License == lincese;
        /// <summary>
        /// Lambda Action
        /// </summary>
        public static Action<Worker> ShowWorkerDetails = worker => Console.WriteLine($"Name: { worker.NameWorker}\nGender: {worker.gender}\nSalary: {worker.Salary}");

        /// <summary>
        /// Expressions and Delegates
        /// Permite passar um bloco de código como parâmetro num método delegate. 
        /// Métodos sem designação, apenas o código que o implementa!,
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="salary"></param>
        /// <returns></returns>
        public delegate bool IsYoungerThan(Worker worker, int salary);

        IsYoungerThan isYoungerThan = (worker, salary) =>
        {
            return worker.salary < salary;
        };



        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Worker()
        {
        }
        #endregion

        #endregion
    }
}
