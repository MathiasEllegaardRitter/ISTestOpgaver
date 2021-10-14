using System.Collections.Generic;

namespace TestOpgave_1._4_DataAccess.Access
{
    public interface IDataAccess
    {
        string GetConnectionString();
        List<T> LoadData<T>(string sql);
        void SaveData<T>(string sql, T data);
        void ExecuteSql(string sql);

        int SaveBorrowData<T>(string sql, T data);

    }
}