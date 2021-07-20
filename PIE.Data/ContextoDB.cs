﻿using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PIE.Data
{
    public class ContextoDB : IDisposable
    {
        private SqlConnection _sqlConnection = null;
        private SqlCommand _sqlCommand = null;
        string _CadConexion = String.Empty;

        private IConfiguration Configuracion { get; }
        public ContextoDB(string DBCnn)
        {
            _CadConexion = DBCnn;
        }
        public SqlDataReader EjecutaSP(string StoredProcedure, SqlParameter[] Parametros)
        {
            try
            {
                _sqlConnection = new SqlConnection(_CadConexion);
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(StoredProcedure, _sqlConnection);
                _sqlCommand.Parameters.AddRange(Parametros);
                _sqlCommand.CommandTimeout = 0;
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = _sqlCommand.ExecuteReader();
                return reader;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public SqlDataReader EjecutaSP(string StoredProcedure)
        {
            try
            {
                _sqlConnection = new SqlConnection(_CadConexion);
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(StoredProcedure, _sqlConnection);
                _sqlCommand.CommandTimeout = 0;
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = _sqlCommand.ExecuteReader();

                return reader;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        void IDisposable.Dispose()
        {
            if (_sqlConnection.State == ConnectionState.Open)
            {
                _sqlConnection.Close();
            }
        }
    }
}
