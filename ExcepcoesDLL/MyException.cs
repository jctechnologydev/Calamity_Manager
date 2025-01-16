/*
*	<copyright file="MetodosGereCalamage.cs" company="IPCA">
*		Copyright (c) 2021 All Rights Reserved
*	</copyright>
* 	<author>joelj</author>
*   <date>4/13/2021 8:09:52 PM</date>
*	<description></description>
**/
using System;


namespace ExcepcoesDLL
{
    /// <summary>
    /// Purpose:
    /// Created by: Joel Jonassi & Idelvina Fernando
    /// Created on: 4/13/2021 8:09:52 PM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class MyException : ApplicationException
    {

        public MyException(string s) : base(s)
        {

        }
    }
}
