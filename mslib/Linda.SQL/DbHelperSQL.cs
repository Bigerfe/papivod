using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// ���ݿ����
/// </summary>
public abstract class DbHelperSQL
{

    private static string procname = "SP_GetRecordByPage";

    /// <summary>
    /// ���÷�ҳ�Ĵ洢���̵Ĵ洢���̵�����
    /// </summary>
    public static string ProcName
    {
        set
        {
            procname = value;
        }

        get
        {
            return procname;
        }
    }

    //���ݿ������ַ���(web.config������)
    //<add key="ConnectionString" value="server=127.0.0.1;database=DATABASE;uid=sa;pwd=" />		
    protected static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    private static SqlConnection con = new SqlConnection(connectionString);
    public DbHelperSQL()
    {
    }

    #region ���÷���
    /// <summary>
    /// ���ص�ǰ���ID��+1
    /// </summary>
    /// <param name="FieldName"></param>
    /// <param name="TableName"></param>
    /// <returns></returns>
    public static int GetMaxID(string FieldName, string TableName)
    {
        string strsql = "select max(" + FieldName + ")+1 from " + TableName;
        object obj = GetSingle(strsql);
        if (obj == null)
        {
            return 1;
        }
        else
        {
            return int.Parse(obj.ToString());
        }
    }


    /// <summary>
    /// ���ص�ǰ���ID
    /// </summary>
    /// <param name="FieldName"></param>
    /// <param name="TableName"></param>
    /// <returns></returns>
    public static int GetMaxID(string FieldName, string TableName,string current)
    {
        string strsql = "select max(" + FieldName + ") from " + TableName;
        object obj = GetSingle(strsql);
        if (obj == null)
        {
            return 1;
        }
        else
        {
            return int.Parse(obj.ToString());
        }
    }

    /// <summary>
    /// �ж��Ƿ����
    /// </summary>
    /// <param name="strSql">���</param>
    /// <param name="cmdParms">����</param>
    /// <returns></returns>
    public static bool Exists(string strSql, params SqlParameter[] cmdParms)
    {
        object obj = GetSingle(strSql, cmdParms);
        int cmdresult;
        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        {
            cmdresult = 0;
        }
        else
        {
            cmdresult = int.Parse(obj.ToString());
        }
        if (cmdresult == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    #endregion

    #region  ִ�м�SQL���

    /// <summary>
    /// ִ��SQL��䣬����Ӱ��ļ�¼��
    /// </summary>
    /// <param name="SQLString">SQL���</param>
    /// <returns>Ӱ��ļ�¼��</returns>
    public static int ExecuteSql(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    connection.Close();
                    throw new Exception(E.Message);
                }
            }
        }
    }

    /// <summary>
    /// ִ�ж���SQL��䣬ʵ�����ݿ�����
    /// </summary>
    /// <param name="SQLStringList">����SQL���</param>		
    public static void ExecuteSqlTran(ArrayList SQLStringList)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlTransaction tx = conn.BeginTransaction();
            cmd.Transaction = tx;
            try
            {
                for (int n = 0; n < SQLStringList.Count; n++)
                {
                    string strsql = SQLStringList[n].ToString();
                    if (strsql.Trim().Length > 1)
                    {
                        cmd.CommandText = strsql;
                        cmd.ExecuteNonQuery();
                    }
                }
                tx.Commit();
            }
            catch (System.Data.SqlClient.SqlException E)
            {
                tx.Rollback();
                throw new Exception(E.Message);
            }
        }
    }
    /// <summary>
    /// ִ�д�һ���洢���̲����ĵ�SQL��䡣
    /// </summary>
    /// <param name="SQLString">SQL���</param>
    /// <param name="content">��������,����һ���ֶ��Ǹ�ʽ���ӵ����£���������ţ�����ͨ�������ʽ���</param>
    /// <returns>Ӱ��ļ�¼��</returns>
    public static int ExecuteSql(string SQLString, string content)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(SQLString, connection);
            System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
            myParameter.Value = content;
            cmd.Parameters.Add(myParameter);
            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
            catch (System.Data.SqlClient.SqlException E)
            {
                throw new Exception(E.Message);
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }
    }


    /// <summary>
    /// ����һ���ֶ��Ǹ�ʽ���ӵ����£���������ţ�����ͨ�������ʽ���  �ֶ�����Ϊvachar
    /// </summary>
    /// <param name="SQLString">SQL���</param>
    /// <param name="content">��������,����һ���ֶ��Ǹ�ʽ���ӵ����£���������ţ�����ͨ�������ʽ���</param>
    /// <returns>Ӱ��ļ�¼��</returns>
    public static int ExecuteSqlVarchar(string SQLString, string content)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(SQLString, connection);
            System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.VarChar);
            myParameter.Value = content;
            cmd.Parameters.Add(myParameter);
            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
            catch (System.Data.SqlClient.SqlException E)
            {
                throw new Exception(E.Message);
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }
    }
    /// <summary>
    /// �����ݿ������ͼ���ʽ���ֶ�(������������Ƶ���һ��ʵ��)
    /// </summary>
    /// <param name="strSQL">SQL���</param>
    /// <param name="fs">ͼ���ֽ�,���ݿ���ֶ�����Ϊimage�����</param>
    /// <returns>Ӱ��ļ�¼��</returns>
    public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@fs", SqlDbType.Image);
            myParameter.Value = fs;
            cmd.Parameters.Add(myParameter);
            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
            catch (System.Data.SqlClient.SqlException E)
            {
                throw new Exception(E.Message);
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }
    }

    /// <summary>
    /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
    /// </summary>
    /// <param name="SQLString">�����ѯ������</param>
    /// <returns>��ѯ�����object��</returns>
    public static object GetSingle(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }
    }
    /// <summary>
    /// ִ�в�ѯ��䣬����SqlDataReader
    /// </summary>
    /// <param name="strSQL">��ѯ���</param>
    /// <returns>SqlDataReader</returns>
    public static SqlDataReader ExecuteReader(string strSQL)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(strSQL, connection);
        try
        {
            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader();
            return myReader;
        }
        catch (System.Data.SqlClient.SqlException e)
        {
            throw new Exception(e.Message);
        }

    }
    /// <summary>
    /// ִ�в�ѯ��䣬����DataSet
    /// </summary>
    /// <param name="SQLString">��ѯ���</param>
    /// <returns>DataSet</returns>
    public static DataSet Query(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            if (ds != null && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
    }


    #endregion

    #region ִ�д�������SQL���

    /// <summary>
    /// ִ��SQL��䣬����Ӱ��ļ�¼��
    /// </summary>
    /// <param name="SQLString">SQL���</param>
    /// <returns>Ӱ��ļ�¼��</returns>
    public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
            }
        }
    }


    /// <summary>
    /// ִ�ж���SQL��䣬ʵ�����ݿ�����
    /// </summary>
    /// <param name="SQLStringList">SQL���Ĺ�ϣ��keyΪsql��䣬value�Ǹ�����SqlParameter[]��</param>
    public static void ExecuteSqlTran(Hashtable SQLStringList)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    //ѭ��
                    foreach (DictionaryEntry myDE in SQLStringList)
                    {
                        string cmdText = myDE.Key.ToString();
                        SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                        PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                        int val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        trans.Commit();
                    }
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
    }


    /// <summary>
    /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
    /// </summary>
    /// <param name="SQLString">�����ѯ������</param>
    /// <returns>��ѯ�����object��</returns>
    public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }

    /// <summary>
    /// ִ�в�ѯ��䣬����SqlDataReader
    /// </summary>
    /// <param name="strSQL">��ѯ���</param>
    /// <returns>SqlDataReader</returns>
    public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand();
        try
        {
            PrepareCommand(cmd, connection, null, SQLString, cmdParms);
            SqlDataReader myReader = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            return myReader;
        }
        catch (System.Data.SqlClient.SqlException e)
        {
            throw new Exception(e.Message);
        }

    }

    /// <summary>
    /// ִ�в�ѯ��䣬����DataSet
    /// </summary>
    /// <param name="SQLString">��ѯ���</param>
    /// <returns>DataSet</returns>
    public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, SQLString, cmdParms);
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                    return ds;
                else
                    return null;
            }

        }
    }


    private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
    {
        if (conn.State != ConnectionState.Open)
            conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = cmdText;
        if (trans != null)
            cmd.Transaction = trans;
        cmd.CommandType = CommandType.Text;//cmdType;
        if (cmdParms != null)
        {
            foreach (SqlParameter parm in cmdParms)
                cmd.Parameters.Add(parm);
        }
    }

    #endregion

    #region �洢���̲���

    /// <summary>
    /// ִ�д洢����returnReader
    /// </summary>
    /// <param name="storedProcName">�洢������</param>
    /// <param name="parameters">�洢���̲���</param>
    /// <returns>SqlDataReader</returns>
    public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        SqlDataReader returnReader;
        connection.Open();
        SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
        command.CommandType = CommandType.StoredProcedure;
        returnReader = command.ExecuteReader();
        return returnReader;
    }

    /// <summary>
    /// ִ�д洢���̣�����Ӱ�������		
    /// </summary>
    /// <param name="storedProcName">�洢������</param>
    /// <param name="parameters">�洢���̲���</param>
    /// <param name="rowsAffected">Ӱ�������</param>
    /// <returns></returns>
    public static int RunProcedureRV(string storedProcName, IDataParameter[] parameters)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            int result;
            connection.Open();
            SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
            command.ExecuteNonQuery();
            result = (int)command.Parameters["ReturnValue"].Value;
            //Connection.Close();
            return result;
        }
    }


    /// <summary>
    /// ִ�д洢���̷���dataset
    /// </summary>
    /// <param name="storedProcName">�洢������</param>
    /// <param name="parameters">�洢���̲���</param>
    /// <param name="tableName">DataSet����еı���</param>
    /// <returns>DataSet</returns>
    public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            DataSet dataSet = new DataSet();
            connection.Open();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
            sqlDA.Fill(dataSet, tableName);
            connection.Close();

            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
                return dataSet;
            return null;
        }
    }


    /// <summary>
    /// ���� SqlCommand ����(��������һ���������������һ������ֵ)
    /// </summary>
    /// <param name="connection">���ݿ�����</param>
    /// <param name="storedProcName">�洢������</param>
    /// <param name="parameters">�洢���̲���</param>
    /// <returns>SqlCommand</returns>
    private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
    {
        SqlCommand command = new SqlCommand(storedProcName, connection);
        command.CommandType = CommandType.StoredProcedure;
        foreach (SqlParameter parameter in parameters)
        {
            command.Parameters.Add(parameter);
        }
        return command;
    }

    /// <summary>
    /// ִ�д洢���̣�����Ӱ�������		
    /// </summary>
    /// <param name="storedProcName">�洢������</param>
    /// <param name="parameters">�洢���̲���</param>
    /// <param name="rowsAffected">Ӱ�������</param>
    /// <returns></returns>
    public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            int result;
            connection.Open();
            SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
            rowsAffected = command.ExecuteNonQuery();
            result = (int)command.Parameters["ReturnValue"].Value;
            //Connection.Close();
            return result;
        }
    }

    /// <summary>
    /// ���� SqlCommand ����ʵ��(��������һ������ֵ)	
    /// </summary>
    /// <param name="storedProcName">�洢������</param>
    /// <param name="parameters">�洢���̲���</param>
    /// <returns>SqlCommand ����ʵ��</returns>
    private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
    {
        SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
        command.Parameters.Add(new SqlParameter("ReturnValue",
            SqlDbType.Int, 4, ParameterDirection.ReturnValue,
            false, 0, 0, string.Empty, DataRowVersion.Default, null));
        return command;
    }
    #endregion

    #region ��������Դcon.open()

    /// <summary>
    /// �����ݿ�����.
    /// </summary>
    private static void Open()
    {
        // �����ݿ�����
        if (con.State == ConnectionState.Closed)
        {
            try
            {
                ///�����ݿ�����
                con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
                //SystemError.SystemLog(ex.Message);
            }
            finally
            {
                ///�ر��Ѿ��򿪵����ݿ�����				
            }
        }
    }
    #endregion


    #region �ر����ݿ�����
    /// <summary>
    /// �ر����ݿ�����
    /// </summary>
    public static void Close()
    {
        ///�ж������Ƿ��Ѿ�����
        if (con != null)
        {
            ///�ж����ӵ�״̬�Ƿ��
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }
        }
    }


    /// <summary>
    /// �ͷ���Դ
    /// </summary>
    public void Dispose()
    {
        // ȷ�������Ƿ��Ѿ��ر�
        if (con != null)
        {
            con.Dispose();
            con = null;
        }
    }
    #endregion


    #region ִ�д洢����,�洢��������,���ش洢���̷���ֵ(int����)
    /// <summary>
    /// ִ�д洢����
    /// </summary>
    /// <param name="procName">�洢���̵�����</param>
    /// <returns>���ش洢���̷���ֵ</returns>
    public static int RunProc(string procName)
    {
        SqlCommand cmd = CreateCommand(procName, null);
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
            //SystemError.SystemLog(ex.Message);
        }
        Close();
        return (int)cmd.Parameters["ReturnValue"].Value;
    }
    #endregion

    #region ִ�д洢����,�洢��������,�洢��������Ҫ����,���ش洢���̷���ֵ(int����)
    /// <summary>
    /// ִ�д洢����
    /// </summary>
    /// <param name="procName">�洢��������</param>
    /// <param name="prams">�洢�����������</param>
    /// <returns>���ش洢���̷���ֵ</returns>
    public static int RunProc(string procName, SqlParameter[] prams)
    {
        SqlCommand cmd = CreateCommand(procName, prams);
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
            //SystemError.SystemLog(ex.Message);
        }
        Close();
        return (int)cmd.Parameters["ReturnValue"].Value;
    }
    #endregion

    #region ִ�д洢����,�洢��������,�洢�����������
    /// <summary>
    /// ִ�д洢����
    /// </summary>
    /// <param name="procName">�洢��������</param>
    /// <param name="prams">�洢�����������</param>		
    public static void RunProcEdit(string procName, SqlParameter[] prams)
    {
        SqlCommand cmd = CreateCommand(procName, prams);
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
            //SystemError.SystemLog(ex.Message);
        }
        Close();

    }
    #endregion

    #region ִ�д洢����,�洢��������,���ش洢���̷���ֵ(DataReader����)
    /// <summary>
    /// ִ�д洢����
    /// </summary>
    /// <param name="procName">�洢���̵�����</param>
    /// <param name="dataReader">���ش洢���̷���ֵ</param>
    public static void RunProc(string procName, out SqlDataReader dataReader)
    {
        SqlCommand cmd = CreateCommand(procName, null);
        dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    }
    #endregion

    #region ִ�д洢����,�洢���̵�����,�洢�����������,���ش洢���̷���ֵ(DataReader����)
    /// <summary>
    /// ִ�д洢����
    /// </summary>
    /// <param name="procName">�洢���̵�����</param>
    /// <param name="prams">�洢�����������</param>
    /// <param name="dataReader">�洢�����������</param>
    public static void RunProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
    {
        SqlCommand cmd = CreateCommand(procName, prams);
        dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    }
    #endregion

    #region ����һ��SqlCommand�����Դ���ִ�д洢����
    /// <summary>
    /// ����һ��SqlCommand�����Դ���ִ�д洢����
    /// </summary>
    /// <param name="procName">�洢���̵�����</param>
    /// <param name="prams">�洢�����������</param>
    /// <returns>����SqlCommand����</returns>
    private static SqlCommand CreateCommand(string procName, SqlParameter[] prams)
    {
        // ȷ�ϴ�����
        Open();

        SqlCommand cmd = new SqlCommand(procName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        // ���ΰѲ�������洢����
        if (prams != null)
        {
            foreach (SqlParameter parameter in prams)
            {
                cmd.Parameters.Add(parameter);
            }
        }

        // ���뷵�ز���
        cmd.Parameters.Add(
            new SqlParameter("ReturnValue", SqlDbType.Int, 4,
            ParameterDirection.ReturnValue, false, 0, 0,
            string.Empty, DataRowVersion.Default, null));

        ///���ش�����SqlCommand����
        return cmd;
    }
    #endregion

    #region ���ɴ洢���̲���
    /// <summary>
    /// ���ɴ洢���̲���
    /// </summary>
    /// <param name="ParamName">�洢��������</param>
    /// <param name="DbType">��������</param>
    /// <param name="Size">������С</param>
    /// <param name="Direction">��������</param>
    /// <param name="Value">����ֵ</param>
    /// <returns>�µ� parameter ����</returns>
    public static SqlParameter CreateParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
    {
        SqlParameter param;

        ///��������СΪ0ʱ����ʹ�øò�����Сֵ
        if (Size > 0)
        {
            param = new SqlParameter(ParamName, DbType, Size);
        }
        else
        {
            ///��������СΪ0ʱ����ʹ�øò�����Сֵ
            param = new SqlParameter(ParamName, DbType);
        }

        ///����������͵Ĳ���
        param.Direction = Direction;
        if (!(Direction == ParameterDirection.Output && Value == null))
        {
            param.Value = Value;
        }

        ///���ش����Ĳ���
        return param;
    }
    #endregion

    #region �����������(CreateInParam)
    /// <summary>
    /// �����������
    /// </summary>
    /// <param name="ParamName">�洢��������</param>
    /// <param name="DbType">��������</param></param>
    /// <param name="Size">������С</param>
    /// <param name="Value">����ֵ</param>
    /// <returns>�µ� parameter ����</returns>
    public static SqlParameter CreateInParam(string ParamName, SqlDbType DbType, int Size, object Value)
    {
        return CreateParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
    }
    #endregion

    #region ���뷵��ֵ����(CreateOutParam)
    /// <summary>
    /// ���뷵��ֵ����
    /// </summary>
    /// <param name="ParamName">�洢��������</param>
    /// <param name="DbType">��������</param>
    /// <param name="Size">������С</param>
    /// <returns>�µ� parameter ����</returns>
    public static SqlParameter CreateOutParam(string ParamName, SqlDbType DbType, int Size)
    {
        return CreateParam(ParamName, DbType, Size, ParameterDirection.Output, null);
    }
    #endregion

    #region ���뷵��ֵ����(CreateReturnParam)
    /// <summary>
    /// ���뷵��ֵ����
    /// </summary>
    /// <param name="ParamName">�洢��������</param>
    /// <param name="DbType">��������</param>
    /// <param name="Size">������С</param>
    /// <returns>�µ� parameter ����</returns>
    public static SqlParameter CreateReturnParam(string ParamName, SqlDbType DbType, int Size)
    {
        return CreateParam(ParamName, DbType, Size, ParameterDirection.ReturnValue, null);
    }
    #endregion

    #region ִ��һ����ѯ���,����һ�����ݼ�DataSet
    /// <summary>
    /// ִ��һ����ѯ���,
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns>���ص���һ�����ݼ�DataSet</returns>
    /// 
    public static DataSet ReturnDataSet(string strSql)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            DataSet dataSet = new DataSet();
            SqlDataAdapter sqlDA = new SqlDataAdapter(strSql, connection);
            sqlDA.Fill(dataSet, "objDataSet");
            connection.Close();

            return dataSet;
        }
    }
    #endregion

    #region ִ��һ����ѯ���,���ص���DataReader
    /// <summary>
    /// ִ��һ����ѯ���
    /// </summary>
    /// <param name="sql"></param>
    /// <returns>���ص���DataReader</returns>
    /// 
    public static SqlDataReader ReturnDataReader(String strSql)
    {

        //objSqlConn.Open();
        if (con.State == ConnectionState.Closed)
            Open();
        SqlCommand objSqlCmd = new SqlCommand(strSql, con);
        SqlDataReader objDataReader = objSqlCmd.ExecuteReader();


        return objDataReader;
    }
    #endregion


    #region ִ��sql���,�޸����ݿ�
    /// <summary>
    /// �޸����ݿ�
    /// </summary>
    /// <param name="sql"></param>
    /// <returns>������ͼ� true  false</returns>
    /// 
    public static bool EditDatabase(string strSql)
    {
        bool boolState = false;
        if (con.State == ConnectionState.Open)
        {
        }
        else
        {
            Open();
        }
        SqlTransaction objSqlTr = con.BeginTransaction();
        SqlCommand objSqlCmd = new SqlCommand(strSql, con, objSqlTr);
        SqlCommand d = new SqlCommand();
        try
        {
            objSqlCmd.ExecuteNonQuery();
            objSqlTr.Commit();
            boolState = true;
        }

        catch
        {
            objSqlTr.Rollback();
        }
        finally
        {
            objSqlCmd.Dispose();
            con.Close();
        }

        return boolState;
    }
    #endregion

    #region ����һ�����εĽ��(����ֵExecuteSqlValuOfInt)
    /// <summary>
    /// ����һ�����εĽ��(����ֵ)
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns>���ص���һ�����͵���ֵ</returns>

    public static int ExecuteSqlValueOfInt(string strSql)
    {
        //objSqlConn.Open();
        Open();
        SqlCommand objSqlCmd = new SqlCommand(strSql, con);
        try
        {
            object r = objSqlCmd.ExecuteScalar();
            if (Object.Equals(r, null))
            {
                throw new Exception("value unavailable");
            }
            else
            {
                return (int)r;
            }
        }
        catch
        {
            return 0;

        }
        finally
        {
            objSqlCmd.Dispose();
            con.Close();
        }
    }
    #endregion 

    #region ��DataReader תΪ DataTable
    /// <summary>
    /// ��DataReader תΪ DataTable
    /// </summary>
    /// <param name="DataReader">DataReader</param>
    public static DataTable ConvertDataReaderToDataTable(SqlDataReader dataReader)
    {
        DataTable datatable = new DataTable();
        DataTable schemaTable = dataReader.GetSchemaTable();
        foreach (DataRow myRow in schemaTable.Rows)
        {
            DataColumn myDataColumn = new DataColumn();
            myDataColumn.DataType = myRow.GetType();
            myDataColumn.ColumnName = myRow[0].ToString();
            datatable.Columns.Add(myDataColumn);
        }

        while (dataReader.Read())
        {
            DataRow myDataRow = datatable.NewRow();
            for (int i = 0; i < schemaTable.Rows.Count; i++)
            {
                myDataRow[i] = dataReader[i].ToString();
            }
            datatable.Rows.Add(myDataRow);
            myDataRow = null;
        }
        schemaTable = null;
        dataReader.Close();
        return datatable;
    }

    #endregion

     
    /// <summary>
    /// ִ�ж���SQL���
    /// </summary>
    /// <param name="strSQLs"></param>
    /// <returns></returns>
    public static int ExecuteSqls(string[] strSQLs)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand mycmd = new SqlCommand();
            int j = strSQLs.Length;
            SqlTransaction myTrans = connection.BeginTransaction();//�½�һ������
            try
            {
                mycmd.Connection = connection;
                mycmd.Transaction = myTrans;//ָ��Transaction����Ϊ�½���myTrans
                foreach (string str in strSQLs)
                {
                    mycmd.CommandText = str;
                    mycmd.ExecuteNonQuery();//ִ�����ݿ������
                }
                myTrans.Commit();
                return 1;
            }
            catch
            {
                myTrans.Rollback();
                return 0;
                //֤��ʧ����
                //throw new Exception(e.Message);
            }
            finally
            {
                mycmd.Dispose();
                Close();
            }
        }
    }
 

    /// <summary>
    /// ��ȡ���ݵ�ͨ�÷���
    /// </summary>
    /// <param name="tablename">������</param>
    /// <param name="fldname">����</param>
    /// <param name="strWhere">����</param>
    /// <param name="sorttype">�������� ��0����</param>
    /// <param name="sortname">�����ֶ�</param>
    /// <param name="count">���ؼ�¼������</param>
    /// <returns></returns>
    public static DataSet GetList(string tablename, string fldname, string strWhere, int sorttype, string sortname, int count)
    {
        SqlParameter[] parameters = {
											new SqlParameter("@tblName", SqlDbType.VarChar, 255),
											new SqlParameter("@fldName", SqlDbType.VarChar, 255),
											new SqlParameter("@PageSize", SqlDbType.Int),
											new SqlParameter("@PageIndex", SqlDbType.Int),
											new SqlParameter("@IsReCount", SqlDbType.Bit),
											new SqlParameter("@OrderType", SqlDbType.Bit),
											new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                                            new SqlParameter("@sortname",SqlDbType.VarChar)
			};
        parameters[0].Value = tablename;
        parameters[1].Value = fldname;
        parameters[2].Value = count;
        parameters[3].Value = 1;
        parameters[4].Value = 0;
        parameters[5].Value = sorttype;
        parameters[6].Value = strWhere;
        parameters[7].Value = sortname;

        DataSet ds = DbHelperSQL.RunProcedure(ProcName, parameters, "table1");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
            return ds;
        return null;
    }

    /// <summary> 
    /// ��ȡ���ݵ�ͨ�÷���  ������ҳ��ȡ
    /// </summary>
    /// <param name="tablename">������</param>
    /// <param name="fldname">����</param>
    /// <param name="strWhere">����</param>
    /// <param name="sorttype">�������� ��0����</param>
    /// <param name="sortname">�����ֶ�</param>
    /// <returns></returns>
    public static DataSet GetList(string tablename, string fldname, int pagesize, int pageindex, string strWhere, int sorttype, string sortname)
    {
        SqlParameter[] parameters = {
											new SqlParameter("@tblName", SqlDbType.VarChar, 255),
											new SqlParameter("@fldName", SqlDbType.VarChar, 255),
											new SqlParameter("@PageSize", SqlDbType.Int),
											new SqlParameter("@PageIndex", SqlDbType.Int),
											new SqlParameter("@IsReCount", SqlDbType.Bit),
											new SqlParameter("@OrderType", SqlDbType.Bit),
											new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                                            new SqlParameter("@sortname",SqlDbType.VarChar)
			};
        parameters[0].Value = tablename;
        parameters[1].Value = fldname;
        parameters[2].Value = pagesize;
        parameters[3].Value = pageindex;
        parameters[4].Value = 0;
        parameters[5].Value = sorttype;
        parameters[6].Value = strWhere;
        parameters[7].Value = sortname;

        DataSet ds = DbHelperSQL.RunProcedure(ProcName, parameters, "table1");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
            return ds;
        return null;
    }

    /// <summary>
    /// ��ȡ�ܼ�¼��
    /// </summary>
    /// <param name="tablename"></param>
    /// <param name="fldname"></param>
    /// <param name="strWhere"></param>
    /// <returns></returns>
    public static int GetRecordCount(string tablename, string fldname, string strWhere)
    {
        SqlParameter[] parameters = {
											new SqlParameter("@tblName", SqlDbType.VarChar, 255),
											new SqlParameter("@fldName", SqlDbType.VarChar, 255),
											new SqlParameter("@PageSize", SqlDbType.Int),
											new SqlParameter("@PageIndex", SqlDbType.Int),
											new SqlParameter("@IsReCount", SqlDbType.Bit),
											new SqlParameter("@OrderType", SqlDbType.Bit),
											new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                                            new SqlParameter("@sortname",SqlDbType.VarChar)
			};
        parameters[0].Value = tablename;
        parameters[1].Value = fldname;
        parameters[2].Value = 1;
        parameters[3].Value = 1;
        parameters[4].Value = 1;//��ȡ�ܼ�¼��
        parameters[5].Value = 1;
        parameters[6].Value = strWhere;
        parameters[7].Value = fldname;

        DataSet ds = DbHelperSQL.RunProcedure(ProcName, parameters, "table1");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            return int.Parse(ds.Tables[0].Rows[0][0].ToString());
        }
        return 0;
    }


    //////////////////////////���·���
    /// <summary>
    /// ִ�в�ѯ��䣬����datarow����
    /// </summary>
    /// <param name="SQLString">��ѯ���</param>
    /// <returns>DataSet</returns>
    public static DataRowCollection ReadRows(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection drs = ds.Tables[0].Rows;
                if (drs != null)
                    return drs;
                else
                    return null;
            }
            return null;
        }
    }

    /// <summary>
    /// ִ�в�ѯ��䣬����datarow
    /// </summary>
    /// <param name="SQLString">��ѯ���</param>
    /// <returns>DataSet</returns>
    public static DataRow ReadRow(string SQLString, params SqlParameter[] cmdParms)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, SQLString, cmdParms);
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    if (dr != null)
                        return dr;
                    else
                        return null;
                }
                else
                    return null;
            }

        }
    }



    //////////////////////////���·���
    /// <summary>
    /// ִ�в�ѯ��䣬����datarow����  ��������
    /// </summary>
    /// <param name="SQLString">��ѯ���</param>
    /// <returns>DataSet</returns>
    public static DataRow ReadRow(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (dr != null)
                    return dr;
            }
            return null;
        }
    }



}
