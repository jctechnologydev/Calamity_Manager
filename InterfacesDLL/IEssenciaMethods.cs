/*
*	<copyright file="TrabalhoLP2_19681_19698_fase1.cs" company="IPCA">
*		Copyright (c) 2021 All Rights Reserved
*	</copyright>
* 	<author>joelj</author>
*   <date>4/18/2021 1:06:59 AM</date>
*	<description></description>
**/

namespace InterfacesDLL
{
    /// <summary>
    /// Purpose: Trabalho LP2
    /// Created by: Joel Jonassi & Idelvina Fernando
    /// Created on: 4/18/2021 1:06:59 AM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public interface IEssenciaMethods<T, S>
    {

        bool Remove(T Pessoa);
        bool Existe(S name);
        bool Save(S fileName);
        bool Load(S fileName);
    }
}
